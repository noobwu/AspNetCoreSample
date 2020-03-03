using Newtonsoft.Json;
using ons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aliyun.RocketMQSDK.Producers
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {

            try
            {
                Console.Title = "ProducerTest";
                ProducerTest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
        /// <summary>
        /// 每线程发送消息数量
        /// </summary>
        private static readonly int MessageCountPerThread = 1;
        /// <summary>
        /// 线程总数
        /// </summary>
        private static readonly int ProducerThreadCount = 2;
        /// <summary>
        /// Producers the test.
        /// </summary>
        static void ProducerTest()
        {
            string strRocketMQConfigs = ReadAllFromFile("RocketMQConfigs.json");
            List<RocketMQConfig> configs = JsonConvertDeserialize<List<RocketMQConfig>>(strRocketMQConfigs);
            Console.WriteLine($"ProducerTest,开始:{DateTime.Now}");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            List<OnscSharp> onscSharpList = new List<OnscSharp>();
            var taskList = new List<Task>();
            if (configs != null && configs.Count > 0)
            {
                configs.ForEach(config =>
                {
                    OnscSharp instance = new OnscSharp(config);
                    switch (config.MsgType)
                    {
                        case 2:
                        case 3:
                            {
                                instance.CreateOrderProducer();
                                instance.StartOrderProducer();
                            }
                            break;
                        case 4:
                            {
                                Func<Message, TransactionStatus> transCheckFunc = (msg) =>
                                {
                                    //消息 ID（有可能消息体一样，但消息 ID 不一样，当前消息属于半事务消息，所以消息 ID 在控制台无法查询）
                                    string msgId = msg.getMsgID();
                                    //消息体内容进行 crc32，也可以使用其它的方法如 MD5
                                    int crc32Id = 0;// HashUtil.crc32Code(msg.getBody());;
                                                    //消息 ID、消息本 crc32Id 主要是用来防止消息重复
                                                    //如果业务本身是幂等的，可以忽略，否则需要利用 msgId 或 crc32Id 来做幂等
                                                    //如果要求消息绝对不重复，推荐做法是对消息体使用 crc32 或 MD5 来防止重复消息
                                                    //业务自己的参数对象，这里只是一个示例，需要您根据实际情况来处理
                                    Object businessServiceArgs = new Object();
                                    TransactionStatus transactionStatus = TransactionStatus.Unknow;
                                    try
                                    {
                                        bool isCommit = true;// businessService.checkbusinessService(businessServiceArgs);//处理相关的业务逻辑
                                        if (isCommit)
                                        {
                                            //本地事务已成功则提交消息
                                            transactionStatus = TransactionStatus.CommitTransaction;
                                        }
                                        else
                                        {
                                            //本地事务已失败则回滚消息
                                            transactionStatus = TransactionStatus.RollbackTransaction;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                    }
                                    return transactionStatus;
                                };
                                instance.CreateTransProducer(new LocalTransactionCheckerImpl(transCheckFunc));
                                instance.StartTransProducer();
                            }
                            break;
                        default:
                            {
                                instance.CreateProducer();
                                instance.StartProducer();
                            }
                            break;
                    }
                    onscSharpList.Add(instance);
                });
            }
            onscSharpList.ForEach(instance =>
            {
                string queueName = string.Empty;
                //消息类型(1:普通消息,2:分区顺序消息,3:全局顺序消息,4:事务消息,5:定时/延时消息)
                switch (instance.Config.MsgType)
                {
                    case 2:
                    case 3:
                        {
                            queueName = $"{instance.Config.GroupId.Replace(instance.Config.GroupIdPrefix, string.Empty)}OrderMessage";
                            for (int tempThreadIndex = 1; tempThreadIndex <= ProducerThreadCount; tempThreadIndex++)
                            {
                                // 生产消费
                                var task = Task.Factory.StartNew(() =>
                                {
                                    for (int tempMessageIndex = 1; tempMessageIndex <= MessageCountPerThread; tempMessageIndex++)
                                    {
                                        instance.SendOrderMessage($"This is order test message {tempThreadIndex}:{tempMessageIndex}", queueName);
                                    }
                                }, TaskCreationOptions.LongRunning);

                                taskList.Add(task);
                            }
                        }
                        break;
                    case 5: //延迟队列
                        {
                            queueName = $"{instance.Config.GroupId.Replace(instance.Config.GroupIdPrefix, string.Empty)}Message";
                            for (int tempThreadIndex = 1; tempThreadIndex <= ProducerThreadCount; tempThreadIndex++)
                            {
                                // 生产消费
                                var task = Task.Factory.StartNew(() =>
                                {
                                    for (int tempMessageIndex = 1; tempMessageIndex <= MessageCountPerThread; tempMessageIndex++)
                                    {
                                        instance.SendMessage($"This is time delay test message {tempThreadIndex}:{tempMessageIndex}", queueName, DateTime.Now.AddSeconds(10));
                                    }
                                }, TaskCreationOptions.LongRunning);

                                taskList.Add(task);
                            }
                        }
                        break;
                    case 4:
                        {
                            queueName = $"{instance.Config.GroupId.Replace(instance.Config.GroupIdPrefix, string.Empty)}TransMessage";
                            Func<Message, TransactionStatus> transExecFunc = (msg) =>
                            {
                                //消息 ID（有可能消息体一样，但消息 ID 不一样，当前消息属于半事务消息，所以消息 ID 在控制台无法查询）
                                string msgId = msg.getMsgID();
                                //消息体内容进行 crc32，也可以使用其它的方法如 MD5
                                int crc32Id = 0;// HashUtil.crc32Code(msg.getBody());;
                                                //消息 ID、消息本 crc32Id 主要是用来防止消息重复
                                                //如果业务本身是幂等的，可以忽略，否则需要利用 msgId 或 crc32Id 来做幂等
                                                //如果要求消息绝对不重复，推荐做法是对消息体使用 crc32 或 MD5 来防止重复消息
                                                //业务自己的参数对象，这里只是一个示例，需要您根据实际情况来处理
                                Object businessServiceArgs = new Object();
                                TransactionStatus transactionStatus = TransactionStatus.Unknow;
                                try
                                {
                                    bool isCommit = true;// businessService.checkbusinessService(businessServiceArgs);//处理相关的业务逻辑
                                    if (isCommit)
                                    {
                                        //本地事务已成功则提交消息
                                        transactionStatus = TransactionStatus.CommitTransaction;
                                    }
                                    else
                                    {
                                        //本地事务已失败则回滚消息
                                        transactionStatus = TransactionStatus.RollbackTransaction;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                }
                                return transactionStatus;
                            };
                            for (int tempThreadIndex = 1; tempThreadIndex <= ProducerThreadCount; tempThreadIndex++)
                            {
                                // 生产消费
                                var task = Task.Factory.StartNew(() =>
                                {
                                    for (int tempMessageIndex = 1; tempMessageIndex <= MessageCountPerThread; tempMessageIndex++)
                                    {
                                        instance.SendTransMessage($"This is trans test message {tempThreadIndex}:{tempMessageIndex}", new LocalTransactionExecuterImpl(transExecFunc), queueName);
                                    }
                                }, TaskCreationOptions.LongRunning);

                                taskList.Add(task);
                            }
                        }
                        break;
                    default:
                        {
                            queueName = $"{instance.Config.GroupId.Replace(instance.Config.GroupIdPrefix, string.Empty)}Message";
                            for (int tempThreadIndex = 1; tempThreadIndex <= ProducerThreadCount; tempThreadIndex++)
                            {
                                // 生产消费
                                var task = Task.Factory.StartNew(() =>
                                {
                                    for (int tempMessageIndex = 1; tempMessageIndex <= MessageCountPerThread; tempMessageIndex++)
                                    {
                                        instance.SendMessage($"This is test message {tempThreadIndex}:{tempMessageIndex}", queueName);
                                    }
                                }, TaskCreationOptions.LongRunning);
                                taskList.Add(task);
                            }
                        }
                        break;
                }
            });
            Task.WaitAll(taskList.ToArray());
            onscSharpList.ForEach(a =>
            {
                a.ShutdownProducer();
                a.ShutdownOrderProducer();
                a.ShutdownTransProducer();
            });
            stopWatch.Stop();

            Console.WriteLine($"ProducerTest,结束, 使用时间{stopWatch.ElapsedMilliseconds}毫秒");
        }

        /// <summary>
        /// 读json配制文件的内容
        /// </summary>
        /// <param name="configFile">The configuration file.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception">配置文件 " + strFilePath + " 不存在</exception>
        /// <exception cref="Exception">配置文件 " + strFilePath + " 不存在</exception>
        static string ReadAllFromFile(string configFile)
        {
            string strFilePath = GetConfigFilePath(configFile);

            if (!File.Exists(strFilePath))
            {
                throw new Exception("配置文件 " + strFilePath + " 不存在");
            }
            return File.ReadAllText(strFilePath);
        }
        /// <summary>
        /// 功能:获取配置文件路径
        /// </summary>
        /// <param name="strConfigFileName">配置文件名称</param>
        /// <returns>配置文件路径</returns>
        static string GetConfigFilePath(string strConfigFileName)
        {
            string strConfigFilePath = Thread.GetDomain().BaseDirectory;// System.Environment.CurrentDirectory;

            strConfigFilePath = Path.Combine(strConfigFilePath, "Config");
            strConfigFilePath = Path.Combine(strConfigFilePath, strConfigFileName);

            return strConfigFilePath;
        }

        /// <summary>
        /// 功能:JSON反序列化JsonConvert方式
        /// </summary>
        /// <typeparam name="T">反序列化的类型</typeparam>
        /// <param name="jsonString">json字符串</param>
        /// <returns>反序列化的类型对象</returns>
        static T JsonConvertDeserialize<T>(string jsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                return default(T);
            }
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default(T);
            }
        }
    }
}

// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample.Consumer
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-01
// ***********************************************************************
// <copyright file="Program.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Kmmp.Core.Helper;
using Kmmp.Core.Imps;
using Kmmp.Core.Models;
using Kmmp.Core.MqFramework.RocketMQ;
using Kmmp.Core.MqFramework.RocketMQ.Consumers;
using Kmmp.DSync.Data;
using Kmmp.MqReceiver.DSync;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The Consumer namespace.
/// </summary>
namespace Aliyun.RocketMQSample.Consumer
{
    /// <summary>
    /// Class Program.
    /// </summary>
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
                //KmmpMQConsumerTest();
                //ConsumerTest();
                KmmpRocketMQReceiverTest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
        /// <summary>
        /// Consumers the test.
        /// </summary>
        static void ConsumerTest()
        {
            string strRocketMQConfigs = JsonConfigInfo.ReadAllFromFile("RocketMQConfigs.json");
            List<RocketMQConfig> configs = JsonHelper.JsonConvertDeserialize<List<RocketMQConfig>>(strRocketMQConfigs);

            Console.WriteLine($"instance,开始:{DateTime.Now}");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            configs = configs.Where(a => !(new byte[] { 2, 3 }).Contains(a.MsgType)).ToList();
            configs?.ForEach(config =>
            {
                OnscSharp instance = new OnscSharp(config);
                switch (config.MsgType)
                {
                    case 2:
                    case 3:
                        {
                            instance.CreateOrderConsumer();
                            instance.StartOrderConsumer($"{instance.Config.GroupId.Replace(instance.Config.GroupIdPrefix, string.Empty)}OrderMessage");
                        }
                        break;
                    default:
                        {
                            instance.CreatePushConsumer();
                            instance.StartPushConsumer($"{instance.Config.GroupId.Replace(instance.Config.GroupIdPrefix, string.Empty)}Message");
                        }
                        break;
                }

            });

            stopWatch.Stop();
            Console.WriteLine($"instance,结束, 使用时间{stopWatch.ElapsedMilliseconds}毫秒");
        }
        /// <summary>
        /// Consumers the test.
        /// </summary>
        static void KmmpRocketMQReceiverTest()
        {
            Console.WriteLine($"KmmpRocketMQReceiverTest,开始:{DateTime.Now}");
            string strRocketMQConfigs = JsonConfigInfo.ReadAllFromFile("RocketMQConfigs.json");
            List<RocketMQConfig> configs = JsonHelper.JsonConvertDeserialize<List<RocketMQConfig>>(strRocketMQConfigs);
            string queueName = "CateringVipType";

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            configs = configs.Where(a => !(new byte[] { 2, 3 }).Contains(a.MsgType)).ToList();
            configs?.ForEach(config =>
            {
                IMessageReceiver instance = null;
                switch (config.MsgType)
                {
                    case 2:
                    case 3:
                        {
                            instance = new RocketMQOrderReceiver(config, queueName);
                        }
                        break;
                    default:
                        {
                            instance = new RocketMQReceiver(config, queueName);

                        }
                        break;
                }
                if (instance != null)
                {
                    StartKmmpMQReceiver(instance);
                }

            });

            stopWatch.Stop();
            Console.WriteLine($"KmmpRocketMQReceiverTest,结束, 使用时间{stopWatch.ElapsedMilliseconds}毫秒");
        }
        /// <summary>
        /// KMMPs the mq consumer test.
        /// </summary>
        static void KmmpMQConsumerTest()
        {
            /// <summary>
            /// 消费都数量
            /// </summary>
            const int ConsumerCount = 2;
            string queueName = "CateringVipType";
            Console.WriteLine($"接收消息,{queueName}:{DateTime.Now}");

            KmmpMQReceiverTest(queueName);
            string tempQueueName = "TempCateringVipType";
            Console.WriteLine($"接收消息,{tempQueueName}:{DateTime.Now}");

            KmmpMQReceiverTest(tempQueueName);
        }

        /// <summary>
        /// KMMPs the mq publisher test.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        static void KmmpMQReceiverTest(string queueName)
        {
            try
            {
                var receiver = GetReceiver(queueName);
                StartKmmpMQReceiver(receiver);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Author：tiny.wu
        /// Date：2016-09-28
        /// Desc：执行
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="msg">The MSG.</param>
        private void Execute(string typeName, object msg)
        {
            Type type = Type.GetType(typeName);
            var method = type.GetMethod("Execute");
            method.Invoke(Activator.CreateInstance(type), new[] { msg });
        }

        /// <summary>
        /// 获取消息接收者
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <returns>IMessageReceiver.</returns>
        /// <exception cref="Exception">0006</exception>
        private static IMessageReceiver GetReceiver(string queueName)
        {
            var messageQueue = MessageQueueHelper.GetMessageQueueFromPool(queueName);
            var receiver = messageQueue.GetMessageReceiver(queueName, null);
            if (receiver == null)
            {
                throw new Exception("0006");
            }
            return receiver;
        }
        /// <summary>
        /// KMMPs the mq publisher test.
        /// </summary>
        /// <param name="receiver">The receiver.</param>
        static void StartKmmpMQReceiver(IMessageReceiver receiver)
        {
            try
            {
                receiver.Received += (sender, args) =>
                {
                    //Execute(q.Value<string>("Method"), args.Message);
                    //Console.WriteLine($"args:{JsonHelper.JsonConvertSerialize(args)}");
                    var mqData = args.Message as MQ_VipData<Temp_VipType>;
                    if (mqData == null)
                    {
                        mqData = JsonHelper.JsonConvertDeserialize<MQ_VipData<Temp_VipType>>(args.Message.ToString());
                    }
                    new SyncVipTypeMqReceiver().Execute(mqData);
                    Console.WriteLine($"ChannelName:{args.ChannelName},MessageId:{mqData?.MessageId}");
                };
                receiver.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

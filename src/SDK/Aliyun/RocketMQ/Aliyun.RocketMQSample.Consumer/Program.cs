using Kmmp.Core.Helper;
using Kmmp.Core.Imps;
using Kmmp.DSync.Data;
using Kmmp.MqReceiver.DSync;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                KmmpMQConsumerTest();
                //ConsumerTest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
        static void ConsumerTest()
        {
            /// <summary>
            /// 每线程发送消息数量
            /// </summary>
            int MessageCountPerThread = 2;
            /// <summary>
            /// 线程总数
            /// </summary>
            int ProducerThreadCount = 2;
            Console.WriteLine($"instance,开始:{DateTime.Now}");
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            OnscSharp instance = new OnscSharp();
            instance.CreatePushConsumer();
            instance.StartPushConsumer("TestMessage");

            //instance.shutdownPushConsumer();
            //for (int tempThreadIndex = 1; tempThreadIndex <= ProducerThreadCount; tempThreadIndex++)
            //{
            //    OnscSharp instance = new OnscSharp();
            //    instance.CreatePushConsumer();
            //    instance.StartPushConsumer("TestMessage");
            //}


            //for (int tempThreadIndex = 1; tempThreadIndex <= ProducerThreadCount; tempThreadIndex++)
            //{
            //    OnscSharp tempInstance = new OnscSharp();
            //    tempInstance.CreatePushConsumer();
            //    tempInstance.StartPushConsumer("TempTestMessage");
            //}

            //OnscSharp tempInstance = new OnscSharp();
            //tempInstance.CreatePushConsumer();
            //tempInstance.StartPushConsumer("TempTestMessage");


            //tempInstance.shutdownPushConsumer();

            stopWatch.Stop();


            Console.WriteLine($"instance,结束, 使用时间{stopWatch.ElapsedMilliseconds}毫秒");
        }

        static void KmmpMQConsumerTest()
        {
            /// <summary>
            /// 消费都数量
            /// </summary>
            const int ConsumerCount = 2;
            string queueName = "CateringVipType";
            Console.WriteLine($"接收消息,{queueName}:{DateTime.Now}");
            //for (int index = 1; index <= ConsumerCount; index++)
            //{
            //    // 接收消息
            //    KmmpMQReceiverTest(queueName);
            //}
            KmmpMQReceiverTest(queueName);
            string tempQueueName = "CateringVipTypeTemp";
            Console.WriteLine($"接收消息,{tempQueueName}:{DateTime.Now}");
            //for (int index = 1; index <= ConsumerCount; index++)
            //{
            //    接收消息
            //    KmmpMQReceiverTest(tempQueueName);
            //}
            //KmmpMQReceiverTest(tempQueueName);
            Console.ReadKey();
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
                receiver.ReceivedEventHandler += (sender, args) =>
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

        /// <summary>
        /// Author：tiny.wu
        /// Date：2016-09-28
        /// Desc：执行
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="msg"></param>
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

    }
}

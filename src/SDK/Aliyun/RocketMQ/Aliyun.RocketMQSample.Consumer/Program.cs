using Kmmp.Core.Helper;
using Kmmp.DSync.Data;
using Kmmp.MqReceiver.DSync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            //OnscSharp.CreateProducer();
            //OnscSharp.CreatePushConsumer();
            //OnscSharp.StartPushConsumer();
            //OnscSharp.StartProducer();
            //System.DateTime beforDt = System.DateTime.Now;
            //for (int i = 0; i < 10; ++i)
            //{
            //    //byte[] bytes = Encoding.UTF8.GetBytes("中文messages");//中文encode
            //    //String body = Convert.ToBase64String(bytes);
            //    OnscSharp.SendMessage("This is test message");
            //    Thread.Sleep(1000 * 1);
            //}
            //System.DateTime endDt = System.DateTime.Now;
            //System.TimeSpan ts = endDt.Subtract(beforDt);
            //Console.WriteLine("per message:{0}ms.", ts.TotalMilliseconds / 10000);
            //Thread.Sleep(1000 * 100);
            //Console.ReadKey();
            //OnscSharp.ShutdownProducer();
            //OnscSharp.shutdownPushConsumer();
            //Console.WriteLine("end");

            try
            {
                KmmpMQTest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
        static void KmmpMQTest()
        {
            System.DateTime startTime = System.DateTime.Now;
            string queueName = "CateringVipType";
            KmmpMQReceiverTest(queueName);
            System.DateTime endTime = System.DateTime.Now;
            System.TimeSpan ts = endTime.Subtract(startTime);
            Console.WriteLine("per message:{0}ms.", ts.TotalMilliseconds / 10000);
        }

        /// <summary>
        /// KMMPs the mq publisher test.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        static void KmmpMQReceiverTest(string queueName)
        {
            var queue = MessageQueueHelper.GetMessageQueueFromPool(queueName);
            var receiver = queue.GetMessageReceiver(queueName, null);
            receiver.Received += (sender, args) =>
            {
                //Execute(q.Value<string>("Method"), args.Message);
                //Console.WriteLine($"args:{JsonHelper.JsonConvertSerialize(args)}");
                var mqData = args.Message as MQ_VipData<Temp_VipType>;
                new SyncVipTypeMqReceiver().Execute(mqData);
            };
            receiver.Start();
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

    }
}

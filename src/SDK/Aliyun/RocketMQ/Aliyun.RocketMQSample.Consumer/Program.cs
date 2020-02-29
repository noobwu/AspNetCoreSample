﻿using Kmmp.Core.Helper;
using Kmmp.Core.Imps;
using Kmmp.DSync.Data;
using Kmmp.MqReceiver.DSync;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// <summary>
        /// 线程总数iwg
        /// </summary>
        private static readonly int ConsumerThreadCount = 2;
        static void KmmpMQTest()
        {
            string queueName = "CateringVipType";
            Console.WriteLine($"接收消息,{queueName}:{DateTime.Now}");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var taskList = new List<Task>();
            for (int threadIndex = 1; threadIndex <= ConsumerThreadCount; threadIndex++)
            {
                // 生产消费
                var task = Task.Factory.StartNew(() =>
                {
                    KmmpMQReceiverTest(queueName);
                }, TaskCreationOptions.LongRunning);

                taskList.Add(task);
            }
            Task.WaitAll(taskList.ToArray());
            stopWatch.Stop();
            Console.WriteLine($"接收消息,{queueName}：{ConsumerThreadCount}条， 使用时间{stopWatch.ElapsedMilliseconds}毫秒");
        }

        /// <summary>
        /// KMMPs the mq publisher test.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        static void KmmpMQReceiverTest(string queueName)
        {
            var receiver = GetReceiver(queueName);
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

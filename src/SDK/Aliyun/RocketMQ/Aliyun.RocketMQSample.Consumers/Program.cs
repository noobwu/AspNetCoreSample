﻿// ***********************************************************************
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
using ons;
using Aliyun.RocketMQSDK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kmmp.Core.MqFramework.RabbitMQ;
using Kmmp.Core.MqFramework;

/// <summary>
/// The Consumer namespace.
/// </summary>
namespace Aliyun.RocketMQSample.Consumers
{
    /// <summary>
    /// Class Program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// 线程总数
        /// </summary>
        private static readonly int ConsumerThreadCount = 10;
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "KmmpRabbitConsumerTest";
                //KmmpMQReceiverTest();
                //KmmpRocketMQReceiverTest();
                //KmmpRocketMQTransReceiverTest();
                KmmpRabbitConsumerTest();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
        private static int count = 0;
        /// <summary>
        /// Consumers the test.
        /// </summary>
        static void KmmpRabbitConsumerTest()
        {
            Console.WriteLine($"KmmpRabbitConsumerTest,开始:{DateTime.Now}");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            RabbitMqMessageFactory msgFactory = new RabbitMqMessageFactory("localhost");
            string queueName = new QueueNames("CateringVipType").In;
            for (int tempThreadIndex = 1; tempThreadIndex <= ConsumerThreadCount; tempThreadIndex++)
            {
                RabbitMqPushConsumer rabbitMqPushConsumer = new RabbitMqPushConsumer(msgFactory, queueName);
                try
                {
                    rabbitMqPushConsumer.Received += (sender, args) =>
                    {
                        count++;
                        //var mqData = args.Message as MQ_VipData<Temp_VipType>;
                        //new SyncVipTypeMqReceiver().Execute(mqData);
                        //Execute("Kmmp.MqReceiver.DSync.SyncVipTypeMqReceiver,Aliyun.RocketMQSample", args.Body);
                        Console.WriteLine($"KmmpRabbitConsumerTest {count} at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")},RoutingKey:{args.RoutingKey}");
                    };
                    rabbitMqPushConsumer.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"KmmpRocketMQTransReceiverTest,结束, 使用时间{stopWatch.ElapsedMilliseconds}毫秒");
        }
        /// <summary>
        /// Consumers the test.
        /// </summary>
        static void KmmpRocketMQTransReceiverTest()
        {
            Console.WriteLine($"KmmpRocketMQTransReceiverTest,开始:{DateTime.Now}");
            string strRocketMQConfigs = JsonConfigInfo.ReadAllFromFile("RocketMQConfigs.json");
            List<RocketMQConfig> configs = JsonHelper.JsonConvertDeserialize<List<RocketMQConfig>>(strRocketMQConfigs);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            configs = configs?.Where(a => (new byte[] { 4 }).Contains(a.MsgType)).ToList();
            configs?.ForEach(config =>
            {
                string queueName = $"{config.GroupId.Replace(config.GroupIdPrefix, string.Empty)}";
                IMessageReceiver instance = new RocketMQReceiver(config, queueName);
                if (instance != null)
                {
                    StartKmmpMQReceiver(instance);
                }
            });

            stopWatch.Stop();
            Console.WriteLine($"KmmpRocketMQTransReceiverTest,结束, 使用时间{stopWatch.ElapsedMilliseconds}毫秒");
        }
        /// <summary>
        /// Consumers the test.
        /// </summary>
        static void KmmpRocketMQReceiverTest()
        {
            Console.WriteLine($"KmmpRocketMQReceiverTest,开始:{DateTime.Now}");
            string strRocketMQConfigs = JsonConfigInfo.ReadAllFromFile("RocketMQConfigs.json");
            List<RocketMQConfig> configs = JsonHelper.JsonConvertDeserialize<List<RocketMQConfig>>(strRocketMQConfigs);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            configs = configs.Where(a => !(new byte[] { 2, 3 }).Contains(a.MsgType)).ToList();
            configs?.ForEach(config =>
            {
                string queueName = $"{config.GroupId.Replace(config.GroupIdPrefix, string.Empty)}";
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
        static void KmmpMQReceiverTest()
        {
            /// <summary>
            /// 消费都数量
            /// </summary>
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
        private static void Execute(string typeName, object msg)
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
                    //var mqData = args.Message as MQ_VipData<Temp_VipType>;
                    //new SyncVipTypeMqReceiver().Execute(mqData);
                    Execute("Kmmp.MqReceiver.DSync.SyncVipTypeMqReceiver,Aliyun.RocketMQSample", args.Message);
                    Console.WriteLine($"StartKmmpMQReceiver,ChannelName:{args.ChannelName}");
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

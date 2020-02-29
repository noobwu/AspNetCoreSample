// ***********************************************************************
// Assembly         : demo
// Author           : carl.wu
// Created          : 02-28-2020
//
// Last Modified By : carl.wu
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="ConsumerAndProducer.cs" company="Microsoft">
//     Copyright © Microsoft 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ons;

/// <summary>
/// The test namespace.
/// </summary>
namespace Aliyun.RocketMQSample
{

    /// <summary>
    /// Class MyMsgListener.
    /// Implements the <see cref="ons.MessageListener" />
    /// </summary>
    /// <seealso cref="ons.MessageListener" />
    public class MyMsgListener : MessageListener
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyMsgListener" /> class.
        /// </summary>
        public MyMsgListener()
        {
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MyMsgListener" /> class.
        /// </summary>
        ~MyMsgListener()
        {
        }

        /// <summary>
        /// Consumes the specified value.
        /// </summary>
        /// <param name="message">The value.</param>
        /// <param name="context">The context.</param>
        /// <returns>ons.Action.</returns>
        public override ons.Action consume(Message message, ConsumeContext context)
        {
            // 根据业务唯一标识的 Key 做幂等处理
            string key = message.getKey();
            //byte[] text = Convert.FromBase64String(value.getBody());//中文decode
            //string body = Encoding.UTF8.GetString(text);
            Byte[] text = Encoding.Default.GetBytes(message.getBody());
            Console.WriteLine(Encoding.UTF8.GetString(text));
            Console.WriteLine("Receive message:{0}", key);
            return ons.Action.CommitMessage;
        }
    }


    /// <summary>
    /// Class MyMsgOrderListener.
    /// Implements the <see cref="ons.MessageOrderListener" />
    /// </summary>
    /// <seealso cref="ons.MessageOrderListener" />
    public class MyMsgOrderListener : MessageOrderListener
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyMsgOrderListener" /> class.
        /// </summary>
        public MyMsgOrderListener()
        {

        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MyMsgOrderListener" /> class.
        /// </summary>
        ~MyMsgOrderListener()
        {
        }

        /// <summary>
        /// Consumes the specified value.
        /// </summary>
        /// <param name="message">The value.</param>
        /// <param name="context">The context.</param>
        /// <returns>ons.OrderAction.</returns>
        public override ons.OrderAction consume(Message message, ConsumeOrderContext context)
        {
            // 根据业务唯一标识的 Key 做幂等处理
            string key = message.getKey();
            Byte[] text = Encoding.Default.GetBytes(message.getBody());
            Console.WriteLine(Encoding.UTF8.GetString(text));
            return ons.OrderAction.Success;
        }
    }


    /// <summary>
    /// Class OnscSharp.
    /// </summary>
    public class OnscSharp
    {
        /// <summary>
        /// The producer
        /// </summary>
        private static Producer _producer;
        /// <summary>
        /// The consumer
        /// </summary>
        private static PushConsumer _consumer;
        /// <summary>
        /// The orderconsumer
        /// </summary>
        private static OrderConsumer _orderconsumer;
        /// <summary>
        /// The orderproducer
        /// </summary>
        private static OrderProducer _orderproducer;
        /// <summary>
        /// The listen
        /// </summary>
        private static MyMsgListener _listen;
        /// <summary>
        /// The order listen
        /// </summary>
        private static MyMsgOrderListener _order_listen;
        /// <summary>
        /// The s synchronize lock
        /// </summary>
        private static object s_SyncLock = new Object();
        /// <summary>
        /// 您在控制台创建的 Topic
        /// </summary>
        private static string Ons_Topic = "TopicTest";
        /// <summary>
        /// 您在阿里云账号管理控制台中创建的 AccessKeyId，用于身份认证
        /// </summary>
        private static string Ons_AccessKey = "LTAI4Fp1PGyST687RSEq7fkN";
        /// <summary>
        /// 您在阿里云账号管理控制台中创建的 AccessKeySecret，用于身份认证
        /// </summary>
        private static string Ons_SecretKey = "GMX1ofSPe1mocuzUO1N86b756aBpmy";
        /// <summary>
        /// 您在控制台创建的 Group ID
        /// </summary>
        private static string Ons_GroupId = "GID_Test";
        /// <summary>
        /// 设置 TCP 协议接入点，从消息队列 RocketMQ 版控制台的实例详情页面获取
        /// </summary>
        private static string Ons_NameSrv = "http://MQ_INST_1747983802895635_BcIcHhW0.mq-internet-access.mq-internet.aliyuncs.com:80";

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="msgBody">The MSG body.</param>
        /// <param name="tag">The tag.</param>
        public static void SendMessage(string msgBody, String tag = "RegisterLog")
        {
            Message msg = new Message(Ons_Topic, tag, msgBody);
            msg.setKey(Guid.NewGuid().ToString("N"));
            try
            {
                SendResultONS sendResult = _producer.send(msg);
                Console.WriteLine("send success {0}", sendResult.getMessageId());
            }
            catch (Exception ex)
            {
                Console.WriteLine("send failure{0}", ex.ToString());
            }
        }

        /// <summary>
        /// 发送顺序消息
        /// </summary>
        /// <param name="msgBody">The MSG body.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="shardingKey">顺序消息中用来计算不同分区的值(全局顺序消息，该字段可以设置为任意非空字符串。)</param>
        public static void SendOrderMessage(string msgBody, String tag = "RegisterLog", String shardingKey = "test")
        {
            Message msg = new Message(Ons_Topic, tag, msgBody);
            msg.setKey(Guid.NewGuid().ToString());
            try
            {
                SendResultONS sendResult = _orderproducer.send(msg, shardingKey);
                Console.WriteLine("send success {0}", sendResult.getMessageId());
            }
            catch (Exception ex)
            {
                Console.WriteLine("send failure{0}", ex.ToString());
            }
        }

        /// <summary>
        /// Starts the push consumer.
        /// </summary>
        public static void StartPushConsumer()
        {
            _listen = new MyMsgListener();
            _consumer.subscribe(Ons_Topic, "*", _listen);
            _consumer.start();
        }

        /// <summary>
        /// Starts the order consumer.
        /// </summary>
        public static void StartOrderConsumer()
        {
            _order_listen = new MyMsgOrderListener();
            _orderconsumer.subscribe(Ons_Topic, "*", _order_listen);
            _orderconsumer.start();
        }

        /// <summary>
        /// Shutdowns the push consumer.
        /// </summary>
        public static void shutdownPushConsumer()
        {
            _consumer.shutdown();
        }

        /// <summary>
        /// Shutdowns the order consumer.
        /// </summary>
        public static void shutdownOrderConsumer()
        {
            _orderconsumer.shutdown();
        }

        /// <summary>
        /// 启动客户端实例
        /// </summary>
        public static void StartProducer()
        {
            _producer.start();
        }

        /// <summary>
        /// 在您的线程即将退出时，关闭生产者实例
        /// </summary>
        public static void ShutdownProducer()
        {
            _producer.shutdown();
        }


        /// <summary>
        /// 启动顺序消息客户端实例
        /// </summary>
        public static void StartOrderProducer()
        {
            _orderproducer.start();
        }

        /// <summary>
        /// 在您的线程即将退出时，关闭顺序生产者实例
        /// </summary>
        public static void ShutdownOrderProducer()
        {
            _orderproducer.shutdown();
        }

        /// <summary>
        /// 设置RocketMQ连接信息
        /// </summary>
        /// <returns>ONSFactoryProperty.</returns>
        private static ONSFactoryProperty getFactoryProperty()
        {
            ONSFactoryProperty factoryInfo = new ONSFactoryProperty();
            factoryInfo.setFactoryProperty(ONSFactoryProperty.AccessKey, Ons_AccessKey);
            factoryInfo.setFactoryProperty(ONSFactoryProperty.SecretKey, Ons_SecretKey);
            factoryInfo.setFactoryProperty(ONSFactoryProperty.ConsumerId, Ons_GroupId);
            factoryInfo.setFactoryProperty(ONSFactoryProperty.ProducerId, Ons_GroupId);
            factoryInfo.setFactoryProperty(ONSFactoryProperty.PublishTopics, Ons_Topic);
            factoryInfo.setFactoryProperty(ONSFactoryProperty.NAMESRV_ADDR, Ons_NameSrv);
            factoryInfo.setFactoryProperty(ONSFactoryProperty.LogPath, $"{AppDomain.CurrentDomain.BaseDirectory}\\Logs");
            return factoryInfo;
        }

        /// <summary>
        /// Creates the push consumer.
        /// </summary>
        public static void CreatePushConsumer()
        {

            _consumer = ONSFactory.getInstance().createPushConsumer(getFactoryProperty());
        }

        /// <summary>
        /// 创建生产者实例
        /// 说明：生产者实例是线程安全的，可用于发送不同 Topic 的消息。基本上，您每一个线程只需要一个生产者实例
        /// </summary>
        public static void CreateProducer()
        {

            _producer = ONSFactory.getInstance().createProducer(getFactoryProperty());
        }


        /// <summary>
        /// 创建顺序消息消费都实例
        /// </summary>
        public static void CreateOrderConsumer()
        {

            _orderconsumer = ONSFactory.getInstance().createOrderConsumer(getFactoryProperty());
        }

        /// <summary>
        /// 创建顺序消息生产者实例
        /// 说明：生产者实例是线程安全的，可用于发送不同 Topic 的消息。基本上，您每一个线程只需要一个生产者实例
        /// </summary>
        public static void CreateOrderProducer()
        {

            _orderproducer = ONSFactory.getInstance().createOrderProducer(getFactoryProperty());
        }
    }

}

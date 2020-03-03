// ***********************************************************************
// Assembly         : demo
// Author           : carl.wu
// Created          : 02-28-2020
//
// Last Modified By : carl.wu
// Last Modified On : 2020-03-03
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
namespace Aliyun.RocketMQSDK
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
            //Console.WriteLine($"Receive message,key:{key},tag:{message.getTag()},body:{Encoding.UTF8.GetString(text)},BodyTypeFullName:{message.getUserProperties("BodyTypeFullName")}");
            Console.WriteLine($"Receive message  at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")},Topic:{message.getTopic()},key:{key},tag:{message.getTag()},body:{Encoding.UTF8.GetString(text)}");
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
            //Console.WriteLine($"Receive order message,key:{key},tag:{message.getTag()},body:{Encoding.UTF8.GetString(text)},BodyTypeFullName:{message.getUserProperties("BodyTypeFullName")}");
            Console.WriteLine($"Receive order message at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")},Topic:{message.getTopic()},tag:{message.getTag()},key:{key},body:{Encoding.UTF8.GetString(text)}");
            return ons.OrderAction.Success;
        }
    }

    /// <summary>
    /// 参考文档https://help.aliyun.com/document_detail/29548.html与https://help.aliyun.com/document_detail/29564.html
    /// 扩展本地事务检查者
    /// Implements the <see cref="ons.LocalTransactionChecker" />
    /// </summary>
    /// <seealso cref="ons.LocalTransactionChecker" />
    public class LocalTransactionCheckerImpl : LocalTransactionChecker
    {
        /// <summary>
        /// 事务检查方法
        /// </summary>
        private readonly Func<Message, TransactionStatus> checkFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalTransactionCheckerImpl" /> class.
        /// </summary>
        /// <param name="checkFunc">The check function.</param>
        public LocalTransactionCheckerImpl(Func<Message, TransactionStatus> checkFunc)
        {
            this.checkFunc = checkFunc;
        }

        /// <summary>
        /// Checks the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>TransactionStatus.</returns>
        public override TransactionStatus check(Message msg)
        {
            return checkFunc.Invoke(msg);
        }
    }
    /// <summary>
    /// 参考文档https://help.aliyun.com/document_detail/29548.html与https://help.aliyun.com/document_detail/29564.html
    /// Implements the <see cref="ons.LocalTransactionExecuter" />
    /// </summary>
    /// <seealso cref="ons.LocalTransactionExecuter" />
    public class LocalTransactionExecuterImpl : LocalTransactionExecuter
    {
        /// <summary>
        /// 业务逻辑方法
        /// </summary>
        private readonly Func<Message, TransactionStatus> transExecFunc;

        /// <summary>
        /// 异常处理方法
        /// </summary>
        private readonly Action<Message, Exception> exceptionAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalTransactionExecuterImpl" /> class.
        /// </summary>
        /// <param name="transExecFunc">The biz function.</param>
        /// <param name="exceptionAction">The exception action.</param>
        public LocalTransactionExecuterImpl(Func<Message, TransactionStatus> transExecFunc, Action<Message, Exception> exceptionAction = null)
        {
            this.transExecFunc = transExecFunc;
            this.exceptionAction = exceptionAction;
        }

        /// <summary>
        /// Executes the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>TransactionStatus.</returns>
        public override TransactionStatus execute(Message msg)
        {
            // 消息体内容进行crc32, 也可以使用其它的如MD5
            // 消息ID和crc32id主要是用来防止消息重复
            // 如果业务本身是幂等的, 可以忽略, 否则需要利用msgId或crc32Id来做幂等
            // 如果要求消息绝对不重复, 推荐做法是对消息体body使用crc32或md5来防止重复消息.
            return transExecFunc.Invoke(msg);
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
        private Producer _producer;
        /// <summary>
        /// The consumer
        /// </summary>
        private PushConsumer _consumer;
        /// <summary>
        /// The orderconsumer
        /// </summary>
        private OrderConsumer _orderconsumer;
        /// <summary>
        /// The orderproducer
        /// </summary>
        private OrderProducer _orderproducer;
        /// <summary>
        /// The listen
        /// </summary>
        private MyMsgListener _listen;
        /// <summary>
        /// The order listen
        /// </summary>
        private MyMsgOrderListener _order_listen;
        /// <summary>
        /// The orderproducer
        /// </summary>
        private TransactionProducer _transProducer;
        /// <summary>
        /// The consumer
        /// </summary>
        private PushConsumer _transConsumer;
        /// <summary>
        /// The listen
        /// </summary>
        private MyMsgListener _transListen;
        /// <summary>
        /// The s synchronize lock
        /// </summary>
        private object s_SyncLock = new Object();
        /// <summary>
        /// 您在控制台创建的 Topic
        /// </summary>
        private string Ons_Topic = "";
        /// <summary>
        /// 您在阿里云账号管理控制台中创建的 AccessKeyId，用于身份认证
        /// </summary>
        private string Ons_AccessKey = "";
        /// <summary>
        /// 您在阿里云账号管理控制台中创建的 AccessKeySecret，用于身份认证
        /// </summary>
        private string Ons_SecretKey = "";
        /// <summary>
        /// 同一组GroupId一个进程只能有一个消费者
        /// 一类Producer或Consumer标识，这类 Producer 或 Consumer 通常生产或消费同一类消息，且消息发布或订阅的逻辑一致。
        /// 1. Group ID 既可用于生产者，标识同一类 Producer 实例（Producer ID），又可用于消费者，标识同一类 Consumer 实例（Consumer ID）；
        /// 2. 同一个 Group ID 不可以共用于 TCP 协议和 HTTP 协议，需要分别申请。
        /// 3. 以 “GID_” 或者 “GID-” 开头，只能包含字母、数字、短横线（-）和下划线（_）；
        /// 4. 长度限制在 7-64 字符之间；
        /// 5. Group ID 一旦创建，则无法修改。
        /// </summary>
        /// <value>The group identifier.</value>
        private string Ons_GroupId = "";
        /// <summary>
        /// 设置 TCP 协议接入点，从消息队列 RocketMQ 版控制台的实例详情页面获取
        /// </summary>
        private string Ons_NameSrv = "";

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public RocketMQConfig Config { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="OnscSharp" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public OnscSharp(RocketMQConfig config)
        {
            this.Ons_AccessKey = config.AccessKeyId;
            this.Ons_SecretKey = config.AccessKeySecret;
            this.Ons_NameSrv = config.NameSrvAddr;
            this.Ons_Topic = config.Topic;
            this.Ons_GroupId = config.GroupId;
            this.Config = config;
        }
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="msgBody">The MSG body.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="deliveryTime">The delivery time.</param>
        public void SendMessage(string msgBody, String tag = "RegisterLog", DateTime? deliveryTime = null)
        {
            Message msg = new Message(Ons_Topic, tag, msgBody);
            msg.setKey(Guid.NewGuid().ToString("N"));
            if (deliveryTime.HasValue)
            {
                msg.setStartDeliverTime(ToTimestamp(deliveryTime.Value));
            }
            //msg.putSystemProperties("BodyTypeFullName", base64BodyTypeFullName);// 接收信息的时候无法获取到
            //msg.putUserProperties("BodyTypeFullName", base64BodyTypeFullName);// 接收信息的时候可以获取到
            try
            {
                SendResultONS sendResult = _producer.send(msg);
                msg.setMsgID(sendResult.getMessageId());
                Console.WriteLine($"SendMessage success at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} MessageId:{sendResult.getMessageId()},Topic:{msg.getTopic()},Tag:{msg.getTag()},Key:{msg.getKey()}");
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
        public void SendOrderMessage(string msgBody, String tag = "RegisterLog", String shardingKey = "test")
        {
            Message msg = new Message(Ons_Topic, tag, msgBody);
            msg.setKey(Guid.NewGuid().ToString());
            string base64BodyTypeFullName = "SayHello";
            //msg.putSystemProperties("BodyTypeFullName", base64BodyTypeFullName);// 接收信息的时候无法获取到
            msg.putUserProperties("BodyTypeFullName", base64BodyTypeFullName);// 接收信息的时候可以获取到
            try
            {
                SendResultONS sendResult = _orderproducer.send(msg, shardingKey);
                msg.setMsgID(sendResult.getMessageId());
                //Console.WriteLine("send success {0}", sendResult.getMessageId());
                Console.WriteLine($"SendOrderMessage success at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")},MessageId:{sendResult.getMessageId()},Topic:{msg.getTopic()},Tag:{msg.getTag()},Key:{msg.getKey()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("send failure{0}", ex.ToString());
            }
        }

        /// <summary>
        /// Starts the push consumer.
        /// </summary>
        /// <param name="subExpression">The sub expression.</param>
        public void StartPushConsumer(string subExpression = "*")
        {
            _listen = new MyMsgListener();
            _consumer.subscribe(Ons_Topic, subExpression, _listen);
            Console.WriteLine($"StartPushConsumer,{_consumer.GetHashCode()}");
            _consumer.start();
        }

        /// <summary>
        /// Starts the order consumer.
        /// </summary>
        /// <param name="subExpression">The sub expression.</param>
        public void StartOrderConsumer(string subExpression = "*")
        {
            _order_listen = new MyMsgOrderListener();
            _orderconsumer.subscribe(Ons_Topic, subExpression, _order_listen);
            _orderconsumer.start();
        }

        /// <summary>
        /// Shutdowns the push consumer.
        /// </summary>
        public void shutdownPushConsumer()
        {
            _consumer?.shutdown();
        }

        /// <summary>
        /// Shutdowns the order consumer.
        /// </summary>
        public void shutdownOrderConsumer()
        {
            _orderconsumer?.shutdown();
        }

        /// <summary>
        /// 启动客户端实例
        /// </summary>
        public void StartProducer()
        {
            _producer?.start();
        }

        /// <summary>
        /// 在您的线程即将退出时，关闭生产者实例
        /// </summary>
        public void ShutdownProducer()
        {
            _producer?.shutdown();
        }


        /// <summary>
        /// 启动顺序消息客户端实例
        /// </summary>
        public void StartOrderProducer()
        {
            _orderproducer?.start();
        }

        /// <summary>
        /// 在您的线程即将退出时，关闭顺序生产者实例
        /// </summary>
        public void ShutdownOrderProducer()
        {
            _orderproducer?.shutdown();
        }

        /// <summary>
        /// 设置RocketMQ连接信息
        /// </summary>
        /// <returns>ONSFactoryProperty.</returns>
        private ONSFactoryProperty getFactoryProperty()
        {
            ONSFactoryProperty factoryInfo = new ONSFactoryProperty();
            factoryInfo.setFactoryProperty(ONSFactoryProperty.AccessKey, Ons_AccessKey);
            factoryInfo.setFactoryProperty(ONSFactoryProperty.SecretKey, Ons_SecretKey);
            factoryInfo.setFactoryProperty(ONSFactoryProperty.PublishTopics, Ons_Topic);
            factoryInfo.setFactoryProperty(ONSFactoryProperty.NAMESRV_ADDR, Ons_NameSrv);
            factoryInfo.setFactoryProperty(ONSFactoryProperty.LogPath, $"{AppDomain.CurrentDomain.BaseDirectory}Logs");
            return factoryInfo;
        }

        /// <summary>
        /// 创建普通消息消费者实例(同一个GroupId,同一个进程,不允许有多个消费者实例)
        /// </summary>
        public void CreatePushConsumer()
        {
            ONSFactoryProperty onsFactoryProperty = getFactoryProperty();
            onsFactoryProperty.setFactoryProperty(ONSFactoryProperty.ConsumerId, Ons_GroupId);
            _consumer = ONSFactory.getInstance().createPushConsumer(onsFactoryProperty);
        }

        /// <summary>
        /// 创建生产者实例
        /// 说明：生产者实例是线程安全的，可用于发送不同 Topic 的消息。基本上，您每一个线程只需要一个生产者实例
        /// </summary>
        public void CreateProducer()
        {
            ONSFactoryProperty onsFactoryProperty = getFactoryProperty();
            onsFactoryProperty.setFactoryProperty(ONSFactoryProperty.ProducerId, Ons_GroupId);
            _producer = ONSFactory.getInstance().createProducer(onsFactoryProperty);

        }


        /// <summary>
        /// 创建顺序消息消费者实例(同一个GroupId,同一个进程,不允许有多个消费者实例)
        /// </summary>
        public void CreateOrderConsumer()
        {
            ONSFactoryProperty onsFactoryProperty = getFactoryProperty();
            onsFactoryProperty.setFactoryProperty(ONSFactoryProperty.ConsumerId, Ons_GroupId);
            _orderconsumer = ONSFactory.getInstance().createOrderConsumer(onsFactoryProperty);
        }

        /// <summary>
        /// 创建顺序消息生产者实例
        /// 说明：生产者实例是线程安全的，可用于发送不同 Topic 的消息。基本上，您每一个线程只需要一个生产者实例
        /// </summary>
        public void CreateOrderProducer()
        {
            ONSFactoryProperty onsFactoryProperty = getFactoryProperty();
            onsFactoryProperty.setFactoryProperty(ONSFactoryProperty.ProducerId, Ons_GroupId);
            _orderproducer = ONSFactory.getInstance().createOrderProducer(onsFactoryProperty);
        }
        /// <summary>
        /// 创建顺序消息生产者实例
        /// 说明：生产者实例是线程安全的，可用于发送不同 Topic 的消息。基本上，您每一个线程只需要一个生产者实例
        /// </summary>
        /// <param name="transactionChecker">The local transaction checker.</param>
        public void CreateTransProducer(LocalTransactionCheckerImpl transactionChecker)
        {
            ONSFactoryProperty onsFactoryProperty = getFactoryProperty();
            onsFactoryProperty.setFactoryProperty(ONSFactoryProperty.ProducerId, Ons_GroupId);
            _transProducer = ONSFactory.getInstance().createTransactionProducer(onsFactoryProperty, transactionChecker);
        }
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="msgBody">The MSG body.</param>
        /// <param name="localTransactionExecuter">The local transaction executer.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="deliveryTime">The delivery time.</param>
        public void SendTransMessage(string msgBody, LocalTransactionExecuter localTransactionExecuter, String tag = "RegisterLog", DateTime? deliveryTime = null)
        {
            Message msg = new Message(Ons_Topic, tag, msgBody);
            msg.setKey(Guid.NewGuid().ToString("N"));
            if (deliveryTime.HasValue)
            {
                msg.setStartDeliverTime(ToTimestamp(deliveryTime.Value));
            }
            //msg.putSystemProperties("BodyTypeFullName", base64BodyTypeFullName);// 接收信息的时候无法获取到
            //msg.putUserProperties("BodyTypeFullName", base64BodyTypeFullName);// 接收信息的时候可以获取到
            try
            {
                SendResultONS sendResult = _transProducer.send(msg, localTransactionExecuter);
                Console.WriteLine($"SendTransMessage  success at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} MessageId:{sendResult.getMessageId()},Key:{msg.getKey()},tag:{msg.getTag()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("send failure {0}", ex.ToString());
            }
        }
        /// <summary>
        /// Starts the trans producer.
        /// </summary>
        public void StartTransProducer()
        {
            _transProducer?.start();
        }

        /// <summary>
        /// Shutdowns the trans producer.
        /// </summary>
        public void ShutdownTransProducer()
        {
            _transProducer?.shutdown();
        }
        /// <summary>
        /// 创建普通消息消费者实例(同一个GroupId,同一个进程,不允许有多个消费者实例)
        /// </summary>
        public void CreateTransConsumer()
        {
            ONSFactoryProperty onsFactoryProperty = getFactoryProperty();
            onsFactoryProperty.setFactoryProperty(ONSFactoryProperty.ConsumerId, Ons_GroupId);
            _transConsumer = ONSFactory.getInstance().createPushConsumer(onsFactoryProperty);
        }
        /// <summary>
        /// Starts the push consumer.
        /// </summary>
        /// <param name="subExpression">The sub expression.</param>
        public void StartTransConsumer(string subExpression = "*")
        {
            _transListen = new MyMsgListener();
            _transConsumer.subscribe(Ons_Topic, subExpression, _transListen);
            Console.WriteLine($"StartTransConsumer,{_transConsumer.GetHashCode()}");
            _transConsumer.start();
        }
        /// <summary>
        /// Shutdowns the push consumer.
        /// </summary>
        public void shutdownTransConsumer()
        {
            _transConsumer?.shutdown();
        }
        /// <summary>
        /// 转换成时间戳
        /// </summary>
        /// <param name="dateTime">当前时间</param>
        /// <returns>System.Int64.</returns>
        public long ToTimestamp(DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }

}

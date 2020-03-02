using Kmmp.Core.Imps;
using Newtonsoft.Json;
using ons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kmmp.Core.MqFramework.RocketMQ.Consumers
{
    /// <summary>
    /// Class RocketMQReceiver.
    /// Implements the <see cref="Kmmp.Core.MqFramework.RocketMQ.Consumers.PushConsumerClient" />
    /// Implements the <see cref="Kmmp.Core.Imps.IMessageReceiver" />
    /// </summary>
    /// <seealso cref="Kmmp.Core.MqFramework.RocketMQ.Consumers.PushConsumerClient" />
    /// <seealso cref="Kmmp.Core.Imps.IMessageReceiver" />
    public class RocketMQReceiver : PushConsumerClient, IMessageReceiver, IBroadcastReceiver
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config">RocketMQ配置信息</param>
        /// <param name="queueName">队列名称</param>
        /// <param name="receiverId">接受对象Id</param>
        /// <param name="consumerThreadCount">Consumer 实例的消费线程数，默认值：5</param>
        public RocketMQReceiver(RocketMQConfig config, string queueName, string receiverId = null, int consumerThreadCount = 5)
            : base(config.AccessKeyId, config.AccessKeySecret, config.NameSrvAddr, config.Topic, config.GroupIdPrefix + queueName, queueName, consumerThreadCount)
        {

        }
        /// <summary>
        /// 接收消息事件
        /// </summary>
        public event EventHandler<MessageEventArgs> Received;
        /// <summary>
        /// 作者：carl.wu
        /// 时间：2020-02-01
        /// 功能：启动监听
        /// </summary>
        public override void Start()
        {
            ReceiverMessageListener listener = new ReceiverMessageListener();
            listener.ReceivedEventHandler += OnReceived;
            base.SetMessageListener(listener);
            base.Start();

        }
        /// <summary>
        /// 作者：carl.wu
        /// 时间：2020-02-01
        /// 功能：收到消息事件
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="args">The <see cref="MessageEventArgs"/> instance containing the event data.</param>
        private void OnReceived(object sender, MessageEventArgs args)
        {
            // 定义一个局部变量，已防止最后一个订阅者刚好在检查null后取消订阅
            EventHandler<MessageEventArgs> handler = Received;
            // 如果没有 订阅者（观察者）， 委托对象将为null
            if (handler != null)
            {
                handler(this, args);
            }
            else
            {
                Console.WriteLine($"handler is null");
            }
        }
        /// <summary>
        /// 执行与释放或重置非托管资源关联的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {
            this.Shutdown();
        }
        private static int count = 0;
        /// <summary>
        /// Class ReceiverMessageListener.
        /// Implements the <see cref="ons.MessageListener" />
        /// </summary>
        /// <seealso cref="ons.MessageListener" />
        private class ReceiverMessageListener : MessageListener
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ReceiverMessageListener"/> class.
            /// </summary>
            public ReceiverMessageListener()
            {

            }
            /// <summary>
            /// Consumes the specified message.
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="context">The context.</param>
            /// <returns>Action.</returns>
            /// <exception cref="ArgumentNullException"></exception>
            public override ons.Action consume(Message message, ConsumeContext context)
            {
                var base64BodyTypeFullName = message.getUserProperties("BodyTypeFullName");
                MessageEventArgs messageEventArgs = null;
                string msgName = $"{message.getTopic()}:{message.getTag()}:{message.getKey()}";
                if (!string.IsNullOrWhiteSpace(base64BodyTypeFullName))
                {
                    try
                    {
                        var bodyTypeFullName = Encoding.UTF8.GetString(Convert.FromBase64String(base64BodyTypeFullName));
                        var bodyType = Type.GetType(bodyTypeFullName);
                        if (bodyType == null)
                        {
                            throw new ArgumentNullException("bodyType is null");
                        }
                        var msgBody = JsonConvert.DeserializeObject(message.getBody(), bodyType);
                        messageEventArgs = new MessageEventArgs(msgName, msgBody);
                    }
                    catch (Exception ex)
                    {
                        messageEventArgs = new MessageEventArgs(msgName, message.getBody());
                        Console.WriteLine(ex);
                    }
                }
                else
                {
                    Console.WriteLine($"base64BodyTypeFullName is null,body:{message.getBody()}");
                    messageEventArgs = new MessageEventArgs(msgName, message.getBody());
                }
                //Console.WriteLine($"消息序号:{count++}, 当前线程ID:{ Thread.CurrentThread.ManagedThreadId},Tag:{message.getTag()},key:{message.getKey()},MsgID:{message.getMsgID()},typeFullName:{base64BodyTypeFullName}");
                Console.WriteLine($"于{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}接收到消息,序号:{count++}, 当前线程ID:{ Thread.CurrentThread.ManagedThreadId},Topic:{message.getTopic()},Tag:{message.getTag()},key:{message.getKey()},MsgID:{message.getMsgID()}");
                try
                {
                    OnReceived(messageEventArgs);
                    return ons.Action.CommitMessage;
                }
                catch (Exception)
                {
                    return ons.Action.ReconsumeLater;
                }
                //return ons.Action.ReconsumeLater;//失败&稍后重试
            }
            /// <summary>
            /// Handles the <see cref="E:Received" /> event.
            /// </summary>
            /// <param name="args">The <see cref="MessageEventArgs"/> instance containing the event data.</param>
            private void OnReceived(MessageEventArgs args)
            {
                // 定义一个局部变量，已防止最后一个订阅者刚好在检查null后取消订阅
                EventHandler<MessageEventArgs> handler = ReceivedEventHandler;
                // 如果没有 订阅者（观察者）， 委托对象将为null
                if (handler != null)
                {
                    handler(this, args);
                }
                else
                {
                    Console.WriteLine($"handler is null");
                }

            }
            /// <summary>
            /// 接收到消息事件
            /// </summary>
            public event EventHandler<MessageEventArgs> ReceivedEventHandler;
        }
    }
}

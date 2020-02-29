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
        /// <param name="accessKeyId">您在阿里云账号管理控制台中创建的 AccessKeyId，用于身份认证</param>
        /// <param name="accessKeySecret">您在阿里云账号管理控制台中创建的 AccessKeySecret，用于身份认证</param>
        /// <param name="nameSrvAddr">设置 TCP 协议接入点，从消息队列 RocketMQ 版控制台的实例详情页面获取</param>
        /// <param name="topic">您在控制台创建的消息主题，一级消息类型，通过 Topic 对消息进行分类。详情请参见 Topic 与 Tag 最佳实践。</param>
        /// <param name="groupId">一类Producer或Consumer标识，这类 Producer 或 Consumer 通常生产或消费同一类消息，且消息发布或订阅的逻辑一致。</param>
        /// <param name="queueName">Name of the queue.</param>
        /// <param name="consumerThreadCount">Consumer 实例的消费线程数，默认值：5</param>
        public RocketMQReceiver(string accessKeyId, string accessKeySecret, string nameSrvAddr, string topic, string groupId, string queueName, int consumerThreadCount = 5)
            : base(accessKeyId, accessKeySecret, nameSrvAddr, topic, groupId, queueName, consumerThreadCount)
        {

        }

        /// <summary>
        /// 接收消息事件
        /// </summary>
        public event EventHandler<MessageEventArgs> Received = delegate { };

        private bool running = false;
        /// <summary>
        /// 作者：carl.wu
        /// 时间：2020-02-01
        /// 功能：启动监听
        /// </summary>
        public override void Start()
        {
            ReceiverMessageListener listener = new ReceiverMessageListener();
            listener.ReceivedEventHandler += receiver_Received;
            base.SetMessageListener(listener);
            if (!running)
            {
                running = true;
            }
            base.Start();

        }
        /// <summary>
        /// 作者：carl.wu
        /// 时间：2020-02-01
        /// 功能：收到消息事件
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="e">消息参数</param>
        private void receiver_Received(object sender, MessageEventArgs e)
        {
            //防止两个消息同时从不同 channel 中获取，并执行
            Received(this, e);
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
                var typeFullName = message.getSystemProperties("BodyTypeFullName");
                if (!string.IsNullOrWhiteSpace(typeFullName))
                {
                    var bodyType = Type.GetType(typeFullName);
                    if (bodyType == null)
                    {
                        throw new ArgumentNullException("bodyType is null");
                    }
                    var msgBody = JsonConvert.DeserializeObject(message.getBody(), bodyType);
                    OnReceived(new MessageEventArgs($"{message.getTopic()}:{message.getTag()}", msgBody));
                }
                else
                {
                    OnReceived(new MessageEventArgs($"{message.getTopic()}:{message.getTag()}", message.getBody()));
                }
                Console.WriteLine($"消息序号:{count++}, 当前线程ID:{ Thread.CurrentThread.ManagedThreadId},Tag:{message.getTag()},key:{message.getKey()},MsgID:{message.getMsgID()},typeFullName:{typeFullName}");
                return ons.Action.CommitMessage;
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
                    // 这是最重要的一句。
                    // 此时执行的  handler已经是一个多播委托（如果有多个订阅者或观察者注册）。
                    // 既然是多播委托，就可以依次调用各个 回调函数 （既然是回调函数，实际的执行就由订阅者类决定）。
                    //这里面传入一个this, 就代表 事件源（或发布者 或 被观察者 都一个意思）
                    handler(this, args);
                }
            }
            /// <summary>
            /// 接收到消息事件
            /// </summary>
            public event EventHandler<MessageEventArgs> ReceivedEventHandler;
        }
    }
}

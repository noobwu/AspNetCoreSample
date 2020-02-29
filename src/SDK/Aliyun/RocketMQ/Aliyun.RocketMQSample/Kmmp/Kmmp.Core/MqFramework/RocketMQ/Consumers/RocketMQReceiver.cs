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
            listener.Received += receiver_Received;
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
            lock (this)
            {
                Received(this, e);
            }
        }
        /// <summary>
        /// 执行与释放或重置非托管资源关联的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {
            this.Shutdown();
        }
        /// <summary>
        /// Class ReceiverMessageListener.
        /// Implements the <see cref="ons.MessageListener" />
        /// </summary>
        /// <seealso cref="ons.MessageListener" />
        private class ReceiverMessageListener : MessageListener
        {
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
                    Received(this, new MessageEventArgs($"{message.getTopic()}:{message.getTag()}", msgBody));
                }
                //Console.WriteLine("消息序号: {0}, 当前线程ID = {1}, MessageId为： {2}", ++count, Thread.CurrentThread.ManagedThreadId, message.getMsgID());
                return ons.Action.CommitMessage;
            }
            /// <summary>
            /// 接收到消息事件
            /// </summary>
            public event EventHandler<MessageEventArgs> Received = delegate { };
        }
    }
}

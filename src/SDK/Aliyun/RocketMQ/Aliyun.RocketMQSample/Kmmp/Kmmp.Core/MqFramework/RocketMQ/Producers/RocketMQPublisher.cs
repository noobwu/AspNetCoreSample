// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="RocketMQPublisher.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Kmmp.Core.Helper;
using Kmmp.Core.Imps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Producers namespace.
/// </summary>
namespace Kmmp.Core.MqFramework.RocketMQ.Producers
{
    /// <summary>
    /// Class RocketMQPublisher.
    /// Implements the <see cref="Kmmp.Core.MqFramework.RocketMQ.Producers.DefaultProducerClient" />
    /// Implements the <see cref="Kmmp.Core.Imps.IMessagePublisher" />
    /// </summary>
    /// <seealso cref="Kmmp.Core.MqFramework.RocketMQ.Producers.DefaultProducerClient" />
    /// <seealso cref="Kmmp.Core.Imps.IMessagePublisher" />
    public class RocketMQPublisher : DefaultProducerClient, IMessagePublisher, IBroadcastPublisher
    {
        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <value>The tag.</value>
        private string queueName;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="accessKeyId">您在阿里云账号管理控制台中创建的 AccessKeyId，用于身份认证</param>
        /// <param name="accessKeySecret">您在阿里云账号管理控制台中创建的 AccessKeySecret，用于身份认证</param>
        /// <param name="nameSrvAddr">设置 TCP 协议接入点，从消息队列 RocketMQ 版控制台的实例详情页面获取</param>
        /// <param name="topic">您在控制台创建的消息主题，一级消息类型，通过 Topic 对消息进行分类。详情请参见 Topic 与 Tag 最佳实践。</param>
        /// <param name="groupId">一类Producer或Consumer标识，这类 Producer 或 Consumer 通常生产或消费同一类消息，且消息发布或订阅的逻辑一致。</param>
        /// <param name="queueName">Name of the queue.</param>
        public RocketMQPublisher(string accessKeyId, string accessKeySecret, string nameSrvAddr, string topic, string groupId, string queueName)
            : base(accessKeyId, accessKeySecret, nameSrvAddr, topic, groupId)
        {
            this.queueName = queueName;
        }
        /// <summary>
        /// 执行与释放或重置非托管资源关联的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {
            this.Shutdown();
        }

        /// <summary>
        /// 作者：carl.wu
        /// 时间：2020-02-01
        /// 功能：发送一个消息，将消息发入队列(异步)
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="timeOut">The time out.</param>
        /// <param name="delay">消息延迟投递时间(秒)</param>
        public void Put(object body, DateTime? timeOut = null, int? delay = null)
        {
            string messageId = null;
            IIdentityMessage identityMessage = body as IIdentityMessage;
            if (identityMessage != null)
            {
                messageId = identityMessage.MessageId;
            }
            else
            {
                messageId = Guid.NewGuid().ToString("N");
            }
            this.Start();
            if (delay.HasValue && delay > 0)
            {
                var result = this.SendTimingMessage(body, DateTime.Now.AddSeconds(delay.Value), queueName, messageId);
            }
            else
            {
                var result = this.SendMessage(body, queueName, messageId);
            }
        }

        /// <summary>
        /// 作者：carl.wu
        /// 时间：2020-02-01
        /// 功能：发送一个消息，将消息发入队列(异步)
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="timeOut">The time out.</param>
        /// <param name="delay">消息延迟投递时间(秒)</param>
        /// <returns>Task.</returns>
        public Task PutAsync(object body, DateTime? timeOut = null, int? delay = null)
        {
            return Task.Run(() => Put(body, timeOut, delay));
        }
    }
}

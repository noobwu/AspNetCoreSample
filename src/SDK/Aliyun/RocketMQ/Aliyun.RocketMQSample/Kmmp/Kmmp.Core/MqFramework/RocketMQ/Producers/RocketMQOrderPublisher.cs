﻿// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-03-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-01
// ***********************************************************************
// <copyright file="RocketMQOrderPublisher.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Kmmp.Core.Imps;
using ons;
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
    /// Class RocketMQOrderPublisher.
    /// Implements the <see cref="Kmmp.Core.MqFramework.RocketMQ.Producers.OrderProducerClient" />
    /// Implements the <see cref="Kmmp.Core.Imps.IMessagePublisher" />
    /// Implements the <see cref="Kmmp.Core.Imps.IBroadcastPublisher" />
    /// </summary>
    /// <seealso cref="Kmmp.Core.MqFramework.RocketMQ.Producers.OrderProducerClient" />
    /// <seealso cref="Kmmp.Core.Imps.IMessagePublisher" />
    /// <seealso cref="Kmmp.Core.Imps.IBroadcastPublisher" />
    public class RocketMQOrderPublisher : OrderProducerClient, IMessagePublisher, IBroadcastPublisher
    {
        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <value>The tag.</value>
        private string queueName;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config">RocketMQ配置信息</param>
        /// <param name="queueName">Name of the queue.</param>
        public RocketMQOrderPublisher(RocketMQConfig config, string queueName) : base(
            config.AccessKeyId, config.AccessKeySecret, config.NameSrvAddr, config.Topic, config.GroupIdPrefix + queueName, config.LogPath)
        {
            this.queueName = queueName;
            this.Start();//多线程的问题
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
            try
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
                DateTime? deliveryTime = null;
                if (delay.HasValue && delay > 0)
                {
                    deliveryTime = DateTime.Now.AddSeconds(delay.Value);
                }
                var result = this.SendMessage(body, messageId, queueName, messageId, deliveryTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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

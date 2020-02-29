// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="MessageQueueExtension.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kmmp.Core.Imps;

/// <summary>
/// The Extension namespace.
/// </summary>
namespace Kmmp.Core.Extension
{
    /// <summary>
    /// 作者：吴廷有
    /// 时间：2015-10-23
    /// 功能：mq 扩展方法
    /// </summary>
    public static class MessageQueueExtension
    {
        #region "  方法定义  "

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：获取消息接收器
        /// </summary>
        /// <param name="messageQueue">消息队列</param>
        /// <param name="queueName">通道名称</param>
        /// <returns>IMessageReceiver.</returns>
        public static IMessageReceiver GetMessageReceiver(this IMessageQueue messageQueue, string queueName)
        {
            return messageQueue.GetMessageReceiver(queueName, null);
        }

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：获取广播接收器
        /// </summary>
        /// <param name="messageQueue">消息队列</param>
        /// <param name="broadcastName">通道名称</param>
        /// <returns>IBroadcastReceiver.</returns>
        public static IBroadcastReceiver GetBroadcastReceiver(this IMessageQueue messageQueue, string broadcastName)
        {
            return messageQueue.GetBroadcastReceiver(broadcastName, null);
        }

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：发送一个消息
        /// </summary>
        /// <param name="messageQueue">消息队列</param>
        /// <param name="queueName">队列名称</param>
        /// <param name="messages">被发送的消息</param>
        public static void Puts(this IMessageQueue messageQueue, string queueName, params object[] messages)
        {
            using (var publisher = messageQueue.GetMessagePublisher(queueName))
            {
                foreach (var message in messages)
                {
                    publisher.Put(message);
                }
            }
        }

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：发送一个消息
        /// </summary>
        /// <param name="messageQueue">消息队列</param>
        /// <param name="queueName">队列名</param>
        /// <param name="message">The message.</param>
        public static void Put(this IMessageQueue messageQueue, string queueName, object message)
        {
            using (var publisher = messageQueue.GetMessagePublisher(queueName))
            {
                publisher.Put(message);
            }
        }

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：发送一个消息
        /// </summary>
        /// <param name="messageQueue">消息队列</param>
        /// <param name="queueName">队列名</param>
        /// <param name="message">The message.</param>
        /// <returns>Task.</returns>
        public static async Task PutAsync(this IMessageQueue messageQueue, string queueName, object message)
        {
            using (var publisher = messageQueue.GetMessagePublisher(queueName))
            {
                await publisher.PutAsync(message);
            }
        }

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：广播消息
        /// </summary>
        /// <param name="messageQueue">消息队列</param>
        /// <param name="queueName">队列名称</param>
        /// <param name="message">消息正文</param>
        public static void Broadcast(this IMessageQueue messageQueue, string queueName, object message)
        {
            using (var publisher = messageQueue.GetBroadcastPublisher(queueName))
            {
                publisher.Put(message);
            }
        }

        #endregion
    }
}

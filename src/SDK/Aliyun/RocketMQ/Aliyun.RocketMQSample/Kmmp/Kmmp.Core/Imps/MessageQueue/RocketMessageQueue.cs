// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="RocketMessageQueue.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Kmmp.Core.MqFramework.RocketMQ;
using Kmmp.Core.MqFramework.RocketMQ.Consumers;
using Kmmp.Core.MqFramework.RocketMQ.Producers;
using ons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The MessageQueue namespace.
/// </summary>
namespace Kmmp.Core.Imps.MessageQueue
{
    /// <summary>
    /// Class RocketMessageQueue.
    /// Implements the <see cref="Kmmp.Core.Imps.IMessageQueue" />
    /// Implements the <see cref="Kmmp.Core.Imps.IComponent" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="Kmmp.Core.Imps.IMessageQueue" />
    /// <seealso cref="Kmmp.Core.Imps.IComponent" />
    /// <seealso cref="System.IDisposable" />
    public class RocketMessageQueue : IMessageQueue, IComponent, IDisposable
    {
        /// <summary>
        /// RocketMQ配置信息
        /// </summary>
        /// <value>The rocket mq configuration.</value>
        public RocketMQConfig Config { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="RocketMessageQueue" /> class.
        /// </summary>
        public RocketMessageQueue()
        {

        }
        /// <summary>
        /// 初始化组件
        /// </summary>
        /// <exception cref="ArgumentNullException">RocketMQ配置信息不能为空</exception>
        void IComponent.Init()
        {
            if (Config == null)
            {
                throw new ArgumentNullException("RocketMQ配置信息不能为空");
            }
        }
        /// <summary>
        /// 执行与释放或重置非托管资源关联的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {

        }
        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：获取一个消息发布者
        /// </summary>
        /// <param name="queueName">The queue.</param>
        /// <returns>IMessagePublisher.</returns>
        public IMessagePublisher GetMessagePublisher(string queueName)
        {
            return new RocketMQPublisher(Config, queueName);
        }

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：获取一个广播消息发布者
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <returns>IBroadcastPublisher.</returns>
        public IBroadcastPublisher GetBroadcastPublisher(string queueName)
        {
            return new RocketMQPublisher(Config, queueName);
        }

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：获取一个消息接收者对象
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <param name="receiverId">接收对象 Id</param>
        /// <returns>IMessageReceiver.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IMessageReceiver GetMessageReceiver(string queueName, string receiverId)
        {
            return new RocketMQReceiver(Config, queueName, receiverId);
        }
        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：获取一个广播消息发布者
        /// </summary>
        /// <param name="queueName">队列名称</param>
        /// <param name="receiverId">接收对象 Id</param>
        /// <returns>IBroadcastReceiver.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IBroadcastReceiver GetBroadcastReceiver(string queueName, string receiverId)
        {
            return new RocketMQReceiver(Config, queueName, receiverId);
        }


    }
}

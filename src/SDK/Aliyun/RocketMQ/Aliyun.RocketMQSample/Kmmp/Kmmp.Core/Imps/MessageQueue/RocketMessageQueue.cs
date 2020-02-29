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
using Kmmp.Core.MqFramework.RocketMQ.Consumers;
using Kmmp.Core.MqFramework.RocketMQ.Producers;
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
        #region 配置信息
        /// <summary>
        /// 您在阿里云账号管理控制台中创建的 AccessKeyId，用于身份认证
        /// </summary>
        /// <value>The access key identifier.</value>
        public string AccessKeyId { get; set; }

        /// <summary>
        /// 您在阿里云账号管理控制台中创建的 AccessKeySecret，用于身份认证
        /// </summary>
        /// <value>The access key secret.</value>
        public string AccessKeySecret { get; set; }

        /// <summary>
        /// 设置 TCP 协议接入点，从消息队列 RocketMQ 版控制台的实例详情页面获取
        /// </summary>
        /// <value>The name SRV addr.</value>
        public string NameSrvAddr { get; set; }


        /// <summary>
        /// 您在控制台创建的消息主题，一级消息类型，通过 Topic 对消息进行分类。详情请参见 Topic 与 Tag 最佳实践。
        /// </summary>
        /// <value>The topic.</value>
        public string Topic { get; set; }
        /// <summary>
        /// 一类Producer或Consumer标识，这类 Producer 或 Consumer 通常生产或消费同一类消息，且消息发布或订阅的逻辑一致。
        /// </summary>
        /// <value>The group identifier.</value>
        public string GroupId { get; set; }
        /// <summary>
        /// 是否启用异步
        /// </summary>
        /// <value><c>true</c> if this instance is asynchronous; otherwise, <c>false</c>.</value>
        public bool IsAsync { get; set; }

        #endregion 配置信息
        /// <summary>
        /// Initializes a new instance of the <see cref="RocketMessageQueue" /> class.
        /// </summary>
        public RocketMessageQueue()
        {

        }
        /// <summary>
        /// 初始化组件
        /// </summary>
        void IComponent.Init()
        {

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
            return new RocketMQPublisher(AccessKeyId, AccessKeySecret, NameSrvAddr, Topic, GroupId, queueName);
        }

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：获取一个广播消息发布者
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <returns>IBroadcastPublisher.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IBroadcastPublisher GetBroadcastPublisher(string queueName)
        {
            return new RocketMQPublisher(AccessKeyId, AccessKeySecret, NameSrvAddr, Topic, GroupId, queueName);
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
            return new RocketMQReceiver(AccessKeyId, AccessKeySecret, NameSrvAddr, Topic, GroupId, queueName);
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
            return new RocketMQReceiver(AccessKeyId, AccessKeySecret, NameSrvAddr, Topic, GroupId, queueName);
        }


    }
}

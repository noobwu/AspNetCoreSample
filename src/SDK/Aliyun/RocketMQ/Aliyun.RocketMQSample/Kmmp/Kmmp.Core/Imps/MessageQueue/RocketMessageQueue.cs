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
        /// Initializes a new instance of the <see cref="RocketMessageQueue"/> class.
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
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：获取一个广播消息发布者
        /// </summary>
        /// <param name="queue">队列名称</param>
        /// <returns>IBroadcastPublisher.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IBroadcastPublisher GetBroadcastPublisher(string queue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：获取一个广播消息发布者
        /// </summary>
        /// <param name="broadcastName">队列名称</param>
        /// <param name="receiverId">接收对象 Id</param>
        /// <returns>IBroadcastReceiver.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IBroadcastReceiver GetBroadcastReceiver(string broadcastName, string receiverId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：获取一个消息发布者
        /// </summary>
        /// <param name="queue">The queue.</param>
        /// <returns>IMessagePublisher.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IMessagePublisher GetMessagePublisher(string queue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：获取一个消息接收者对象
        /// </summary>
        /// <param name="queue">列表名称</param>
        /// <param name="receiverId">接收对象 Id</param>
        /// <returns>IMessageReceiver.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IMessageReceiver GetMessageReceiver(string queue, string receiverId)
        {
            throw new NotImplementedException();
        }


    }
}

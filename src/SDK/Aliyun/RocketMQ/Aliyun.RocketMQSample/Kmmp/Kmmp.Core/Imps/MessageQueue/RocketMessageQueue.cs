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
    /// </summary>
    public class RocketMessageQueue : IMessageQueue, IComponent, IDisposable
    {
        /// <summary>
        /// 
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
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IBroadcastPublisher GetBroadcastPublisher(string queue)
        {
            throw new NotImplementedException();
        }

        public IBroadcastReceiver GetBroadcastReceiver(string broadcastName, string receiverId)
        {
            throw new NotImplementedException();
        }

        public IMessagePublisher GetMessagePublisher(string queue)
        {
            throw new NotImplementedException();
        }

        public IMessageReceiver GetMessageReceiver(string queue, string receiverId)
        {
            throw new NotImplementedException();
        }


    }
}

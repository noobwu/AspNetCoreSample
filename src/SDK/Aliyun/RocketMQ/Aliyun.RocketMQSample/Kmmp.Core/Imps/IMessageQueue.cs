﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kmmp.Core.Imps
{
    /// <summary>
    ///     作者：吴廷有
    ///     时间：2015-10-23
    ///     功能：消息队列接口
    /// </summary>
    public interface IMessageQueue : IDisposable
    {
        #region "  方法定义  "

        /// <summary>
        ///     作者：吴廷有
        ///     时间：2015-10-23
        ///     功能：获取一个消息发布者
        /// </summary>
        /// <param name="queue"></param>
        /// <returns></returns>
        IMessagePublisher GetMessagePublisher(string queue);

        /// <summary>
        ///     作者：吴廷有
        ///     时间：2015-10-23
        ///     功能：获取一个广播消息发布者
        /// </summary>
        /// <param name="queue">队列名称</param>
        /// <returns></returns>
        IBroadcastPublisher GetBroadcastPublisher(string queue);

        /// <summary>
        ///     作者：吴廷有
        ///     时间：2015-10-23
        ///     功能：获取一个消息接收者对象
        /// </summary>
        /// <param name="queue">列表名称</param>
        /// <param name="receiverId">接收对象 Id</param>
        /// <returns></returns>
        IMessageReceiver GetMessageReceiver(string queue, string receiverId);

        /// <summary>
        ///     作者：吴廷有
        ///     时间：2015-10-23
        ///     功能：获取一个广播消息发布者
        /// </summary>
        /// <param name="broadcastName">队列名称</param>
        /// <param name="receiverId">接收对象 Id</param>
        /// <returns></returns>
        IBroadcastReceiver GetBroadcastReceiver(string broadcastName, string receiverId);

        #endregion
    }

    /// <summary>
    ///     作者：吴廷有
    ///     时间：2015-10-23
    ///     功能：消息接收者
    /// </summary>
    public interface IMessageReceiver : IDisposable
    {
        #region "  方法定义  "

        /// <summary>
        ///     作者：吴廷有
        ///     时间：2015-10-23
        ///     功能：启动监听
        /// </summary>
        void Start();

        #endregion

        /// <summary>
        /// 消息接收事件
        /// </summary>
        event EventHandler<MessageEventArgs> Received;
    }

    /// <summary>
    ///     作者：吴廷有
    ///     时间：2015-10-23
    ///     功能：消息接收者
    /// </summary>
    public interface IBroadcastReceiver : IDisposable
    {
        #region "  方法定义  "

        /// <summary>
        ///     作者：吴廷有
        ///     时间：2015-10-23
        ///     功能：启动监听
        /// </summary>
        void Start();

        #endregion

        /// <summary>
        /// 消息接收事件
        /// </summary>
        event EventHandler<MessageEventArgs> Received;
    }

    /// <summary>
    ///     作者：吴廷有
    ///     时间：2015-10-23
    ///     功能：消息事件参数
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        #region "  属性定义  "

        /// <summary>
        ///     消息正文
        /// </summary>
        public object Message { get; private set; }

        /// <summary>
        ///     通道名
        /// </summary>
        public string ChannelName { get; set; }

        #endregion

        #region "  构造函数  "

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：创建一个消息事件

        /// </summary>
        /// <param name="channelName">通道</param>
        /// <param name="message">消息正文</param>
        public MessageEventArgs(string channelName, object message)
        {
            ChannelName = channelName;
            Message = message;
        }

        #endregion
    }

    /// <summary>
    ///     作者：吴廷有
    ///     时间：2015-10-23
    ///     功能：点对点消息发布器
    /// </summary>
    public interface IMessagePublisher : IDisposable
    {
        #region "  方法定义  "

        /// <summary>
        ///     作者：吴廷有
        ///     时间：2015-10-23
        ///     功能：发送一个消息，将消息发入队列
        /// </summary>
        /// <param name="target"></param>
        /// <param name="timeOut"></param>
        /// <param name="delay">消息延迟投递时间(秒)</param>
        void Put(object target, DateTime? timeOut = null, int? delay = null);

        /// <summary>
        ///     作者：吴廷有
        ///     时间：2015-10-23
        ///     功能：发送一个消息，将消息发入队列(异步)
        /// </summary>
        /// <param name="target"></param>
        /// <param name="timeOut"></param>
        /// <param name="delay">消息延迟投递时间(秒)</param>
        Task PutAsync(object target, DateTime? timeOut = null, int? delay = null);

        #endregion
    }

    /// <summary>
    ///     作者：吴廷有
    ///     时间：2015-10-23
    ///     功能：广播消息发布器
    /// </summary>
    public interface IBroadcastPublisher : IDisposable
    {
        #region "  方法定义  "

        /// <summary>
        ///     作者：吴廷有
        ///     时间：2015-10-23
        ///     功能：发送一个消息，将消息发入队列
        /// </summary>
        /// <param name="target"></param>
        /// <param name="timeOut"></param>
        /// <param name="delay">消息延迟投递时间(秒)</param>
        void Put(object target, DateTime? timeOut = null, int? delay = null);

        /// <summary>
        ///     作者：吴廷有
        ///     时间：2015-10-23
        ///     功能：发送一个消息，将消息发入队列(异步)
        /// </summary>
        /// <param name="target"></param>
        /// <param name="timeOut"></param>
        /// <param name="delay">消息延迟投递时间(秒)</param>
        Task PutAsync(object target, DateTime? timeOut = null, int? delay = null);

        #endregion
    }

    /// <summary>
    ///     作者：吴廷有
    ///     时间：2015-10-23
    ///     功能：消息类
    /// </summary>
    public interface IIdentityMessage
    {
        #region "  属性定义  "

        /// <summary>
        /// 消息ID
        /// </summary>
        string MessageId { get; }


        #endregion
    }

    /// <summary>
    ///     作者：魏桓基
    ///     时间：2019-8-8
    ///     功能：消息类
    /// </summary>
    public abstract class IIdenticMessage
    {
        #region "  属性定义  "

        /// <summary>
        ///     消息ID
        /// </summary>
        public abstract string MessageId { get; }

        /// <summary>
        ///     队列名称
        /// </summary>
        public abstract string QueueName { get; }

        #endregion

    }
}

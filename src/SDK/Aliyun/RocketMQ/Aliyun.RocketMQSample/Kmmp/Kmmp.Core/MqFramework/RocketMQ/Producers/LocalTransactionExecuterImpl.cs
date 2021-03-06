﻿// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="ExtendedLocalTransactionExecuter.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using ons;
using System;

/// <summary>
/// The Producers namespace.
/// </summary>
namespace Kmmp.Core.MqFramework.RocketMQ.Producers
{
    /// <summary>
    /// 扩展的事务消息执行者
    /// Implements the <see cref="ons.LocalTransactionExecuter" />
    /// </summary>
    /// <seealso cref="ons.LocalTransactionExecuter" />
    public class LocalTransactionExecuterImpl : LocalTransactionExecuter
    {
        /// <summary>
        /// 业务逻辑方法
        /// </summary>
        private readonly Func<Message, TransactionStatus> transExecFunc;

        /// <summary>
        /// 异常处理方法
        /// </summary>
        private readonly Action<Message, Exception> exceptionAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalTransactionExecuterImpl" /> class.
        /// </summary>
        /// <param name="transExecFunc">The biz function.</param>
        /// <param name="exceptionAction">The exception action.</param>
        public LocalTransactionExecuterImpl(Func<Message, TransactionStatus> transExecFunc, Action<Message, Exception> exceptionAction = null)
        {
            this.transExecFunc = transExecFunc;
            this.exceptionAction = exceptionAction;
        }

        /// <summary>
        /// Executes the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>TransactionStatus.</returns>
        public override TransactionStatus execute(Message msg)
        {
            // 消息体内容进行crc32, 也可以使用其它的如MD5
            // 消息ID和crc32id主要是用来防止消息重复
            // 如果业务本身是幂等的, 可以忽略, 否则需要利用msgId或crc32Id来做幂等
            // 如果要求消息绝对不重复, 推荐做法是对消息体body使用crc32或md5来防止重复消息.
            return transExecFunc.Invoke(msg);
        }
    }
}
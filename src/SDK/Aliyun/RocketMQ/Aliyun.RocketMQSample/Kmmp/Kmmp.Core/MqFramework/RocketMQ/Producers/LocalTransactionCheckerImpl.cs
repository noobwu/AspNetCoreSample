// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="ExtendedLocalTransactionChecker.cs" company="NoobCore.com">
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
    /// 扩展本地事务检查者
    /// Implements the <see cref="ons.LocalTransactionChecker" />
    /// </summary>
    /// <seealso cref="ons.LocalTransactionChecker" />
    public class LocalTransactionCheckerImpl : LocalTransactionChecker
    {
        /// <summary>
        /// 事务检查方法
        /// </summary>
        private readonly Func<Message, TransactionStatus> checkFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalTransactionCheckerImpl" /> class.
        /// </summary>
        /// <param name="transCheckFunc">The check function.</param>
        public LocalTransactionCheckerImpl(Func<Message, TransactionStatus> transCheckFunc)
        {
            this.checkFunc = transCheckFunc;
        }

        /// <summary>
        /// Checks the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>TransactionStatus.</returns>
        public override TransactionStatus check(Message msg)
        {
            return checkFunc.Invoke(msg);
        }
    }
}
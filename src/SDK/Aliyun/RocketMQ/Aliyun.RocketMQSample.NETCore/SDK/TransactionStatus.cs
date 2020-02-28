// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample.NETCore
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="TransactionStatus.cs" company="Aliyun.RocketMQSample.NETCore">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The ons namespace.
/// </summary>
namespace ons
{

    /// <summary>
    /// Enum TransactionStatus
    /// </summary>
    public enum TransactionStatus
    {
        /// <summary>
        /// The commit transaction
        /// </summary>
        CommitTransaction = 0,
        /// <summary>
        /// The rollback transaction
        /// </summary>
        RollbackTransaction = 1,
        /// <summary>
        /// The unknow
        /// </summary>
        Unknow = 2
    }

}

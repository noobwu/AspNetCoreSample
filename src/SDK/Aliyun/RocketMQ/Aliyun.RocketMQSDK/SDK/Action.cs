// ***********************************************************************
// Assembly         : RocketMQSDK
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="Action.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The ons namespace.
/// </summary>
namespace ons
{

    /// <summary>
    /// Enum Action
    /// </summary>
    public enum Action
    {
        /// <summary>
        /// 成功
        /// </summary>
        CommitMessage,
        /// <summary>
        /// 失败&稍后重试
        /// </summary>
        ReconsumeLater
    }

}

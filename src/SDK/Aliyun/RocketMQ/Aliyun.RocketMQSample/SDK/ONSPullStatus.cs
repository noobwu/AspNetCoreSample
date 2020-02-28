// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="ONSPullStatus.cs" company="NoobCore.com">
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
    /// Enum ONSPullStatus
    /// </summary>
    public enum ONSPullStatus
    {
        /// <summary>
        /// The ons found
        /// </summary>
        ONS_FOUND,
        /// <summary>
        /// The ons no new MSG
        /// </summary>
        ONS_NO_NEW_MSG,
        /// <summary>
        /// The ons no matched MSG
        /// </summary>
        ONS_NO_MATCHED_MSG,
        /// <summary>
        /// The ons offset illegal
        /// </summary>
        ONS_OFFSET_ILLEGAL,
        /// <summary>
        /// The ons broker timeout
        /// </summary>
        ONS_BROKER_TIMEOUT
    }

}

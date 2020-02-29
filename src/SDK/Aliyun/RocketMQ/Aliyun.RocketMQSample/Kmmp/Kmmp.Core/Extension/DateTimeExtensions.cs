// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="DateTimeExtensions.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

/// <summary>
/// The Extension namespace.
/// </summary>
namespace Kmmp.Core.Extension
{
    /// <summary>
    /// DateTime扩展类
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 转换成时间戳
        /// </summary>
        /// <param name="dateTime">当前时间</param>
        /// <returns>System.Int64.</returns>
        public static long ToTimestamp(this DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
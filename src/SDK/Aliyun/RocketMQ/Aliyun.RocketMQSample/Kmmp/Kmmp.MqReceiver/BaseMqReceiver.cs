// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="BaseMqReceiver.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Kmmp.Core.Imps;

/// <summary>
/// The MqReceiver namespace.
/// </summary>
namespace Kmmp.MqReceiver
{
    /// <summary>
    /// Interface BaseMqReceiver
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface BaseMqReceiver<T> where T : IIdentityMessage
    {
        /// <summary>
        /// Executes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Execute(T obj);

    }
}
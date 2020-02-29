// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="SyncVipTypeMqReceiver.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Kmmp.DSync.Data;
using System;

/// <summary>
/// The DSync namespace.
/// </summary>
namespace Kmmp.MqReceiver.DSync
{
    /// <summary>
    /// 同步会员类型
    /// Implements the <see cref="Kmmp.MqReceiver.BaseMqReceiver{Kmmp.DSync.Data.MQ_VipData{Kmmp.DSync.Data.Temp_VipType}}" />
    /// </summary>
    /// <seealso cref="Kmmp.MqReceiver.BaseMqReceiver{Kmmp.DSync.Data.MQ_VipData{Kmmp.DSync.Data.Temp_VipType}}" />
    public class SyncVipTypeMqReceiver : BaseMqReceiver<MQ_VipData<Temp_VipType>>
    {
        /// <summary>
        /// Executes the specified object.
        /// </summary>
        /// <param name="mqData">The object.</param>
        public void Execute(MQ_VipData<Temp_VipType> mqData)
        {
            try
            {
                //Console.WriteLine($"SyncVipTypeMqReceiver,MessageId:{mqData.MessageId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}

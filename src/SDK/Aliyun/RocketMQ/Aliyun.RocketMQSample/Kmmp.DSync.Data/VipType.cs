// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="VipType.cs" company="NoobCore.com">
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
/// The Data namespace.
/// </summary>
namespace Kmmp.DSync.Data
{
    /// <summary>
    /// 会员类别
    /// </summary>
    public class VipType
    {
        /// <summary>
        /// 商户Id
        /// </summary>
        /// <value>The customer identifier.</value>
        public int CustId { get; set; }
        /// <summary>
        /// 类别编号
        /// </summary>
        /// <value>The card type no.</value>
        public string CardTypeNo { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        /// <value>The name of the card type.</value>
        public string CardTypeName { get; set; }
        /// <summary>
        /// Gets or sets the upgrade.
        /// </summary>
        /// <value>The upgrade.</value>
        public decimal Upgrade { get; set; }
        /// <summary>
        /// 门店编号
        /// </summary>
        /// <value>The branch no.</value>
        public string BranchNo { get; set; }
        /// <summary>
        /// 是否支持储值
        /// </summary>
        /// <value><c>true</c> if [supply balance]; otherwise, <c>false</c>.</value>
        public bool SupplyBalance { get; set; }
        /// <summary>
        /// Gets or sets the last update date.
        /// </summary>
        /// <value>The last update date.</value>
        public DateTime LastUpdateDate { get; set; }

        /// <summary>
        /// 是否管控有效期bit 类型  1 控制 0 不控制
        /// </summary>
        /// <value><c>true</c> if [supply validate]; otherwise, <c>false</c>.</value>
        public bool SupplyValidate { get; set; }
        /// <summary>
        /// 是否付费会员
        /// </summary>
        /// <value>The paid flag.</value>
        public string PaidFlag { get; set; }
        /// <summary>
        /// 会费
        /// </summary>
        /// <value>The vip fee.</value>
        public decimal VipFee { get; set; }
        /// <summary>
        /// 有效期（月）
        /// </summary>
        /// <value>The validity.</value>
        public int Validity { get; set; }
        /// <summary>
        /// 赠送金额
        /// </summary>
        /// <value>The present amt.</value>
        public decimal PresentAmt { get; set; }
    }
}

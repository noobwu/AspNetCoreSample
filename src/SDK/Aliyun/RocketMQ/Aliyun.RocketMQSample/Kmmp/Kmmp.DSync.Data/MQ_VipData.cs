// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="MQ_VipData.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Kmmp.Core.Imps;
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
    /// Class MQ_VipData.
    /// Implements the <see cref="Kmmp.Core.Imps.IIdentityMessage" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Kmmp.Core.Imps.IIdentityMessage" />
    public class MQ_VipData<T> : IIdentityMessage
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the custid.
        /// </summary>
        /// <value>The custid.</value>
        public int custid { get; set; }
        /// <summary>
        /// Gets or sets the branch no.
        /// </summary>
        /// <value>The branch no.</value>
        public string branchNo { get; set; }
        /// <summary>
        /// Gets or sets the type of the production.
        /// </summary>
        /// <value>The type of the production.</value>
        public string ProductionType { get; set; }
        /// <summary>
        /// Gets or sets the flow identifier.
        /// </summary>
        /// <value>The flow identifier.</value>
        public string FlowId { get; set; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public List<T> data { get; set; }
        /// <summary>
        /// 消息ID
        /// </summary>
        /// <value>The message identifier.</value>
        public string MessageId
        {
            get { return Name; }
        }
    }
}

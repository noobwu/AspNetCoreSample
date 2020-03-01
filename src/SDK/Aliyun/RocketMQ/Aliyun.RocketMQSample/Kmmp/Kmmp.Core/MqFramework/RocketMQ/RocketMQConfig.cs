// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-03-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-01
// ***********************************************************************
// <copyright file="RocketMQConfig.cs" company="NoobCore.com">
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
/// The RocketMQ namespace.
/// </summary>
namespace Kmmp.Core.MqFramework.RocketMQ
{
    /// <summary>
    /// RocketMQ配置信息
    /// </summary>
    [Serializable]
    public class RocketMQConfig
    {
        /// <summary>
        /// 您在阿里云账号管理控制台中创建的 AccessKeyId，用于身份认证
        /// </summary>
        /// <value>The access key identifier.</value>
        public string AccessKeyId { get; set; }

        /// <summary>
        /// 您在阿里云账号管理控制台中创建的 AccessKeySecret，用于身份认证
        /// </summary>
        /// <value>The access key secret.</value>
        public string AccessKeySecret { get; set; }

        /// <summary>
        /// 设置 TCP 协议接入点，从消息队列 RocketMQ 版控制台的实例详情页面获取
        /// </summary>
        /// <value>The name SRV addr.</value>
        public string NameSrvAddr { get; set; }


        /// <summary>
        /// 您在控制台创建的消息主题，一级消息类型，通过 Topic 对消息进行分类。详情请参见 Topic 与 Tag 最佳实践。
        /// </summary>
        /// <value>The topic.</value>
        public string Topic { get; set; }
        /// <summary>
        /// 一类Producer或Consumer标识，这类 Producer 或 Consumer 通常生产或消费同一类消息，且消息发布或订阅的逻辑一致。
        /// 1. Group ID 既可用于生产者，标识同一类 Producer 实例（Producer ID），又可用于消费者，标识同一类 Consumer 实例（Consumer ID）；
        /// 2. 同一个 Group ID 不可以共用于 TCP 协议和 HTTP 协议，需要分别申请。
        /// 3. 以 “GID_” 或者 “GID-” 开头，只能包含字母、数字、短横线（-）和下划线（_）；
        /// 4. 长度限制在 7-64 字符之间；
        /// 5. Group ID 一旦创建，则无法修改。
        /// </summary>
        /// <value>The group identifier.</value>
        public string GroupId { get; set; }

        /// <summary>
        /// 以 “GID_” 或者 “GID-” 开头
        /// </summary>
        /// <value>The group identifier prefix.</value>
        public string GroupIdPrefix { get; set; } = "GID_";
        /// <summary>
        /// 是否启用异步
        /// </summary>
        /// <value><c>true</c> if this instance is asynchronous; otherwise, <c>false</c>.</value>
        public bool IsAsync { get; set; }
    }
}

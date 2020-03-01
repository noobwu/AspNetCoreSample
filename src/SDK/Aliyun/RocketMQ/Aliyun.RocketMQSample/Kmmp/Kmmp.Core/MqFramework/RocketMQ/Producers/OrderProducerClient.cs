﻿// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="OrderProducerClient.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using ons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Producers namespace.
/// </summary>
namespace Kmmp.Core.MqFramework.RocketMQ.Producers
{
    /// <summary>
    /// 顺序消息生产者
    /// Implements the <see cref="Kmmp.Core.MqFramework.RocketMQ.Producers.ProducerClientBase" />
    /// </summary>
    /// <seealso cref="Kmmp.Core.MqFramework.RocketMQ.Producers.ProducerClientBase" />
    public class OrderProducerClient : ProducerClientBase
    {
        /// <summary>
        /// 有序消息生产者
        /// </summary>
        private OrderProducer producer;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="accessKeyId">您在阿里云账号管理控制台中创建的 AccessKeyId，用于身份认证</param>
        /// <param name="accessKeySecret">您在阿里云账号管理控制台中创建的 AccessKeySecret，用于身份认证</param>
        /// <param name="nameSrvAddr">设置 TCP 协议接入点，从消息队列 RocketMQ 版控制台的实例详情页面获取</param>
        /// <param name="topic">您在控制台创建的消息主题，一级消息类型，通过 Topic 对消息进行分类。详情请参见 Topic 与 Tag 最佳实践。</param>
        /// <param name="groupId">一类Producer或Consumer标识，这类 Producer 或 Consumer 通常生产或消费同一类消息，且消息发布或订阅的逻辑一致。</param>
        public OrderProducerClient(string accessKeyId, string accessKeySecret, string nameSrvAddr, string topic, string groupId)
            : base(accessKeyId, accessKeySecret, nameSrvAddr, topic, groupId)
        {
        }

        /// <summary>
        /// 启动
        /// </summary>
        public override void Start()
        {
            producer = ONSFactory.getInstance().createOrderProducer(this.FactoryProperty);
            producer.start();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public override void Shutdown()
        {
            producer.shutdown();
        }

        /// <summary>
        /// 发送分区顺序消息
        /// </summary>
        /// <param name="shardingKey">分区Key</param>
        /// <param name="body">内容</param>
        /// <param name="tag">消息标签</param>
        /// <param name="key">消息Key</param>
        /// <returns>Message.</returns>
        public Message SendMessage(string shardingKey, object body, string tag = "", string key = "", DateTime? deliveryTime = null)
        {
            var message = ComposeMessage(body, tag, key);

            var sendResult = producer.send(message, shardingKey);
            message.setMsgID(sendResult.getMessageId());
            return message;
        }
    }
}

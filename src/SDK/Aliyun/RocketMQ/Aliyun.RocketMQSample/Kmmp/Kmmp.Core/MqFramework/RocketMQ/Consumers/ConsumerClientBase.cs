﻿using ons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kmmp.Core.MqFramework.RocketMQ.Consumers
{
    /// <summary>
    /// Class ConsumerBase.
    /// </summary>
    public abstract class ConsumerClientBase : RocketMQClientBase
    {
        /// <summary>
        /// 子表达式, Tag的过滤，全部使用*, 多个TagA||TagB
        /// </summary>
        protected string SubExpression { get; private set; }

        /// <summary>
        /// Consumer 实例的消费线程数，默认值：5
        /// </summary>
        protected int ConsumerThreadCount { get; set; } = 5;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="accessKeyId">您在阿里云账号管理控制台中创建的 AccessKeyId，用于身份认证</param>
        /// <param name="accessKeySecret">您在阿里云账号管理控制台中创建的 AccessKeySecret，用于身份认证</param>
        /// <param name="nameSrvAddr">设置 TCP 协议接入点，从消息队列 RocketMQ 版控制台的实例详情页面获取</param>
        /// <param name="topic">您在控制台创建的消息主题，一级消息类型，通过 Topic 对消息进行分类。详情请参见 Topic 与 Tag 最佳实践。</param>
        /// <param name="groupId">一类Producer或Consumer标识，这类 Producer 或 Consumer 通常生产或消费同一类消息，且消息发布或订阅的逻辑一致。</param>
        /// <param name="subExpression">子表达式, Tag的过滤，全部使用*, 多个TagA||TagB</param>
        /// <param name="consumerThreadCount">Consumer 实例的消费线程数，默认值：5</param>
        protected ConsumerClientBase(string accessKeyId, string accessKeySecret, string nameSrvAddr, string topic, string groupId,
                                    string subExpression = "*", int consumerThreadCount = 5)
            : base(accessKeyId, accessKeySecret, nameSrvAddr, topic, groupId)
        {
            this.SubExpression = subExpression;
            this.ConsumerThreadCount = consumerThreadCount;

            this.FactoryProperty.setFactoryProperty(ONSFactoryProperty.ConsumerId, GroupId);
            this.FactoryProperty.setFactoryProperty(ONSFactoryProperty.ConsumeThreadNums, this.ConsumerThreadCount.ToString());
        }
    }
}

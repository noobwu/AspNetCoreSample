// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="PushConsumerClient.cs" company="NoobCore.com">
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
/// The Consumers namespace.
/// </summary>
namespace Kmmp.Core.MqFramework.RocketMQ.Consumers
{
    /// <summary>
    /// 消费者客户端(push模式)
    /// Implements the <see cref="Kmmp.Core.MqFramework.RocketMQ.Consumers.ConsumerClientBase" />
    /// </summary>
    /// <seealso cref="Kmmp.Core.MqFramework.RocketMQ.Consumers.ConsumerClientBase" />
    public class PushConsumerClient : ConsumerClientBase
    {
        /// <summary>
        /// 消费者
        /// </summary>
        protected PushConsumer consumer;

        /// <summary>
        /// 消息监听器
        /// </summary>
        protected MessageListener listener;

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
        public PushConsumerClient(string accessKeyId, string accessKeySecret, string nameSrvAddr, string topic, string groupId, string subExpression = "*", int consumerThreadCount = 5)
            : base(accessKeyId, accessKeySecret, nameSrvAddr, topic, groupId, subExpression, consumerThreadCount)
        {
        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <exception cref="Exception">没有找到消息监控器</exception>
        /// <exception cref="NullReferenceException">consumer为空</exception>
        public override void Start()
        {
            if (this.listener == null)
            {
                throw new Exception("没有找到消息监控器");
            }
            consumer = ONSFactory.getInstance()?.createPushConsumer(this.FactoryProperty);
            if (consumer == null)
            {
                throw new NullReferenceException("consumer为空");
            }
            try
            {
                consumer.subscribe(Topic, SubExpression, listener);
                consumer.start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// 关闭
        /// </summary>
        public override void Shutdown()
        {
            try
            {
                consumer.shutdown();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// 设置消息监听器
        /// </summary>
        /// <param name="listener">The listener.</param>
        public void SetMessageListener(MessageListener listener)
        {
            this.listener = listener;
        }
    }
}

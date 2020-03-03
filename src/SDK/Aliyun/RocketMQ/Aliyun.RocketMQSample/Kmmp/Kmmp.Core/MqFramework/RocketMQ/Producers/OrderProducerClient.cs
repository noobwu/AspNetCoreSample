// ***********************************************************************
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
        /// <param name="logPath">日志文件所在目录</param>
        public OrderProducerClient(string accessKeyId, string accessKeySecret, string nameSrvAddr, string topic, string groupId, string logPath)
            : base(accessKeyId, accessKeySecret, nameSrvAddr, topic, groupId, logPath)
        {
        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <exception cref="NullReferenceException">producer为空</exception>
        public override void Start()
        {
            producer = ONSFactory.getInstance()?.createOrderProducer(this.FactoryProperty);
            if (producer == null)
            {
                throw new NullReferenceException("producer为空");
            }
            producer.start();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <exception cref="NullReferenceException">producer为空</exception>
        public override void Shutdown()
        {
            if (producer == null)
            {
                throw new NullReferenceException("producer为空");
            }
            producer.shutdown();
        }

        /// <summary>
        /// 发送分区顺序消息
        /// https://help.aliyun.com/document_detail/49323.html
        /// </summary>
        /// <param name="body">内容</param>
        /// <param name="shardingKey">分区Key(分区顺序消息中区分不同分区的关键字段，Sharding Key 与普通消息的 key 是完全不同的概念。全局顺序消息，该字段可以设置为任意非空字符串。)</param>
        /// <param name="tag">消息标签</param>
        /// <param name="key">消息Key</param>
        /// <param name="deliveryTime">The delivery time.</param>
        /// <returns>Message.</returns>
        public Message SendMessage(object body, string shardingKey = "shardingKey", string tag = "", string key = "", DateTime? deliveryTime = null)
        {
            if (producer == null)
            {
                throw new NullReferenceException("producer为空");
            }
            var message = ComposeMessage(body, tag, key);
            var sendResult = producer.send(message, shardingKey);
            message.setMsgID(sendResult.getMessageId());
            Console.WriteLine($"SendOrderMessage at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},Topic:{Topic},GroupId:{GroupId},tag:{tag},key:{key},MsgID:{message.getMsgID()}");
            return message;
        }
    }
}

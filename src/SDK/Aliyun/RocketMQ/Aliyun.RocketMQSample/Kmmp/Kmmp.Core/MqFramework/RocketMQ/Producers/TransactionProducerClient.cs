// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="TransactionProducerClient.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Kmmp.Core.Extension;
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
    /// 事务消息生产者
    /// Implements the <see cref="Kmmp.Core.MqFramework.RocketMQ.Producers.ProducerClientBase" />
    /// </summary>
    /// <seealso cref="Kmmp.Core.MqFramework.RocketMQ.Producers.ProducerClientBase" />
    public class TransactionProducerClient : ProducerClientBase
    {
        /// <summary>
        /// 消息生产者
        /// </summary>
        private TransactionProducer producer;
        private Func<Message, TransactionStatus> transCheckFunc;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="accessKeyId">您在阿里云账号管理控制台中创建的 AccessKeyId，用于身份认证</param>
        /// <param name="accessKeySecret">您在阿里云账号管理控制台中创建的 AccessKeySecret，用于身份认证</param>
        /// <param name="nameSrvAddr">设置 TCP 协议接入点，从消息队列 RocketMQ 版控制台的实例详情页面获取</param>
        /// <param name="topic">您在控制台创建的消息主题，一级消息类型，通过 Topic 对消息进行分类。详情请参见 Topic 与 Tag 最佳实践。</param>
        /// <param name="groupId">一类Producer或Consumer标识，这类 Producer 或 Consumer 通常生产或消费同一类消息，且消息发布或订阅的逻辑一致。</param>
        /// <param name="logPath">The log path.</param>
        /// <param name="transCheckFunc">The check function.</param>
        public TransactionProducerClient(string accessKeyId, string accessKeySecret, string nameSrvAddr, string topic, string groupId, string logPath, Func<Message, TransactionStatus> transCheckFunc)
            : base(accessKeyId, accessKeySecret, nameSrvAddr, topic, groupId, logPath)
        {
            this.transCheckFunc = transCheckFunc;
        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <exception cref="System.NullReferenceException">producer为空</exception>
        public override void Start()
        {
            producer = ONSFactory.getInstance()?.createTransactionProducer(this.FactoryProperty, new LocalTransactionCheckerImpl(transCheckFunc));
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
        /// 发送普通消息
        /// </summary>
        /// <param name="body">内容</param>
        /// <param name="transExecFunc">业务方法</param>
        /// <param name="tag">消息标签</param>
        /// <param name="key">消息Key</param>
        /// <param name="deliveryTime">定时/延时时间</param>
        /// <returns>Message.</returns>
        /// <exception cref="System.NullReferenceException">producer为空</exception>
        public Message SendMessage(object body, Func<Message, TransactionStatus> transExecFunc, string tag = "", string key = "", DateTime? deliveryTime = null)
        {
            if (producer == null)
            {
                throw new NullReferenceException("producer为空");
            }
            var message = ComposeMessage(body, tag, key);
            if (deliveryTime.HasValue)
            {
                message.setStartDeliverTime(deliveryTime.Value.ToTimestamp());
            }
            var result = producer.send(message, new LocalTransactionExecuterImpl(transExecFunc));
            message.setMsgID(result.getMessageId());
            Console.WriteLine($"SendTransactionMessage at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},Topic:{Topic},GroupId:{GroupId},tag:{tag},key:{key},MsgID:{message.getMsgID()}");
            return message;
        }
    }
}

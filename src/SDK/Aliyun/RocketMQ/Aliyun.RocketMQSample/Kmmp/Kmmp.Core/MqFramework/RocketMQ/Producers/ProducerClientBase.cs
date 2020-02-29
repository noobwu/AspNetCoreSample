using ons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kmmp.Core.MqFramework.RocketMQ.Producers
{
    /// <summary>
    /// 生产者
    /// </summary>
    public abstract class ProducerClientBase : RocketMQClientBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="accessKeyId">您在阿里云账号管理控制台中创建的 AccessKeyId，用于身份认证</param>
        /// <param name="accessKeySecret">您在阿里云账号管理控制台中创建的 AccessKeySecret，用于身份认证</param>
        /// <param name="nameSrvAddr">设置 TCP 协议接入点，从消息队列 RocketMQ 版控制台的实例详情页面获取</param>
        /// <param name="topic">您在控制台创建的消息主题，一级消息类型，通过 Topic 对消息进行分类。详情请参见 Topic 与 Tag 最佳实践。</param>
        /// <param name="groupId">一类Producer或Consumer标识，这类 Producer 或 Consumer 通常生产或消费同一类消息，且消息发布或订阅的逻辑一致。</param>
        protected ProducerClientBase(string accessKeyId, string accessKeySecret, string nameSrvAddr, string topic, string groupId)
            : base(accessKeyId, accessKeySecret, nameSrvAddr, topic, groupId)
        {
            this.FactoryProperty.setFactoryProperty(ONSFactoryProperty.ProducerId, GroupId);
        }

        /// <summary>
        /// 组合消息
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="tag">标签</param>
        /// <param name="key">消息Key</param>
        /// <returns></returns>
        protected Message ComposeMessage(string content, string tag = "", string key = "")
        {
            var message = new Message(Topic, tag, string.Empty);

            var bodyData = Encoding.UTF8.GetBytes(content);
            message.setBody(bodyData, bodyData.Length);

            message.setKey(key);

            return message;
        }
    }
}

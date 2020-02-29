// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="RocketMQClientBase.cs" company="NoobCore.com">
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
/// The RocketMQ namespace.
/// </summary>
namespace Kmmp.Core.MqFramework.RocketMQ
{
    /// <summary>
    /// Class RocketMQBase.
    /// </summary>
    public abstract class RocketMQClientBase
    {
        /// <summary>
        /// 您在阿里云账号管理控制台中创建的 AccessKeyId，用于身份认证
        /// </summary>
        /// <value>The access key identifier.</value>
        protected string AccessKeyId { get; private set; }

        /// <summary>
        /// 您在阿里云账号管理控制台中创建的 AccessKeySecret，用于身份认证
        /// </summary>
        /// <value>The access key secret.</value>
        protected string AccessKeySecret { get; private set; }

        /// <summary>
        /// 设置 TCP 协议接入点，从消息队列 RocketMQ 版控制台的实例详情页面获取
        /// </summary>
        /// <value>The name SRV addr.</value>
        protected string NameSrvAddr { get; private set; }

        /// <summary>
        /// 用户渠道，默认值为：ALIYUN，聚石塔用户为：CLOUD
        /// </summary>
        protected string OnsChannel = "ALIYUN";

        /// <summary>
        /// 您在控制台创建的消息主题，一级消息类型，通过 Topic 对消息进行分类。详情请参见 Topic 与 Tag 最佳实践。
        /// </summary>
        /// <value>The topic.</value>
        protected string Topic { get; private set; }
        /// <summary>
        /// 一类Producer或Consumer标识，这类 Producer 或 Consumer 通常生产或消费同一类消息，且消息发布或订阅的逻辑一致。
        /// </summary>
        /// <value>The group identifier.</value>
        protected string GroupId { get; private set; }
        /// <summary>
        /// 工厂属性
        /// </summary>
        /// <value>The factory property.</value>
        protected ONSFactoryProperty FactoryProperty { get; private set; }
        /// <summary>
        /// The log path
        /// </summary>
        private string logPath = AppDomain.CurrentDomain.BaseDirectory + @"\Logs";

        /// <summary>
        /// 日志保存路径
        /// </summary>
        /// <value>The log path.</value>
        protected string LogPath
        {
            get
            {
                return logPath;
            }
            set
            {
                logPath = value;
                FactoryProperty.setFactoryProperty(ONSFactoryProperty.LogPath, logPath);
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="accessKeyId">您在阿里云账号管理控制台中创建的 AccessKeyId，用于身份认证</param>
        /// <param name="accessKeySecret">您在阿里云账号管理控制台中创建的 AccessKeySecret，用于身份认证</param>
        /// <param name="nameSrvAddr">设置 TCP 协议接入点，从消息队列 RocketMQ 版控制台的实例详情页面获取</param>
        /// <param name="topic">您在控制台创建的消息主题，一级消息类型，通过 Topic 对消息进行分类。详情请参见 Topic 与 Tag 最佳实践。</param>
        /// <param name="groupId">一类Producer或Consumer标识，这类 Producer 或 Consumer 通常生产或消费同一类消息，且消息发布或订阅的逻辑一致。</param>
        protected RocketMQClientBase(string accessKeyId, string accessKeySecret, string nameSrvAddr, string topic, string groupId)
        {
            this.AccessKeyId = accessKeyId;
            this.AccessKeySecret = accessKeySecret;
            this.NameSrvAddr = nameSrvAddr;
            this.Topic = topic;
            this.GroupId = groupId;
            this.FactoryProperty = this.CreateDefaultFactoryProperty();
        }
        /// <summary>
        /// 创建默认的工厂属性
        /// </summary>
        /// <returns>ONSFactoryProperty.</returns>
        private ONSFactoryProperty CreateDefaultFactoryProperty()
        {
            ONSFactoryProperty factoryProperty = new ONSFactoryProperty();
            factoryProperty.setFactoryProperty(ONSFactoryProperty.AccessKey, AccessKeyId);
            factoryProperty.setFactoryProperty(ONSFactoryProperty.SecretKey, AccessKeySecret);
            factoryProperty.setFactoryProperty(ONSFactoryProperty.PublishTopics, Topic);
            factoryProperty.setFactoryProperty(ONSFactoryProperty.NAMESRV_ADDR, NameSrvAddr);
            factoryProperty.setFactoryProperty(ONSFactoryProperty.LogPath, LogPath);
            return factoryProperty;
        }

        /// <summary>
        /// 启动
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// 关闭
        /// </summary>
        public abstract void Shutdown();
    }
}

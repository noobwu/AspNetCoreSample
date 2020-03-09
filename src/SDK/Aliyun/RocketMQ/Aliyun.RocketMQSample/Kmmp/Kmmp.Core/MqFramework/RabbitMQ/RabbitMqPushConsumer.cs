// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-03-09
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-09
// ***********************************************************************
// <copyright file="RabbitMqPushConsumer.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The RabbitMQ namespace.
/// </summary>
namespace Kmmp.Core.MqFramework.RabbitMQ
{
    /// <summary>
    /// Class RabbitMqPushConsumer.
    /// Implements the <see cref="Kmmp.Core.MqFramework.RabbitMQ.RabbitMqClient" />
    /// </summary>
    /// <seealso cref="Kmmp.Core.MqFramework.RabbitMQ.RabbitMqClient" />
    public class RabbitMqPushConsumer : RabbitMqClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RabbitMqQueueClient" /> class.
        /// </summary>
        /// <param name="msgFactory">The MSG factory.</param>
        public RabbitMqPushConsumer(RabbitMqMessageFactory msgFactory)
       : base(msgFactory)
        {

        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <exception cref="Exception">没有找到消息监控器</exception>
        /// <exception cref="NullReferenceException">consumer为空</exception>
        public void Start(string queueName)
        {
            try
            {
                if (!Queues.Contains(queueName))
                {
                    Channel.RegisterQueueByName(queueName);
                    Queues = new HashSet<string>(Queues) { queueName };
                }
                CreateConsumer(queueName);
            }
            catch (OperationInterruptedException ex)
            {
                if (ex.Is404())
                {
                    Channel.RegisterQueueByName(queueName);
                    CreateConsumer(queueName);
                }
                throw;
            }

        }
        /// <summary>
        /// Creates the consumer.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        private void CreateConsumer(string queueName)
        {
            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += OnReceived;
            Channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
        }
        /// <summary>
        /// 作者：carl.wu
        /// 时间：2020-02-01
        /// 功能：收到消息事件
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="args">The <see cref="MessageEventArgs"/> instance containing the event data.</param>
        private void OnReceived(object sender, BasicDeliverEventArgs args)
        {
            // 定义一个局部变量，已防止最后一个订阅者刚好在检查null后取消订阅
            EventHandler<BasicDeliverEventArgs> handler = Received;
            // 如果没有 订阅者（观察者）， 委托对象将为null
            if (handler != null)
            {
                try
                {
                    //var body = args.Body;
                    //var message = Encoding.UTF8.GetString(body);
                    handler(this, args);
                    Channel.BasicAck(deliveryTag: args.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {

                }
            }
            else
            {
                Console.WriteLine($"handler is null");
            }
        }
        /// <summary>
        /// 接收消息事件
        /// </summary>
        public event EventHandler<BasicDeliverEventArgs> Received;
    }
}

// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-03-08
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-08
// ***********************************************************************
// <copyright file="RabbitMqProducer.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using RabbitMQ.Client;
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
    /// Class RabbitMqProducer.
    /// </summary>
    public class RabbitMqProducer
    {
        /// <summary>
        /// The MSG factory
        /// </summary>
        protected readonly RabbitMqMessageFactory msgFactory;
        /// <summary>
        /// Gets or sets the retry count.
        /// </summary>
        /// <value>The retry count.</value>
        public int RetryCount { get; set; }

        //http://www.rabbitmq.com/blog/2012/04/25/rabbitmq-performance-measurements-part-2/
        //http://www.rabbitmq.com/amqp-0-9-1-reference.html
        /// <summary>
        /// Gets or sets the prefetch count.
        /// </summary>
        /// <value>The prefetch count.</value>
        public ushort PrefetchCount { get; set; } = 20;
        /// <summary>
        /// The connection
        /// </summary>
        private IConnection connection;
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>The connection.</value>
        public IConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = msgFactory.ConnectionFactory.CreateConnection();
                }
                return connection;
            }
        }

        /// <summary>
        /// The channel
        /// </summary>
        private IModel channel;
        /// <summary>
        /// Gets the channel.
        /// </summary>
        /// <value>The channel.</value>
        public IModel Channel
        {
            get
            {
                if (channel == null || !channel.IsOpen)
                {
                    channel = Connection.OpenChannel();
                    //prefetch size is no supported by RabbitMQ
                    //http://www.rabbitmq.com/specification.html#method-status-basic.qos
                    channel.BasicQos(prefetchSize: 0, prefetchCount: PrefetchCount, global: false);
                }
                return channel;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RabbitMqProducer"/> class.
        /// </summary>
        /// <param name="msgFactory">The MSG factory.</param>
        public RabbitMqProducer(RabbitMqMessageFactory msgFactory)
        {
            this.msgFactory = msgFactory;
        }
    }
}

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
using Kmmp.Core.Extension;
using Kmmp.Core.Helper;
using RabbitMQ.Client;
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
    /// Class RabbitMqProducer.
    /// </summary>
    public class RabbitMqProducer : IDisposable
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
        /// <summary>
        /// Publishes the specified queue name.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <param name="body">The body.</param>
        public virtual void Publish(string queueName, object body)
        {
            Publish(queueName, body, QueueNames.Exchange);
        }
        /// <summary>
        /// Publishes the specified queue name.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <param name="body">The body.</param>
        /// <param name="exchange">The exchange.</param>
        public virtual void Publish(string queueName, object body, string exchange)
        {
            var props = Channel.CreateBasicProperties();
            props.Persistent = true;
            props.MessageId = Guid.NewGuid().ToString("N");
            props.Timestamp = new AmqpTimestamp(DateTime.Now.ToTimestamp());
            props.Priority = 0;
            props.ContentType = "application/json";
            if (body != null)
            {
                props.Type = body.GetType().Name;
            }
            string strBody = JsonHelper.JsonConvertSerialize(body);
            var messageBytes = Encoding.UTF8.GetBytes(strBody);

            PublishMessage(exchange ?? QueueNames.Exchange,
                routingKey: queueName,
                basicProperties: props, body: messageBytes);

        }
        /// <summary>
        /// The queues
        /// </summary>
        static HashSet<string> Queues = new HashSet<string>();
        /// <summary>
        /// Publishes the message.
        /// </summary>
        /// <param name="exchange">The exchange.</param>
        /// <param name="routingKey">The routing key.</param>
        /// <param name="basicProperties">The basic properties.</param>
        /// <param name="body">The body.</param>
        public virtual void PublishMessage(string exchange, string routingKey, IBasicProperties basicProperties, byte[] body)
        {
            try
            {
                // In case of server named queues (client declared queue with channel.declare()), assume queue already exists
                //(redeclaration would result in error anyway since queue was marked as exclusive) and publish to default exchange
                if (routingKey.IsServerNamedQueue())
                {
                    Channel.BasicPublish("", routingKey, basicProperties, body);
                }
                else
                {
                    if (!Queues.Contains(routingKey))
                    {
                        Channel.RegisterQueueByName(routingKey);
                        Queues = new HashSet<string>(Queues) { routingKey };
                    }

                    Channel.BasicPublish(exchange, routingKey, basicProperties, body);
                }

            }
            catch (OperationInterruptedException ex)
            {
                if (ex.Is404())
                {
                    // In case of server named queues (client declared queue with channel.declare()), assume queue already exists (redeclaration would result in error anyway since queue was marked as exclusive) and publish to default exchange
                    if (routingKey.IsServerNamedQueue())
                    {
                        Channel.BasicPublish("", routingKey, basicProperties, body);
                    }
                    else
                    {
                        Channel.RegisterExchangeByName(exchange);

                        Channel.BasicPublish(exchange, routingKey, basicProperties, body);
                    }
                }
                throw;
            }
        }
        /// <summary>
        /// Notifies the specified queue name.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <param name="body">The body.</param>
        public virtual void Notify(string queueName, object body)
        {
            var json = body.ToJson();
            var messageBytes = json.ToUtf8Bytes();

            PublishMessage(QueueNames.ExchangeTopic,
                routingKey: queueName,
                basicProperties: null, body: messageBytes);
        }
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <param name="noAck">if set to <c>true</c> [no ack].</param>
        /// <returns>BasicGetResult.</returns>
        public virtual BasicGetResult GetMessage(string queueName, bool noAck)
        {
            try
            {
                if (!Queues.Contains(queueName))
                {
                    Channel.RegisterQueueByName(queueName);
                    Queues = new HashSet<string>(Queues) { queueName };
                }

                var basicMsg = Channel.BasicGet(queueName, autoAck: noAck);

                return basicMsg;
            }
            catch (OperationInterruptedException ex)
            {
                if (ex.Is404())
                {
                    Channel.RegisterQueueByName(queueName);

                    return Channel.BasicGet(queueName, autoAck: noAck);
                }
                throw;
            }
        }
        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public virtual void Dispose()
        {
            if (channel != null)
            {
                try
                {
                    channel.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                channel = null;
            }
            if (connection != null)
            {
                try
                {
                    connection.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                connection = null;
            }
        }
    }
}

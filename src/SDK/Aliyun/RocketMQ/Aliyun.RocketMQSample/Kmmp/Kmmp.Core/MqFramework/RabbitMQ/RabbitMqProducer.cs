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
    public class RabbitMqProducer : RabbitMqClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RabbitMqProducer"/> class.
        /// </summary>
        /// <param name="msgFactory">The MSG factory.</param>
        public RabbitMqProducer(RabbitMqMessageFactory msgFactory) : base(msgFactory)
        {
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

            string exchangeName = exchange ?? QueueNames.Exchange;

            Console.WriteLine($"Rabbit Publish at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")},exchange:{exchangeName},routingKey:{queueName}");
            PublishMessage(exchangeName,
                routingKey: queueName,
                basicProperties: props, body: messageBytes);

        }

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

    }
}

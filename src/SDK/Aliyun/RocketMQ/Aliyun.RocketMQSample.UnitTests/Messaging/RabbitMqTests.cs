// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample.UnitTests
// Author           : Administrator
// Created          : 2020-03-08
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-08
// ***********************************************************************
// <copyright file="RabbitMqTests.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Kmmp.Core.MqFramework;
using Kmmp.Core.MqFramework.RabbitMQ;
using NUnit.Framework;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kmmp.Core.Extension;
using System.Threading;

/// <summary>
/// The Messaging namespace.
/// </summary>
namespace Aliyun.RocketMQSample.UnitTests.Messaging
{
    /// <summary>
    /// Class HelloRabbit.
    /// </summary>
    public class HelloRabbit
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
    }
    /// <summary>
    /// Class RabbitMqTests.
    /// </summary>
    public class RabbitMqTests
    {
        /// <summary>
        /// The mq factory
        /// </summary>
        private readonly ConnectionFactory mqFactory = new ConnectionFactory
        {
            //HostName = Environment.GetEnvironmentVariable("CI_RABBITMQ") ?? "localhost"
            HostName = "localhost"
        };
        /// <summary>
        /// The exchange
        /// </summary>
        private const string Exchange = "mq:tests";
        /// <summary>
        /// The exchange DLQ
        /// </summary>
        private const string ExchangeDlq = "mq:tests.dlq";
        /// <summary>
        /// The exchange topic
        /// </summary>
        private const string ExchangeTopic = "mq:tests.topic";
        /// <summary>
        /// The exchange fanout
        /// </summary>
        private const string ExchangeFanout = "mq:tests.fanout";
        /// <summary>
        /// Tests the fixture set up.
        /// </summary>

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            using (IConnection connection = mqFactory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.RegisterDirectExchange(Exchange);
                channel.RegisterDlqExchange(ExchangeDlq);
                channel.RegisterTopicExchange(ExchangeTopic);

                RegisterQueue(channel, QueueNames<HelloRabbit>.In);
                RegisterQueue(channel, QueueNames<HelloRabbit>.Priority);
                RegisterDlq(channel, QueueNames<HelloRabbit>.Dlq);
                RegisterTopic(channel, QueueNames<HelloRabbit>.Out);
                RegisterQueue(channel, QueueNames<HelloRabbit>.In, exchange: ExchangeTopic);

                channel.PurgeQueue<HelloRabbit>();
            }
        }

        /// <summary>
        /// Registers the queue.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="queueName">Name of the queue.</param>
        /// <param name="exchange">The exchange.</param>
        public static void RegisterQueue(IModel channel, string queueName, string exchange = Exchange)
        {
            var args = new Dictionary<string, object> {
                {"x-dead-letter-exchange", ExchangeDlq },
                {"x-dead-letter-routing-key", queueName.Replace(".inq",".dlq").Replace(".priorityq",".dlq") },
            };
            channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: args);
            channel.QueueBind(queueName, exchange, routingKey: queueName);
        }

        /// <summary>
        /// Registers the topic.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="queueName">Name of the queue.</param>
        public static void RegisterTopic(IModel channel, string queueName)
        {
            channel.QueueDeclare(queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.QueueBind(queueName, ExchangeTopic, routingKey: queueName);
        }

        /// <summary>
        /// Registers the DLQ.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="queueName">Name of the queue.</param>
        public static void RegisterDlq(IModel channel, string queueName)
        {
            channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            channel.QueueBind(queueName, ExchangeDlq, routingKey: queueName);
        }

        /// <summary>
        /// Exchanges the delete.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="exchange">The exchange.</param>
        public void ExchangeDelete(IModel channel, string exchange)
        {
            try
            {
                channel.ExchangeDelete(exchange);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ExchangeDelete(): {ex.Message}");
            }
        }

        /// <summary>
        /// Defines the test method Can_publish_messages_to_RabbitMQ.
        /// </summary>
        [Test]
        public void Can_publish_messages_to_RabbitMQ()
        {
            using (IConnection connection = mqFactory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                5.Times(i =>
                {
                    byte[] payload = new HelloRabbit { Name = $"World! #{i}" }.ToJson().ToUtf8Bytes();
                    var props = channel.CreateBasicProperties();
                    props.Persistent = true;

                    channel.BasicPublish(exchange: Exchange,
                        routingKey: QueueNames<HelloRabbit>.In, basicProperties: props, body: payload);

                    Console.WriteLine("Sent Message " + i);
                    Thread.Sleep(1000);
                });
            }
        }
        /// <summary>
        /// Defines the test method Can_consume_messages_from_RabbitMQ_with_BasicGet.
        /// </summary>
        [Test]
        public void Can_consume_messages_from_RabbitMQ_with_BasicGet()
        {
            using (IConnection connection = mqFactory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                PublishHelloRabbit(channel);

                while (true)
                {
                    var basicGetMsg = channel.BasicGet(QueueNames<HelloRabbit>.In, autoAck: false);

                    if (basicGetMsg == null)
                    {
                        Console.WriteLine("End of the road...");
                        return;
                    }

                    var msg = basicGetMsg.Body.FromUtf8Bytes().FromJson<HelloRabbit>();

                    Thread.Sleep(1000);

                    channel.BasicAck(basicGetMsg.DeliveryTag, multiple: false);
                }
            }
        }
        /// <summary>
        /// Publishes the hello rabbit.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="text">The text.</param>
        private static void PublishHelloRabbit(IModel channel, string text = "World!")
        {
            byte[] payload = new HelloRabbit { Name = text }.ToJson().ToUtf8Bytes();
            var props = channel.CreateBasicProperties();
            props.Persistent = true;
            channel.BasicPublish(Exchange, QueueNames<HelloRabbit>.In, props, payload);
        }

    }
}

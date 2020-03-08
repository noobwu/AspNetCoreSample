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
using System.IO;
using RabbitMQ.Client.Exceptions;

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
        /// Defines the test method Publishing_message_with_routingKey_sends_only_to_registered_queue.
        /// </summary>
        [Test]
        public void Publishing_message_with_routingKey_sends_only_to_registered_queue()
        {
            using (IConnection connection = mqFactory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                PublishHelloRabbit(channel);

                var basicGetMsg = channel.BasicGet(QueueNames<HelloRabbit>.In, autoAck: true);
                Assert.That(basicGetMsg, Is.Not.Null);

                basicGetMsg = channel.BasicGet(QueueNames<HelloRabbit>.Priority, autoAck: true);
                Assert.That(basicGetMsg, Is.Null);
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
        /// <summary>
        /// Defines the test method Publishing_message_to_fanout_exchange_publishes_to_all_queues.
        /// </summary>
        [Test]
        public void Publishing_message_to_fanout_exchange_publishes_to_all_queues()
        {
            using (IConnection connection = mqFactory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.RegisterFanoutExchange(ExchangeFanout);

                RegisterQueue(channel, QueueNames<HelloRabbit>.In, exchange: ExchangeFanout);
                RegisterQueue(channel, QueueNames<HelloRabbit>.Priority, exchange: ExchangeFanout);

                byte[] payload = new HelloRabbit { Name = "World!" }.ToJson().ToUtf8Bytes();
                var props = channel.CreateBasicProperties();
                props.Persistent = true;

                channel.BasicPublish(ExchangeFanout, QueueNames<HelloRabbit>.In, props, payload);

                var basicGetMsg = channel.BasicGet(QueueNames<HelloRabbit>.In, autoAck: true);
                Assert.That(basicGetMsg, Is.Not.Null);

                basicGetMsg = channel.BasicGet(QueueNames<HelloRabbit>.Priority, autoAck: true);
                Assert.That(basicGetMsg, Is.Not.Null);
            }
        }

        /// <summary>
        /// Defines the test method Does_publish_to_dead_letter_exchange.
        /// </summary>
        [Test]
        public void Does_publish_to_dead_letter_exchange()
        {
            using (IConnection connection = mqFactory.CreateConnection())
            using (IModel channel = connection.OpenChannel())
            {
                PublishHelloRabbit(channel);

                var basicGetMsg = channel.BasicGet(QueueNames<HelloRabbit>.In, autoAck: true);
                var dlqBasicMsg = channel.BasicGet(QueueNames<HelloRabbit>.Dlq, autoAck: true);
                Assert.That(basicGetMsg, Is.Not.Null);
                Assert.That(dlqBasicMsg, Is.Null);

                PublishHelloRabbit(channel);

                basicGetMsg = channel.BasicGet(QueueNames<HelloRabbit>.In, autoAck: false);
                Thread.Sleep(500);
                dlqBasicMsg = channel.BasicGet(QueueNames<HelloRabbit>.Dlq, autoAck: false);
                Assert.That(basicGetMsg, Is.Not.Null);
                Assert.That(dlqBasicMsg, Is.Null);

                channel.BasicNack(basicGetMsg.DeliveryTag, multiple: false, requeue: false);

                Thread.Sleep(500);
                dlqBasicMsg = channel.BasicGet(QueueNames<HelloRabbit>.Dlq, autoAck: true);
                Assert.That(dlqBasicMsg, Is.Not.Null);
            }
        }
        /// <summary>
        /// Defines the test method Can_interrupt_BasicConsumer_in_bgthread_by_closing_channel.
        /// </summary>
        [Test]
        public void Can_interrupt_BasicConsumer_in_bgthread_by_closing_channel()
        {
            using (IConnection connection = mqFactory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                string recvMsg = null;
                EndOfStreamException lastEx = null;

                var bgThread = new Thread(() =>
                {
                    try
                    {
                        var consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume(QueueNames<HelloRabbit>.In, autoAck: false, consumer: consumer);

                        while (true)
                        {
                            try
                            {
                                var e = consumer.Queue.Dequeue();
                                recvMsg = e.Body.FromUtf8Bytes();
                            }
                            catch (EndOfStreamException ex)
                            {
                                // The consumer was cancelled, the model closed, or the
                                // connection went away.
                                "EndOfStreamException in bgthread: {0}".Print(ex.Message);
                                lastEx = ex;
                                return;
                            }
                            catch (Exception ex)
                            {
                                Assert.Fail("Unexpected exception in bgthread: " + ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        "Exception in bgthread: {0}: {1}".Print(ex.GetType().Name, ex.Message);
                    }
                })
                {
                    Name = "Closing Channel Test",
                    IsBackground = true,
                };
                bgThread.Start();

                PublishHelloRabbit(channel);
                Thread.Sleep(100);

                //closing either throws EndOfStreamException in bgthread
                channel.Close();
                //connection.Close();

                Thread.Sleep(2000);

                Assert.That(recvMsg, Is.Not.Null);
                Assert.That(lastEx, Is.Not.Null);

                "EOF...".Print();
            }
        }
        /// <summary>
        /// Defines the test method Can_consume_messages_with_BasicConsumer.
        /// </summary>
        [Test]
        public void Can_consume_messages_with_BasicConsumer()
        {
            using (IConnection connection = mqFactory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                OperationInterruptedException lastEx = null;

                channel.Close();

                ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        PublishHelloRabbit(channel);
                    }
                    catch (Exception ex)
                    {
                        lastEx = ex as OperationInterruptedException;
                        "Caught {0}: {1}".Print(ex.GetType().Name, ex);
                    }
                });

                Thread.Sleep(1000);

                Assert.That(lastEx, Is.Not.Null);

                "EOF...".Print();
            }
        }
        /// <summary>
        /// Defines the test method Delete_all_queues_and_exchanges.
        /// </summary>
        [Test]
        public void Delete_all_queues_and_exchanges()
        {
            var exchangeNames = new[] {
                Exchange,
                ExchangeDlq,
                ExchangeTopic,
                ExchangeFanout,
                QueueNames.Exchange,
                QueueNames.ExchangeDlq,
                QueueNames.ExchangeTopic,
            };

            using (IConnection connection = mqFactory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                foreach (var item in exchangeNames)
                {
                    channel.ExchangeDelete(item);
                }

                channel.DeleteQueue<AlwaysThrows>();
                channel.DeleteQueue<Hello>();
                channel.DeleteQueue<HelloRabbit>();
                channel.DeleteQueue<HelloResponse>();
                channel.DeleteQueue<Reverse>();
                channel.DeleteQueue<Rot13>();
                channel.DeleteQueue<Wait>();
            }
        }
        //Dummy messages to delete Queue's created else where.
        /// <summary>
        /// Class AlwaysThrows.
        /// </summary>
        public class AlwaysThrows { }
        /// <summary>
        /// Class Hello.
        /// </summary>
        public class Hello { }
        /// <summary>
        /// Class HelloResponse.
        /// </summary>
        public class HelloResponse { }
        /// <summary>
        /// Class Reverse.
        /// </summary>
        public class Reverse { }
        /// <summary>
        /// Class Rot13.
        /// </summary>
        public class Rot13 { }
        /// <summary>
        /// Class Wait.
        /// </summary>
        public class Wait { }
    }
}

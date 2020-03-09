using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kmmp.Core.MqFramework.RabbitMQ
{
    /// <summary>
    /// Class RabbitMqClient.
    /// </summary>
    public class RabbitMqClient : IDisposable
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
        public RabbitMqClient(RabbitMqMessageFactory msgFactory)
        {
            this.msgFactory = msgFactory;
        }
        /// <summary>
        /// The queues
        /// </summary>
        protected static HashSet<string> Queues = new HashSet<string>();
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
        /// 执行与释放或重置非托管资源关联的应用程序定义的任务。
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

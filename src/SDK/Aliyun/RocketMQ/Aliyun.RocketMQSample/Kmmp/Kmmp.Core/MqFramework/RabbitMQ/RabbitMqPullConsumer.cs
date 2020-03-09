using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kmmp.Core.MqFramework.RabbitMQ
{
    /// <summary>
    /// Class RabbitMqQueueClient.
    /// </summary>
    public class RabbitMqPullConsumer : RabbitMqClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RabbitMqQueueClient"/> class.
        /// </summary>
        /// <param name="msgFactory">The MSG factory.</param>
        public RabbitMqPullConsumer(RabbitMqMessageFactory msgFactory)
       : base(msgFactory) { }
        /// <summary>
        /// Gets the specified queue name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queueName">Name of the queue.</param>
        /// <param name="timeOut">The time out.</param>
        /// <returns>IMessage&lt;T&gt;.</returns>
        public virtual T Get<T>(string queueName, TimeSpan? timeOut = null)
        {
            var now = DateTime.UtcNow;

            while (timeOut == null || (DateTime.UtcNow - now) < timeOut.Value)
            {
                var basicMsg = GetMessage(queueName, noAck: false);
                if (basicMsg != null)
                {
                    return basicMsg.ToMessageBody<T>();
                }
                Thread.Sleep(100);
            }
            return default(T);
        }
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queueName">Name of the queue.</param>
        /// <returns>IMessage&lt;T&gt;.</returns>
        public virtual T GetAsync<T>(string queueName)
        {
            var basicMsg = GetMessage(queueName, noAck: false);
            return basicMsg.ToMessageBody<T>();
        }

        /// <summary>
        /// deliveryTag
        /// </summary>
        /// <param name="String">The string.</param>
        public virtual void Ack(string tag)
        {
            var deliveryTag = ulong.Parse(tag);
            Channel.BasicAck(deliveryTag, multiple: false);
        }
        /// <summary>
        /// Gets the name of the temporary queue.
        /// </summary>
        /// <returns>System.String.</returns>
        public virtual string GetTempQueueName()
        {
            var anonMq = Channel.QueueDeclare(
                queue: QueueNames.GetTempQueueName(),
                durable: false,
                exclusive: true,
                autoDelete: true,
                arguments: null);

            return anonMq.QueueName;
        }
    }
}

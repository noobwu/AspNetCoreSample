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
    public class RabbitMqQueueClient : RabbitMqProducer
    {
        public RabbitMqQueueClient(RabbitMqMessageFactory msgFactory)
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
    }
}

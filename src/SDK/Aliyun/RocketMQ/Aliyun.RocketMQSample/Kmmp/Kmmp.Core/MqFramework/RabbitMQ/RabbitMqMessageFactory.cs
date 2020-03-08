// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-03-08
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-08
// ***********************************************************************
// <copyright file="RabbitMqMessageFactory.cs" company="NoobCore.com">
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
using Kmmp.Core.Extension;
/// <summary>
/// The RabbitMQ namespace.
/// </summary>
namespace Kmmp.Core.MqFramework.RabbitMQ
{
    /// <summary>
    /// Class RabbitMqMessageFactory.
    /// </summary>
    public class RabbitMqMessageFactory : IDisposable
    {
        /// <summary>
        /// Gets the connection factory.
        /// </summary>
        /// <value>The connection factory.</value>
        public ConnectionFactory ConnectionFactory { get; private set; }
        /// <summary>
        /// The retry count
        /// </summary>
        private int retryCount;
        /// <summary>
        /// Gets or sets the retry count.
        /// </summary>
        /// <value>The retry count.</value>
        /// <exception cref="ArgumentOutOfRangeException">RetryCount - Rabbit MQ RetryCount must be 0-1</exception>
        public int RetryCount
        {
            get => retryCount;
            set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentOutOfRangeException(nameof(RetryCount),
                        "Rabbit MQ RetryCount must be 0-1");

                retryCount = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use polling].
        /// </summary>
        /// <value><c>true</c> if [use polling]; otherwise, <c>false</c>.</value>
        public bool UsePolling { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RabbitMqMessageFactory"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <exception cref="ArgumentNullException">connectionString</exception>
        public RabbitMqMessageFactory(string connectionString = "localhost",
            string username = null, string password = null)
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));

            ConnectionFactory = new ConnectionFactory
            {
                RequestedHeartbeat = 10,
            };

            if (username != null)
                ConnectionFactory.UserName = username;
            if (password != null)
                ConnectionFactory.Password = password;

            if (connectionString.StartsWith("amqp://") || connectionString.StartsWith("amqps://"))
            {
                ConnectionFactory.Uri = new Uri(connectionString);
            }
            else
            {
                var parts = connectionString.SplitOnFirst(':');
                var hostName = parts[0];
                ConnectionFactory.HostName = hostName;

                if (parts.Length > 1)
                {
                    ConnectionFactory.Port = parts[1].ToInt();
                }
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RabbitMqMessageFactory"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        public RabbitMqMessageFactory(ConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}

// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-03-16
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-16
// ***********************************************************************
// <copyright file="ConnectionChannelPool.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using RabbitMQ.Client;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The RabbitMQ namespace.
/// </summary>
namespace Kmmp.Core.MqFramework.RabbitMQ
{
    /// <summary>
    /// Class ConnectionChannelPool.
    /// Implements the <see cref="IConnectionChannelPool" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="IConnectionChannelPool" />
    /// <seealso cref="System.IDisposable" />
    public class ConnectionChannelPool : IDisposable
    {
        /// <summary>
        /// The default pool size
        /// </summary>
        private const int DefaultPoolSize = 15;
        /// <summary>
        /// The connection activator
        /// </summary>
        private readonly Func<IConnection> _connectionActivator;

        /// <summary>
        /// The pool
        /// </summary>
        private readonly ConcurrentQueue<IModel> _pool;
        /// <summary>
        /// The connection
        /// </summary>
        private IConnection _connection;
        /// <summary>
        /// The s lock
        /// </summary>
        private static readonly object SLock = new object();

        /// <summary>
        /// The count
        /// </summary>
        private int _count;
        /// <summary>
        /// The maximum size
        /// </summary>
        private int _maxSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionChannelPool"/> class.
        /// </summary>
        /// <param name="config">The rabbit mq configuration.</param>
        public ConnectionChannelPool(
            RabbitMQConfig config)
        {
            _maxSize = DefaultPoolSize;
            _pool = new ConcurrentQueue<IModel>();

            _connectionActivator = CreateConnection(config);

            HostAddress = $"{config.HostName}:{config.Port}";
            Exchange = config.ExchangeName;

            Console.WriteLine($"RabbitMQ configuration:'HostName:{config.HostName}, Port:{config.Port}, UserName:{config.UserName}, Password:{config.Password}, ExchangeName:{config.ExchangeName}'");
        }
        /// <summary>
        /// Rents this instance.
        /// </summary>
        /// <returns>IModel.</returns>
        public IModel Rent()
        {
            lock (SLock)
            {
                while (_count > _maxSize)
                {
                    Thread.SpinWait(1);
                }
                return RentModel();
            }
        }
        /// <summary>
        /// Rents this instance.
        /// </summary>
        /// <returns>IModel.</returns>
        public virtual IModel RentModel()
        {
            if (_pool.TryDequeue(out var model))
            {
                Interlocked.Decrement(ref _count);

                Debug.Assert(_count >= 0);

                return model;
            }

            try
            {
                model = GetConnection().CreateModel();
            }
            catch (Exception e)
            {
                Console.WriteLine("RabbitMQ channel model create failed!");
                Console.WriteLine(e);
                throw;
            }

            return model;
        }
        /// <summary>
        /// Returns the specified connection.
        /// </summary>
        /// <param name="model">The connection.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool Return(IModel model)
        {
            if (Interlocked.Increment(ref _count) <= _maxSize)
            {
                _pool.Enqueue(model);

                return true;
            }

            Interlocked.Decrement(ref _count);

            Debug.Assert(_maxSize == 0 || _pool.Count <= _maxSize);

            return false;
        }

        /// <summary>
        /// Gets the host address.
        /// </summary>
        /// <value>The host address.</value>
        public string HostAddress { get; }

        /// <summary>
        /// Gets the exchange.
        /// </summary>
        /// <value>The exchange.</value>
        public string Exchange { get; }
        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <param name="config">The options.</param>
        /// <returns>Func&lt;IConnection&gt;.</returns>
        private static Func<IConnection> CreateConnection(RabbitMQConfig config)
        {
            var serviceName = Assembly.GetEntryAssembly()?.GetName().Name.ToLower();
            var factory = new ConnectionFactory
            {
                UserName = config.UserName,
                Port = config.Port,
                Password = config.Password,
                VirtualHost = config.VirtualHost
            };

            if (config.HostName.Contains(","))
            {
                return () => factory.CreateConnection(
                    config.HostName.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries), serviceName);
            }
            factory.HostName = config.HostName;
            return () => factory.CreateConnection(serviceName);
        }
        /// <summary>
        /// Handles the ConnectionShutdown event of the RabbitMQ control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ShutdownEventArgs"/> instance containing the event data.</param>
        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine($"RabbitMQ client connection closed! --> {e.ReplyText}");

        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns>IConnection.</returns>
        public IConnection GetConnection()
        {
            if (_connection != null && _connection.IsOpen)
            {
                return _connection;
            }

            _connection = _connectionActivator();
            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
            return _connection;
        }
        /// <summary>
        /// 执行与释放或重置非托管资源关联的应用程序定义的任务。
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            _maxSize = 0;

            while (_pool.TryDequeue(out var context))
            {
                context.Dispose();
            }
        }
    }
}

// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-03-16
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-16
// ***********************************************************************
// <copyright file="RabbitMQConfig.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// Class RabbitMQConfig.
    /// </summary>
    public class RabbitMQConfig
    {   /// <summary>
        /// Default password (value: "guest").
        /// </summary>
        /// <remarks>PLEASE KEEP THIS MATCHING THE DOC ABOVE.</remarks>
        public const string DefaultPass = "guest";

        /// <summary>
        /// Default user name (value: "guest").
        /// </summary>
        public const string DefaultUser = "guest";

        /// <summary>
        /// Default virtual host (value: "/").
        /// </summary>
        public const string DefaultVHost = "/";

        /// <summary>
        /// Default exchange name (value: "kmmp.default.router").
        /// </summary>
        public const string DefaultExchangeName = "kmmp.default.router";

        /// <summary>
        /// The topic exchange type.
        /// </summary>
        public const string ExchangeType = "topic";

        /// <summary>
        /// The host to connect to.
        /// If you want connect to the cluster, you can assign like “192.168.1.111,192.168.1.112”
        /// </summary>
        /// <value>The name of the host.</value>
        public string HostName { get; set; } = "localhost";

        /// <summary>
        /// Password to use when authenticating to the server.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; } = DefaultPass;

        /// <summary>
        /// Username to use when authenticating to the server.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; } = DefaultUser;

        /// <summary>
        /// Virtual host to access during this connection.
        /// </summary>
        /// <value>The virtual host.</value>
        public string VirtualHost { get; set; } = DefaultVHost;

        /// <summary>
        /// Topic exchange name when declare a topic exchange.
        /// </summary>
        /// <value>The name of the exchange.</value>
        public string ExchangeName { get; set; } = DefaultExchangeName;

        /// <summary>
        /// The port to connect on.
        /// </summary>
        /// <value>The port.</value>
        public int Port { get; set; } = -1;

        /// <summary>
        /// Gets or sets queue message automatic deletion time (in milliseconds). Default 864000000 ms (10 days).
        /// </summary>
        /// <value>The queue message expires.</value>
        public int QueueMessageExpires { get; set; } = 864000000;
    }
}

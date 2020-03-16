// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-03-08
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-16
// ***********************************************************************
// <copyright file="QueueNames.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text;

/// <summary>
/// The MqFramework namespace.
/// </summary>
namespace Kmmp.Core.MqFramework
{
    /// <summary>
    /// Util static generic class to create unique queue names for types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class QueueNames<T>
    {
        /// <summary>
        /// Initializes static members of the <see cref="QueueNames{T}" /> class.
        /// </summary>
        static QueueNames()
        {
            Priority = QueueNames.ResolveQueueNameFn(typeof(T).Name, ".priorityq");
            In = QueueNames.ResolveQueueNameFn(typeof(T).Name, ".inq");
            Out = QueueNames.ResolveQueueNameFn(typeof(T).Name, ".outq");
            Dlq = QueueNames.ResolveQueueNameFn(typeof(T).Name, ".dlq");
        }

        /// <summary>
        /// Gets the priority.
        /// </summary>
        /// <value>The priority.</value>
        public static string Priority { get; private set; }

        /// <summary>
        /// Gets the in.
        /// </summary>
        /// <value>The in.</value>
        public static string In { get; private set; }

        /// <summary>
        /// Gets the out.
        /// </summary>
        /// <value>The out.</value>
        public static string Out { get; private set; }

        /// <summary>
        /// Gets the DLQ.
        /// </summary>
        /// <value>The DLQ.</value>
        public static string Dlq { get; private set; }

        /// <summary>
        /// Gets all queue names.
        /// </summary>
        /// <value>All queue names.</value>
        public static string[] AllQueueNames
        {
            get
            {
                return new[] {
                    In,
                    Priority,
                    Out,
                    Dlq,
                };
            }
        }
    }

    /// <summary>
    /// Util class to create unique queue names for runtime types
    /// </summary>
    public class QueueNames
    {
        /// <summary>
        /// The exchange
        /// </summary>
        public static string Exchange = "mx.kmmp";
        /// <summary>
        /// The exchange DLQ
        /// </summary>
        public static string ExchangeDlq = "mx.kmmp.dlq";
        /// <summary>
        /// The exchange topic
        /// </summary>
        public static string ExchangeTopic = "mx.kmmp.topic";

        /// <summary>
        /// The mq prefix
        /// </summary>
        public static string MqPrefix = "mq:";
        /// <summary>
        /// The queue prefix
        /// </summary>
        public static string QueuePrefix = "";

        /// <summary>
        /// The temporary mq prefix
        /// </summary>
        public static string TempMqPrefix = MqPrefix + "tmp:";
        /// <summary>
        /// The topic in
        /// </summary>
        public static string TopicIn = MqPrefix + "topic:in";
        /// <summary>
        /// The topic out
        /// </summary>
        public static string TopicOut = MqPrefix + "topic:out";

        /// <summary>
        /// The resolve queue name function
        /// </summary>
        public static Func<string, string, string> ResolveQueueNameFn = ResolveQueueName;

        /// <summary>
        /// Resolves the name of the queue.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="queueSuffix">The queue suffix.</param>
        /// <returns>System.String.</returns>
        public static string ResolveQueueName(string typeName, string queueSuffix)
        {
            return QueuePrefix + MqPrefix + typeName + queueSuffix;
        }

        /// <summary>
        /// Determines whether [is temporary queue] [the specified queue name].
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <returns><c>true</c> if [is temporary queue] [the specified queue name]; otherwise, <c>false</c>.</returns>
        public static bool IsTempQueue(string queueName)
        {
            return queueName != null
                && queueName.StartsWith(TempMqPrefix, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Sets the queue prefix.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        public static void SetQueuePrefix(string prefix)
        {
            TopicIn = prefix + MqPrefix + "topic:in";
            TopicOut = prefix + MqPrefix + "topic:out";
            QueuePrefix = prefix;
            TempMqPrefix = prefix + MqPrefix + "tmp:";
        }

        /// <summary>
        /// The queue nmae
        /// </summary>
        private readonly string queueNmae;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueNames" /> class.
        /// </summary>
        /// <param name="queueNmae">The queue nmae.</param>
        public QueueNames(string queueNmae)
        {
            this.queueNmae = queueNmae;
        }

        /// <summary>
        /// Gets the priority.
        /// </summary>
        /// <value>The priority.</value>
        public string Priority => ResolveQueueNameFn(queueNmae, ".priorityq");

        /// <summary>
        /// Gets the in.
        /// </summary>
        /// <value>The in.</value>
        public string In => ResolveQueueNameFn(queueNmae, ".inq");

        /// <summary>
        /// Gets the out.
        /// </summary>
        /// <value>The out.</value>
        public string Out => ResolveQueueNameFn(queueNmae, ".outq");

        /// <summary>
        /// Gets the DLQ.
        /// </summary>
        /// <value>The DLQ.</value>
        public string Dlq => ResolveQueueNameFn(queueNmae, ".dlq");

        /// <summary>
        /// Gets the name of the temporary queue.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string GetTempQueueName()
        {
            return TempMqPrefix + Guid.NewGuid().ToString("n");
        }
    }

}
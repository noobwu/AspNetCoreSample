﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Kmmp.Core.Imps;
using Kmmp.Core.Models;

namespace Kmmp.Core.Helper
{
    /// <summary>
    ///     作者：吴廷有
    ///     时间：2015-10-23
    ///     功能：message queue 帮助类
    /// </summary>
    public class MessageQueueHelper
    {
        static Dictionary<string, string> queueNameHostConfigDict = new Dictionary<string, string>();

        #region "  常量定义  "

        /// <summary>
        ///     队列池
        /// </summary>
        private static readonly Dictionary<string, IMessageQueue> _messageQueues =
            new Dictionary<string, IMessageQueue>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     消息队列池锁
        /// </summary>
        private static readonly object s_messageQueuesLocker = new object();

        #endregion

        static MessageQueueHelper()
        {
            initMqHostConfigFileName();
        }
        #region "  方法定义  "

        /// <summary>
        ///     作者：吴廷有
        ///     时间：2015-10-23
        ///     功能：关闭消息队列中所有的队列
        /// </summary>
        public static void CloseAll()
        {
            lock (s_messageQueuesLocker)
            {
                foreach (var messageQueueKey in _messageQueues.Keys.ToList())
                {
                    var queue = _messageQueues[messageQueueKey];
                    queue.Dispose();
                    _messageQueues.Remove(messageQueueKey);
                }
            }
        }

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-11-26
        /// 功能：移除指定消息队列
        /// </summary>
        /// <param name="queueName"></param>
        public static void CloseQueue(string queueName)
        {
            lock (s_messageQueuesLocker)
            {
                var queue = _messageQueues[queueName];
                queue.Dispose();
                _messageQueues.Remove(queueName);
            }
        }

        /// <summary>
        ///     作者：吴廷有
        ///     时间：2015-10-23
        ///     功能：获取一个 Message Queue
        /// </summary>
        /// <param name="mqConfigFileName">队列配置文件名称</param>
        /// <returns></returns>
        public static IMessageQueue GetMessageQueue(string mqConfigFileName)
        {
            if (mqConfigFileName == null) throw new ArgumentNullException("mqConfigFileName");
            JsonConfigInfo mongoConfigInfo = JsonConfigInfo.LoadFromFile(mqConfigFileName + ".mq.json");
            return ComponentLoader.Load<IMessageQueue>(mongoConfigInfo);
        }

        /// <summary>
        ///     作者：吴廷有
        ///     时间：2015-10-23
        ///     功能：从消息队列池中获取一个 Message Queue，注意，请勿 Dispose 消息队列池中的 MessageQueue
        /// </summary>
        /// <param name="mqConfigFileName">队列配置文件名称</param>
        /// <returns></returns>
        public static IMessageQueue GetMessageQueueFromPool(string queueName)
        {
            string mqConfigFileName = getMqHostConfigFileName(queueName);
            if (mqConfigFileName == null) throw new ArgumentNullException("mqConfigFileName");
            IMessageQueue messageQueue;
            if (_messageQueues.TryGetValue(mqConfigFileName, out messageQueue))
            {
                return new UnhappylessDisposeMessageQueue(messageQueue);
            }


            lock (s_messageQueuesLocker)
            {
                if (_messageQueues.TryGetValue(mqConfigFileName, out messageQueue))
                {
                    return new UnhappylessDisposeMessageQueue(messageQueue);
                }

                messageQueue = GetMessageQueue(mqConfigFileName);
                _messageQueues[mqConfigFileName] = messageQueue;
                return new UnhappylessDisposeMessageQueue(messageQueue);
            }
        }

        /// <summary>
        /// 初始化队列所对应的配置文件名称
        /// </summary>
        private static void initMqHostConfigFileName()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "/config/mqConnection.config";
            if (System.IO.File.Exists(filePath) == false)
            {
                return;
            }
            XDocument configDoc = XDocument.Load(filePath);
            var itemNodes = configDoc.Root.Elements("item");
            if (itemNodes == null || itemNodes.Count() == 0)
            {
                return;
            }
            string key = "";
            string val = "";
            foreach (var node in itemNodes)
            {
                key = node.Attribute("key")?.Value;
                val = node.Attribute("value")?.Value;
                if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(val))
                {
                    queueNameHostConfigDict[key] = val;
                }
            }
        }

        /// <summary>
        /// 获取队列对应的配置文件名
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        private static string getMqHostConfigFileName(string queueName)
        {
            string filename = "messageQueue";
            if (queueNameHostConfigDict.ContainsKey(queueName))
            {
                filename = queueNameHostConfigDict[queueName];
            }
            return filename;
        }

        #endregion

        #region "  内部类定义  "

        private class UnhappylessDisposeMessageQueue : IMessageQueue
        {
            #region "  变量定义  "

            private readonly IMessageQueue m_messageQueue;

            #endregion

            #region "  构造函数  "

            /// <summary>
            ///     作者：吴廷有
            ///     时间：2015-10-23
            ///     功能：创建一个 <see cref="UnhappylessDisposeMessageQueue" />
            /// </summary>
            /// <param name="messageQueue"></param>
            public UnhappylessDisposeMessageQueue(IMessageQueue messageQueue)
            {
                m_messageQueue = messageQueue;
            }

            #endregion

            #region "  方法定义  "

            /// <summary>
            ///     作者：吴廷有
            ///     时间：2015-10-23
            ///     功能：执行与释放或重置非托管资源相关的应用程序定义的任务。
            /// </summary>
            public void Dispose()
            {
                throw new Exception("请不要队列池中的队列的 Dispose 方法，请调用 MessageQueueHelper.CloseAll() 方法");
            }

            /// <summary>
            ///     作者：吴廷有
            ///     时间：2015-10-23
            ///     功能：获取一个消息发布者
            /// </summary>
            /// <param name="queue">队列名称</param>
            /// <returns></returns>
            public IMessagePublisher GetMessagePublisher(string queue)
            {
                return m_messageQueue.GetMessagePublisher(queue);
            }

            /// <summary>
            ///     作者：吴廷有
            ///     时间：2015-10-23
            ///     功能：获取一个广播消息发布者
            /// </summary>
            /// <param name="queue">队列名称</param>
            /// <returns></returns>
            public IBroadcastPublisher GetBroadcastPublisher(string queue)
            {
                return m_messageQueue.GetBroadcastPublisher(queue);
            }

            /// <summary>
            ///     作者：吴廷有
            ///     时间：2015-10-23
            ///     功能：获取一个消息接收者对象
            /// </summary>
            /// <param name="queue">列表名称</param>
            /// <param name="receiverId">接收对象 Id</param>
            /// <returns></returns>
            public IMessageReceiver GetMessageReceiver(string queue, string receiverId)
            {
                return m_messageQueue.GetMessageReceiver(queue, receiverId);
            }

            /// <summary>
            ///     作者：吴廷有
            ///     时间：2015-10-23
            ///     功能：获取一个广播消息发布者
            /// </summary>
            /// <param name="broadcastName">队列名称</param>
            /// <param name="receiverId">接收对象 Id</param>
            /// <returns></returns>
            public IBroadcastReceiver GetBroadcastReceiver(string broadcastName, string receiverId)
            {
                return m_messageQueue.GetBroadcastReceiver(broadcastName, receiverId);
            }

            #endregion
        }

        #endregion
    }
}


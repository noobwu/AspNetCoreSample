// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="Message.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The ons namespace.
/// </summary>
namespace ons
{

    /// <summary>
    /// 消息队列中信息传递的载体。
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class Message : global::System.IDisposable
    {
        /// <summary>
        /// The swig c PTR
        /// </summary>
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        /// <summary>
        /// The swig c memory own
        /// </summary>
        protected bool swigCMemOwn;

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="cPtr">The c PTR.</param>
        /// <param name="cMemoryOwn">if set to <c>true</c> [c memory own].</param>
        internal Message(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets the c PTR.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Message obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Message"/> class.
        /// </summary>
        ~Message()
        {
            Dispose();
        }

        /// <summary>
        /// 执行与释放或重置非托管资源关联的应用程序定义的任务。
        /// </summary>
        public virtual void Dispose()
        {
            lock (this)
            {
                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        ONSClient4CPPPINVOKE.delete_Message(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        public Message() : this(ONSClient4CPPPINVOKE.new_Message__SWIG_0(), true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="tags">The tags.</param>
        /// <param name="byte_body">The byte body.</param>
        public Message(string topic, string tags, string byte_body) : this(ONSClient4CPPPINVOKE.new_Message__SWIG_1(topic, tags, byte_body), true)
        {
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="topic_size">Size of the topic.</param>
        /// <param name="tags">The tags.</param>
        /// <param name="tags_size">Size of the tags.</param>
        /// <param name="body">The body.</param>
        /// <param name="body_size">Size of the body.</param>
        public Message(string topic, uint topic_size, string tags, uint tags_size, string body, uint body_size) : this(ONSClient4CPPPINVOKE.new_Message__SWIG_3(topic, topic_size, tags, tags_size, body, body_size), true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="tags">The tags.</param>
        /// <param name="keys">The keys.</param>
        /// <param name="body">The body.</param>
        public Message(string topic, string tags, string keys, string body) : this(ONSClient4CPPPINVOKE.new_Message__SWIG_4(topic, tags, keys, body), true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="other">The other.</param>
        public Message(Message other) : this(ONSClient4CPPPINVOKE.new_Message__SWIG_5(Message.getCPtr(other)), true)
        {
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Puts the user properties.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void putUserProperties(string key, string value)
        {
            ONSClient4CPPPINVOKE.Message_putUserProperties(swigCPtr, key, value);
        }

        /// <summary>
        /// Gets the user properties.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public string getUserProperties(string key)
        {
            string ret = ONSClient4CPPPINVOKE.Message_getUserProperties__SWIG_0(swigCPtr, key);
            return ret;
        }

        /// <summary>
        /// Sets the user properties.
        /// </summary>
        /// <param name="userProperty">The user property.</param>
        public void setUserProperties(SWIGTYPE_p_std__mapT_std__string_std__string_t userProperty)
        {
            ONSClient4CPPPINVOKE.Message_setUserProperties(swigCPtr, SWIGTYPE_p_std__mapT_std__string_std__string_t.getCPtr(userProperty));
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the user properties.
        /// </summary>
        /// <returns>SWIGTYPE_p_std__mapT_std__string_std__string_t.</returns>
        public SWIGTYPE_p_std__mapT_std__string_std__string_t getUserProperties()
        {
            SWIGTYPE_p_std__mapT_std__string_std__string_t ret = new SWIGTYPE_p_std__mapT_std__string_std__string_t(ONSClient4CPPPINVOKE.Message_getUserProperties__SWIG_1(swigCPtr), true);
            return ret;
        }

        /// <summary>
        /// Puts the system properties.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void putSystemProperties(string key, string value)
        {
            ONSClient4CPPPINVOKE.Message_putSystemProperties(swigCPtr, key, value);
        }

        /// <summary>
        /// Gets the system properties.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public string getSystemProperties(string key)
        {
            string ret = ONSClient4CPPPINVOKE.Message_getSystemProperties__SWIG_0(swigCPtr, key);
            return ret;
        }

        /// <summary>
        /// Sets the system properties.
        /// </summary>
        /// <param name="systemProperty">The system property.</param>
        public void setSystemProperties(SWIGTYPE_p_std__mapT_std__string_std__string_t systemProperty)
        {
            ONSClient4CPPPINVOKE.Message_setSystemProperties(swigCPtr, SWIGTYPE_p_std__mapT_std__string_std__string_t.getCPtr(systemProperty));
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the system properties.
        /// </summary>
        /// <returns>SWIGTYPE_p_std__mapT_std__string_std__string_t.</returns>
        public SWIGTYPE_p_std__mapT_std__string_std__string_t getSystemProperties()
        {
            SWIGTYPE_p_std__mapT_std__string_std__string_t ret = new SWIGTYPE_p_std__mapT_std__string_std__string_t(ONSClient4CPPPINVOKE.Message_getSystemProperties__SWIG_1(swigCPtr), true);
            return ret;
        }

        /// <summary>
        /// 获取消息主题，一级消息类型，通过 Topic 对消息进行分类。详情请参见 Topic 与 Tag 最佳实践。
        /// </summary>
        /// <returns>System.String.</returns>
        public string getTopic()
        {
            string ret = ONSClient4CPPPINVOKE.Message_getTopic(swigCPtr);
            return ret;
        }

        /// <summary>
        /// 设置消息主题，一级消息类型，通过 Topic 对消息进行分类。详情请参见 Topic 与 Tag 最佳实践。
        /// </summary>
        /// <param name="topic">The topic.</param>
        public void setTopic(string topic)
        {
            ONSClient4CPPPINVOKE.Message_setTopic(swigCPtr, topic);
        }

        /// <summary>
        /// 获取消息标签，二级消息类型，用来进一步区分某个 Topic 下的消息分类。详情请参见 Topic 与 Tag 最佳实践。
        /// </summary>
        /// <returns>System.String.</returns>
        public string getTag()
        {
            string ret = ONSClient4CPPPINVOKE.Message_getTag(swigCPtr);
            return ret;
        }

        /// <summary>
        /// 设置消息标签，二级消息类型，用来进一步区分某个 Topic 下的消息分类。详情请参见 Topic 与 Tag 最佳实践。
        /// </summary>
        /// <param name="tags">The tags.</param>
        public void setTag(string tags)
        {
            ONSClient4CPPPINVOKE.Message_setTag(swigCPtr, tags);
        }

        /// <summary>
        /// 获取消息的业务标识，由消息生产者（Producer）设置，唯一标识某个业务逻辑。
        /// </summary>
        /// <returns>System.String.</returns>
        public string getKey()
        {
            string ret = ONSClient4CPPPINVOKE.Message_getKey(swigCPtr);
            return ret;
        }

        /// <summary>
        /// 设置消息的业务标识，由消息生产者（Producer）设置，唯一标识某个业务逻辑。
        /// </summary>
        /// <param name="keys">The keys.</param>
        public void setKey(string keys)
        {
            ONSClient4CPPPINVOKE.Message_setKey(swigCPtr, keys);
        }

        /// <summary>
        /// 获取消息的全局唯一标识
        /// </summary>
        /// <returns>System.String.</returns>
        public string getMsgID()
        {
            string ret = ONSClient4CPPPINVOKE.Message_getMsgID(swigCPtr);
            return ret;
        }

        /// <summary>
        /// 设置消息的全局唯一标识
        /// </summary>
        /// <param name="msgId">The MSG identifier.</param>
        public void setMsgID(string msgId)
        {
            ONSClient4CPPPINVOKE.Message_setMsgID(swigCPtr, msgId);
        }

        /// <summary>
        /// Gets the start deliver time.
        /// </summary>
        /// <returns>System.Int64.</returns>
        public long getStartDeliverTime()
        {
            long ret = ONSClient4CPPPINVOKE.Message_getStartDeliverTime(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Sets the start deliver time.
        /// </summary>
        /// <param name="level">The level.</param>
        public void setStartDeliverTime(long level)
        {
            ONSClient4CPPPINVOKE.Message_setStartDeliverTime(swigCPtr, level);
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getBody()
        {
            string ret = ONSClient4CPPPINVOKE.Message_getBody(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the MSG body.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getMsgBody()
        {
            string ret = ONSClient4CPPPINVOKE.Message_getMsgBody(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Sets the MSG body.
        /// </summary>
        /// <param name="msgbody">The msgbody.</param>
        public void setMsgBody(string msgbody)
        {
            ONSClient4CPPPINVOKE.Message_setMsgBody(swigCPtr, msgbody);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the body.
        /// </summary>
        /// <param name="byte_msgbody">The byte msgbody.</param>
        /// <param name="len">The length.</param>
        public void setBody(byte[] byte_msgbody, int len)
        {
            ONSClient4CPPPINVOKE.Message_setBody(swigCPtr, byte_msgbody, len);
        }

        /// <summary>
        /// Gets the reconsume times.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int getReconsumeTimes()
        {
            int ret = ONSClient4CPPPINVOKE.Message_getReconsumeTimes(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Sets the reconsume times.
        /// </summary>
        /// <param name="reconsumeTimes">The reconsume times.</param>
        public void setReconsumeTimes(int reconsumeTimes)
        {
            ONSClient4CPPPINVOKE.Message_setReconsumeTimes(swigCPtr, reconsumeTimes);
        }

        /// <summary>
        /// Gets the store timestamp.
        /// </summary>
        /// <returns>System.Int64.</returns>
        public long getStoreTimestamp()
        {
            long ret = ONSClient4CPPPINVOKE.Message_getStoreTimestamp(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Sets the store timestamp.
        /// </summary>
        /// <param name="storeTimestamp">The store timestamp.</param>
        public void setStoreTimestamp(long storeTimestamp)
        {
            ONSClient4CPPPINVOKE.Message_setStoreTimestamp(swigCPtr, storeTimestamp);
        }

        /// <summary>
        /// To the string.
        /// </summary>
        /// <returns>System.String.</returns>
        public string toString()
        {
            string ret = ONSClient4CPPPINVOKE.Message_toString(swigCPtr);
            return ret;
        }

        /// <summary>
        /// To the system string.
        /// </summary>
        /// <returns>System.String.</returns>
        public string toSystemString()
        {
            string ret = ONSClient4CPPPINVOKE.Message_toSystemString(swigCPtr);
            return ret;
        }

        /// <summary>
        /// To the user string.
        /// </summary>
        /// <returns>System.String.</returns>
        public string toUserString()
        {
            string ret = ONSClient4CPPPINVOKE.Message_toUserString(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the queue offset.
        /// </summary>
        /// <returns>System.Int64.</returns>
        public long getQueueOffset()
        {
            long ret = ONSClient4CPPPINVOKE.Message_getQueueOffset(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Sets the queue offset.
        /// </summary>
        /// <param name="queueOffset">The queue offset.</param>
        public void setQueueOffset(long queueOffset)
        {
            ONSClient4CPPPINVOKE.Message_setQueueOffset(swigCPtr, queueOffset);
        }

    }

}

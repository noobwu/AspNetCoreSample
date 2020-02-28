// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="MessageQueueONS.cs" company="NoobCore.com">
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
    /// Class MessageQueueONS.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class MessageQueueONS : global::System.IDisposable
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
        /// Initializes a new instance of the <see cref="MessageQueueONS"/> class.
        /// </summary>
        /// <param name="cPtr">The c PTR.</param>
        /// <param name="cMemoryOwn">if set to <c>true</c> [c memory own].</param>
        internal MessageQueueONS(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets the c PTR.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(MessageQueueONS obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MessageQueueONS"/> class.
        /// </summary>
        ~MessageQueueONS()
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
                        ONSClient4CPPPINVOKE.delete_MessageQueueONS(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageQueueONS"/> class.
        /// </summary>
        public MessageQueueONS() : this(ONSClient4CPPPINVOKE.new_MessageQueueONS__SWIG_0(), true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageQueueONS"/> class.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="brokerName">Name of the broker.</param>
        /// <param name="queueId">The queue identifier.</param>
        public MessageQueueONS(string topic, string brokerName, int queueId) : this(ONSClient4CPPPINVOKE.new_MessageQueueONS__SWIG_1(topic, brokerName, queueId), true)
        {
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageQueueONS"/> class.
        /// </summary>
        /// <param name="other">The other.</param>
        public MessageQueueONS(MessageQueueONS other) : this(ONSClient4CPPPINVOKE.new_MessageQueueONS__SWIG_2(MessageQueueONS.getCPtr(other)), true)
        {
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the topic.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getTopic()
        {
            string ret = ONSClient4CPPPINVOKE.MessageQueueONS_getTopic(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Sets the topic.
        /// </summary>
        /// <param name="topic">The topic.</param>
        public void setTopic(string topic)
        {
            ONSClient4CPPPINVOKE.MessageQueueONS_setTopic(swigCPtr, topic);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the name of the broker.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getBrokerName()
        {
            string ret = ONSClient4CPPPINVOKE.MessageQueueONS_getBrokerName(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Sets the name of the broker.
        /// </summary>
        /// <param name="brokerName">Name of the broker.</param>
        public void setBrokerName(string brokerName)
        {
            ONSClient4CPPPINVOKE.MessageQueueONS_setBrokerName(swigCPtr, brokerName);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the queue identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int getQueueId()
        {
            int ret = ONSClient4CPPPINVOKE.MessageQueueONS_getQueueId(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Sets the queue identifier.
        /// </summary>
        /// <param name="queueId">The queue identifier.</param>
        public void setQueueId(int queueId)
        {
            ONSClient4CPPPINVOKE.MessageQueueONS_setQueueId(swigCPtr, queueId);
        }

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <returns>System.Int32.</returns>
        public int compareTo(MessageQueueONS mq)
        {
            int ret = ONSClient4CPPPINVOKE.MessageQueueONS_compareTo(swigCPtr, MessageQueueONS.getCPtr(mq));
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}

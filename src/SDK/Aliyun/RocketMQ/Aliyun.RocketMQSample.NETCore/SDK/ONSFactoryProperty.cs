// ***********************************************************************
// Assembly         : Aliyun.RocketSample.NETCore
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="ONSFactoryProperty.cs" company="Aliyun.RocketSample.NETCore">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The ons namespace.
/// </summary>
namespace ons
{

    /// <summary>
    /// Class ONSFactoryProperty.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ONSFactoryProperty : global::System.IDisposable
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
        /// Initializes a new instance of the <see cref="ONSFactoryProperty"/> class.
        /// </summary>
        /// <param name="cPtr">The c PTR.</param>
        /// <param name="cMemoryOwn">if set to <c>true</c> [c memory own].</param>
        internal ONSFactoryProperty(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets the c PTR.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ONSFactoryProperty obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ONSFactoryProperty"/> class.
        /// </summary>
        ~ONSFactoryProperty()
        {
            Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
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
                        ONSClient4CPPPINVOKE.delete_ONSFactoryProperty(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ONSFactoryProperty"/> class.
        /// </summary>
        public ONSFactoryProperty() : this(ONSClient4CPPPINVOKE.new_ONSFactoryProperty(), true)
        {
        }

        /// <summary>
        /// Checks the validity of factory properties.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool checkValidityOfFactoryProperties(string key, string value)
        {
            bool ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_checkValidityOfFactoryProperties(swigCPtr, key, value);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the log path.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getLogPath()
        {
            string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getLogPath(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Sets the send MSG timeout.
        /// </summary>
        /// <param name="value">The value.</param>
        public void setSendMsgTimeout(int value)
        {
            ONSClient4CPPPINVOKE.ONSFactoryProperty_setSendMsgTimeout(swigCPtr, value);
        }

        /// <summary>
        /// Sets the send MSG retry times.
        /// </summary>
        /// <param name="value">The value.</param>
        public void setSendMsgRetryTimes(int value)
        {
            ONSClient4CPPPINVOKE.ONSFactoryProperty_setSendMsgRetryTimes(swigCPtr, value);
        }

        /// <summary>
        /// Sets the maximum size of the MSG cache.
        /// </summary>
        /// <param name="size">The size.</param>
        public void setMaxMsgCacheSize(int size)
        {
            ONSClient4CPPPINVOKE.ONSFactoryProperty_setMaxMsgCacheSize(swigCPtr, size);
        }

        /// <summary>
        /// Sets the ons trace switch.
        /// </summary>
        /// <param name="onswitch">if set to <c>true</c> [onswitch].</param>
        public void setOnsTraceSwitch(bool onswitch)
        {
            ONSClient4CPPPINVOKE.ONSFactoryProperty_setOnsTraceSwitch(swigCPtr, onswitch);
        }

        /// <summary>
        /// Sets the ons channel.
        /// </summary>
        /// <param name="onsChannel">The ons channel.</param>
        public void setOnsChannel(ONSChannel onsChannel)
        {
            ONSClient4CPPPINVOKE.ONSFactoryProperty_setOnsChannel(swigCPtr, (int)onsChannel);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the factory property.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void setFactoryProperty(string key, string value)
        {
            ONSClient4CPPPINVOKE.ONSFactoryProperty_setFactoryProperty(swigCPtr, key, value);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the factory properties.
        /// </summary>
        /// <param name="factoryProperties">The factory properties.</param>
        public void setFactoryProperties(SWIGTYPE_p_std__mapT_std__string_std__string_t factoryProperties)
        {
            ONSClient4CPPPINVOKE.ONSFactoryProperty_setFactoryProperties(swigCPtr, SWIGTYPE_p_std__mapT_std__string_std__string_t.getCPtr(factoryProperties));
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the factory properties.
        /// </summary>
        /// <returns>SWIGTYPE_p_std__mapT_std__string_std__string_t.</returns>
        public SWIGTYPE_p_std__mapT_std__string_std__string_t getFactoryProperties()
        {
            SWIGTYPE_p_std__mapT_std__string_std__string_t ret = new SWIGTYPE_p_std__mapT_std__string_std__string_t(ONSClient4CPPPINVOKE.ONSFactoryProperty_getFactoryProperties(swigCPtr), true);
            return ret;
        }

        /// <summary>
        /// Gets the producer identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getProducerId()
        {
            string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getProducerId(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the consumer identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getConsumerId()
        {
            string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getConsumerId(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the publish topics.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getPublishTopics()
        {
            string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getPublishTopics(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the message model.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getMessageModel()
        {
            string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getMessageModel(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the send MSG timeout.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int getSendMsgTimeout()
        {
            int ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getSendMsgTimeout(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the send MSG retry times.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int getSendMsgRetryTimes()
        {
            int ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getSendMsgRetryTimes(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the consume thread nums.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int getConsumeThreadNums()
        {
            int ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getConsumeThreadNums(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the maximum size of the MSG cache.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int getMaxMsgCacheSize()
        {
            int ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getMaxMsgCacheSize(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the ons channel.
        /// </summary>
        /// <returns>ONSChannel.</returns>
        public ONSChannel getOnsChannel()
        {
            ONSChannel ret = (ONSChannel)ONSClient4CPPPINVOKE.ONSFactoryProperty_getOnsChannel(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the channel.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getChannel()
        {
            string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getChannel(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the content of the message.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getMessageContent()
        {
            string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getMessageContent(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the name SRV addr.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getNameSrvAddr()
        {
            string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getNameSrvAddr(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the name SRV domain.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getNameSrvDomain()
        {
            string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getNameSrvDomain(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the access key.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getAccessKey()
        {
            string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getAccessKey(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the secret key.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getSecretKey()
        {
            string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getSecretKey(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the name of the consumer instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getConsumerInstanceName()
        {
            string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getConsumerInstanceName(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the ons trace switch.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool getOnsTraceSwitch()
        {
            bool ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getOnsTraceSwitch(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the name space.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getNameSpace()
        {
            string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_getNameSpace(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets or sets the log path.
        /// </summary>
        /// <value>The log path.</value>
        public static string LogPath
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_LogPath_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_LogPath_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the producer identifier.
        /// </summary>
        /// <value>The producer identifier.</value>
        public static string ProducerId
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_ProducerId_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_ProducerId_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the consumer identifier.
        /// </summary>
        /// <value>The consumer identifier.</value>
        public static string ConsumerId
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_ConsumerId_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_ConsumerId_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the publish topics.
        /// </summary>
        /// <value>The publish topics.</value>
        public static string PublishTopics
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_PublishTopics_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_PublishTopics_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the content of the MSG.
        /// </summary>
        /// <value>The content of the MSG.</value>
        public static string MsgContent
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_MsgContent_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_MsgContent_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the ons addr.
        /// </summary>
        /// <value>The ons addr.</value>
        public static string ONSAddr
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_ONSAddr_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_ONSAddr_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the access key.
        /// </summary>
        /// <value>The access key.</value>
        public static string AccessKey
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_AccessKey_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_AccessKey_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the secret key.
        /// </summary>
        /// <value>The secret key.</value>
        public static string SecretKey
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_SecretKey_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_SecretKey_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the message model.
        /// </summary>
        /// <value>The message model.</value>
        public static string MessageModel
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_MessageModel_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_MessageModel_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the broadcasting.
        /// </summary>
        /// <value>The broadcasting.</value>
        public static string BROADCASTING
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_BROADCASTING_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_BROADCASTING_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the clustering.
        /// </summary>
        /// <value>The clustering.</value>
        public static string CLUSTERING
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_CLUSTERING_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_CLUSTERING_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the send MSG timeout millis.
        /// </summary>
        /// <value>The send MSG timeout millis.</value>
        public static string SendMsgTimeoutMillis
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_SendMsgTimeoutMillis_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_SendMsgTimeoutMillis_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the namesrv addr.
        /// </summary>
        /// <value>The namesrv addr.</value>
        public static string NAMESRV_ADDR
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_NAMESRV_ADDR_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_NAMESRV_ADDR_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the consume thread nums.
        /// </summary>
        /// <value>The consume thread nums.</value>
        public static string ConsumeThreadNums
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_ConsumeThreadNums_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_ConsumeThreadNums_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the ons channel.
        /// </summary>
        /// <value>The ons channel.</value>
        public static string OnsChannel
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_OnsChannel_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_OnsChannel_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the maximum size of the MSG cache.
        /// </summary>
        /// <value>The maximum size of the MSG cache.</value>
        public static string MaxMsgCacheSize
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_MaxMsgCacheSize_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_MaxMsgCacheSize_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the ons trace switch.
        /// </summary>
        /// <value>The ons trace switch.</value>
        public static string OnsTraceSwitch
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_OnsTraceSwitch_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_OnsTraceSwitch_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the send MSG retry times.
        /// </summary>
        /// <value>The send MSG retry times.</value>
        public static string SendMsgRetryTimes
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_SendMsgRetryTimes_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_SendMsgRetryTimes_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the name of the consumer instance.
        /// </summary>
        /// <value>The name of the consumer instance.</value>
        public static string ConsumerInstanceName
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_ConsumerInstanceName_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_ConsumerInstanceName_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the instance identifier.
        /// </summary>
        /// <value>The instance identifier.</value>
        public static string InstanceId
        {
            set
            {
                ONSClient4CPPPINVOKE.ONSFactoryProperty_InstanceId_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.ONSFactoryProperty_InstanceId_get();
                return ret;
            }
        }

    }

}

// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="SystemPropKey.cs" company="NoobCore.com">
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
    /// Class SystemPropKey.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class SystemPropKey : global::System.IDisposable
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
        /// Initializes a new instance of the <see cref="SystemPropKey" /> class.
        /// </summary>
        /// <param name="cPtr">The c PTR.</param>
        /// <param name="cMemoryOwn">if set to <c>true</c> [c memory own].</param>
        internal SystemPropKey(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets the c PTR.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SystemPropKey obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="SystemPropKey" /> class.
        /// </summary>
        ~SystemPropKey()
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
                        ONSClient4CPPPINVOKE.delete_SystemPropKey(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemPropKey" /> class.
        /// </summary>
        public SystemPropKey() : this(ONSClient4CPPPINVOKE.new_SystemPropKey(), true)
        {
        }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        public static string TAG
        {
            set
            {
                ONSClient4CPPPINVOKE.SystemPropKey_TAG_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.SystemPropKey_TAG_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public static string KEY
        {
            set
            {
                ONSClient4CPPPINVOKE.SystemPropKey_KEY_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.SystemPropKey_KEY_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the msgid.
        /// </summary>
        /// <value>The msgid.</value>
        public static string MSGID
        {
            set
            {
                ONSClient4CPPPINVOKE.SystemPropKey_MSGID_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.SystemPropKey_MSGID_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the reconsumetimes.
        /// </summary>
        /// <value>The reconsumetimes.</value>
        public static string RECONSUMETIMES
        {
            set
            {
                ONSClient4CPPPINVOKE.SystemPropKey_RECONSUMETIMES_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.SystemPropKey_RECONSUMETIMES_get();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the startdelivertime.
        /// </summary>
        /// <value>The startdelivertime.</value>
        public static string STARTDELIVERTIME
        {
            set
            {
                ONSClient4CPPPINVOKE.SystemPropKey_STARTDELIVERTIME_set(value);
            }
            get
            {
                string ret = ONSClient4CPPPINVOKE.SystemPropKey_STARTDELIVERTIME_get();
                return ret;
            }
        }

    }

}

// ***********************************************************************
// Assembly         : Aliyun.RocketSample
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="PullResultONS.cs" company="NoobCore.com">
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
    /// Class PullResultONS.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class PullResultONS : global::System.IDisposable
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
        /// Initializes a new instance of the <see cref="PullResultONS"/> class.
        /// </summary>
        /// <param name="cPtr">The c PTR.</param>
        /// <param name="cMemoryOwn">if set to <c>true</c> [c memory own].</param>
        internal PullResultONS(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets the c PTR.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PullResultONS obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="PullResultONS"/> class.
        /// </summary>
        ~PullResultONS()
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
                        ONSClient4CPPPINVOKE.delete_PullResultONS(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PullResultONS"/> class.
        /// </summary>
        /// <param name="status">The status.</param>
        public PullResultONS(ONSPullStatus status) : this(ONSClient4CPPPINVOKE.new_PullResultONS__SWIG_0((int)status), true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PullResultONS"/> class.
        /// </summary>
        /// <param name="pullStatus">The pull status.</param>
        /// <param name="nextBeginOffset">The next begin offset.</param>
        /// <param name="minOffset">The minimum offset.</param>
        /// <param name="maxOffset">The maximum offset.</param>
        public PullResultONS(ONSPullStatus pullStatus, long nextBeginOffset, long minOffset, long maxOffset) : this(ONSClient4CPPPINVOKE.new_PullResultONS__SWIG_1((int)pullStatus, nextBeginOffset, minOffset, maxOffset), true)
        {
        }

        /// <summary>
        /// Gets or sets the pull status.
        /// </summary>
        /// <value>The pull status.</value>
        public ONSPullStatus pullStatus
        {
            set
            {
                ONSClient4CPPPINVOKE.PullResultONS_pullStatus_set(swigCPtr, (int)value);
            }
            get
            {
                ONSPullStatus ret = (ONSPullStatus)ONSClient4CPPPINVOKE.PullResultONS_pullStatus_get(swigCPtr);
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the next begin offset.
        /// </summary>
        /// <value>The next begin offset.</value>
        public long nextBeginOffset
        {
            set
            {
                ONSClient4CPPPINVOKE.PullResultONS_nextBeginOffset_set(swigCPtr, value);
            }
            get
            {
                long ret = ONSClient4CPPPINVOKE.PullResultONS_nextBeginOffset_get(swigCPtr);
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the minimum offset.
        /// </summary>
        /// <value>The minimum offset.</value>
        public long minOffset
        {
            set
            {
                ONSClient4CPPPINVOKE.PullResultONS_minOffset_set(swigCPtr, value);
            }
            get
            {
                long ret = ONSClient4CPPPINVOKE.PullResultONS_minOffset_get(swigCPtr);
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the maximum offset.
        /// </summary>
        /// <value>The maximum offset.</value>
        public long maxOffset
        {
            set
            {
                ONSClient4CPPPINVOKE.PullResultONS_maxOffset_set(swigCPtr, value);
            }
            get
            {
                long ret = ONSClient4CPPPINVOKE.PullResultONS_maxOffset_get(swigCPtr);
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the MSG found list.
        /// </summary>
        /// <value>The MSG found list.</value>
        public SWIGTYPE_p_std__vectorT_ons__Message_t msgFoundList
        {
            set
            {
                ONSClient4CPPPINVOKE.PullResultONS_msgFoundList_set(swigCPtr, SWIGTYPE_p_std__vectorT_ons__Message_t.getCPtr(value));
            }
            get
            {
                global::System.IntPtr cPtr = ONSClient4CPPPINVOKE.PullResultONS_msgFoundList_get(swigCPtr);
                SWIGTYPE_p_std__vectorT_ons__Message_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_ons__Message_t(cPtr, false);
                return ret;
            }
        }

    }

}

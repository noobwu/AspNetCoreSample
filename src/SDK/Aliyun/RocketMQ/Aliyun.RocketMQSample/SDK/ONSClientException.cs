// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="ONSClientException.cs" company="NoobCore.com">
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
    /// Class ONSClientException.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ONSClientException : global::System.IDisposable
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
        /// Initializes a new instance of the <see cref="ONSClientException" /> class.
        /// </summary>
        /// <param name="cPtr">The c PTR.</param>
        /// <param name="cMemoryOwn">if set to <c>true</c> [c memory own].</param>
        internal ONSClientException(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets the c PTR.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ONSClientException obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ONSClientException" /> class.
        /// </summary>
        ~ONSClientException()
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
                        ONSClient4CPPPINVOKE.delete_ONSClientException(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ONSClientException" /> class.
        /// </summary>
        public ONSClientException() : this(ONSClient4CPPPINVOKE.new_ONSClientException__SWIG_0(), true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ONSClientException" /> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="error">The error.</param>
        public ONSClientException(string msg, int error) : this(ONSClient4CPPPINVOKE.new_ONSClientException__SWIG_1(msg, error), true)
        {
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the MSG.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetMsg()
        {
            string ret = ONSClient4CPPPINVOKE.ONSClientException_GetMsg(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Whats this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string what()
        {
            string ret = ONSClient4CPPPINVOKE.ONSClientException_what(swigCPtr);
            return ret;
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetError()
        {
            int ret = ONSClient4CPPPINVOKE.ONSClientException_GetError(swigCPtr);
            return ret;
        }

    }

}

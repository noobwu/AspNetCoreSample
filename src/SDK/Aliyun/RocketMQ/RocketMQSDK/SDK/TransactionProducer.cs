// ***********************************************************************
// Assembly         : RocketMQSDK
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="TransactionProducer.cs" company="NoobCore.com">
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
    /// Class TransactionProducer.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class TransactionProducer : global::System.IDisposable
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
        /// Initializes a new instance of the <see cref="TransactionProducer" /> class.
        /// </summary>
        /// <param name="cPtr">The c PTR.</param>
        /// <param name="cMemoryOwn">if set to <c>true</c> [c memory own].</param>
        internal TransactionProducer(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets the c PTR.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TransactionProducer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TransactionProducer" /> class.
        /// </summary>
        ~TransactionProducer()
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
                        ONSClient4CPPPINVOKE.delete_TransactionProducer(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public virtual void start()
        {
            ONSClient4CPPPINVOKE.TransactionProducer_start(swigCPtr);
        }

        /// <summary>
        /// Shutdowns this instance.
        /// </summary>
        public virtual void shutdown()
        {
            ONSClient4CPPPINVOKE.TransactionProducer_shutdown(swigCPtr);
        }

        /// <summary>
        /// Sends the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="executer">The executer.</param>
        /// <returns>SendResultONS.</returns>
        public virtual SendResultONS send(Message msg, LocalTransactionExecuter executer)
        {
            SendResultONS ret = new SendResultONS(ONSClient4CPPPINVOKE.TransactionProducer_send(swigCPtr, Message.getCPtr(msg), LocalTransactionExecuter.getCPtr(executer)), true);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}

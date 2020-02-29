// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="LocalTransactionExecuter.cs" company="NoobCore.com">
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
    /// Class LocalTransactionExecuter.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class LocalTransactionExecuter : global::System.IDisposable
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
        /// Initializes a new instance of the <see cref="LocalTransactionExecuter" /> class.
        /// </summary>
        /// <param name="cPtr">The c PTR.</param>
        /// <param name="cMemoryOwn">if set to <c>true</c> [c memory own].</param>
        internal LocalTransactionExecuter(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets the c PTR.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LocalTransactionExecuter obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="LocalTransactionExecuter" /> class.
        /// </summary>
        ~LocalTransactionExecuter()
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
                        ONSClient4CPPPINVOKE.delete_LocalTransactionExecuter(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalTransactionExecuter" /> class.
        /// </summary>
        public LocalTransactionExecuter() : this(ONSClient4CPPPINVOKE.new_LocalTransactionExecuter(), true)
        {
            SwigDirectorConnect();
        }

        /// <summary>
        /// Executes the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>TransactionStatus.</returns>
        public virtual TransactionStatus execute(Message msg)
        {
            TransactionStatus ret = (TransactionStatus)ONSClient4CPPPINVOKE.LocalTransactionExecuter_execute(swigCPtr, Message.getCPtr(msg));
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Swigs the director connect.
        /// </summary>
        private void SwigDirectorConnect()
        {
            if (SwigDerivedClassHasMethod("execute", swigMethodTypes0))
                swigDelegate0 = new SwigDelegateLocalTransactionExecuter_0(SwigDirectorexecute);
            ONSClient4CPPPINVOKE.LocalTransactionExecuter_director_connect(swigCPtr, swigDelegate0);
        }

        /// <summary>
        /// Swigs the derived class has method.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="methodTypes">The method types.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes)
        {
            global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
            bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(LocalTransactionExecuter));
            return hasDerivedMethod;
        }

        /// <summary>
        /// Swigs the directorexecute.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>System.Int32.</returns>
        private int SwigDirectorexecute(global::System.IntPtr msg)
        {
            return (int)execute(new Message(msg, false));
        }

        /// <summary>
        /// Delegate SwigDelegateLocalTransactionExecuter_0
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>System.Int32.</returns>
        public delegate int SwigDelegateLocalTransactionExecuter_0(global::System.IntPtr msg);

        /// <summary>
        /// The swig delegate0
        /// </summary>
        private SwigDelegateLocalTransactionExecuter_0 swigDelegate0;

        /// <summary>
        /// The swig method types0
        /// </summary>
        private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(Message) };
    }

}

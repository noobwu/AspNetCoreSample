// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="MessageOrderListener.cs" company="NoobCore.com">
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
    /// Class MessageOrderListener.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class MessageOrderListener : global::System.IDisposable
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
        /// Initializes a new instance of the <see cref="MessageOrderListener"/> class.
        /// </summary>
        /// <param name="cPtr">The c PTR.</param>
        /// <param name="cMemoryOwn">if set to <c>true</c> [c memory own].</param>
        internal MessageOrderListener(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets the c PTR.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(MessageOrderListener obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MessageOrderListener"/> class.
        /// </summary>
        ~MessageOrderListener()
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
                        ONSClient4CPPPINVOKE.delete_MessageOrderListener(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageOrderListener"/> class.
        /// </summary>
        public MessageOrderListener() : this(ONSClient4CPPPINVOKE.new_MessageOrderListener(), true)
        {
            SwigDirectorConnect();
        }

        /// <summary>
        /// Consumes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="context">The context.</param>
        /// <returns>OrderAction.</returns>
        public virtual OrderAction consume(Message message, ConsumeOrderContext context)
        {
            OrderAction ret = (OrderAction)ONSClient4CPPPINVOKE.MessageOrderListener_consume(swigCPtr, Message.getCPtr(message), ConsumeOrderContext.getCPtr(context));
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Swigs the director connect.
        /// </summary>
        private void SwigDirectorConnect()
        {
            if (SwigDerivedClassHasMethod("consume", swigMethodTypes0))
                swigDelegate0 = new SwigDelegateMessageOrderListener_0(SwigDirectorconsume);
            ONSClient4CPPPINVOKE.MessageOrderListener_director_connect(swigCPtr, swigDelegate0);
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
            bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(MessageOrderListener));
            return hasDerivedMethod;
        }

        /// <summary>
        /// Swigs the directorconsume.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="context">The context.</param>
        /// <returns>System.Int32.</returns>
        private int SwigDirectorconsume(global::System.IntPtr message, global::System.IntPtr context)
        {
            return (int)consume(new Message(message, false), new ConsumeOrderContext(context, false));
        }

        /// <summary>
        /// Delegate SwigDelegateMessageOrderListener_0
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="context">The context.</param>
        /// <returns>System.Int32.</returns>
        public delegate int SwigDelegateMessageOrderListener_0(global::System.IntPtr message, global::System.IntPtr context);

        /// <summary>
        /// The swig delegate0
        /// </summary>
        private SwigDelegateMessageOrderListener_0 swigDelegate0;

        /// <summary>
        /// The swig method types0
        /// </summary>
        private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(Message), typeof(ConsumeOrderContext) };
    }

}

// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="OrderConsumer.cs" company="NoobCore.com">
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
    /// Class OrderConsumer.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class OrderConsumer : global::System.IDisposable
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
        /// Initializes a new instance of the <see cref="OrderConsumer"/> class.
        /// </summary>
        /// <param name="cPtr">The c PTR.</param>
        /// <param name="cMemoryOwn">if set to <c>true</c> [c memory own].</param>
        internal OrderConsumer(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets the c PTR.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(OrderConsumer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="OrderConsumer"/> class.
        /// </summary>
        ~OrderConsumer()
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
                        ONSClient4CPPPINVOKE.delete_OrderConsumer(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderConsumer"/> class.
        /// </summary>
        public OrderConsumer() : this(ONSClient4CPPPINVOKE.new_OrderConsumer(), true)
        {
            SwigDirectorConnect();
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public virtual void start()
        {
            ONSClient4CPPPINVOKE.OrderConsumer_start(swigCPtr);
        }

        /// <summary>
        /// Shutdowns this instance.
        /// </summary>
        public virtual void shutdown()
        {
            ONSClient4CPPPINVOKE.OrderConsumer_shutdown(swigCPtr);
        }

        /// <summary>
        /// Subscribes the specified topic.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="subExpression">The sub expression.</param>
        /// <param name="listener">The listener.</param>
        public virtual void subscribe(string topic, string subExpression, MessageOrderListener listener)
        {
            ONSClient4CPPPINVOKE.OrderConsumer_subscribe(swigCPtr, topic, subExpression, MessageOrderListener.getCPtr(listener));
        }

        /// <summary>
        /// Swigs the director connect.
        /// </summary>
        private void SwigDirectorConnect()
        {
            if (SwigDerivedClassHasMethod("start", swigMethodTypes0))
                swigDelegate0 = new SwigDelegateOrderConsumer_0(SwigDirectorstart);
            if (SwigDerivedClassHasMethod("shutdown", swigMethodTypes1))
                swigDelegate1 = new SwigDelegateOrderConsumer_1(SwigDirectorshutdown);
            if (SwigDerivedClassHasMethod("subscribe", swigMethodTypes2))
                swigDelegate2 = new SwigDelegateOrderConsumer_2(SwigDirectorsubscribe);
            ONSClient4CPPPINVOKE.OrderConsumer_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
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
            bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(OrderConsumer));
            return hasDerivedMethod;
        }

        /// <summary>
        /// Swigs the directorstart.
        /// </summary>
        private void SwigDirectorstart()
        {
            start();
        }

        /// <summary>
        /// Swigs the directorshutdown.
        /// </summary>
        private void SwigDirectorshutdown()
        {
            shutdown();
        }

        /// <summary>
        /// Swigs the directorsubscribe.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="subExpression">The sub expression.</param>
        /// <param name="listener">The listener.</param>
        private void SwigDirectorsubscribe(string topic, string subExpression, global::System.IntPtr listener)
        {
            subscribe(topic, subExpression, (listener == global::System.IntPtr.Zero) ? null : new MessageOrderListener(listener, false));
        }

        /// <summary>
        /// Delegate SwigDelegateOrderConsumer_0
        /// </summary>
        public delegate void SwigDelegateOrderConsumer_0();
        /// <summary>
        /// Delegate SwigDelegateOrderConsumer_1
        /// </summary>
        public delegate void SwigDelegateOrderConsumer_1();
        /// <summary>
        /// Delegate SwigDelegateOrderConsumer_2
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="subExpression">The sub expression.</param>
        /// <param name="listener">The listener.</param>
        public delegate void SwigDelegateOrderConsumer_2(string topic, string subExpression, global::System.IntPtr listener);

        /// <summary>
        /// The swig delegate0
        /// </summary>
        private SwigDelegateOrderConsumer_0 swigDelegate0;
        /// <summary>
        /// The swig delegate1
        /// </summary>
        private SwigDelegateOrderConsumer_1 swigDelegate1;
        /// <summary>
        /// The swig delegate2
        /// </summary>
        private SwigDelegateOrderConsumer_2 swigDelegate2;

        /// <summary>
        /// The swig method types0
        /// </summary>
        private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { };
        /// <summary>
        /// The swig method types1
        /// </summary>
        private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] { };
        /// <summary>
        /// The swig method types2
        /// </summary>
        private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(string), typeof(string), typeof(MessageOrderListener) };
    }

}

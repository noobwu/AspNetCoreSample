// ***********************************************************************
// Assembly         : RocketMQSDK
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="OrderProducer.cs" company="NoobCore.com">
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
    /// Class OrderProducer.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class OrderProducer : global::System.IDisposable
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
        /// Initializes a new instance of the <see cref="OrderProducer" /> class.
        /// </summary>
        /// <param name="cPtr">The c PTR.</param>
        /// <param name="cMemoryOwn">if set to <c>true</c> [c memory own].</param>
        internal OrderProducer(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets the c PTR.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(OrderProducer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="OrderProducer" /> class.
        /// </summary>
        ~OrderProducer()
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
                        ONSClient4CPPPINVOKE.delete_OrderProducer(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderProducer" /> class.
        /// </summary>
        public OrderProducer() : this(ONSClient4CPPPINVOKE.new_OrderProducer(), true)
        {
            SwigDirectorConnect();
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public virtual void start()
        {
            ONSClient4CPPPINVOKE.OrderProducer_start(swigCPtr);
        }

        /// <summary>
        /// Shutdowns this instance.
        /// </summary>
        public virtual void shutdown()
        {
            ONSClient4CPPPINVOKE.OrderProducer_shutdown(swigCPtr);
        }

        /// <summary>
        /// 发送顺序消息
        /// </summary>
        /// <param name="msg">消息队列中信息传递的载体</param>
        /// <param name="shardingKey">顺序消息中用来计算不同分区的值(全局顺序消息，该字段可以设置为任意非空字符串。)</param>
        /// <returns>SendResultONS.</returns>
        public virtual SendResultONS send(Message msg, string shardingKey)
        {
            SendResultONS ret = new SendResultONS(ONSClient4CPPPINVOKE.OrderProducer_send(swigCPtr, Message.getCPtr(msg), shardingKey), true);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Swigs the director connect.
        /// </summary>
        private void SwigDirectorConnect()
        {
            if (SwigDerivedClassHasMethod("start", swigMethodTypes0))
                swigDelegate0 = new SwigDelegateOrderProducer_0(SwigDirectorstart);
            if (SwigDerivedClassHasMethod("shutdown", swigMethodTypes1))
                swigDelegate1 = new SwigDelegateOrderProducer_1(SwigDirectorshutdown);
            if (SwigDerivedClassHasMethod("send", swigMethodTypes2))
                swigDelegate2 = new SwigDelegateOrderProducer_2(SwigDirectorsend);
            ONSClient4CPPPINVOKE.OrderProducer_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
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
            bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(OrderProducer));
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
        /// Swigs the directorsend.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="shardingKey">The sharding key.</param>
        /// <returns>System.IntPtr.</returns>
        private global::System.IntPtr SwigDirectorsend(global::System.IntPtr msg, string shardingKey)
        {
            return SendResultONS.getCPtr(send(new Message(msg, false), shardingKey)).Handle;
        }

        /// <summary>
        /// Delegate SwigDelegateOrderProducer_0
        /// </summary>
        public delegate void SwigDelegateOrderProducer_0();
        /// <summary>
        /// Delegate SwigDelegateOrderProducer_1
        /// </summary>
        public delegate void SwigDelegateOrderProducer_1();
        /// <summary>
        /// Delegate SwigDelegateOrderProducer_2
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="shardingKey">The sharding key.</param>
        /// <returns>System.IntPtr.</returns>
        public delegate global::System.IntPtr SwigDelegateOrderProducer_2(global::System.IntPtr msg, string shardingKey);

        /// <summary>
        /// The swig delegate0
        /// </summary>
        private SwigDelegateOrderProducer_0 swigDelegate0;
        /// <summary>
        /// The swig delegate1
        /// </summary>
        private SwigDelegateOrderProducer_1 swigDelegate1;
        /// <summary>
        /// The swig delegate2
        /// </summary>
        private SwigDelegateOrderProducer_2 swigDelegate2;

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
        private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(Message), typeof(string) };
    }

}

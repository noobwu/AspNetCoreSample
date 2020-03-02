// ***********************************************************************
// Assembly         : RocketMQSDK
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="Producer.cs" company="NoobCore.com">
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
    /// Class Producer.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class Producer : global::System.IDisposable
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
        /// Initializes a new instance of the <see cref="Producer" /> class.
        /// </summary>
        /// <param name="cPtr">The c PTR.</param>
        /// <param name="cMemoryOwn">if set to <c>true</c> [c memory own].</param>
        internal Producer(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets the c PTR.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Producer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Producer" /> class.
        /// </summary>
        ~Producer()
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
                        ONSClient4CPPPINVOKE.delete_Producer(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Producer" /> class.
        /// </summary>
        public Producer() : this(ONSClient4CPPPINVOKE.new_Producer(), true)
        {
            SwigDirectorConnect();
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public virtual void start()
        {
            ONSClient4CPPPINVOKE.Producer_start(swigCPtr);
        }

        /// <summary>
        /// Shutdowns this instance.
        /// </summary>
        public virtual void shutdown()
        {
            ONSClient4CPPPINVOKE.Producer_shutdown(swigCPtr);
        }

        /// <summary>
        /// 发送顺序消息
        /// </summary>
        /// <param name="msg">消息队列中信息传递的载体.</param>
        /// <returns>SendResultONS.</returns>
        public virtual SendResultONS send(Message msg)
        {
            SendResultONS ret = new SendResultONS(ONSClient4CPPPINVOKE.Producer_send__SWIG_0(swigCPtr, Message.getCPtr(msg)), true);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg">消息队列中信息传递的载体.</param>
        /// <param name="mq">The mq.</param>
        /// <returns>SendResultONS.</returns>
        public virtual SendResultONS send(Message msg, MessageQueueONS mq)
        {
            SendResultONS ret = new SendResultONS(ONSClient4CPPPINVOKE.Producer_send__SWIG_1(swigCPtr, Message.getCPtr(msg), MessageQueueONS.getCPtr(mq)), true);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// 单向发送消息(发送方只负责发送消息，不等待服务端返回响应且没有回调函数触发，即只发送请求不等待应答。此方式发送消息的过程耗时非常短，一般在微秒级别。)
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public virtual void sendOneway(Message msg)
        {
            ONSClient4CPPPINVOKE.Producer_sendOneway(swigCPtr, Message.getCPtr(msg));
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Swigs the director connect.
        /// </summary>
        private void SwigDirectorConnect()
        {
            if (SwigDerivedClassHasMethod("start", swigMethodTypes0))
                swigDelegate0 = new SwigDelegateProducer_0(SwigDirectorstart);
            if (SwigDerivedClassHasMethod("shutdown", swigMethodTypes1))
                swigDelegate1 = new SwigDelegateProducer_1(SwigDirectorshutdown);
            if (SwigDerivedClassHasMethod("send", swigMethodTypes2))
                swigDelegate2 = new SwigDelegateProducer_2(SwigDirectorsend__SWIG_0);
            if (SwigDerivedClassHasMethod("send", swigMethodTypes3))
                swigDelegate3 = new SwigDelegateProducer_3(SwigDirectorsend__SWIG_1);
            if (SwigDerivedClassHasMethod("sendOneway", swigMethodTypes4))
                swigDelegate4 = new SwigDelegateProducer_4(SwigDirectorsendOneway);
            ONSClient4CPPPINVOKE.Producer_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
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
            bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(Producer));
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
        /// Swigs the directorsend swig 0.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>System.IntPtr.</returns>
        private global::System.IntPtr SwigDirectorsend__SWIG_0(global::System.IntPtr msg)
        {
            return SendResultONS.getCPtr(send(new Message(msg, false))).Handle;
        }

        /// <summary>
        /// Swigs the directorsend swig 1.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="mq">The mq.</param>
        /// <returns>System.IntPtr.</returns>
        private global::System.IntPtr SwigDirectorsend__SWIG_1(global::System.IntPtr msg, global::System.IntPtr mq)
        {
            return SendResultONS.getCPtr(send(new Message(msg, false), new MessageQueueONS(mq, false))).Handle;
        }

        /// <summary>
        /// Swigs the directorsend oneway.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        private void SwigDirectorsendOneway(global::System.IntPtr msg)
        {
            sendOneway(new Message(msg, false));
        }

        /// <summary>
        /// Delegate SwigDelegateProducer_0
        /// </summary>
        public delegate void SwigDelegateProducer_0();
        /// <summary>
        /// Delegate SwigDelegateProducer_1
        /// </summary>
        public delegate void SwigDelegateProducer_1();
        /// <summary>
        /// Delegate SwigDelegateProducer_2
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>System.IntPtr.</returns>
        public delegate global::System.IntPtr SwigDelegateProducer_2(global::System.IntPtr msg);
        /// <summary>
        /// Delegate SwigDelegateProducer_3
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="mq">The mq.</param>
        /// <returns>System.IntPtr.</returns>
        public delegate global::System.IntPtr SwigDelegateProducer_3(global::System.IntPtr msg, global::System.IntPtr mq);
        /// <summary>
        /// Delegate SwigDelegateProducer_4
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public delegate void SwigDelegateProducer_4(global::System.IntPtr msg);

        /// <summary>
        /// The swig delegate0
        /// </summary>
        private SwigDelegateProducer_0 swigDelegate0;
        /// <summary>
        /// The swig delegate1
        /// </summary>
        private SwigDelegateProducer_1 swigDelegate1;
        /// <summary>
        /// The swig delegate2
        /// </summary>
        private SwigDelegateProducer_2 swigDelegate2;
        /// <summary>
        /// The swig delegate3
        /// </summary>
        private SwigDelegateProducer_3 swigDelegate3;
        /// <summary>
        /// The swig delegate4
        /// </summary>
        private SwigDelegateProducer_4 swigDelegate4;

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
        private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(Message) };
        /// <summary>
        /// The swig method types3
        /// </summary>
        private static global::System.Type[] swigMethodTypes3 = new global::System.Type[] { typeof(Message), typeof(MessageQueueONS) };
        /// <summary>
        /// The swig method types4
        /// </summary>
        private static global::System.Type[] swigMethodTypes4 = new global::System.Type[] { typeof(Message) };
    }

}

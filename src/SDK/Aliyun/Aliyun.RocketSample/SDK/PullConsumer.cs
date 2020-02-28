// ***********************************************************************
// Assembly         : Aliyun.RocketSample
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="PullConsumer.cs" company="NoobCore.com">
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
    /// Class PullConsumer.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class PullConsumer : global::System.IDisposable
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
        /// Initializes a new instance of the <see cref="PullConsumer"/> class.
        /// </summary>
        /// <param name="cPtr">The c PTR.</param>
        /// <param name="cMemoryOwn">if set to <c>true</c> [c memory own].</param>
        internal PullConsumer(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets the c PTR.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PullConsumer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="PullConsumer"/> class.
        /// </summary>
        ~PullConsumer()
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
                        ONSClient4CPPPINVOKE.delete_PullConsumer(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PullConsumer"/> class.
        /// </summary>
        public PullConsumer() : this(ONSClient4CPPPINVOKE.new_PullConsumer(), true)
        {
            SwigDirectorConnect();
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public virtual void start()
        {
            ONSClient4CPPPINVOKE.PullConsumer_start(swigCPtr);
        }

        /// <summary>
        /// Shutdowns this instance.
        /// </summary>
        public virtual void shutdown()
        {
            ONSClient4CPPPINVOKE.PullConsumer_shutdown(swigCPtr);
        }

        /// <summary>
        /// Fetches the subscribe message queues.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="mqs">The MQS.</param>
        public virtual void fetchSubscribeMessageQueues(string topic, SWIGTYPE_p_std__vectorT_ons__MessageQueueONS_t mqs)
        {
            ONSClient4CPPPINVOKE.PullConsumer_fetchSubscribeMessageQueues(swigCPtr, topic, SWIGTYPE_p_std__vectorT_ons__MessageQueueONS_t.getCPtr(mqs));
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Pulls the specified mq.
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <param name="subExpression">The sub expression.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="maxNums">The maximum nums.</param>
        /// <returns>PullResultONS.</returns>
        public virtual PullResultONS pull(MessageQueueONS mq, string subExpression, long offset, int maxNums)
        {
            PullResultONS ret = new PullResultONS(ONSClient4CPPPINVOKE.PullConsumer_pull(swigCPtr, MessageQueueONS.getCPtr(mq), subExpression, offset, maxNums), true);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Searches the offset.
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>System.Int64.</returns>
        public virtual long searchOffset(MessageQueueONS mq, long timestamp)
        {
            long ret = ONSClient4CPPPINVOKE.PullConsumer_searchOffset(swigCPtr, MessageQueueONS.getCPtr(mq), timestamp);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Maximums the offset.
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <returns>System.Int64.</returns>
        public virtual long maxOffset(MessageQueueONS mq)
        {
            long ret = ONSClient4CPPPINVOKE.PullConsumer_maxOffset(swigCPtr, MessageQueueONS.getCPtr(mq));
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Minimums the offset.
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <returns>System.Int64.</returns>
        public virtual long minOffset(MessageQueueONS mq)
        {
            long ret = ONSClient4CPPPINVOKE.PullConsumer_minOffset(swigCPtr, MessageQueueONS.getCPtr(mq));
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Updates the consume offset.
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <param name="offset">The offset.</param>
        public virtual void updateConsumeOffset(MessageQueueONS mq, long offset)
        {
            ONSClient4CPPPINVOKE.PullConsumer_updateConsumeOffset(swigCPtr, MessageQueueONS.getCPtr(mq), offset);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes the consume offset.
        /// </summary>
        /// <param name="mq">The mq.</param>
        public virtual void removeConsumeOffset(MessageQueueONS mq)
        {
            ONSClient4CPPPINVOKE.PullConsumer_removeConsumeOffset(swigCPtr, MessageQueueONS.getCPtr(mq));
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Fetches the consume offset.
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <param name="fromStore">if set to <c>true</c> [from store].</param>
        /// <returns>System.Int64.</returns>
        public virtual long fetchConsumeOffset(MessageQueueONS mq, bool fromStore)
        {
            long ret = ONSClient4CPPPINVOKE.PullConsumer_fetchConsumeOffset(swigCPtr, MessageQueueONS.getCPtr(mq), fromStore);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Persists the consumer offset4 pull consumer.
        /// </summary>
        /// <param name="mq">The mq.</param>
        public virtual void persistConsumerOffset4PullConsumer(MessageQueueONS mq)
        {
            ONSClient4CPPPINVOKE.PullConsumer_persistConsumerOffset4PullConsumer(swigCPtr, MessageQueueONS.getCPtr(mq));
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Swigs the director connect.
        /// </summary>
        private void SwigDirectorConnect()
        {
            if (SwigDerivedClassHasMethod("start", swigMethodTypes0))
                swigDelegate0 = new SwigDelegatePullConsumer_0(SwigDirectorstart);
            if (SwigDerivedClassHasMethod("shutdown", swigMethodTypes1))
                swigDelegate1 = new SwigDelegatePullConsumer_1(SwigDirectorshutdown);
            if (SwigDerivedClassHasMethod("fetchSubscribeMessageQueues", swigMethodTypes2))
                swigDelegate2 = new SwigDelegatePullConsumer_2(SwigDirectorfetchSubscribeMessageQueues);
            if (SwigDerivedClassHasMethod("pull", swigMethodTypes3))
                swigDelegate3 = new SwigDelegatePullConsumer_3(SwigDirectorpull);
            if (SwigDerivedClassHasMethod("searchOffset", swigMethodTypes4))
                swigDelegate4 = new SwigDelegatePullConsumer_4(SwigDirectorsearchOffset);
            if (SwigDerivedClassHasMethod("maxOffset", swigMethodTypes5))
                swigDelegate5 = new SwigDelegatePullConsumer_5(SwigDirectormaxOffset);
            if (SwigDerivedClassHasMethod("minOffset", swigMethodTypes6))
                swigDelegate6 = new SwigDelegatePullConsumer_6(SwigDirectorminOffset);
            if (SwigDerivedClassHasMethod("updateConsumeOffset", swigMethodTypes7))
                swigDelegate7 = new SwigDelegatePullConsumer_7(SwigDirectorupdateConsumeOffset);
            if (SwigDerivedClassHasMethod("removeConsumeOffset", swigMethodTypes8))
                swigDelegate8 = new SwigDelegatePullConsumer_8(SwigDirectorremoveConsumeOffset);
            if (SwigDerivedClassHasMethod("fetchConsumeOffset", swigMethodTypes9))
                swigDelegate9 = new SwigDelegatePullConsumer_9(SwigDirectorfetchConsumeOffset);
            if (SwigDerivedClassHasMethod("persistConsumerOffset4PullConsumer", swigMethodTypes10))
                swigDelegate10 = new SwigDelegatePullConsumer_10(SwigDirectorpersistConsumerOffset4PullConsumer);
            ONSClient4CPPPINVOKE.PullConsumer_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
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
            bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(PullConsumer));
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
        /// Swigs the directorfetch subscribe message queues.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="mqs">The MQS.</param>
        private void SwigDirectorfetchSubscribeMessageQueues(string topic, global::System.IntPtr mqs)
        {
            fetchSubscribeMessageQueues(topic, new SWIGTYPE_p_std__vectorT_ons__MessageQueueONS_t(mqs, false));
        }

        /// <summary>
        /// Swigs the directorpull.
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <param name="subExpression">The sub expression.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="maxNums">The maximum nums.</param>
        /// <returns>System.IntPtr.</returns>
        private global::System.IntPtr SwigDirectorpull(global::System.IntPtr mq, string subExpression, long offset, int maxNums)
        {
            return PullResultONS.getCPtr(pull(new MessageQueueONS(mq, false), subExpression, offset, maxNums)).Handle;
        }

        /// <summary>
        /// Swigs the directorsearch offset.
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>System.Int64.</returns>
        private long SwigDirectorsearchOffset(global::System.IntPtr mq, long timestamp)
        {
            return searchOffset(new MessageQueueONS(mq, false), timestamp);
        }

        /// <summary>
        /// Swigs the directormax offset.
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <returns>System.Int64.</returns>
        private long SwigDirectormaxOffset(global::System.IntPtr mq)
        {
            return maxOffset(new MessageQueueONS(mq, false));
        }

        /// <summary>
        /// Swigs the directormin offset.
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <returns>System.Int64.</returns>
        private long SwigDirectorminOffset(global::System.IntPtr mq)
        {
            return minOffset(new MessageQueueONS(mq, false));
        }

        /// <summary>
        /// Swigs the directorupdate consume offset.
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <param name="offset">The offset.</param>
        private void SwigDirectorupdateConsumeOffset(global::System.IntPtr mq, long offset)
        {
            updateConsumeOffset(new MessageQueueONS(mq, false), offset);
        }

        /// <summary>
        /// Swigs the directorremove consume offset.
        /// </summary>
        /// <param name="mq">The mq.</param>
        private void SwigDirectorremoveConsumeOffset(global::System.IntPtr mq)
        {
            removeConsumeOffset(new MessageQueueONS(mq, false));
        }

        /// <summary>
        /// Swigs the directorfetch consume offset.
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <param name="fromStore">if set to <c>true</c> [from store].</param>
        /// <returns>System.Int64.</returns>
        private long SwigDirectorfetchConsumeOffset(global::System.IntPtr mq, bool fromStore)
        {
            return fetchConsumeOffset(new MessageQueueONS(mq, false), fromStore);
        }

        /// <summary>
        /// Swigs the directorpersist consumer offset4 pull consumer.
        /// </summary>
        /// <param name="mq">The mq.</param>
        private void SwigDirectorpersistConsumerOffset4PullConsumer(global::System.IntPtr mq)
        {
            persistConsumerOffset4PullConsumer(new MessageQueueONS(mq, false));
        }

        /// <summary>
        /// Delegate SwigDelegatePullConsumer_0
        /// </summary>
        public delegate void SwigDelegatePullConsumer_0();
        /// <summary>
        /// Delegate SwigDelegatePullConsumer_1
        /// </summary>
        public delegate void SwigDelegatePullConsumer_1();
        /// <summary>
        /// Delegate SwigDelegatePullConsumer_2
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="mqs">The MQS.</param>
        public delegate void SwigDelegatePullConsumer_2(string topic, global::System.IntPtr mqs);
        /// <summary>
        /// Delegate SwigDelegatePullConsumer_3
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <param name="subExpression">The sub expression.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="maxNums">The maximum nums.</param>
        /// <returns>System.IntPtr.</returns>
        public delegate global::System.IntPtr SwigDelegatePullConsumer_3(global::System.IntPtr mq, string subExpression, long offset, int maxNums);
        /// <summary>
        /// Delegate SwigDelegatePullConsumer_4
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>System.Int64.</returns>
        public delegate long SwigDelegatePullConsumer_4(global::System.IntPtr mq, long timestamp);
        /// <summary>
        /// Delegate SwigDelegatePullConsumer_5
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <returns>System.Int64.</returns>
        public delegate long SwigDelegatePullConsumer_5(global::System.IntPtr mq);
        /// <summary>
        /// Delegate SwigDelegatePullConsumer_6
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <returns>System.Int64.</returns>
        public delegate long SwigDelegatePullConsumer_6(global::System.IntPtr mq);
        /// <summary>
        /// Delegate SwigDelegatePullConsumer_7
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <param name="offset">The offset.</param>
        public delegate void SwigDelegatePullConsumer_7(global::System.IntPtr mq, long offset);
        /// <summary>
        /// Delegate SwigDelegatePullConsumer_8
        /// </summary>
        /// <param name="mq">The mq.</param>
        public delegate void SwigDelegatePullConsumer_8(global::System.IntPtr mq);
        /// <summary>
        /// Delegate SwigDelegatePullConsumer_9
        /// </summary>
        /// <param name="mq">The mq.</param>
        /// <param name="fromStore">if set to <c>true</c> [from store].</param>
        /// <returns>System.Int64.</returns>
        public delegate long SwigDelegatePullConsumer_9(global::System.IntPtr mq, bool fromStore);
        /// <summary>
        /// Delegate SwigDelegatePullConsumer_10
        /// </summary>
        /// <param name="mq">The mq.</param>
        public delegate void SwigDelegatePullConsumer_10(global::System.IntPtr mq);

        /// <summary>
        /// The swig delegate0
        /// </summary>
        private SwigDelegatePullConsumer_0 swigDelegate0;
        /// <summary>
        /// The swig delegate1
        /// </summary>
        private SwigDelegatePullConsumer_1 swigDelegate1;
        /// <summary>
        /// The swig delegate2
        /// </summary>
        private SwigDelegatePullConsumer_2 swigDelegate2;
        /// <summary>
        /// The swig delegate3
        /// </summary>
        private SwigDelegatePullConsumer_3 swigDelegate3;
        /// <summary>
        /// The swig delegate4
        /// </summary>
        private SwigDelegatePullConsumer_4 swigDelegate4;
        /// <summary>
        /// The swig delegate5
        /// </summary>
        private SwigDelegatePullConsumer_5 swigDelegate5;
        /// <summary>
        /// The swig delegate6
        /// </summary>
        private SwigDelegatePullConsumer_6 swigDelegate6;
        /// <summary>
        /// The swig delegate7
        /// </summary>
        private SwigDelegatePullConsumer_7 swigDelegate7;
        /// <summary>
        /// The swig delegate8
        /// </summary>
        private SwigDelegatePullConsumer_8 swigDelegate8;
        /// <summary>
        /// The swig delegate9
        /// </summary>
        private SwigDelegatePullConsumer_9 swigDelegate9;
        /// <summary>
        /// The swig delegate10
        /// </summary>
        private SwigDelegatePullConsumer_10 swigDelegate10;

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
        private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(string), typeof(SWIGTYPE_p_std__vectorT_ons__MessageQueueONS_t) };
        /// <summary>
        /// The swig method types3
        /// </summary>
        private static global::System.Type[] swigMethodTypes3 = new global::System.Type[] { typeof(MessageQueueONS), typeof(string), typeof(long), typeof(int) };
        /// <summary>
        /// The swig method types4
        /// </summary>
        private static global::System.Type[] swigMethodTypes4 = new global::System.Type[] { typeof(MessageQueueONS), typeof(long) };
        /// <summary>
        /// The swig method types5
        /// </summary>
        private static global::System.Type[] swigMethodTypes5 = new global::System.Type[] { typeof(MessageQueueONS) };
        /// <summary>
        /// The swig method types6
        /// </summary>
        private static global::System.Type[] swigMethodTypes6 = new global::System.Type[] { typeof(MessageQueueONS) };
        /// <summary>
        /// The swig method types7
        /// </summary>
        private static global::System.Type[] swigMethodTypes7 = new global::System.Type[] { typeof(MessageQueueONS), typeof(long) };
        /// <summary>
        /// The swig method types8
        /// </summary>
        private static global::System.Type[] swigMethodTypes8 = new global::System.Type[] { typeof(MessageQueueONS) };
        /// <summary>
        /// The swig method types9
        /// </summary>
        private static global::System.Type[] swigMethodTypes9 = new global::System.Type[] { typeof(MessageQueueONS), typeof(bool) };
        /// <summary>
        /// The swig method types10
        /// </summary>
        private static global::System.Type[] swigMethodTypes10 = new global::System.Type[] { typeof(MessageQueueONS) };
    }

}

// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample.NETCore
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="ONSFactoryAPI.cs" company="Aliyun.RocketMQSample.NETCore">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The ons namespace.
/// </summary>
namespace ons
{

    /// <summary>
    /// Class ONSFactoryAPI.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ONSFactoryAPI : global::System.IDisposable
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
        /// Initializes a new instance of the <see cref="ONSFactoryAPI"/> class.
        /// </summary>
        /// <param name="cPtr">The c PTR.</param>
        /// <param name="cMemoryOwn">if set to <c>true</c> [c memory own].</param>
        internal ONSFactoryAPI(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets the c PTR.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ONSFactoryAPI obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ONSFactoryAPI"/> class.
        /// </summary>
        ~ONSFactoryAPI()
        {
            Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
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
                        ONSClient4CPPPINVOKE.delete_ONSFactoryAPI(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ONSFactoryAPI"/> class.
        /// </summary>
        public ONSFactoryAPI() : this(ONSClient4CPPPINVOKE.new_ONSFactoryAPI(), true)
        {
        }

        /// <summary>
        /// Creates the producer.
        /// </summary>
        /// <param name="factoryProperty">The factory property.</param>
        /// <returns>Producer.</returns>
        public virtual Producer createProducer(ONSFactoryProperty factoryProperty)
        {
            global::System.IntPtr cPtr = ONSClient4CPPPINVOKE.ONSFactoryAPI_createProducer(swigCPtr, ONSFactoryProperty.getCPtr(factoryProperty));
            Producer ret = (cPtr == global::System.IntPtr.Zero) ? null : new Producer(cPtr, false);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates the order producer.
        /// </summary>
        /// <param name="factoryProperty">The factory property.</param>
        /// <returns>OrderProducer.</returns>
        public virtual OrderProducer createOrderProducer(ONSFactoryProperty factoryProperty)
        {
            global::System.IntPtr cPtr = ONSClient4CPPPINVOKE.ONSFactoryAPI_createOrderProducer(swigCPtr, ONSFactoryProperty.getCPtr(factoryProperty));
            OrderProducer ret = (cPtr == global::System.IntPtr.Zero) ? null : new OrderProducer(cPtr, false);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates the order consumer.
        /// </summary>
        /// <param name="factoryProperty">The factory property.</param>
        /// <returns>OrderConsumer.</returns>
        public virtual OrderConsumer createOrderConsumer(ONSFactoryProperty factoryProperty)
        {
            global::System.IntPtr cPtr = ONSClient4CPPPINVOKE.ONSFactoryAPI_createOrderConsumer(swigCPtr, ONSFactoryProperty.getCPtr(factoryProperty));
            OrderConsumer ret = (cPtr == global::System.IntPtr.Zero) ? null : new OrderConsumer(cPtr, false);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates the transaction producer.
        /// </summary>
        /// <param name="factoryProperty">The factory property.</param>
        /// <param name="checker">The checker.</param>
        /// <returns>TransactionProducer.</returns>
        public virtual TransactionProducer createTransactionProducer(ONSFactoryProperty factoryProperty, LocalTransactionChecker checker)
        {
            global::System.IntPtr cPtr = ONSClient4CPPPINVOKE.ONSFactoryAPI_createTransactionProducer(swigCPtr, ONSFactoryProperty.getCPtr(factoryProperty), LocalTransactionChecker.getCPtr(checker));
            TransactionProducer ret = (cPtr == global::System.IntPtr.Zero) ? null : new TransactionProducer(cPtr, false);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates the pull consumer.
        /// </summary>
        /// <param name="factoryProperty">The factory property.</param>
        /// <returns>PullConsumer.</returns>
        public virtual PullConsumer createPullConsumer(ONSFactoryProperty factoryProperty)
        {
            global::System.IntPtr cPtr = ONSClient4CPPPINVOKE.ONSFactoryAPI_createPullConsumer(swigCPtr, ONSFactoryProperty.getCPtr(factoryProperty));
            PullConsumer ret = (cPtr == global::System.IntPtr.Zero) ? null : new PullConsumer(cPtr, false);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates the push consumer.
        /// </summary>
        /// <param name="factoryProperty">The factory property.</param>
        /// <returns>PushConsumer.</returns>
        public virtual PushConsumer createPushConsumer(ONSFactoryProperty factoryProperty)
        {
            global::System.IntPtr cPtr = ONSClient4CPPPINVOKE.ONSFactoryAPI_createPushConsumer(swigCPtr, ONSFactoryProperty.getCPtr(factoryProperty));
            PushConsumer ret = (cPtr == global::System.IntPtr.Zero) ? null : new PushConsumer(cPtr, false);
            if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}

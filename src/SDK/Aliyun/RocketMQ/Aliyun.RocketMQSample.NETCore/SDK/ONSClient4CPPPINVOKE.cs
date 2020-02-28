// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample.NETCore
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="ONSClient4CPPPINVOKE.cs" company="Aliyun.RocketMQSample.NETCore">
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
    /// Class ONSClient4CPPPINVOKE.
    /// </summary>
    class ONSClient4CPPPINVOKE
    {

        /// <summary>
        /// Class SWIGExceptionHelper.
        /// </summary>
        protected class SWIGExceptionHelper
        {

            /// <summary>
            /// Delegate ExceptionDelegate
            /// </summary>
            /// <param name="message">The message.</param>
            public delegate void ExceptionDelegate(string message);
            /// <summary>
            /// Delegate ExceptionArgumentDelegate
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="paramName">Name of the parameter.</param>
            public delegate void ExceptionArgumentDelegate(string message, string paramName);

            /// <summary>
            /// The application delegate
            /// </summary>
            static ExceptionDelegate applicationDelegate = new ExceptionDelegate(SetPendingApplicationException);
            /// <summary>
            /// The arithmetic delegate
            /// </summary>
            static ExceptionDelegate arithmeticDelegate = new ExceptionDelegate(SetPendingArithmeticException);
            /// <summary>
            /// The divide by zero delegate
            /// </summary>
            static ExceptionDelegate divideByZeroDelegate = new ExceptionDelegate(SetPendingDivideByZeroException);
            /// <summary>
            /// The index out of range delegate
            /// </summary>
            static ExceptionDelegate indexOutOfRangeDelegate = new ExceptionDelegate(SetPendingIndexOutOfRangeException);
            /// <summary>
            /// The invalid cast delegate
            /// </summary>
            static ExceptionDelegate invalidCastDelegate = new ExceptionDelegate(SetPendingInvalidCastException);
            /// <summary>
            /// The invalid operation delegate
            /// </summary>
            static ExceptionDelegate invalidOperationDelegate = new ExceptionDelegate(SetPendingInvalidOperationException);
            /// <summary>
            /// The io delegate
            /// </summary>
            static ExceptionDelegate ioDelegate = new ExceptionDelegate(SetPendingIOException);
            /// <summary>
            /// The null reference delegate
            /// </summary>
            static ExceptionDelegate nullReferenceDelegate = new ExceptionDelegate(SetPendingNullReferenceException);
            /// <summary>
            /// The out of memory delegate
            /// </summary>
            static ExceptionDelegate outOfMemoryDelegate = new ExceptionDelegate(SetPendingOutOfMemoryException);
            /// <summary>
            /// The overflow delegate
            /// </summary>
            static ExceptionDelegate overflowDelegate = new ExceptionDelegate(SetPendingOverflowException);
            /// <summary>
            /// The system delegate
            /// </summary>
            static ExceptionDelegate systemDelegate = new ExceptionDelegate(SetPendingSystemException);

            /// <summary>
            /// The argument delegate
            /// </summary>
            static ExceptionArgumentDelegate argumentDelegate = new ExceptionArgumentDelegate(SetPendingArgumentException);
            /// <summary>
            /// The argument null delegate
            /// </summary>
            static ExceptionArgumentDelegate argumentNullDelegate = new ExceptionArgumentDelegate(SetPendingArgumentNullException);
            /// <summary>
            /// The argument out of range delegate
            /// </summary>
            static ExceptionArgumentDelegate argumentOutOfRangeDelegate = new ExceptionArgumentDelegate(SetPendingArgumentOutOfRangeException);

            /// <summary>
            /// Swigs the register exception callbacks ons client4 CPP.
            /// </summary>
            /// <param name="applicationDelegate">The application delegate.</param>
            /// <param name="arithmeticDelegate">The arithmetic delegate.</param>
            /// <param name="divideByZeroDelegate">The divide by zero delegate.</param>
            /// <param name="indexOutOfRangeDelegate">The index out of range delegate.</param>
            /// <param name="invalidCastDelegate">The invalid cast delegate.</param>
            /// <param name="invalidOperationDelegate">The invalid operation delegate.</param>
            /// <param name="ioDelegate">The io delegate.</param>
            /// <param name="nullReferenceDelegate">The null reference delegate.</param>
            /// <param name="outOfMemoryDelegate">The out of memory delegate.</param>
            /// <param name="overflowDelegate">The overflow delegate.</param>
            /// <param name="systemExceptionDelegate">The system exception delegate.</param>
            [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "SWIGRegisterExceptionCallbacks_ONSClient4CPP")]
            public static extern void SWIGRegisterExceptionCallbacks_ONSClient4CPP(
                                        ExceptionDelegate applicationDelegate,
                                        ExceptionDelegate arithmeticDelegate,
                                        ExceptionDelegate divideByZeroDelegate,
                                        ExceptionDelegate indexOutOfRangeDelegate,
                                        ExceptionDelegate invalidCastDelegate,
                                        ExceptionDelegate invalidOperationDelegate,
                                        ExceptionDelegate ioDelegate,
                                        ExceptionDelegate nullReferenceDelegate,
                                        ExceptionDelegate outOfMemoryDelegate,
                                        ExceptionDelegate overflowDelegate,
                                        ExceptionDelegate systemExceptionDelegate);

            /// <summary>
            /// Swigs the register exception callbacks argument ons client4 CPP.
            /// </summary>
            /// <param name="argumentDelegate">The argument delegate.</param>
            /// <param name="argumentNullDelegate">The argument null delegate.</param>
            /// <param name="argumentOutOfRangeDelegate">The argument out of range delegate.</param>
            [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_ONSClient4CPP")]
            public static extern void SWIGRegisterExceptionCallbacksArgument_ONSClient4CPP(
                                        ExceptionArgumentDelegate argumentDelegate,
                                        ExceptionArgumentDelegate argumentNullDelegate,
                                        ExceptionArgumentDelegate argumentOutOfRangeDelegate);

            /// <summary>
            /// Sets the pending application exception.
            /// </summary>
            /// <param name="message">The message.</param>
            static void SetPendingApplicationException(string message)
            {
                SWIGPendingException.Set(new global::System.ApplicationException(message, SWIGPendingException.Retrieve()));
            }
            /// <summary>
            /// Sets the pending arithmetic exception.
            /// </summary>
            /// <param name="message">The message.</param>
            static void SetPendingArithmeticException(string message)
            {
                SWIGPendingException.Set(new global::System.ArithmeticException(message, SWIGPendingException.Retrieve()));
            }
            /// <summary>
            /// Sets the pending divide by zero exception.
            /// </summary>
            /// <param name="message">The message.</param>
            static void SetPendingDivideByZeroException(string message)
            {
                SWIGPendingException.Set(new global::System.DivideByZeroException(message, SWIGPendingException.Retrieve()));
            }
            /// <summary>
            /// Sets the pending index out of range exception.
            /// </summary>
            /// <param name="message">The message.</param>
            static void SetPendingIndexOutOfRangeException(string message)
            {
                SWIGPendingException.Set(new global::System.IndexOutOfRangeException(message, SWIGPendingException.Retrieve()));
            }
            /// <summary>
            /// Sets the pending invalid cast exception.
            /// </summary>
            /// <param name="message">The message.</param>
            static void SetPendingInvalidCastException(string message)
            {
                SWIGPendingException.Set(new global::System.InvalidCastException(message, SWIGPendingException.Retrieve()));
            }
            /// <summary>
            /// Sets the pending invalid operation exception.
            /// </summary>
            /// <param name="message">The message.</param>
            static void SetPendingInvalidOperationException(string message)
            {
                SWIGPendingException.Set(new global::System.InvalidOperationException(message, SWIGPendingException.Retrieve()));
            }
            /// <summary>
            /// Sets the pending io exception.
            /// </summary>
            /// <param name="message">The message.</param>
            static void SetPendingIOException(string message)
            {
                SWIGPendingException.Set(new global::System.IO.IOException(message, SWIGPendingException.Retrieve()));
            }
            /// <summary>
            /// Sets the pending null reference exception.
            /// </summary>
            /// <param name="message">The message.</param>
            static void SetPendingNullReferenceException(string message)
            {
                SWIGPendingException.Set(new global::System.NullReferenceException(message, SWIGPendingException.Retrieve()));
            }
            /// <summary>
            /// Sets the pending out of memory exception.
            /// </summary>
            /// <param name="message">The message.</param>
            static void SetPendingOutOfMemoryException(string message)
            {
                SWIGPendingException.Set(new global::System.OutOfMemoryException(message, SWIGPendingException.Retrieve()));
            }
            /// <summary>
            /// Sets the pending overflow exception.
            /// </summary>
            /// <param name="message">The message.</param>
            static void SetPendingOverflowException(string message)
            {
                SWIGPendingException.Set(new global::System.OverflowException(message, SWIGPendingException.Retrieve()));
            }
            /// <summary>
            /// Sets the pending system exception.
            /// </summary>
            /// <param name="message">The message.</param>
            static void SetPendingSystemException(string message)
            {
                SWIGPendingException.Set(new global::System.SystemException(message, SWIGPendingException.Retrieve()));
            }

            /// <summary>
            /// Sets the pending argument exception.
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="paramName">Name of the parameter.</param>
            static void SetPendingArgumentException(string message, string paramName)
            {
                SWIGPendingException.Set(new global::System.ArgumentException(message, paramName, SWIGPendingException.Retrieve()));
            }
            /// <summary>
            /// Sets the pending argument null exception.
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="paramName">Name of the parameter.</param>
            static void SetPendingArgumentNullException(string message, string paramName)
            {
                global::System.Exception e = SWIGPendingException.Retrieve();
                if (e != null) message = message + " Inner Exception: " + e.Message;
                SWIGPendingException.Set(new global::System.ArgumentNullException(paramName, message));
            }
            /// <summary>
            /// Sets the pending argument out of range exception.
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="paramName">Name of the parameter.</param>
            static void SetPendingArgumentOutOfRangeException(string message, string paramName)
            {
                global::System.Exception e = SWIGPendingException.Retrieve();
                if (e != null) message = message + " Inner Exception: " + e.Message;
                SWIGPendingException.Set(new global::System.ArgumentOutOfRangeException(paramName, message));
            }

            /// <summary>
            /// Initializes static members of the <see cref="SWIGExceptionHelper"/> class.
            /// </summary>
            static SWIGExceptionHelper()
            {
                SWIGRegisterExceptionCallbacks_ONSClient4CPP(
                                          applicationDelegate,
                                          arithmeticDelegate,
                                          divideByZeroDelegate,
                                          indexOutOfRangeDelegate,
                                          invalidCastDelegate,
                                          invalidOperationDelegate,
                                          ioDelegate,
                                          nullReferenceDelegate,
                                          outOfMemoryDelegate,
                                          overflowDelegate,
                                          systemDelegate);

                SWIGRegisterExceptionCallbacksArgument_ONSClient4CPP(
                                          argumentDelegate,
                                          argumentNullDelegate,
                                          argumentOutOfRangeDelegate);
            }
        }

        /// <summary>
        /// The swig exception helper
        /// </summary>
        protected static SWIGExceptionHelper swigExceptionHelper = new SWIGExceptionHelper();

        /// <summary>
        /// Class SWIGPendingException.
        /// </summary>
        public class SWIGPendingException
        {
            /// <summary>
            /// The pending exception
            /// </summary>
            [global::System.ThreadStatic]
            private static global::System.Exception pendingException = null;
            /// <summary>
            /// The number exceptions pending
            /// </summary>
            private static int numExceptionsPending = 0;

            /// <summary>
            /// Gets a value indicating whether this <see cref="SWIGPendingException"/> is pending.
            /// </summary>
            /// <value><c>true</c> if pending; otherwise, <c>false</c>.</value>
            public static bool Pending
            {
                get
                {
                    bool pending = false;
                    if (numExceptionsPending > 0)
                        if (pendingException != null)
                            pending = true;
                    return pending;
                }
            }

            /// <summary>
            /// Sets the specified e.
            /// </summary>
            /// <param name="e">The e.</param>
            /// <exception cref="System.ApplicationException">FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + pendingException.ToString() + ")</exception>
            public static void Set(global::System.Exception e)
            {
                if (pendingException != null)
                    throw new global::System.ApplicationException("FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + pendingException.ToString() + ")", e);
                pendingException = e;
                lock (typeof(ONSClient4CPPPINVOKE))
                {
                    numExceptionsPending++;
                }
            }

            /// <summary>
            /// Retrieves this instance.
            /// </summary>
            /// <returns>System.Exception.</returns>
            public static global::System.Exception Retrieve()
            {
                global::System.Exception e = null;
                if (numExceptionsPending > 0)
                {
                    if (pendingException != null)
                    {
                        e = pendingException;
                        pendingException = null;
                        lock (typeof(ONSClient4CPPPINVOKE))
                        {
                            numExceptionsPending--;
                        }
                    }
                }
                return e;
            }
        }


        /// <summary>
        /// Class SWIGStringHelper.
        /// </summary>
        protected class SWIGStringHelper
        {

            /// <summary>
            /// Delegate SWIGStringDelegate
            /// </summary>
            /// <param name="message">The message.</param>
            /// <returns>System.String.</returns>
            public delegate string SWIGStringDelegate(string message);
            /// <summary>
            /// The string delegate
            /// </summary>
            static SWIGStringDelegate stringDelegate = new SWIGStringDelegate(CreateString);

            /// <summary>
            /// Swigs the register string callback ons client4 CPP.
            /// </summary>
            /// <param name="stringDelegate">The string delegate.</param>
            [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "SWIGRegisterStringCallback_ONSClient4CPP")]
            public static extern void SWIGRegisterStringCallback_ONSClient4CPP(SWIGStringDelegate stringDelegate);

            /// <summary>
            /// Creates the string.
            /// </summary>
            /// <param name="cString">The c string.</param>
            /// <returns>System.String.</returns>
            static string CreateString(string cString)
            {
                return cString;
            }

            /// <summary>
            /// Initializes static members of the <see cref="SWIGStringHelper"/> class.
            /// </summary>
            static SWIGStringHelper()
            {
                SWIGRegisterStringCallback_ONSClient4CPP(stringDelegate);
            }
        }

        /// <summary>
        /// The swig string helper
        /// </summary>
        static protected SWIGStringHelper swigStringHelper = new SWIGStringHelper();


        /// <summary>
        /// Initializes static members of the <see cref="ONSClient4CPPPINVOKE"/> class.
        /// </summary>
        static ONSClient4CPPPINVOKE()
        {
        }


        /// <summary>
        /// News the system property key.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_SystemPropKey")]
        public static extern global::System.IntPtr new_SystemPropKey();

        /// <summary>
        /// Deletes the system property key.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_SystemPropKey")]
        public static extern void delete_SystemPropKey(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Systems the property key tag set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_SystemPropKey_TAG_set")]
        public static extern void SystemPropKey_TAG_set(string jarg1);

        /// <summary>
        /// Systems the property key tag get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_SystemPropKey_TAG_get")]
        public static extern string SystemPropKey_TAG_get();

        /// <summary>
        /// Systems the property key key set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_SystemPropKey_KEY_set")]
        public static extern void SystemPropKey_KEY_set(string jarg1);

        /// <summary>
        /// Systems the property key key get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_SystemPropKey_KEY_get")]
        public static extern string SystemPropKey_KEY_get();

        /// <summary>
        /// Systems the property key msgid set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_SystemPropKey_MSGID_set")]
        public static extern void SystemPropKey_MSGID_set(string jarg1);

        /// <summary>
        /// Systems the property key msgid get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_SystemPropKey_MSGID_get")]
        public static extern string SystemPropKey_MSGID_get();

        /// <summary>
        /// Systems the property key reconsumetimes set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_SystemPropKey_RECONSUMETIMES_set")]
        public static extern void SystemPropKey_RECONSUMETIMES_set(string jarg1);

        /// <summary>
        /// Systems the property key reconsumetimes get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_SystemPropKey_RECONSUMETIMES_get")]
        public static extern string SystemPropKey_RECONSUMETIMES_get();

        /// <summary>
        /// Systems the property key startdelivertime set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_SystemPropKey_STARTDELIVERTIME_set")]
        public static extern void SystemPropKey_STARTDELIVERTIME_set(string jarg1);

        /// <summary>
        /// Systems the property key startdelivertime get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_SystemPropKey_STARTDELIVERTIME_get")]
        public static extern string SystemPropKey_STARTDELIVERTIME_get();

        /// <summary>
        /// News the message swig 0.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_Message__SWIG_0")]
        public static extern global::System.IntPtr new_Message__SWIG_0();

        /// <summary>
        /// News the message swig 1.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_Message__SWIG_1")]
        public static extern global::System.IntPtr new_Message__SWIG_1(string jarg1, string jarg2, string jarg3);

        /// <summary>
        /// News the message swig 3.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <param name="jarg4">The jarg4.</param>
        /// <param name="jarg5">The jarg5.</param>
        /// <param name="jarg6">The jarg6.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_Message__SWIG_3")]
        public static extern global::System.IntPtr new_Message__SWIG_3(string jarg1, uint jarg2, string jarg3, uint jarg4, string jarg5, uint jarg6);

        /// <summary>
        /// News the message swig 4.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <param name="jarg4">The jarg4.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_Message__SWIG_4")]
        public static extern global::System.IntPtr new_Message__SWIG_4(string jarg1, string jarg2, string jarg3, string jarg4);

        /// <summary>
        /// Deletes the message.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_Message")]
        public static extern void delete_Message(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// News the message swig 5.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_Message__SWIG_5")]
        public static extern global::System.IntPtr new_Message__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the put user properties.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_putUserProperties")]
        public static extern void Message_putUserProperties(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3);

        /// <summary>
        /// Messages the get user properties swig 0.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_getUserProperties__SWIG_0")]
        public static extern string Message_getUserProperties__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        /// <summary>
        /// Messages the set user properties.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_setUserProperties")]
        public static extern void Message_setUserProperties(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Messages the get user properties swig 1.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_getUserProperties__SWIG_1")]
        public static extern global::System.IntPtr Message_getUserProperties__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the put system properties.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_putSystemProperties")]
        public static extern void Message_putSystemProperties(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3);

        /// <summary>
        /// Messages the get system properties swig 0.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_getSystemProperties__SWIG_0")]
        public static extern string Message_getSystemProperties__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        /// <summary>
        /// Messages the set system properties.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_setSystemProperties")]
        public static extern void Message_setSystemProperties(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Messages the get system properties swig 1.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_getSystemProperties__SWIG_1")]
        public static extern global::System.IntPtr Message_getSystemProperties__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the get topic.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_getTopic")]
        public static extern string Message_getTopic(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the set topic.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_setTopic")]
        public static extern void Message_setTopic(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        /// <summary>
        /// Messages the get tag.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_getTag")]
        public static extern string Message_getTag(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the set tag.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_setTag")]
        public static extern void Message_setTag(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        /// <summary>
        /// Messages the get key.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_getKey")]
        public static extern string Message_getKey(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the set key.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_setKey")]
        public static extern void Message_setKey(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        /// <summary>
        /// Messages the get MSG identifier.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_getMsgID")]
        public static extern string Message_getMsgID(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the set MSG identifier.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_setMsgID")]
        public static extern void Message_setMsgID(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        /// <summary>
        /// Messages the get start deliver time.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int64.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_getStartDeliverTime")]
        public static extern long Message_getStartDeliverTime(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the set start deliver time.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_setStartDeliverTime")]
        public static extern void Message_setStartDeliverTime(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2);

        /// <summary>
        /// Messages the get body.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_getBody")]
        public static extern string Message_getBody(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the get MSG body.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_getMsgBody")]
        public static extern string Message_getMsgBody(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the set MSG body.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_setMsgBody")]
        public static extern void Message_setMsgBody(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        /// <summary>
        /// Messages the set body.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_setBody")]
        public static extern void Message_setBody(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg2, int jarg3);

        /// <summary>
        /// Messages the get reconsume times.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int32.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_getReconsumeTimes")]
        public static extern int Message_getReconsumeTimes(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the set reconsume times.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_setReconsumeTimes")]
        public static extern void Message_setReconsumeTimes(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        /// <summary>
        /// Messages the get store timestamp.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int64.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_getStoreTimestamp")]
        public static extern long Message_getStoreTimestamp(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the set store timestamp.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_setStoreTimestamp")]
        public static extern void Message_setStoreTimestamp(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2);

        /// <summary>
        /// Messages to string.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_toString")]
        public static extern string Message_toString(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages to system string.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_toSystemString")]
        public static extern string Message_toSystemString(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages to user string.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_toUserString")]
        public static extern string Message_toUserString(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the get queue offset.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int64.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_getQueueOffset")]
        public static extern long Message_getQueueOffset(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the set queue offset.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Message_setQueueOffset")]
        public static extern void Message_setQueueOffset(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2);

        /// <summary>
        /// News the message queue ons swig 0.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_MessageQueueONS__SWIG_0")]
        public static extern global::System.IntPtr new_MessageQueueONS__SWIG_0();

        /// <summary>
        /// News the message queue ons swig 1.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_MessageQueueONS__SWIG_1")]
        public static extern global::System.IntPtr new_MessageQueueONS__SWIG_1(string jarg1, string jarg2, int jarg3);

        /// <summary>
        /// News the message queue ons swig 2.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_MessageQueueONS__SWIG_2")]
        public static extern global::System.IntPtr new_MessageQueueONS__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the queue ons get topic.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_MessageQueueONS_getTopic")]
        public static extern string MessageQueueONS_getTopic(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the queue ons set topic.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_MessageQueueONS_setTopic")]
        public static extern void MessageQueueONS_setTopic(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        /// <summary>
        /// Messages the name of the queue ons get broker.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_MessageQueueONS_getBrokerName")]
        public static extern string MessageQueueONS_getBrokerName(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the name of the queue ons set broker.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_MessageQueueONS_setBrokerName")]
        public static extern void MessageQueueONS_setBrokerName(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        /// <summary>
        /// Messages the queue ons get queue identifier.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int32.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_MessageQueueONS_getQueueId")]
        public static extern int MessageQueueONS_getQueueId(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the queue ons set queue identifier.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_MessageQueueONS_setQueueId")]
        public static extern void MessageQueueONS_setQueueId(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        /// <summary>
        /// Messages the queue ons compare to.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <returns>System.Int32.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_MessageQueueONS_compareTo")]
        public static extern int MessageQueueONS_compareTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Deletes the message queue ons.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_MessageQueueONS")]
        public static extern void delete_MessageQueueONS(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// News the ons client exception swig 0.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_ONSClientException__SWIG_0")]
        public static extern global::System.IntPtr new_ONSClientException__SWIG_0();

        /// <summary>
        /// Deletes the ons client exception.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_ONSClientException")]
        public static extern void delete_ONSClientException(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// News the ons client exception swig 1.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_ONSClientException__SWIG_1")]
        public static extern global::System.IntPtr new_ONSClientException__SWIG_1(string jarg1, int jarg2);

        /// <summary>
        /// Onses the client exception get MSG.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSClientException_GetMsg")]
        public static extern string ONSClientException_GetMsg(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the client exception what.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSClientException_what")]
        public static extern string ONSClientException_what(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the client exception get error.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int32.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSClientException_GetError")]
        public static extern int ONSClientException_GetError(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// News the send result ons.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_SendResultONS")]
        public static extern global::System.IntPtr new_SendResultONS();

        /// <summary>
        /// Deletes the send result ons.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_SendResultONS")]
        public static extern void delete_SendResultONS(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Sends the result ons set message identifier.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_SendResultONS_setMessageId")]
        public static extern void SendResultONS_setMessageId(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

        /// <summary>
        /// Sends the result ons get message identifier.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_SendResultONS_getMessageId")]
        public static extern string SendResultONS_getMessageId(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// News the pull result ons swig 0.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_PullResultONS__SWIG_0")]
        public static extern global::System.IntPtr new_PullResultONS__SWIG_0(int jarg1);

        /// <summary>
        /// News the pull result ons swig 1.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <param name="jarg4">The jarg4.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_PullResultONS__SWIG_1")]
        public static extern global::System.IntPtr new_PullResultONS__SWIG_1(int jarg1, long jarg2, long jarg3, long jarg4);

        /// <summary>
        /// Deletes the pull result ons.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_PullResultONS")]
        public static extern void delete_PullResultONS(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Pulls the result ons pull status set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullResultONS_pullStatus_set")]
        public static extern void PullResultONS_pullStatus_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        /// <summary>
        /// Pulls the result ons pull status get.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int32.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullResultONS_pullStatus_get")]
        public static extern int PullResultONS_pullStatus_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Pulls the result ons next begin offset set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullResultONS_nextBeginOffset_set")]
        public static extern void PullResultONS_nextBeginOffset_set(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2);

        /// <summary>
        /// Pulls the result ons next begin offset get.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int64.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullResultONS_nextBeginOffset_get")]
        public static extern long PullResultONS_nextBeginOffset_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Pulls the result ons minimum offset set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullResultONS_minOffset_set")]
        public static extern void PullResultONS_minOffset_set(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2);

        /// <summary>
        /// Pulls the result ons minimum offset get.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int64.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullResultONS_minOffset_get")]
        public static extern long PullResultONS_minOffset_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Pulls the result ons maximum offset set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullResultONS_maxOffset_set")]
        public static extern void PullResultONS_maxOffset_set(global::System.Runtime.InteropServices.HandleRef jarg1, long jarg2);

        /// <summary>
        /// Pulls the result ons maximum offset get.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int64.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullResultONS_maxOffset_get")]
        public static extern long PullResultONS_maxOffset_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Pulls the result ons MSG found list set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullResultONS_msgFoundList_set")]
        public static extern void PullResultONS_msgFoundList_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Pulls the result ons MSG found list get.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullResultONS_msgFoundList_get")]
        public static extern global::System.IntPtr PullResultONS_msgFoundList_get(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// News the consume context.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_ConsumeContext")]
        public static extern global::System.IntPtr new_ConsumeContext();

        /// <summary>
        /// Deletes the consume context.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_ConsumeContext")]
        public static extern void delete_ConsumeContext(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// News the consume order context.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_ConsumeOrderContext")]
        public static extern global::System.IntPtr new_ConsumeOrderContext();

        /// <summary>
        /// Deletes the consume order context.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_ConsumeOrderContext")]
        public static extern void delete_ConsumeOrderContext(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// News the message order listener.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_MessageOrderListener")]
        public static extern global::System.IntPtr new_MessageOrderListener();

        /// <summary>
        /// Deletes the message order listener.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_MessageOrderListener")]
        public static extern void delete_MessageOrderListener(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the order listener consume.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <returns>System.Int32.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_MessageOrderListener_consume")]
        public static extern int MessageOrderListener_consume(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        /// <summary>
        /// Messages the order listener director connect.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="delegate0">The delegate0.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_MessageOrderListener_director_connect")]
        public static extern void MessageOrderListener_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, MessageOrderListener.SwigDelegateMessageOrderListener_0 delegate0);

        /// <summary>
        /// News the message listener.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_MessageListener")]
        public static extern global::System.IntPtr new_MessageListener();

        /// <summary>
        /// Deletes the message listener.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_MessageListener")]
        public static extern void delete_MessageListener(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Messages the listener consume.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <returns>System.Int32.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_MessageListener_consume")]
        public static extern int MessageListener_consume(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        /// <summary>
        /// Messages the listener director connect.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="delegate0">The delegate0.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_MessageListener_director_connect")]
        public static extern void MessageListener_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, MessageListener.SwigDelegateMessageListener_0 delegate0);

        /// <summary>
        /// News the local transaction checker.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_LocalTransactionChecker")]
        public static extern global::System.IntPtr new_LocalTransactionChecker();

        /// <summary>
        /// Locals the transaction checker check.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <returns>System.Int32.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_LocalTransactionChecker_check")]
        public static extern int LocalTransactionChecker_check(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Deletes the local transaction checker.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_LocalTransactionChecker")]
        public static extern void delete_LocalTransactionChecker(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Locals the transaction checker director connect.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="delegate0">The delegate0.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_LocalTransactionChecker_director_connect")]
        public static extern void LocalTransactionChecker_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, LocalTransactionChecker.SwigDelegateLocalTransactionChecker_0 delegate0);

        /// <summary>
        /// News the local transaction executer.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_LocalTransactionExecuter")]
        public static extern global::System.IntPtr new_LocalTransactionExecuter();

        /// <summary>
        /// Locals the transaction executer execute.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <returns>System.Int32.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_LocalTransactionExecuter_execute")]
        public static extern int LocalTransactionExecuter_execute(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Deletes the local transaction executer.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_LocalTransactionExecuter")]
        public static extern void delete_LocalTransactionExecuter(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Locals the transaction executer director connect.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="delegate0">The delegate0.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_LocalTransactionExecuter_director_connect")]
        public static extern void LocalTransactionExecuter_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, LocalTransactionExecuter.SwigDelegateLocalTransactionExecuter_0 delegate0);

        /// <summary>
        /// News the producer.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_Producer")]
        public static extern global::System.IntPtr new_Producer();

        /// <summary>
        /// Deletes the producer.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_Producer")]
        public static extern void delete_Producer(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Producers the start.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Producer_start")]
        public static extern void Producer_start(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Producers the shutdown.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Producer_shutdown")]
        public static extern void Producer_shutdown(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Producers the send swig 0.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Producer_send__SWIG_0")]
        public static extern global::System.IntPtr Producer_send__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Producers the send swig 1.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Producer_send__SWIG_1")]
        public static extern global::System.IntPtr Producer_send__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        /// <summary>
        /// Producers the send oneway.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Producer_sendOneway")]
        public static extern void Producer_sendOneway(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Producers the director connect.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="delegate0">The delegate0.</param>
        /// <param name="delegate1">The delegate1.</param>
        /// <param name="delegate2">The delegate2.</param>
        /// <param name="delegate3">The delegate3.</param>
        /// <param name="delegate4">The delegate4.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_Producer_director_connect")]
        public static extern void Producer_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, Producer.SwigDelegateProducer_0 delegate0, Producer.SwigDelegateProducer_1 delegate1, Producer.SwigDelegateProducer_2 delegate2, Producer.SwigDelegateProducer_3 delegate3, Producer.SwigDelegateProducer_4 delegate4);

        /// <summary>
        /// News the order consumer.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_OrderConsumer")]
        public static extern global::System.IntPtr new_OrderConsumer();

        /// <summary>
        /// Deletes the order consumer.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_OrderConsumer")]
        public static extern void delete_OrderConsumer(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Orders the consumer start.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_OrderConsumer_start")]
        public static extern void OrderConsumer_start(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Orders the consumer shutdown.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_OrderConsumer_shutdown")]
        public static extern void OrderConsumer_shutdown(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Orders the consumer subscribe.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <param name="jarg4">The jarg4.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_OrderConsumer_subscribe")]
        public static extern void OrderConsumer_subscribe(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

        /// <summary>
        /// Orders the consumer director connect.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="delegate0">The delegate0.</param>
        /// <param name="delegate1">The delegate1.</param>
        /// <param name="delegate2">The delegate2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_OrderConsumer_director_connect")]
        public static extern void OrderConsumer_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, OrderConsumer.SwigDelegateOrderConsumer_0 delegate0, OrderConsumer.SwigDelegateOrderConsumer_1 delegate1, OrderConsumer.SwigDelegateOrderConsumer_2 delegate2);

        /// <summary>
        /// News the order producer.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_OrderProducer")]
        public static extern global::System.IntPtr new_OrderProducer();

        /// <summary>
        /// Deletes the order producer.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_OrderProducer")]
        public static extern void delete_OrderProducer(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Orders the producer start.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_OrderProducer_start")]
        public static extern void OrderProducer_start(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Orders the producer shutdown.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_OrderProducer_shutdown")]
        public static extern void OrderProducer_shutdown(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Orders the producer send.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_OrderProducer_send")]
        public static extern global::System.IntPtr OrderProducer_send(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3);

        /// <summary>
        /// Orders the producer director connect.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="delegate0">The delegate0.</param>
        /// <param name="delegate1">The delegate1.</param>
        /// <param name="delegate2">The delegate2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_OrderProducer_director_connect")]
        public static extern void OrderProducer_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, OrderProducer.SwigDelegateOrderProducer_0 delegate0, OrderProducer.SwigDelegateOrderProducer_1 delegate1, OrderProducer.SwigDelegateOrderProducer_2 delegate2);

        /// <summary>
        /// News the push consumer.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_PushConsumer")]
        public static extern global::System.IntPtr new_PushConsumer();

        /// <summary>
        /// Deletes the push consumer.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_PushConsumer")]
        public static extern void delete_PushConsumer(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Pushes the consumer start.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PushConsumer_start")]
        public static extern void PushConsumer_start(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Pushes the consumer shutdown.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PushConsumer_shutdown")]
        public static extern void PushConsumer_shutdown(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Pushes the consumer subscribe.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <param name="jarg4">The jarg4.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PushConsumer_subscribe")]
        public static extern void PushConsumer_subscribe(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

        /// <summary>
        /// Pushes the consumer director connect.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="delegate0">The delegate0.</param>
        /// <param name="delegate1">The delegate1.</param>
        /// <param name="delegate2">The delegate2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PushConsumer_director_connect")]
        public static extern void PushConsumer_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, PushConsumer.SwigDelegatePushConsumer_0 delegate0, PushConsumer.SwigDelegatePushConsumer_1 delegate1, PushConsumer.SwigDelegatePushConsumer_2 delegate2);

        /// <summary>
        /// News the pull consumer.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_PullConsumer")]
        public static extern global::System.IntPtr new_PullConsumer();

        /// <summary>
        /// Deletes the pull consumer.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_PullConsumer")]
        public static extern void delete_PullConsumer(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Pulls the consumer start.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullConsumer_start")]
        public static extern void PullConsumer_start(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Pulls the consumer shutdown.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullConsumer_shutdown")]
        public static extern void PullConsumer_shutdown(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Pulls the consumer fetch subscribe message queues.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullConsumer_fetchSubscribeMessageQueues")]
        public static extern void PullConsumer_fetchSubscribeMessageQueues(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        /// <summary>
        /// Pulls the consumer pull.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <param name="jarg4">The jarg4.</param>
        /// <param name="jarg5">The jarg5.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullConsumer_pull")]
        public static extern global::System.IntPtr PullConsumer_pull(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, long jarg4, int jarg5);

        /// <summary>
        /// Pulls the consumer search offset.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <returns>System.Int64.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullConsumer_searchOffset")]
        public static extern long PullConsumer_searchOffset(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, long jarg3);

        /// <summary>
        /// Pulls the consumer maximum offset.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <returns>System.Int64.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullConsumer_maxOffset")]
        public static extern long PullConsumer_maxOffset(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Pulls the consumer minimum offset.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <returns>System.Int64.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullConsumer_minOffset")]
        public static extern long PullConsumer_minOffset(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Pulls the consumer update consume offset.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullConsumer_updateConsumeOffset")]
        public static extern void PullConsumer_updateConsumeOffset(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, long jarg3);

        /// <summary>
        /// Pulls the consumer remove consume offset.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullConsumer_removeConsumeOffset")]
        public static extern void PullConsumer_removeConsumeOffset(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Pulls the consumer fetch consume offset.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">if set to <c>true</c> [jarg3].</param>
        /// <returns>System.Int64.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullConsumer_fetchConsumeOffset")]
        public static extern long PullConsumer_fetchConsumeOffset(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3);

        /// <summary>
        /// Pulls the consumer persist consumer offset4 pull consumer.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullConsumer_persistConsumerOffset4PullConsumer")]
        public static extern void PullConsumer_persistConsumerOffset4PullConsumer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Pulls the consumer director connect.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="delegate0">The delegate0.</param>
        /// <param name="delegate1">The delegate1.</param>
        /// <param name="delegate2">The delegate2.</param>
        /// <param name="delegate3">The delegate3.</param>
        /// <param name="delegate4">The delegate4.</param>
        /// <param name="delegate5">The delegate5.</param>
        /// <param name="delegate6">The delegate6.</param>
        /// <param name="delegate7">The delegate7.</param>
        /// <param name="delegate8">The delegate8.</param>
        /// <param name="delegate9">The delegate9.</param>
        /// <param name="delegate10">The delegate10.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_PullConsumer_director_connect")]
        public static extern void PullConsumer_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, PullConsumer.SwigDelegatePullConsumer_0 delegate0, PullConsumer.SwigDelegatePullConsumer_1 delegate1, PullConsumer.SwigDelegatePullConsumer_2 delegate2, PullConsumer.SwigDelegatePullConsumer_3 delegate3, PullConsumer.SwigDelegatePullConsumer_4 delegate4, PullConsumer.SwigDelegatePullConsumer_5 delegate5, PullConsumer.SwigDelegatePullConsumer_6 delegate6, PullConsumer.SwigDelegatePullConsumer_7 delegate7, PullConsumer.SwigDelegatePullConsumer_8 delegate8, PullConsumer.SwigDelegatePullConsumer_9 delegate9, PullConsumer.SwigDelegatePullConsumer_10 delegate10);

        /// <summary>
        /// Deletes the transaction producer.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_TransactionProducer")]
        public static extern void delete_TransactionProducer(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Transactions the producer start.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_TransactionProducer_start")]
        public static extern void TransactionProducer_start(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Transactions the producer shutdown.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_TransactionProducer_shutdown")]
        public static extern void TransactionProducer_shutdown(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Transactions the producer send.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_TransactionProducer_send")]
        public static extern global::System.IntPtr TransactionProducer_send(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        /// <summary>
        /// News the ons factory property.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_ONSFactoryProperty")]
        public static extern global::System.IntPtr new_ONSFactoryProperty();

        /// <summary>
        /// Deletes the ons factory property.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_ONSFactoryProperty")]
        public static extern void delete_ONSFactoryProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property check validity of factory properties.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_checkValidityOfFactoryProperties")]
        public static extern bool ONSFactoryProperty_checkValidityOfFactoryProperties(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3);

        /// <summary>
        /// Onses the factory property get log path.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getLogPath")]
        public static extern string ONSFactoryProperty_getLogPath(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property set send MSG timeout.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_setSendMsgTimeout")]
        public static extern void ONSFactoryProperty_setSendMsgTimeout(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        /// <summary>
        /// Onses the factory property set send MSG retry times.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_setSendMsgRetryTimes")]
        public static extern void ONSFactoryProperty_setSendMsgRetryTimes(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        /// <summary>
        /// Onses the size of the factory property set maximum MSG cache.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_setMaxMsgCacheSize")]
        public static extern void ONSFactoryProperty_setMaxMsgCacheSize(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        /// <summary>
        /// Onses the factory property set ons trace switch.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">if set to <c>true</c> [jarg2].</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_setOnsTraceSwitch")]
        public static extern void ONSFactoryProperty_setOnsTraceSwitch(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

        /// <summary>
        /// Onses the factory property set ons channel.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_setOnsChannel")]
        public static extern void ONSFactoryProperty_setOnsChannel(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        /// <summary>
        /// Onses the factory property set factory property.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_setFactoryProperty")]
        public static extern void ONSFactoryProperty_setFactoryProperty(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3);

        /// <summary>
        /// Onses the factory property set factory properties.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_setFactoryProperties")]
        public static extern void ONSFactoryProperty_setFactoryProperties(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Onses the factory property get factory properties.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getFactoryProperties")]
        public static extern global::System.IntPtr ONSFactoryProperty_getFactoryProperties(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get producer identifier.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getProducerId")]
        public static extern string ONSFactoryProperty_getProducerId(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get consumer identifier.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getConsumerId")]
        public static extern string ONSFactoryProperty_getConsumerId(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get publish topics.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getPublishTopics")]
        public static extern string ONSFactoryProperty_getPublishTopics(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get message model.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getMessageModel")]
        public static extern string ONSFactoryProperty_getMessageModel(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get send MSG timeout.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int32.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getSendMsgTimeout")]
        public static extern int ONSFactoryProperty_getSendMsgTimeout(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get send MSG retry times.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int32.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getSendMsgRetryTimes")]
        public static extern int ONSFactoryProperty_getSendMsgRetryTimes(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get consume thread nums.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int32.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getConsumeThreadNums")]
        public static extern int ONSFactoryProperty_getConsumeThreadNums(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the size of the factory property get maximum MSG cache.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int32.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getMaxMsgCacheSize")]
        public static extern int ONSFactoryProperty_getMaxMsgCacheSize(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get ons channel.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.Int32.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getOnsChannel")]
        public static extern int ONSFactoryProperty_getOnsChannel(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get channel.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getChannel")]
        public static extern string ONSFactoryProperty_getChannel(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the content of the factory property get message.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getMessageContent")]
        public static extern string ONSFactoryProperty_getMessageContent(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get name SRV addr.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getNameSrvAddr")]
        public static extern string ONSFactoryProperty_getNameSrvAddr(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get name SRV domain.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getNameSrvDomain")]
        public static extern string ONSFactoryProperty_getNameSrvDomain(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get access key.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getAccessKey")]
        public static extern string ONSFactoryProperty_getAccessKey(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get secret key.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getSecretKey")]
        public static extern string ONSFactoryProperty_getSecretKey(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the name of the factory property get consumer instance.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getConsumerInstanceName")]
        public static extern string ONSFactoryProperty_getConsumerInstanceName(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get ons trace switch.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getOnsTraceSwitch")]
        public static extern bool ONSFactoryProperty_getOnsTraceSwitch(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property get name space.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_getNameSpace")]
        public static extern string ONSFactoryProperty_getNameSpace(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory property log path set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_LogPath_set")]
        public static extern void ONSFactoryProperty_LogPath_set(string jarg1);

        /// <summary>
        /// Onses the factory property log path get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_LogPath_get")]
        public static extern string ONSFactoryProperty_LogPath_get();

        /// <summary>
        /// Onses the factory property producer identifier set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_ProducerId_set")]
        public static extern void ONSFactoryProperty_ProducerId_set(string jarg1);

        /// <summary>
        /// Onses the factory property producer identifier get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_ProducerId_get")]
        public static extern string ONSFactoryProperty_ProducerId_get();

        /// <summary>
        /// Onses the factory property consumer identifier set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_ConsumerId_set")]
        public static extern void ONSFactoryProperty_ConsumerId_set(string jarg1);

        /// <summary>
        /// Onses the factory property consumer identifier get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_ConsumerId_get")]
        public static extern string ONSFactoryProperty_ConsumerId_get();

        /// <summary>
        /// Onses the factory property publish topics set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_PublishTopics_set")]
        public static extern void ONSFactoryProperty_PublishTopics_set(string jarg1);

        /// <summary>
        /// Onses the factory property publish topics get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_PublishTopics_get")]
        public static extern string ONSFactoryProperty_PublishTopics_get();

        /// <summary>
        /// Onses the factory property MSG content set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_MsgContent_set")]
        public static extern void ONSFactoryProperty_MsgContent_set(string jarg1);

        /// <summary>
        /// Onses the factory property MSG content get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_MsgContent_get")]
        public static extern string ONSFactoryProperty_MsgContent_get();

        /// <summary>
        /// Onses the factory property ons addr set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_ONSAddr_set")]
        public static extern void ONSFactoryProperty_ONSAddr_set(string jarg1);

        /// <summary>
        /// Onses the factory property ons addr get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_ONSAddr_get")]
        public static extern string ONSFactoryProperty_ONSAddr_get();

        /// <summary>
        /// Onses the factory property access key set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_AccessKey_set")]
        public static extern void ONSFactoryProperty_AccessKey_set(string jarg1);

        /// <summary>
        /// Onses the factory property access key get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_AccessKey_get")]
        public static extern string ONSFactoryProperty_AccessKey_get();

        /// <summary>
        /// Onses the factory property secret key set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_SecretKey_set")]
        public static extern void ONSFactoryProperty_SecretKey_set(string jarg1);

        /// <summary>
        /// Onses the factory property secret key get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_SecretKey_get")]
        public static extern string ONSFactoryProperty_SecretKey_get();

        /// <summary>
        /// Onses the factory property message model set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_MessageModel_set")]
        public static extern void ONSFactoryProperty_MessageModel_set(string jarg1);

        /// <summary>
        /// Onses the factory property message model get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_MessageModel_get")]
        public static extern string ONSFactoryProperty_MessageModel_get();

        /// <summary>
        /// Onses the factory property broadcasting set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_BROADCASTING_set")]
        public static extern void ONSFactoryProperty_BROADCASTING_set(string jarg1);

        /// <summary>
        /// Onses the factory property broadcasting get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_BROADCASTING_get")]
        public static extern string ONSFactoryProperty_BROADCASTING_get();

        /// <summary>
        /// Onses the factory property clustering set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_CLUSTERING_set")]
        public static extern void ONSFactoryProperty_CLUSTERING_set(string jarg1);

        /// <summary>
        /// Onses the factory property clustering get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_CLUSTERING_get")]
        public static extern string ONSFactoryProperty_CLUSTERING_get();

        /// <summary>
        /// Onses the factory property send MSG timeout millis set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_SendMsgTimeoutMillis_set")]
        public static extern void ONSFactoryProperty_SendMsgTimeoutMillis_set(string jarg1);

        /// <summary>
        /// Onses the factory property send MSG timeout millis get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_SendMsgTimeoutMillis_get")]
        public static extern string ONSFactoryProperty_SendMsgTimeoutMillis_get();

        /// <summary>
        /// Onses the factory property namesrv addr set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_NAMESRV_ADDR_set")]
        public static extern void ONSFactoryProperty_NAMESRV_ADDR_set(string jarg1);

        /// <summary>
        /// Onses the factory property namesrv addr get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_NAMESRV_ADDR_get")]
        public static extern string ONSFactoryProperty_NAMESRV_ADDR_get();

        /// <summary>
        /// Onses the factory property consume thread nums set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_ConsumeThreadNums_set")]
        public static extern void ONSFactoryProperty_ConsumeThreadNums_set(string jarg1);

        /// <summary>
        /// Onses the factory property consume thread nums get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_ConsumeThreadNums_get")]
        public static extern string ONSFactoryProperty_ConsumeThreadNums_get();

        /// <summary>
        /// Onses the factory property ons channel set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_OnsChannel_set")]
        public static extern void ONSFactoryProperty_OnsChannel_set(string jarg1);

        /// <summary>
        /// Onses the factory property ons channel get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_OnsChannel_get")]
        public static extern string ONSFactoryProperty_OnsChannel_get();

        /// <summary>
        /// Onses the factory property maximum MSG cache size set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_MaxMsgCacheSize_set")]
        public static extern void ONSFactoryProperty_MaxMsgCacheSize_set(string jarg1);

        /// <summary>
        /// Onses the factory property maximum MSG cache size get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_MaxMsgCacheSize_get")]
        public static extern string ONSFactoryProperty_MaxMsgCacheSize_get();

        /// <summary>
        /// Onses the factory property ons trace switch set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_OnsTraceSwitch_set")]
        public static extern void ONSFactoryProperty_OnsTraceSwitch_set(string jarg1);

        /// <summary>
        /// Onses the factory property ons trace switch get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_OnsTraceSwitch_get")]
        public static extern string ONSFactoryProperty_OnsTraceSwitch_get();

        /// <summary>
        /// Onses the factory property send MSG retry times set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_SendMsgRetryTimes_set")]
        public static extern void ONSFactoryProperty_SendMsgRetryTimes_set(string jarg1);

        /// <summary>
        /// Onses the factory property send MSG retry times get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_SendMsgRetryTimes_get")]
        public static extern string ONSFactoryProperty_SendMsgRetryTimes_get();

        /// <summary>
        /// Onses the factory property consumer instance name set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_ConsumerInstanceName_set")]
        public static extern void ONSFactoryProperty_ConsumerInstanceName_set(string jarg1);

        /// <summary>
        /// Onses the factory property consumer instance name get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_ConsumerInstanceName_get")]
        public static extern string ONSFactoryProperty_ConsumerInstanceName_get();

        /// <summary>
        /// Onses the factory property instance identifier set.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_InstanceId_set")]
        public static extern void ONSFactoryProperty_InstanceId_set(string jarg1);

        /// <summary>
        /// Onses the factory property instance identifier get.
        /// </summary>
        /// <returns>System.String.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryProperty_InstanceId_get")]
        public static extern string ONSFactoryProperty_InstanceId_get();

        /// <summary>
        /// News the ons factory API.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_new_ONSFactoryAPI")]
        public static extern global::System.IntPtr new_ONSFactoryAPI();

        /// <summary>
        /// Deletes the ons factory API.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_ONSFactoryAPI")]
        public static extern void delete_ONSFactoryAPI(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory API create producer.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryAPI_createProducer")]
        public static extern global::System.IntPtr ONSFactoryAPI_createProducer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Onses the factory API create order producer.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryAPI_createOrderProducer")]
        public static extern global::System.IntPtr ONSFactoryAPI_createOrderProducer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Onses the factory API create order consumer.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryAPI_createOrderConsumer")]
        public static extern global::System.IntPtr ONSFactoryAPI_createOrderConsumer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Onses the factory API create transaction producer.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <param name="jarg3">The jarg3.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryAPI_createTransactionProducer")]
        public static extern global::System.IntPtr ONSFactoryAPI_createTransactionProducer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

        /// <summary>
        /// Onses the factory API create pull consumer.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryAPI_createPullConsumer")]
        public static extern global::System.IntPtr ONSFactoryAPI_createPullConsumer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Onses the factory API create push consumer.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        /// <param name="jarg2">The jarg2.</param>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactoryAPI_createPushConsumer")]
        public static extern global::System.IntPtr ONSFactoryAPI_createPushConsumer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        /// <summary>
        /// Deletes the ons factory.
        /// </summary>
        /// <param name="jarg1">The jarg1.</param>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_delete_ONSFactory")]
        public static extern void delete_ONSFactory(global::System.Runtime.InteropServices.HandleRef jarg1);

        /// <summary>
        /// Onses the factory get instance.
        /// </summary>
        /// <returns>System.IntPtr.</returns>
        [global::System.Runtime.InteropServices.DllImport("ONSClient4CPP", EntryPoint = "CSharp_ons_ONSFactory_getInstance")]
        public static extern global::System.IntPtr ONSFactory_getInstance();
    }

}

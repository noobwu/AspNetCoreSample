﻿// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample.NETCore
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="Program.cs" company="Aliyun.RocketMQSample.NETCore">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading;

/// <summary>
/// The NETCore namespace.
/// </summary>
namespace Aliyun.RocketMQSample.NETCore
{
    /// <summary>
    /// Class Program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            OnscSharp.CreateProducer();
            OnscSharp.CreatePushConsumer();
            OnscSharp.StartPushConsumer();
            OnscSharp.StartProducer();
            System.DateTime beforDt = System.DateTime.Now;
            for (int i = 0; i < 10; ++i)
            {
                //byte[] bytes = Encoding.UTF8.GetBytes("中文messages");//中文encode
                //String body = Convert.ToBase64String(bytes);
                OnscSharp.SendMessage("This is test message");
                Thread.Sleep(1000 * 1);
            }
            System.DateTime endDt = System.DateTime.Now;
            System.TimeSpan ts = endDt.Subtract(beforDt);
            Console.WriteLine("per message:{0}ms.", ts.TotalMilliseconds / 10000);
            Thread.Sleep(1000 * 100);
            Console.ReadKey();
            OnscSharp.ShutdownProducer();
            OnscSharp.shutdownPushConsumer();
            Console.WriteLine("end");
        }
    }
}

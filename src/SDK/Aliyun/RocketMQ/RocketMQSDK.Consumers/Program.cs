// ***********************************************************************
// Assembly         : RocketMQSDK.Consumers
// Author           : Administrator
// Created          : 2020-03-01
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-01
// ***********************************************************************
// <copyright file="Program.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using ons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The Consumers namespace.
/// </summary>
namespace RocketMQSDK.Consumers
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
            try
            {
                ConsumerTest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
        /// <summary>
        /// Consumers the test.
        /// </summary>
        static void ConsumerTest()
        {
            string strRocketMQConfigs = ReadAllFromFile("RocketMQConfigs.json");
            List<RocketMQConfig> configs = JsonConvertDeserialize<List<RocketMQConfig>>(strRocketMQConfigs);

            Console.WriteLine($"ConsumerTest,开始:{DateTime.Now}");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            //configs = configs.Where(a => !(new byte[] { 2, 3 }).Contains(a.MsgType)).ToList();
            configs?.ForEach(config =>
            {
                OnscSharp instance = new OnscSharp(config);
                switch (config.MsgType)
                {
                    case 2:
                    case 3:
                        {
                            instance.CreateOrderConsumer();
                            instance.StartOrderConsumer($"{instance.Config.GroupId.Replace(instance.Config.GroupIdPrefix, string.Empty)}OrderMessage");
                        }
                        break;
                    default:
                        {
                            instance.CreatePushConsumer();
                            instance.StartPushConsumer($"{instance.Config.GroupId.Replace(instance.Config.GroupIdPrefix, string.Empty)}Message");
                        }
                        break;
                }

            });

            stopWatch.Stop();
            Console.WriteLine($"ConsumerTest,结束, 使用时间{stopWatch.ElapsedMilliseconds}毫秒");
        }
        /// <summary>
        /// 读json配制文件的内容
        /// </summary>
        /// <param name="configFile">The configuration file.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception">配置文件 " + strFilePath + " 不存在</exception>
        /// <exception cref="Exception">配置文件 " + strFilePath + " 不存在</exception>
        static string ReadAllFromFile(string configFile)
        {
            string strFilePath = GetConfigFilePath(configFile);

            if (!File.Exists(strFilePath))
            {
                throw new Exception("配置文件 " + strFilePath + " 不存在");
            }
            return File.ReadAllText(strFilePath);
        }
        /// <summary>
        /// 功能:获取配置文件路径
        /// </summary>
        /// <param name="strConfigFileName">配置文件名称</param>
        /// <returns>配置文件路径</returns>
        static string GetConfigFilePath(string strConfigFileName)
        {
            string strConfigFilePath = Thread.GetDomain().BaseDirectory;// System.Environment.CurrentDirectory;

            strConfigFilePath = Path.Combine(strConfigFilePath, "Config");
            strConfigFilePath = Path.Combine(strConfigFilePath, strConfigFileName);

            return strConfigFilePath;
        }

        /// <summary>
        /// 功能:JSON反序列化JsonConvert方式
        /// </summary>
        /// <typeparam name="T">反序列化的类型</typeparam>
        /// <param name="jsonString">json字符串</param>
        /// <returns>反序列化的类型对象</returns>
        static T JsonConvertDeserialize<T>(string jsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                return default(T);
            }
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default(T);
            }
        }
    }
}

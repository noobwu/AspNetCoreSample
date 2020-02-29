// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="JsonConfigInfo.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

/// <summary>
/// The Models namespace.
/// </summary>
namespace Kmmp.Core.Models
{
    /// <summary>
    /// Class JsonConfigInfo.
    /// </summary>
    /// 创建人:吴廷有
    /// 创建时间:2015-09-25
    /// 功能描述:Json配置文件信息类
    public class JsonConfigInfo
    {
        #region "  变量定义  "

        //配置信息
        /// <summary>
        /// The m itemes
        /// </summary>
        private JObject m_itemes = null;

        #endregion

        #region "  构造函数  "


        #endregion

        #region "  静态函数  "

        /// <summary>
        /// 作者:吴廷有
        /// 时间:2015-10-10
        /// 功能:从文件加载配置
        /// </summary>
        /// <param name="configFile">配置文件</param>
        /// <returns>JsonConfigInfo.</returns>
        /// <exception cref="Exception">配置文件 " + strFilePath + " 不存在</exception>
        public static JsonConfigInfo LoadFromFile(string configFile)
        {
            string strFilePath = GetConfigFilePath(configFile);

            if (!File.Exists(strFilePath))
            {
                throw new Exception("配置文件 " + strFilePath + " 不存在");
            }
            var json = File.ReadAllText(strFilePath);

            return LoadFromString(json);
        }

        /// <summary>
        /// 读json配制文件的内容 add by yzl@20180910
        /// </summary>
        /// <param name="configFile">The configuration file.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="Exception">配置文件 " + strFilePath + " 不存在</exception>
        public static string ReadAllFromFile(string configFile)
        {
            string strFilePath = GetConfigFilePath(configFile);

            if (!File.Exists(strFilePath))
            {
                throw new Exception("配置文件 " + strFilePath + " 不存在");
            }
            return File.ReadAllText(strFilePath);
        }

        /// <summary>
        /// 作者:吴廷有
        /// 时间:2015-10-10
        /// 功能:从字符串加载配置
        /// </summary>
        /// <param name="json">配置字符串</param>
        /// <returns>JsonConfigInfo.</returns>
        public static JsonConfigInfo LoadFromString(string json)
        {
            JsonConfigInfo configInfo = new JsonConfigInfo();
            configInfo.m_itemes = JObject.Parse(json);
            return configInfo;
        }

        #endregion

        #region "  属性定义  "

        /// <summary>
        /// Gets the itemes.
        /// </summary>
        /// <value>The itemes.</value>
        public JObject Itemes
        {
            get
            {
                return m_itemes;
            }
        }

        #endregion

        #region "  方法定义  "

        /// <summary>
        /// 作者:吴廷有
        /// 时间:2015-10-10
        /// 功能:获取整形参数值
        /// </summary>
        /// <param name="key">参数键值</param>
        /// <returns>整形参数值</returns>
        public int GetInt(string key)
        {
            return GetValue<int>(key);
        }

        /// <summary>
        /// 作者:吴廷有
        /// 时间:2015-10-10
        /// 功能:获取字符串参数值
        /// </summary>
        /// <param name="key">参数键值</param>
        /// <returns>字符串参数值</returns>
        public string GetString(string key)
        {
            return GetValue<string>(key);
        }

        /// <summary>
        /// 作者:吴廷有
        /// 时间:2015-10-10
        /// 功能:获取泛型参数值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">参数键值</param>
        /// <returns>泛型参数值</returns>
        public T GetValue<T>(string key)
        {
            if (null == m_itemes)
            {
                return default(T);
            }
            if (m_itemes[key] == null)
            {
                return default(T);
            }
            return m_itemes[key].Value<T>();
        }

        /// <summary>
        /// 作者:吴廷有
        /// 时间:2015-10-10
        /// 功能:获取字符串参数数组
        /// </summary>
        /// <param name="key">参数键值</param>
        /// <returns>字符串参数值数组</returns>
        public List<string> GetStringList(string key)
        {
            if (null == m_itemes)
            {
                return null;
            }
            return m_itemes[key].Select(x => x.Value<string>()).ToList();
        }

        /// <summary>
        /// 作者:吴廷有
        /// 时间:2015-10-10
        /// 功能:获取对象数组列表
        /// </summary>
        /// <param name="key">参数键值</param>
        /// <returns>对象数组列表</returns>
        public List<JObject> GetObjectList(string key)
        {
            if (null == m_itemes)
            {
                return null;
            }
            return m_itemes[key].Select(x => x.Value<JObject>()).ToList();
        }

        #endregion

        #region "  函数与过程  "

        /// <summary>
        /// 作者:吴廷有
        /// 时间:2015-10-10
        /// 功能:获取配置文件路径
        /// </summary>
        /// <param name="strConfigFileName">配置文件名称</param>
        /// <returns>配置文件路径</returns>
        public static string GetConfigFilePath(string strConfigFileName)
        {
            string strConfigFilePath = Thread.GetDomain().BaseDirectory;// System.Environment.CurrentDirectory;

            strConfigFilePath = Path.Combine(strConfigFilePath, "Config");
            strConfigFilePath = Path.Combine(strConfigFilePath, strConfigFileName);

            return strConfigFilePath;
        }
        /// <summary>
        /// 确认配置的文件是否存在
        /// </summary>
        /// <param name="configFile">The configuration file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ExistsConfigFile(string configFile)
        {
            try
            {
                string strFilePath = GetConfigFilePath(configFile);
                return File.Exists(strFilePath);
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}

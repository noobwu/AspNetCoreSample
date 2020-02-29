// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="JsonHelper.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Helper namespace.
/// </summary>
namespace Kmmp.Core.Helper
{
    /// <summary>
    /// 创建人:吴廷有
    /// 创建时间:2015-09-25
    /// 功能描述:Json操作帮助类
    /// </summary>
    public class JsonHelper
    {
        #region "  变量定义  "

        /// <summary>
        /// The m default settings
        /// </summary>
        private static JsonSerializerSettings m_defaultSettings = null;


        #endregion

        #region "  构造函数  "

        /// <summary>
        /// Initializes static members of the <see cref="JsonHelper"/> class.
        /// </summary>
        static JsonHelper()
        {
            //Json格式化默认设置
            m_defaultSettings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                Converters = { new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" } },
                Formatting = Formatting.None
            };
        }
        #endregion

        /// <summary>
        /// 作者:吴廷有
        /// 时间:2015-10-10
        /// 功能:JSON反序列化JsonConvert方式
        /// </summary>
        /// <typeparam name="T">反序列化的类型</typeparam>
        /// <param name="jsonString">json字符串</param>
        /// <returns>反序列化的类型对象</returns>
        public static T JsonConvertDeserialize<T>(string jsonString)
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
                return default(T);
            }
        }


        /// <summary>
        /// 作者:吴廷有
        /// 时间:2015-10-10
        /// 功能:JSON序列化JsonConvert方式
        /// </summary>      
        /// <param name="objValue">待序列化的对象</param>
        /// <param name="settings"></param>
        /// <param name="formatting"></param>
        /// <returns>序列化的Json</returns>
        public static string JsonConvertSerialize(object objValue, JsonSerializerSettings settings = null, Formatting formatting = 0)
        {
            if (null == objValue)
            {
                return null;
            }
            try
            {
                return JsonConvert.SerializeObject(objValue, formatting, settings == null ? m_defaultSettings : settings);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
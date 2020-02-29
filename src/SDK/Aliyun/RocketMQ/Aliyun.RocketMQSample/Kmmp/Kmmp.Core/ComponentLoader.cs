// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="ComponentLoader.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kmmp.Core.Helper;
using Kmmp.Core.Imps;
using Kmmp.Core.Models;
using Newtonsoft.Json;

/// <summary>
/// The Core namespace.
/// </summary>
namespace Kmmp.Core
{
    /// <summary>
    /// 作者：吴廷有
    /// 时间：2015-10-23
    /// 功能：组件加载类
    /// </summary>
    public class ComponentLoader
    {
        #region "  方法定义  "

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：加载组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configInfo">The configuration information.</param>
        /// <returns>T.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public static T Load<T>(JsonConfigInfo configInfo)
        {
            var componentTypeName = configInfo.GetString("_type");
            if (componentTypeName == null)
            {
                throw new ArgumentOutOfRangeException(string.Format("无法加载组件 {0}，配置文件中缺少 _type 属性", typeof(T).FullName));
            }
            var classNameArray = componentTypeName.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            if (classNameArray.Length == 1)
            {
                throw new ArgumentOutOfRangeException(string.Format("无法加载组件 {0}，配置属性 _type: {1} 缺少命名空间",
                    typeof(T).FullName, componentTypeName));
            }
            var @namespace = string.Join(".", classNameArray.Take(classNameArray.Length - 1));
            var className = classNameArray.Last();
            var target = ObjectFactoryHelper.CreateInstance<T>(className, @namespace, true);
            if (target == null)
            {
                var componentType = Type.GetType(componentTypeName);
                target = (T)Activator.CreateInstance(componentType);
            }
            JsonConvert.PopulateObject(configInfo.Itemes.ToString(), target);
            IComponent component = target as IComponent;

            if (component != null)
            {
                component.Init();
            }
            return target;
        }

        #endregion
    }
}

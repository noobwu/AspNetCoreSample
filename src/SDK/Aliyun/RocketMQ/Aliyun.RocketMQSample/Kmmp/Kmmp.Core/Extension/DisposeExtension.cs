// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="DisposeExtension.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Extension namespace.
/// </summary>
namespace Kmmp.Core.Extension
{
    /// <summary>
    /// 作者：吴廷有
    /// 时间：2015-10-23
    /// 功能：释放资源帮助类
    /// </summary>
    public static class DisposeExtension
    {
        #region "  方法定义  "

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：释放 <paramref name="items" /> 中所有的 <see cref="System.IDisposable" /> 对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <exception cref="ArgumentNullException">items</exception>
        public static void Dispose<T>(this IEnumerable<T> items) where T : IDisposable
        {
            if (items == null) throw new ArgumentNullException("items");
            foreach (var item in items)
            {
                try
                {
                    if (item != null)
                    {
                        item.Dispose();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        #endregion
    }
}

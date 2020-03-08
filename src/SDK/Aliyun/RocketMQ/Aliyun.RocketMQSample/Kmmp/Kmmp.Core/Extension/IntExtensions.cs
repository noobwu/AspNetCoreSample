// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-03-08
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-08
// ***********************************************************************
// <copyright file="IntExtensions.cs" company="NoobCore.com">
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
    /// Class IntExtensions.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Timeses the specified times.
        /// </summary>
        /// <param name="times">The times.</param>
        /// <returns>IEnumerable&lt;System.Int32&gt;.</returns>
        public static IEnumerable<int> Times(this int times)
        {
            for (var i = 0; i < times; i++)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Timeses the specified action function.
        /// </summary>
        /// <param name="times">The times.</param>
        /// <param name="actionFn">The action function.</param>
        public static void Times(this int times, Action<int> actionFn)
        {
            for (var i = 0; i < times; i++)
            {
                actionFn(i);
            }
        }

        /// <summary>
        /// Timeses the specified action function.
        /// </summary>
        /// <param name="times">The times.</param>
        /// <param name="actionFn">The action function.</param>
        public static void Times(this int times, Action actionFn)
        {
            for (var i = 0; i < times; i++)
            {
                actionFn();
            }
        }

        /// <summary>
        /// Timeses the specified action function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="times">The times.</param>
        /// <param name="actionFn">The action function.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public static List<T> Times<T>(this int times, Func<T> actionFn)
        {
            var list = new List<T>();
            for (var i = 0; i < times; i++)
            {
                list.Add(actionFn());
            }
            return list;
        }

        /// <summary>
        /// Timeses the specified action function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="times">The times.</param>
        /// <param name="actionFn">The action function.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public static List<T> Times<T>(this int times, Func<int, T> actionFn)
        {
            var list = new List<T>();
            for (var i = 0; i < times; i++)
            {
                list.Add(actionFn(i));
            }
            return list;
        }

        /// <summary>
        /// Timeses the asynchronous.
        /// </summary>
        /// <param name="times">The times.</param>
        /// <param name="actionFn">The action function.</param>
        /// <returns>List&lt;IAsyncResult&gt;.</returns>
        public static List<IAsyncResult> TimesAsync(this int times, Action<int> actionFn)
        {
            var asyncResults = new List<IAsyncResult>(times);
            for (var i = 0; i < times; i++)
            {
                asyncResults.Add(actionFn.BeginInvoke(i, null, null));
            }
            return asyncResults;
        }

        /// <summary>
        /// Timeses the asynchronous.
        /// </summary>
        /// <param name="times">The times.</param>
        /// <param name="actionFn">The action function.</param>
        /// <returns>List&lt;IAsyncResult&gt;.</returns>
        public static List<IAsyncResult> TimesAsync(this int times, Action actionFn)
        {
            var asyncResults = new List<IAsyncResult>(times);
            for (var i = 0; i < times; i++)
            {
                asyncResults.Add(actionFn.BeginInvoke(null, null));
            }
            return asyncResults;
        }
    }
}

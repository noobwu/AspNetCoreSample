// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-03-08
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-08
// ***********************************************************************
// <copyright file="StringExtensions.cs" company="NoobCore.com">
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
    /// Class StringExtensions.
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// Converts the string representation of a number to an integer.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.Int32.</returns>
        public static int ToInt(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return default(int);
            }
            return int.Parse(text);
        }

        /// <summary>
        /// Converts the string representation of a number to an integer.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.Int32.</returns>
        public static int ToInt(this string text, int defaultValue)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return defaultValue;
            }
            int ret;
            return int.TryParse(text, out ret) ? ret : defaultValue;
        }
        /// <summary>
        /// Splits the on first.
        /// </summary>
        /// <param name="strVal">The string value.</param>
        /// <param name="needle">The needle.</param>
        /// <returns>System.String[].</returns>
        public static string[] SplitOnFirst(this string strVal, char needle)
        {
            if (strVal == null) return new string[0];
            var pos = strVal.IndexOf(needle);
            return pos == -1
                ? new[] { strVal }
                : new[] { strVal.Substring(0, pos), strVal.Substring(pos + 1) };
        }

        /// <summary>
        /// Splits the on first.
        /// </summary>
        /// <param name="strVal">The string value.</param>
        /// <param name="needle">The needle.</param>
        /// <returns>System.String[].</returns>
        public static string[] SplitOnFirst(this string strVal, string needle)
        {
            if (strVal == null) return new string[0];
            var pos = strVal.IndexOf(needle, StringComparison.OrdinalIgnoreCase);
            return pos == -1
                ? new[] { strVal }
                : new[] { strVal.Substring(0, pos), strVal.Substring(pos + needle.Length) };
        }

        /// <summary>
        /// Splits the on last.
        /// </summary>
        /// <param name="strVal">The string value.</param>
        /// <param name="needle">The needle.</param>
        /// <returns>System.String[].</returns>
        public static string[] SplitOnLast(this string strVal, char needle)
        {
            if (strVal == null) return new string[0];
            var pos = strVal.LastIndexOf(needle);
            return pos == -1
                ? new[] { strVal }
                : new[] { strVal.Substring(0, pos), strVal.Substring(pos + 1) };
        }
    }
}

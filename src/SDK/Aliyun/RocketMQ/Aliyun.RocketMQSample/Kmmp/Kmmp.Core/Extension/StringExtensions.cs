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
using Kmmp.Core.Helper;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// <summary>
        /// Froms the json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">The json.</param>
        /// <returns>T.</returns>
        public static T FromJson<T>(this string json)
        {
            return JsonHelper.JsonConvertDeserialize<T>(json);
        }
        /// <summary>
        /// Converts to json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>System.String.</returns>
        public static string ToJson<T>(this T obj)
        {
            return JsonHelper.JsonConvertSerialize(obj);
        }
        /// <summary>
        /// Froms the UTF8 bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        public static string FromUtf8Bytes(this byte[] bytes)
        {
            return bytes == null ? null
                : bytes.Length > 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF
                    ? Encoding.UTF8.GetString(bytes, 3, bytes.Length - 3)
                    : Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
        /// <summary>
        /// Converts to utf8bytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToUtf8Bytes(this string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        /// <summary>
        /// Withouts the bom.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string WithoutBom(this string value)
        {
            return value.Length > 0 && value[0] == 65279
                ? value.Substring(1)
                : value;
        }

        /// <summary>
        /// from JWT spec
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string ToBase64UrlSafe(this byte[] input)
        {
            var output = Convert.ToBase64String(input);
            output = output.LeftPart('='); // Remove any trailing '='s
            output = output.Replace('+', '-'); // 62nd char of encoding
            output = output.Replace('/', '_'); // 63rd char of encoding
            return output;
        }

        /// <summary>
        /// Converts to base64urlsafe.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>System.String.</returns>
        public static string ToBase64UrlSafe(this MemoryStream ms)
        {
            var output = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            output = output.LeftPart('='); // Remove any trailing '='s
            output = output.Replace('+', '-'); // 62nd char of encoding
            output = output.Replace('/', '_'); // 63rd char of encoding
            return output;
        }
        /// <summary>
        /// from JWT spec
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="Exception">Illegal base64url string!</exception>
        public static byte[] FromBase64UrlSafe(this string input)
        {
            var output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding
            switch (output.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: output += "=="; break; // Two pad chars
                case 3: output += "="; break;  // One pad char
                default: throw new Exception("Illegal base64url string!");
            }
            var converted = Convert.FromBase64String(output); // Standard base64 decoder
            return converted;
        }

        /// <summary>
        /// Skip the encoding process for 'safe strings' 
        /// </summary>
        /// <param name="strVal"></param>
        /// <returns></returns>
        private static byte[] FastToUtf8Bytes(string strVal)
        {
            var bytes = new byte[strVal.Length];
            for (var i = 0; i < strVal.Length; i++)
                bytes[i] = (byte)strVal[i];

            return bytes;
        }
        /// <summary>
        /// Lefts the part.
        /// </summary>
        /// <param name="strVal">The string value.</param>
        /// <param name="needle">The needle.</param>
        /// <returns>System.String.</returns>
        public static string LeftPart(this string strVal, char needle)
        {
            if (strVal == null) return null;
            var pos = strVal.IndexOf(needle);
            return pos == -1
                ? strVal
                : strVal.Substring(0, pos);
        }
        /// <summary>
        /// Lefts the part.
        /// </summary>
        /// <param name="strVal">The string value.</param>
        /// <param name="needle">The needle.</param>
        /// <returns>System.String.</returns>
        public static string LeftPart(this string strVal, string needle)
        {
            if (strVal == null) return null;
            var pos = strVal.IndexOf(needle, StringComparison.OrdinalIgnoreCase);
            return pos == -1
                ? strVal
                : strVal.Substring(0, pos);
        }

    }
}

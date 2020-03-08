// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-03-08
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-08
// ***********************************************************************
// <copyright file="ContentFormat.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Kmmp.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Core namespace.
/// </summary>
namespace Kmmp.Kmmp.Core
{
    /// <summary>
    /// Class ContentFormat.
    /// </summary>
    public static class ContentFormat
    {
        /// <summary>
        /// The UTF8 suffix
        /// </summary>
        public const string Utf8Suffix = "; charset=utf-8";
        /// <summary>
        /// Matcheses the type of the content.
        /// </summary>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="matchesContentType">Type of the matches content.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool MatchesContentType(this string contentType, string matchesContentType)
        {
            return MimeTypes.MatchesContentType(contentType, matchesContentType);
        }
    }
}

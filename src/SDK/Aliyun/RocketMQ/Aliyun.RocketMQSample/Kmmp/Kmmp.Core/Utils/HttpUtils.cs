// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-03-08
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-08
// ***********************************************************************
// <copyright file="HttpUtils.cs" company="NoobCore.com">
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
/// The Utils namespace.
/// </summary>
namespace Kmmp.Core.Utils
{
    /// <summary>
    /// Class HttpUtils.
    /// </summary>
    public static class MimeTypes
    {
        /// <summary>
        /// The json
        /// </summary>
        public const string Json = "application/json";
        /// <summary>
        /// The json text
        /// </summary>
        public const string JsonText = "text/json";

        /// <summary>
        /// Compares two string from start to ';' char, case-insensitive,
        /// ignoring (trimming) spaces at start and end    
        /// </summary>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="matchesContentType">Type of the matches content.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool MatchesContentType(string contentType, string matchesContentType)
        {
            if (string.IsNullOrWhiteSpace(contentType) || string.IsNullOrWhiteSpace(matchesContentType))
                return false;

            int start = -1, matchStart = -1, matchEnd = -1;

            for (var i = 0; i < contentType.Length; i++)
            {
                if (char.IsWhiteSpace(contentType[i]))
                    continue;
                start = i;
                break;
            }

            for (var i = 0; i < matchesContentType.Length; i++)
            {
                if (char.IsWhiteSpace(matchesContentType[i]))
                    continue;
                if (matchesContentType[i] == ';')
                    break;
                if (matchStart == -1)
                    matchStart = i;
                matchEnd = i;
            }

            return start != -1 && matchStart != -1 && matchEnd != -1
                  && string.Compare(contentType, start,
                        matchesContentType, matchStart, matchEnd - matchStart + 1,
                        StringComparison.OrdinalIgnoreCase) == 0;
        }

    }
}

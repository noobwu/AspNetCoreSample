// ***********************************************************************
// Assembly         : AOPDemo
// Author           : Administrator
// Created          : 2020-02-27
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-27
// ***********************************************************************
// <copyright file="ErrorViewModel.cs" company="AOPDemo">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

/// <summary>
/// The Models namespace.
/// </summary>
namespace AOPDemo.Models
{
    /// <summary>
    /// Class ErrorViewModel.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the request identifier.
        /// </summary>
        /// <value>The request identifier.</value>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether [show request identifier].
        /// </summary>
        /// <value><c>true</c> if [show request identifier]; otherwise, <c>false</c>.</value>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

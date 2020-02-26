// ***********************************************************************
// Assembly         : AuthorizationSample
// Author           : Administrator
// Created          : 2019-02-12
//
// Last Modified By : Administrator
// Last Modified On : 2019-02-12
// ***********************************************************************
// <copyright file="Document.cs" company="AuthorizationSample">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationSample.Authorization;

/// <summary>
/// The Data namespace.
/// </summary>
namespace AuthorizationSample.Data
{
    /// <summary>
    /// Class Document.
    /// Implements the <see cref="AuthorizationSample.Authorization.IDocument" />
    /// </summary>
    /// <seealso cref="AuthorizationSample.Authorization.IDocument" />
    public class Document : IDocument
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Required]
        [Display(Name = "标题")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creator.
        /// </summary>
        /// <value>The creator.</value>
        [Display(Name = "创建人")]
        public string Creator { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        /// <value>The creation time.</value>
        [Display(Name = "创建时间")]
        public DateTime CreationTime { get; set; }
    }
}

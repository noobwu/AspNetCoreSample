// ***********************************************************************
// Assembly         : AuthorizationDemo
// Author           : Administrator
// Created          : 2019-02-12
//
// Last Modified By : Administrator
// Last Modified On : 2019-02-12
// ***********************************************************************
// <copyright file="PermissionAuthorizationRequirement.cs" company="AuthorizationDemo">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using AuthorizationDemo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;

/// <summary>
/// The Authorization namespace.
/// </summary>
namespace AuthorizationDemo.Authorization
{
    /// <summary>
    /// Class PermissionAuthorizationRequirement.
    /// Implements the <see cref="Microsoft.AspNetCore.Authorization.IAuthorizationRequirement" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Authorization.IAuthorizationRequirement" />
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionAuthorizationRequirement"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public PermissionAuthorizationRequirement(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 权限名称
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
    }
}
// ***********************************************************************
// Assembly         : AuthorizationDemo
// Author           : Administrator
// Created          : 2019-02-12
//
// Last Modified By : Administrator
// Last Modified On : 2019-02-12
// ***********************************************************************
// <copyright file="Operations.cs" company="AuthorizationDemo">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Authorization.Infrastructure;

/// <summary>
/// The Authorization namespace.
/// </summary>
namespace AuthorizationDemo.Authorization
{
    /// <summary>
    /// Class Operations.
    /// </summary>
    public static class Operations
    {
        /// <summary>
        /// The create
        /// </summary>
        public static OperationAuthorizationRequirement Create =
            new OperationAuthorizationRequirement { Name = "Create" };
        /// <summary>
        /// The read
        /// </summary>
        public static OperationAuthorizationRequirement Read =
            new OperationAuthorizationRequirement { Name = "Read" };
        /// <summary>
        /// The update
        /// </summary>
        public static OperationAuthorizationRequirement Update =
            new OperationAuthorizationRequirement { Name = "Update" };
        /// <summary>
        /// The delete
        /// </summary>
        public static OperationAuthorizationRequirement Delete =
            new OperationAuthorizationRequirement { Name = "Delete" };
    }
}

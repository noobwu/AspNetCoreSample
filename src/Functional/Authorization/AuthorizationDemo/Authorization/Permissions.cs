// ***********************************************************************
// Assembly         : AuthorizationDemo
// Author           : Administrator
// Created          : 2019-02-12
//
// Last Modified By : Administrator
// Last Modified On : 2019-02-12
// ***********************************************************************
// <copyright file="Permissions.cs" company="AuthorizationDemo">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The Authorization namespace.
/// </summary>
namespace AuthorizationDemo.Authorization
{
    /// <summary>
    /// Class Permissions.
    /// </summary>
    public static class Permissions
    {
        /// <summary>
        /// The role
        /// </summary>
        public const string Role = "Role";
        /// <summary>
        /// The role create
        /// </summary>
        public const string RoleCreate = "Role.Create";
        /// <summary>
        /// The role read
        /// </summary>
        public const string RoleRead = "Role.Read";
        /// <summary>
        /// The role update
        /// </summary>
        public const string RoleUpdate = "Role.Update";
        /// <summary>
        /// The role delete
        /// </summary>
        public const string RoleDelete = "Role.Delete";

        /// <summary>
        /// The user
        /// </summary>
        public const string User = "User";
        /// <summary>
        /// The user create
        /// </summary>
        public const string UserCreate = "User.Create";
        /// <summary>
        /// The user read
        /// </summary>
        public const string UserRead = "User.Read";
        /// <summary>
        /// The user update
        /// </summary>
        public const string UserUpdate = "User.Update";
        /// <summary>
        /// The user delete
        /// </summary>
        public const string UserDelete = "User.Delete";
    }
}

// ***********************************************************************
// Assembly         : AuthorizationSample
// Author           : Administrator
// Created          : 2019-02-12
//
// Last Modified By : Administrator
// Last Modified On : 2019-02-12
// ***********************************************************************
// <copyright file="UserStore.cs" company="AuthorizationSample">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using AuthorizationSample.Authorization;

/// <summary>
/// The Data namespace.
/// </summary>
namespace AuthorizationSample.Data
{
    /// <summary>
    /// Class UserStore.
    /// </summary>
    public class UserStore
    {
        /// <summary>
        /// The users
        /// </summary>
        private static List<User> _users = new List<User>() {
            new User {  Id=1, Name="admin", Password="111111", Role="admin", Email="admin@gmail.com", PhoneNumber="18800000000", Birthday = DateTime.Now },
            new User {  Id=2, Name="alice", Password="111111", Role="user", Email="alice@gmail.com", PhoneNumber="18800000001", Birthday = DateTime.Now.AddDays(-1), Permissions = new List<UserPermission> {
                    new UserPermission { UserId = 1, PermissionName = Permissions.User },
                    new UserPermission { UserId = 1, PermissionName = Permissions.Role }
                }
            },
            new User {  Id=3, Name="bob", Password="111111", Role = "user", Email="bob@gmail.com", PhoneNumber="18800000002", Birthday = DateTime.Now.AddDays(-10), Permissions = new List<UserPermission> {
                    new UserPermission { UserId = 2, PermissionName = Permissions.UserRead },
                    new UserPermission { UserId = 2, PermissionName = Permissions.RoleRead }
                }
            },
        };


        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List&lt;User&gt;.</returns>
        public List<User> GetAll()
        {
            return _users;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>User.</returns>
        public User Find(int id)
        {
            return _users.Find(_ => _.Id == id);
        }

        /// <summary>
        /// Finds the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>User.</returns>
        public User Find(string userName, string password)
        {
            return _users.FirstOrDefault(_ => _.Name == userName && _.Password == password);
        }

        /// <summary>
        /// Existses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Exists(int id)
        {
            return _users.Any(_ => _.Id == id);
        }

        /// <summary>
        /// Adds the specified document.
        /// </summary>
        /// <param name="doc">The document.</param>
        public void Add(User doc)
        {
            doc.Id = _users.Max(_ => _.Id) + 1;
            _users.Add(doc);
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="doc">The document.</param>
        public void Update(int id, User doc)
        {
            var oldDoc = _users.Find(_ => _.Id == id);
            if (oldDoc != null)
            {
                oldDoc.Name = doc.Name;
                oldDoc.Email = doc.Email;
                oldDoc.Password = doc.Password;
            }
        }

        /// <summary>
        /// Removes the specified document.
        /// </summary>
        /// <param name="doc">The document.</param>
        public void Remove(User doc)
        {
            if (doc != null)
            {
                _users.Remove(doc);
            }
        }

        /// <summary>
        /// Checks the permission.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="permissionName">Name of the permission.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CheckPermission(int userId, string permissionName)
        {
            var user = Find(userId);
            if (user == null) return false;
            return user.Permissions.Any(p => permissionName.StartsWith(p.PermissionName));
        }
    }
}

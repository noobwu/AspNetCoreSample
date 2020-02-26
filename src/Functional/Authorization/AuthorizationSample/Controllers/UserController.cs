// ***********************************************************************
// Assembly         : AuthorizationSample
// Author           : Administrator
// Created          : 2019-02-12
//
// Last Modified By : Administrator
// Last Modified On : 2019-02-12
// ***********************************************************************
// <copyright file="UserController.cs" company="AuthorizationSample">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using AuthorizationSample.Authorization;
using AuthorizationSample.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

/// <summary>
/// The Controllers namespace.
/// </summary>
namespace AuthorizationSample.Controllers
{
    /// <summary>
    /// Class UserController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    public class UserController : Controller
    {
        /// <summary>
        /// The user store
        /// </summary>
        private readonly UserStore _userStore;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userStore">The user store.</param>
        /// <param name="logger">The logger.</param>
        public UserController(UserStore userStore, ILogger<UserController> logger)
        {
            _userStore = userStore;
            _logger = logger;
        }


        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [PermissionFilter(Permissions.UserRead)]
        public ActionResult Index()
        {
            return View(_userStore.GetAll());
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        [PermissionFilter(Permissions.UserRead)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _userStore.Find(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [PermissionFilter(Permissions.UserCreate)]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>IActionResult.</returns>
        [PermissionFilter(Permissions.UserCreate)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title")] User user)
        {
            if (ModelState.IsValid)
            {
                _userStore.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [PermissionFilter(Permissions.UserUpdate)]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userStore.Find(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns>IActionResult.</returns>
        [PermissionFilter(Permissions.UserUpdate)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _userStore.Update(id, user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [PermissionFilter(Permissions.UserDelete)]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userStore.Find(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [PermissionFilter(Permissions.UserDelete)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _userStore.Find(id);
            _userStore.Remove(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
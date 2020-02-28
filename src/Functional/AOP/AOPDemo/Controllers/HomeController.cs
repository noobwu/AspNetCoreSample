// ***********************************************************************
// Assembly         : AOPDemo
// Author           : Administrator
// Created          : 2020-02-27
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-27
// ***********************************************************************
// <copyright file="HomeController.cs" company="AOPDemo">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AOPDemo.Models;
using AOPDemo.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

/// <summary>
/// The Controllers namespace.
/// </summary>
namespace AOPDemo.Controllers
{
    /// <summary>
    /// Class HomeController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<HomeController> _logger;
        /// <summary>
        /// The imte manage repository
        /// </summary>
        IItemManageRepository _imteManageRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="imteManageRepository">The imte manage repository.</param>
        public HomeController(ILogger<HomeController> logger, IItemManageRepository imteManageRepository)
        {
            _logger = logger;
            _imteManageRepository = imteManageRepository;
        }
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Indexes the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(string username)
        {
            //写Session
            HttpContext.Session.Set(username, Encoding.UTF8.GetBytes("我是Token:" + username));
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim("FullName", "Admin"),
                new Claim(ClaimTypes.Role,"Admin")
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(claims)));
            return new RedirectResult("/home/Privacy");
        }
        /// <summary>
        /// Privacies this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Errors this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

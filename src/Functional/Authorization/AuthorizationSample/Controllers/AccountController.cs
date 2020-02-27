// ***********************************************************************
// Assembly         : AuthorizationSample
// Author           : Administrator
// Created          : 2019-02-12
//
// Last Modified By : Administrator
// Last Modified On : 2019-02-12
// ***********************************************************************
// <copyright file="AccountController.cs" company="AuthorizationSample">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using AuthorizationSample.Data;
using AuthorizationSample.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;

/// <summary>
/// The Controllers namespace.
/// </summary>
namespace AuthorizationSample.Controllers
{
    /// <summary>
    /// Class AccountController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    public class AccountController : Controller
    {
        /// <summary>
        /// The user store
        /// </summary>
        private readonly UserStore _userStore;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<AccountController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userStore">The user store.</param>
        /// <param name="logger">The logger.</param>
        public AccountController(UserStore userStore, ILogger<AccountController> logger)
        {
            _userStore = userStore;
            _logger = logger;
        }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        [TempData]
        public string ErrorMessage { get; set; }


        /// <summary>
        /// Logins the specified return URL.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = _userStore.Find(model.UserName, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "用户名或密码错误。");
                    return View(model);
                }
                else
                {
                    var claimIdentity = new ClaimsIdentity("Cookie");
                    claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claimIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                    claimIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Role));
                    await HttpContext.SignInAsync(new ClaimsPrincipal(claimIdentity), 
                        new AuthenticationProperties { IsPersistent = model.RememberMe });
                    _logger.LogInformation("User logged in.");
                    return RedirectToLocal(returnUrl);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        /// <summary>
        /// Accesses the denied.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }


        /// <summary>
        /// Redirects to local.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>IActionResult.</returns>
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
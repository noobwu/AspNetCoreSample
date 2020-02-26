// ***********************************************************************
// Assembly         : AuthorizationSample
// Author           : Administrator
// Created          : 2019-02-12
//
// Last Modified By : Administrator
// Last Modified On : 2019-02-12
// ***********************************************************************
// <copyright file="DocumentController.cs" company="AuthorizationSample">
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
    /// Class DocumentController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    public class DocumentController : Controller
    {
        /// <summary>
        /// The document store
        /// </summary>
        private readonly DocumentStore _docStore;
        /// <summary>
        /// The authorization service
        /// </summary>
        private readonly IAuthorizationService _authorizationService;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<DocumentController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentController"/> class.
        /// </summary>
        /// <param name="docStore">The document store.</param>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="logger">The logger.</param>
        public DocumentController(DocumentStore docStore, IAuthorizationService authorizationService, ILogger<DocumentController> logger)
        {
            _docStore = docStore;
            _authorizationService = authorizationService;
            _logger = logger;
        }



        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View(_docStore.GetAll());
        }

        // GET: Documents/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var document = _docStore.Find(id.Value);
            if (document == null)
            {
                return NotFound();
            }
            if ((await _authorizationService.AuthorizeAsync(User, document, Operations.Read)).Succeeded)
            {
                return View(document);
            }
            else
            {
                return new ForbidResult();
            }
        }

        // GET: Documents/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: Documents/Create
        /// <summary>
        /// Creates the specified document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title")] Document document)
        {
            if (ModelState.IsValid)
            {
                document.Creator = User.Identity.Name;
                document.CreationTime = DateTime.Now;
                _docStore.Add(document);
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        // GET: Documents/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = _docStore.Find(id.Value);
            if (document == null)
            {
                return NotFound();
            }
            if ((await _authorizationService.AuthorizeAsync(User, document, Operations.Update)).Succeeded)
            {
                return View(document);
            }
            else
            {
                return new ForbidResult();
            }
        }

        // POST: Documents/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="document">The document.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title")] Document document)
        {
            if (id != document.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _docStore.Update(id, document);
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        // GET: Documents/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = _docStore.Find(id.Value);
            if (document == null)
            {
                return NotFound();
            }
            if ((await _authorizationService.AuthorizeAsync(User, document, Operations.Delete)).Succeeded)
            {
                return View(document);
            }
            else
            {
                return new ForbidResult();
            }
        }

        // POST: Documents/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = _docStore.Find(id);
            if ((await _authorizationService.AuthorizeAsync(User, document, Operations.Delete)).Succeeded)
            {
                _docStore.Remove(document);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return new ForbidResult();
            }
        }

        /// <summary>
        /// Documents the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool DocumentExists(int id)
        {
            return _docStore.Exists(id);
        }
    }
}
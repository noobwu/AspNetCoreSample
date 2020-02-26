// ***********************************************************************
// Assembly         : AuthorizationDemo
// Author           : Administrator
// Created          : 2019-02-12
//
// Last Modified By : Administrator
// Last Modified On : 2019-02-12
// ***********************************************************************
// <copyright file="DocumentAuthorizationHandler.cs" company="AuthorizationDemo">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using AuthorizationDemo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Threading.Tasks;

/// <summary>
/// The Authorization namespace.
/// </summary>
namespace AuthorizationDemo.Authorization
{
    /// <summary>
    /// Class DocumentAuthorizationHandler.
    /// Implements the <see cref="Microsoft.AspNetCore.Authorization.AuthorizationHandler{Microsoft.AspNetCore.Authorization.Infrastructure.OperationAuthorizationRequirement, AuthorizationDemo.Authorization.IDocument}" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Authorization.AuthorizationHandler{Microsoft.AspNetCore.Authorization.Infrastructure.OperationAuthorizationRequirement, AuthorizationDemo.Authorization.IDocument}" />
    public class DocumentAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, IDocument>
    {
        /// <summary>
        /// Makes a decision if authorization is allowed based on a specific requirement and resource.
        /// </summary>
        /// <param name="context">The authorization context.</param>
        /// <param name="requirement">The requirement to evaluate.</param>
        /// <param name="resource">The resource to evaluate.</param>
        /// <returns>Task.</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, IDocument resource)
        {
            if (context.User.IsInRole("admin"))
            {
                context.Succeed(requirement);
            }
            else
            {
                if (requirement == Operations.Create || requirement == Operations.Read)
                {
                    context.Succeed(requirement);
                }
                else
                {
                    if (context.User.Identity.Name == resource.Creator)
                    {
                        context.Succeed(requirement);
                    }
                    else
                    {
                        context.Fail();
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}

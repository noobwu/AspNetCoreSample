// ***********************************************************************
// Assembly         : AOPDemo
// Author           : Administrator
// Created          : 2020-02-27
//
// Last Modified By : Administrator
// Last Modified On : 2019-08-22
// ***********************************************************************
// <copyright file="ItemManageRepository.cs" company="AOPDemo">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// The Repository namespace.
/// </summary>
namespace AOPDemo.Models.Repository
{
    /// <summary>
    /// Class ItemManageRepository.
    /// Implements the <see cref="AOPDemo.Models.Repository.IItemManageRepository" />
    /// </summary>
    /// <seealso cref="AOPDemo.Models.Repository.IItemManageRepository" />
    public class ItemManageRepository:IItemManageRepository
    {

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="token">The token.</param>
        /// <returns>System.String.</returns>
        public string  AddItem(Item item,string token="")
        {
            return token;
        }
    }
}

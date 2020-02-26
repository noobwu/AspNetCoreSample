// ***********************************************************************
// Assembly         : AuthorizationSample
// Author           : Administrator
// Created          : 2019-02-12
//
// Last Modified By : Administrator
// Last Modified On : 2019-02-12
// ***********************************************************************
// <copyright file="DocumentStore.cs" company="AuthorizationSample">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The Data namespace.
/// </summary>
namespace AuthorizationSample.Data
{
    /// <summary>
    /// Class DocumentStore.
    /// </summary>
    public class DocumentStore
    {
        /// <summary>
        /// The documents
        /// </summary>
        private static List<Document> _documents = new List<Document>() {
            new Document {  Id=1,Title="今天天气真好！", Creator="alice",  CreationTime=DateTime.Now },
            new Document {  Id=2, Title="何为道心？", Creator="bob",  CreationTime=DateTime.Now.AddDays(1) }
        };

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List&lt;Document&gt;.</returns>
        public List<Document> GetAll()
        {
            return _documents;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Document.</returns>
        public Document Find(int id)
        {
            return _documents.Find(_ => _.Id == id);
        }

        /// <summary>
        /// Existses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Exists(int id)
        {
            return _documents.Any(_ => _.Id == id);
        }

        /// <summary>
        /// Adds the specified document.
        /// </summary>
        /// <param name="doc">The document.</param>
        public void Add(Document doc)
        {
            doc.Id = _documents.Max(_ => _.Id) + 1;
            _documents.Add(doc);
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="doc">The document.</param>
        public void Update(int id, Document doc)
        {
            var oldDoc = _documents.Find(_ => _.Id == id);
            if (oldDoc != null)
            {
                oldDoc.Title = doc.Title;
            }
        }

        /// <summary>
        /// Removes the specified document.
        /// </summary>
        /// <param name="doc">The document.</param>
        public void Remove(Document doc)
        {
            if (doc != null)
            {
                _documents.Remove(doc);
            }
        }
    }
}

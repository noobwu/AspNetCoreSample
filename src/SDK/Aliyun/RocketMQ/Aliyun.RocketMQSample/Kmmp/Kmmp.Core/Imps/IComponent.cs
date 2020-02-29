// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-29
// ***********************************************************************
// <copyright file="IComponent.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Imps namespace.
/// </summary>
namespace Kmmp.Core.Imps
{
    /// <summary>
    /// 作者：吴廷有
    /// 时间：2015-10-23
    /// 功能：组件基类
    /// </summary>
    public interface IComponent
    {
        #region "  方法定义  "

        /// <summary>
        /// 作者：吴廷有
        /// 时间：2015-10-23
        /// 功能：初始化组件
        /// </summary>
        void Init();

        #endregion
    }
}

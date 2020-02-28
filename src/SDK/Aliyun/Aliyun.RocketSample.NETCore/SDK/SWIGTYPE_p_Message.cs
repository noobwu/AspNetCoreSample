// ***********************************************************************
// Assembly         : Aliyun.RocketSample.NETCore
// Author           : Administrator
// Created          : 2020-02-28
//
// Last Modified By : Administrator
// Last Modified On : 2020-02-28
// ***********************************************************************
// <copyright file="SWIGTYPE_p_Message.cs" company="Aliyun.RocketSample.NETCore">
//     Copyright (c) NoobCore.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


/// <summary>
/// Class SWIGTYPE_p_Message.
/// </summary>
public class SWIGTYPE_p_Message
{
    /// <summary>
    /// The swig c PTR
    /// </summary>
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;

    /// <summary>
    /// Initializes a new instance of the <see cref="SWIGTYPE_p_Message"/> class.
    /// </summary>
    /// <param name="cPtr">The c PTR.</param>
    /// <param name="futureUse">if set to <c>true</c> [future use].</param>
    internal SWIGTYPE_p_Message(global::System.IntPtr cPtr, bool futureUse)
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SWIGTYPE_p_Message"/> class.
    /// </summary>
    protected SWIGTYPE_p_Message()
    {
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
    }

    /// <summary>
    /// Gets the c PTR.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <returns>System.Runtime.InteropServices.HandleRef.</returns>
    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SWIGTYPE_p_Message obj)
    {
        return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
}

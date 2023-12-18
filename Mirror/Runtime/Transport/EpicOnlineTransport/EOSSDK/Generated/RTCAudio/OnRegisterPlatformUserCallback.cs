// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.RTCAudio
{
	/// <summary>
	/// Callback for completion of register platform user request.
	/// </summary>
	public delegate void OnRegisterPlatformUserCallback(ref OnRegisterPlatformUserCallbackInfo data);

	[System.Runtime.InteropServices.UnmanagedFunctionPointer(Config.LibraryCallingConvention)]
	internal delegate void OnRegisterPlatformUserCallbackInternal(ref OnRegisterPlatformUserCallbackInfoInternal data);
}
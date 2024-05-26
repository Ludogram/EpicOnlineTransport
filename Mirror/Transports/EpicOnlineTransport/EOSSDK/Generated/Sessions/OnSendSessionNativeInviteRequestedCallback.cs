// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Sessions
{
	/// <summary>
	/// Function prototype definition for notifications that comes from <see cref="SessionsInterface.AddNotifySendSessionNativeInviteRequested" />
	/// After processing the callback EOS_UI_AcknowledgeEventId must be called.
	/// <seealso cref="UI.UIInterface.AcknowledgeEventId" />
	/// </summary>
	/// <param name="data">A <see cref="SendSessionNativeInviteRequestedCallbackInfo" /> containing the output information and result</param>
	public delegate void OnSendSessionNativeInviteRequestedCallback(ref SendSessionNativeInviteRequestedCallbackInfo data);

	[System.Runtime.InteropServices.UnmanagedFunctionPointer(Config.LibraryCallingConvention)]
	internal delegate void OnSendSessionNativeInviteRequestedCallbackInternal(ref SendSessionNativeInviteRequestedCallbackInfoInternal data);
}
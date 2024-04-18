// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Connect
{
	/// <summary>
	/// Input parameters for the <see cref="ConnectInterface.UnlinkAccount" /> Function.
	/// </summary>
	public struct UnlinkAccountOptions
	{
		/// <summary>
		/// Existing logged in product user that is subject for the unlinking operation.
		/// The external account that was used to login to the product user will be unlinked from the owning keychain.
		/// 
		/// On a successful operation, the product user will be logged out as the external account used to authenticate the user was unlinked from the owning keychain.
		/// </summary>
		public ProductUserId LocalUserId { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct UnlinkAccountOptionsInternal : ISettable<UnlinkAccountOptions>, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_LocalUserId;

		public ProductUserId LocalUserId
		{
			set
			{
				Helper.Set(value, ref m_LocalUserId);
			}
		}

		public void Set(ref UnlinkAccountOptions other)
		{
			m_ApiVersion = ConnectInterface.UnlinkaccountApiLatest;
			LocalUserId = other.LocalUserId;
		}

		public void Set(ref UnlinkAccountOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = ConnectInterface.UnlinkaccountApiLatest;
				LocalUserId = other.Value.LocalUserId;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_LocalUserId);
		}
	}
}
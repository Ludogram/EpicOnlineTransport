// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Sessions
{
	/// <summary>
	/// Input parameters for the <see cref="SessionModification.RemoveAttribute" /> function.
	/// </summary>
	public struct SessionModificationRemoveAttributeOptions
	{
		/// <summary>
		/// Session attribute to remove from the session
		/// </summary>
		public Utf8String Key { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct SessionModificationRemoveAttributeOptionsInternal : ISettable<SessionModificationRemoveAttributeOptions>, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_Key;

		public Utf8String Key
		{
			set
			{
				Helper.Set(value, ref m_Key);
			}
		}

		public void Set(ref SessionModificationRemoveAttributeOptions other)
		{
			m_ApiVersion = SessionModification.SessionmodificationRemoveattributeApiLatest;
			Key = other.Key;
		}

		public void Set(ref SessionModificationRemoveAttributeOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = SessionModification.SessionmodificationRemoveattributeApiLatest;
				Key = other.Value.Key;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_Key);
		}
	}
}
// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.PlayerDataStorage
{
	/// <summary>
	/// Input data for the CopyFileMetadataAtIndex function
	/// </summary>
	public struct CopyFileMetadataAtIndexOptions
	{
		/// <summary>
		/// The Product User ID of the local user who is requesting file metadata
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// The index to get data for
		/// </summary>
		public uint Index { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct CopyFileMetadataAtIndexOptionsInternal : ISettable<CopyFileMetadataAtIndexOptions>, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_LocalUserId;
		private uint m_Index;

		public ProductUserId LocalUserId
		{
			set
			{
				Helper.Set(value, ref m_LocalUserId);
			}
		}

		public uint Index
		{
			set
			{
				m_Index = value;
			}
		}

		public void Set(ref CopyFileMetadataAtIndexOptions other)
		{
			m_ApiVersion = PlayerDataStorageInterface.CopyfilemetadataatindexApiLatest;
			LocalUserId = other.LocalUserId;
			Index = other.Index;
		}

		public void Set(ref CopyFileMetadataAtIndexOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = PlayerDataStorageInterface.CopyfilemetadataatindexApiLatest;
				LocalUserId = other.Value.LocalUserId;
				Index = other.Value.Index;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_LocalUserId);
		}
	}
}
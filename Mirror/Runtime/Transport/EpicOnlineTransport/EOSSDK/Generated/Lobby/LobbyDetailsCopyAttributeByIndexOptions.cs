// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Lobby
{
	/// <summary>
	/// Input parameters for the <see cref="LobbyDetails.CopyAttributeByIndex" /> function.
	/// </summary>
	public struct LobbyDetailsCopyAttributeByIndexOptions
	{
		/// <summary>
		/// The index of the attribute to retrieve
		/// <seealso cref="LobbyDetails.GetAttributeCount" />
		/// </summary>
		public uint AttrIndex { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct LobbyDetailsCopyAttributeByIndexOptionsInternal : ISettable<LobbyDetailsCopyAttributeByIndexOptions>, System.IDisposable
	{
		private int m_ApiVersion;
		private uint m_AttrIndex;

		public uint AttrIndex
		{
			set
			{
				m_AttrIndex = value;
			}
		}

		public void Set(ref LobbyDetailsCopyAttributeByIndexOptions other)
		{
			m_ApiVersion = LobbyDetails.LobbydetailsCopyattributebyindexApiLatest;
			AttrIndex = other.AttrIndex;
		}

		public void Set(ref LobbyDetailsCopyAttributeByIndexOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = LobbyDetails.LobbydetailsCopyattributebyindexApiLatest;
				AttrIndex = other.Value.AttrIndex;
			}
		}

		public void Dispose()
		{
		}
	}
}
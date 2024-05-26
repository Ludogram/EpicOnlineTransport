// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.P2P
{
	/// <summary>
	/// Structure containing information needed to query NAT-types
	/// </summary>
	public struct QueryNATTypeOptions
	{
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct QueryNATTypeOptionsInternal : ISettable<QueryNATTypeOptions>, System.IDisposable
	{
		private int m_ApiVersion;

		public void Set(ref QueryNATTypeOptions other)
		{
			m_ApiVersion = P2PInterface.QuerynattypeApiLatest;
		}

		public void Set(ref QueryNATTypeOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = P2PInterface.QuerynattypeApiLatest;
			}
		}

		public void Dispose()
		{
		}
	}
}
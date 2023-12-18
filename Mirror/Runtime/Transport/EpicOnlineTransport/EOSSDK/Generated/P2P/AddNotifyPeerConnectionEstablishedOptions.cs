// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.P2P
{
	/// <summary>
	/// Structure containing information about which connections should be notified
	/// </summary>
	public struct AddNotifyPeerConnectionEstablishedOptions
	{
		/// <summary>
		/// The Product User ID of the local user who would like to receive notifications
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// The optional socket ID, used as a filter for established connections. If <see langword="null" />, this function handler will be called for all sockets
		/// </summary>
		public SocketId? SocketId { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct AddNotifyPeerConnectionEstablishedOptionsInternal : ISettable<AddNotifyPeerConnectionEstablishedOptions>, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_LocalUserId;
		private System.IntPtr m_SocketId;

		public ProductUserId LocalUserId
		{
			set
			{
				Helper.Set(value, ref m_LocalUserId);
			}
		}

		public SocketId? SocketId
		{
			set
			{
				Helper.Set<SocketId, SocketIdInternal>(ref value, ref m_SocketId);
			}
		}

		public void Set(ref AddNotifyPeerConnectionEstablishedOptions other)
		{
			m_ApiVersion = P2PInterface.AddnotifypeerconnectionestablishedApiLatest;
			LocalUserId = other.LocalUserId;
			SocketId = other.SocketId;
		}

		public void Set(ref AddNotifyPeerConnectionEstablishedOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = P2PInterface.AddnotifypeerconnectionestablishedApiLatest;
				LocalUserId = other.Value.LocalUserId;
				SocketId = other.Value.SocketId;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_LocalUserId);
			Helper.Dispose(ref m_SocketId);
		}
	}
}
// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.P2P
{
	/// <summary>
	/// P2P Socket ID
	/// 
	/// The Socket ID contains an application-defined name for the connection between a local person and another peer.
	/// 
	/// When a remote user receives a connection request from you, they will receive this information. It can be important
	/// to only accept connections with a known socket-name and/or from a known user, to prevent leaking of private
	/// information, such as a user's IP address. Using the socket name as a secret key can help prevent such leaks. Shared
	/// private data, like a private match's Session ID are good candidates for a socket name.
	/// </summary>
	public class SocketId : ISettable
	{
		/// <summary>
		/// A name for the connection. Must be a NULL-terminated string of between 1-32 alpha-numeric characters (A-Z, a-z, 0-9)
		/// </summary>
		public string SocketName { get; set; }

		internal void Set(SocketIdInternal? other)
		{
			if (other != null)
			{
				SocketName = other.Value.SocketName;
			}
		}

		public void Set(object other)
		{
			Set(other as SocketIdInternal?);
		}
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct SocketIdInternal : ISettable, System.IDisposable
	{
		private int m_ApiVersion;
		[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 33)]
		private byte[] m_SocketName;

		public string SocketName
		{
			get
			{
				string value;
				Helper.TryMarshalGet(m_SocketName, out value);
				return value;
			}

			set
			{
				Helper.TryMarshalSet(ref m_SocketName, value, 33);
			}
		}

		public void Set(SocketId other)
		{
			if (other != null)
			{
				m_ApiVersion = P2PInterface.SocketidApiLatest;
				SocketName = other.SocketName;
			}
		}

		public void Set(object other)
		{
			Set(other as SocketId);
		}

		public void Dispose()
		{
		}
	}
}
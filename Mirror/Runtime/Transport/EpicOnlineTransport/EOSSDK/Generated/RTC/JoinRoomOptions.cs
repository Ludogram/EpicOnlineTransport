// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.RTC
{
	/// <summary>
	/// This struct is used to call <see cref="RTCInterface.JoinRoom" />.
	/// </summary>
	public struct JoinRoomOptions
	{
		/// <summary>
		/// The product user id of the user trying to request this operation.
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// The room the user would like to join.
		/// </summary>
		public Utf8String RoomName { get; set; }

		/// <summary>
		/// The room the user would like to join.
		/// </summary>
		public Utf8String ClientBaseUrl { get; set; }

		/// <summary>
		/// Authorization credential token to join the room.
		/// </summary>
		public Utf8String ParticipantToken { get; set; }

		/// <summary>
		/// The participant id used to join the room. If set to <see langword="null" /> the LocalUserId will be used instead.
		/// </summary>
		public ProductUserId ParticipantId { get; set; }

		/// <summary>
		/// Join room flags, e.g. <see cref="JoinRoomFlags.EnableEcho" />. This is a bitwise-or union of the defined flags.
		/// </summary>
		public JoinRoomFlags Flags { get; set; }

		/// <summary>
		/// Enable or disable Manual Audio Input. If manual audio input is enabled audio recording is not started and the audio
		/// buffers must be passed manually using <see cref="RTCAudio.RTCAudioInterface.SendAudio" />.
		/// </summary>
		public bool ManualAudioInputEnabled { get; set; }

		/// <summary>
		/// Enable or disable Manual Audio Output. If manual audio output is enabled audio rendering is not started and the audio
		/// buffers must be received with <see cref="RTCAudio.RTCAudioInterface.AddNotifyAudioBeforeRender" /> and rendered manually.
		/// </summary>
		public bool ManualAudioOutputEnabled { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct JoinRoomOptionsInternal : ISettable<JoinRoomOptions>, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_LocalUserId;
		private System.IntPtr m_RoomName;
		private System.IntPtr m_ClientBaseUrl;
		private System.IntPtr m_ParticipantToken;
		private System.IntPtr m_ParticipantId;
		private JoinRoomFlags m_Flags;
		private int m_ManualAudioInputEnabled;
		private int m_ManualAudioOutputEnabled;

		public ProductUserId LocalUserId
		{
			set
			{
				Helper.Set(value, ref m_LocalUserId);
			}
		}

		public Utf8String RoomName
		{
			set
			{
				Helper.Set(value, ref m_RoomName);
			}
		}

		public Utf8String ClientBaseUrl
		{
			set
			{
				Helper.Set(value, ref m_ClientBaseUrl);
			}
		}

		public Utf8String ParticipantToken
		{
			set
			{
				Helper.Set(value, ref m_ParticipantToken);
			}
		}

		public ProductUserId ParticipantId
		{
			set
			{
				Helper.Set(value, ref m_ParticipantId);
			}
		}

		public JoinRoomFlags Flags
		{
			set
			{
				m_Flags = value;
			}
		}

		public bool ManualAudioInputEnabled
		{
			set
			{
				Helper.Set(value, ref m_ManualAudioInputEnabled);
			}
		}

		public bool ManualAudioOutputEnabled
		{
			set
			{
				Helper.Set(value, ref m_ManualAudioOutputEnabled);
			}
		}

		public void Set(ref JoinRoomOptions other)
		{
			m_ApiVersion = RTCInterface.JoinroomApiLatest;
			LocalUserId = other.LocalUserId;
			RoomName = other.RoomName;
			ClientBaseUrl = other.ClientBaseUrl;
			ParticipantToken = other.ParticipantToken;
			ParticipantId = other.ParticipantId;
			Flags = other.Flags;
			ManualAudioInputEnabled = other.ManualAudioInputEnabled;
			ManualAudioOutputEnabled = other.ManualAudioOutputEnabled;
		}

		public void Set(ref JoinRoomOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = RTCInterface.JoinroomApiLatest;
				LocalUserId = other.Value.LocalUserId;
				RoomName = other.Value.RoomName;
				ClientBaseUrl = other.Value.ClientBaseUrl;
				ParticipantToken = other.Value.ParticipantToken;
				ParticipantId = other.Value.ParticipantId;
				Flags = other.Value.Flags;
				ManualAudioInputEnabled = other.Value.ManualAudioInputEnabled;
				ManualAudioOutputEnabled = other.Value.ManualAudioOutputEnabled;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_LocalUserId);
			Helper.Dispose(ref m_RoomName);
			Helper.Dispose(ref m_ClientBaseUrl);
			Helper.Dispose(ref m_ParticipantToken);
			Helper.Dispose(ref m_ParticipantId);
		}
	}
}
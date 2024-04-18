// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.RTCAudio
{
	/// <summary>
	/// This struct is passed in with a call to <see cref="RTCAudioInterface.AddNotifyAudioBeforeRender" /> registered event.
	/// </summary>
	public struct AudioBeforeRenderCallbackInfo : ICallbackInfo
	{
		/// <summary>
		/// Client-specified data passed into <see cref="RTCAudioInterface.AddNotifyAudioBeforeRender" />.
		/// </summary>
		public object ClientData { get; set; }

		/// <summary>
		/// The Product User ID of the user who initiated this request.
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// The room associated with this event.
		/// </summary>
		public Utf8String RoomName { get; set; }

		/// <summary>
		/// Audio buffer.
		/// </summary>
		public AudioBuffer? Buffer { get; set; }

		/// <summary>
		/// The Product User ID of the participant if bUnmixedAudio was set to true when setting the notifications, or empty if
		/// bUnmixedAudio was set to false and thus the buffer is the mixed audio of all participants
		/// </summary>
		public ProductUserId ParticipantId { get; set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(ref AudioBeforeRenderCallbackInfoInternal other)
		{
			ClientData = other.ClientData;
			LocalUserId = other.LocalUserId;
			RoomName = other.RoomName;
			Buffer = other.Buffer;
			ParticipantId = other.ParticipantId;
		}
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct AudioBeforeRenderCallbackInfoInternal : ICallbackInfoInternal, IGettable<AudioBeforeRenderCallbackInfo>, ISettable<AudioBeforeRenderCallbackInfo>, System.IDisposable
	{
		private System.IntPtr m_ClientData;
		private System.IntPtr m_LocalUserId;
		private System.IntPtr m_RoomName;
		private System.IntPtr m_Buffer;
		private System.IntPtr m_ParticipantId;

		public object ClientData
		{
			get
			{
				object value;
				Helper.Get(m_ClientData, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_ClientData);
			}
		}

		public System.IntPtr ClientDataAddress
		{
			get
			{
				return m_ClientData;
			}
		}

		public ProductUserId LocalUserId
		{
			get
			{
				ProductUserId value;
				Helper.Get(m_LocalUserId, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_LocalUserId);
			}
		}

		public Utf8String RoomName
		{
			get
			{
				Utf8String value;
				Helper.Get(m_RoomName, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_RoomName);
			}
		}

		public AudioBuffer? Buffer
		{
			get
			{
				AudioBuffer? value;
				Helper.Get<AudioBufferInternal, AudioBuffer>(m_Buffer, out value);
				return value;
			}

			set
			{
				Helper.Set<AudioBuffer, AudioBufferInternal>(ref value, ref m_Buffer);
			}
		}

		public ProductUserId ParticipantId
		{
			get
			{
				ProductUserId value;
				Helper.Get(m_ParticipantId, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_ParticipantId);
			}
		}

		public void Set(ref AudioBeforeRenderCallbackInfo other)
		{
			ClientData = other.ClientData;
			LocalUserId = other.LocalUserId;
			RoomName = other.RoomName;
			Buffer = other.Buffer;
			ParticipantId = other.ParticipantId;
		}

		public void Set(ref AudioBeforeRenderCallbackInfo? other)
		{
			if (other.HasValue)
			{
				ClientData = other.Value.ClientData;
				LocalUserId = other.Value.LocalUserId;
				RoomName = other.Value.RoomName;
				Buffer = other.Value.Buffer;
				ParticipantId = other.Value.ParticipantId;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_ClientData);
			Helper.Dispose(ref m_LocalUserId);
			Helper.Dispose(ref m_RoomName);
			Helper.Dispose(ref m_Buffer);
			Helper.Dispose(ref m_ParticipantId);
		}

		public void Get(out AudioBeforeRenderCallbackInfo output)
		{
			output = new AudioBeforeRenderCallbackInfo();
			output.Set(ref this);
		}
	}
}
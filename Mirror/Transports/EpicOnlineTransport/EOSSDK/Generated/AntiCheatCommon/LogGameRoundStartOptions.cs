// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.AntiCheatCommon
{
	public struct LogGameRoundStartOptions
	{
		/// <summary>
		/// Optional game session or match identifier useful for some backend API integrations
		/// </summary>
		public Utf8String SessionIdentifier { get; set; }

		/// <summary>
		/// Optional name of the map being played
		/// </summary>
		public Utf8String LevelName { get; set; }

		/// <summary>
		/// Optional name of the game mode being played
		/// </summary>
		public Utf8String ModeName { get; set; }

		/// <summary>
		/// Optional length of the game round to be played, in seconds. If none, use 0.
		/// </summary>
		public uint RoundTimeSeconds { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct LogGameRoundStartOptionsInternal : ISettable<LogGameRoundStartOptions>, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_SessionIdentifier;
		private System.IntPtr m_LevelName;
		private System.IntPtr m_ModeName;
		private uint m_RoundTimeSeconds;

		public Utf8String SessionIdentifier
		{
			set
			{
				Helper.Set(value, ref m_SessionIdentifier);
			}
		}

		public Utf8String LevelName
		{
			set
			{
				Helper.Set(value, ref m_LevelName);
			}
		}

		public Utf8String ModeName
		{
			set
			{
				Helper.Set(value, ref m_ModeName);
			}
		}

		public uint RoundTimeSeconds
		{
			set
			{
				m_RoundTimeSeconds = value;
			}
		}

		public void Set(ref LogGameRoundStartOptions other)
		{
			m_ApiVersion = AntiCheatCommonInterface.LoggameroundstartApiLatest;
			SessionIdentifier = other.SessionIdentifier;
			LevelName = other.LevelName;
			ModeName = other.ModeName;
			RoundTimeSeconds = other.RoundTimeSeconds;
		}

		public void Set(ref LogGameRoundStartOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = AntiCheatCommonInterface.LoggameroundstartApiLatest;
				SessionIdentifier = other.Value.SessionIdentifier;
				LevelName = other.Value.LevelName;
				ModeName = other.Value.ModeName;
				RoundTimeSeconds = other.Value.RoundTimeSeconds;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_SessionIdentifier);
			Helper.Dispose(ref m_LevelName);
			Helper.Dispose(ref m_ModeName);
		}
	}
}
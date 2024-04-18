// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Presence
{
	/// <summary>
	/// An individual presence data record that belongs to a <see cref="Info" /> object. This object is released when its parent <see cref="Info" /> object is released.
	/// <seealso cref="Info" />
	/// </summary>
	public struct DataRecord
	{
		/// <summary>
		/// The name of this data
		/// </summary>
		public Utf8String Key { get; set; }

		/// <summary>
		/// The value of this data
		/// </summary>
		public Utf8String Value { get; set; }

		internal void Set(ref DataRecordInternal other)
		{
			Key = other.Key;
			Value = other.Value;
		}
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct DataRecordInternal : IGettable<DataRecord>, ISettable<DataRecord>, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_Key;
		private System.IntPtr m_Value;

		public Utf8String Key
		{
			get
			{
				Utf8String value;
				Helper.Get(m_Key, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_Key);
			}
		}

		public Utf8String Value
		{
			get
			{
				Utf8String value;
				Helper.Get(m_Value, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_Value);
			}
		}

		public void Set(ref DataRecord other)
		{
			m_ApiVersion = PresenceInterface.DatarecordApiLatest;
			Key = other.Key;
			Value = other.Value;
		}

		public void Set(ref DataRecord? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = PresenceInterface.DatarecordApiLatest;
				Key = other.Value.Key;
				Value = other.Value.Value;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_Key);
			Helper.Dispose(ref m_Value);
		}

		public void Get(out DataRecord output)
		{
			output = new DataRecord();
			output.Set(ref this);
		}
	}
}
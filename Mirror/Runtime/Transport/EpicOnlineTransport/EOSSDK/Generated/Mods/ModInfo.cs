// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Mods
{
	/// <summary>
	/// Data for the <see cref="ModsInterface.CopyModInfo" /> function.
	/// <seealso cref="ModsInterface.CopyModInfo" />
	/// <seealso cref="ModsInterface.Release" />
	/// </summary>
	public struct ModInfo
	{
		/// <summary>
		/// The array of enumerated mods or <see langword="null" /> if no such type of mods were enumerated
		/// </summary>
		public ModIdentifier[] Mods { get; set; }

		/// <summary>
		/// Type of the mods
		/// </summary>
		public ModEnumerationType Type { get; set; }

		internal void Set(ref ModInfoInternal other)
		{
			Mods = other.Mods;
			Type = other.Type;
		}
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct ModInfoInternal : IGettable<ModInfo>, ISettable<ModInfo>, System.IDisposable
	{
		private int m_ApiVersion;
		private int m_ModsCount;
		private System.IntPtr m_Mods;
		private ModEnumerationType m_Type;

		public ModIdentifier[] Mods
		{
			get
			{
				ModIdentifier[] value;
				Helper.Get<ModIdentifierInternal, ModIdentifier>(m_Mods, out value, m_ModsCount);
				return value;
			}

			set
			{
				Helper.Set<ModIdentifier, ModIdentifierInternal>(ref value, ref m_Mods, out m_ModsCount);
			}
		}

		public ModEnumerationType Type
		{
			get
			{
				return m_Type;
			}

			set
			{
				m_Type = value;
			}
		}

		public void Set(ref ModInfo other)
		{
			m_ApiVersion = ModsInterface.CopymodinfoApiLatest;
			Mods = other.Mods;
			Type = other.Type;
		}

		public void Set(ref ModInfo? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = ModsInterface.CopymodinfoApiLatest;
				Mods = other.Value.Mods;
				Type = other.Value.Type;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_Mods);
		}

		public void Get(out ModInfo output)
		{
			output = new ModInfo();
			output.Set(ref this);
		}
	}
}
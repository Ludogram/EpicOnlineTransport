// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.UI
{
	/// <summary>
	/// A rectangle.
	/// </summary>
	public struct Rect
	{
		/// <summary>
		/// Left coordinate.
		/// </summary>
		public int X { get; set; }

		/// <summary>
		/// Top coordinate.
		/// </summary>
		public int Y { get; set; }

		/// <summary>
		/// Width.
		/// </summary>
		public uint Width { get; set; }

		/// <summary>
		/// Height.
		/// </summary>
		public uint Height { get; set; }

		internal void Set(ref RectInternal other)
		{
			X = other.X;
			Y = other.Y;
			Width = other.Width;
			Height = other.Height;
		}
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct RectInternal : IGettable<Rect>, ISettable<Rect>, System.IDisposable
	{
		private int m_ApiVersion;
		private int m_X;
		private int m_Y;
		private uint m_Width;
		private uint m_Height;

		public int X
		{
			get
			{
				return m_X;
			}

			set
			{
				m_X = value;
			}
		}

		public int Y
		{
			get
			{
				return m_Y;
			}

			set
			{
				m_Y = value;
			}
		}

		public uint Width
		{
			get
			{
				return m_Width;
			}

			set
			{
				m_Width = value;
			}
		}

		public uint Height
		{
			get
			{
				return m_Height;
			}

			set
			{
				m_Height = value;
			}
		}

		public void Set(ref Rect other)
		{
			m_ApiVersion = UIInterface.RectApiLatest;
			X = other.X;
			Y = other.Y;
			Width = other.Width;
			Height = other.Height;
		}

		public void Set(ref Rect? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = UIInterface.RectApiLatest;
				X = other.Value.X;
				Y = other.Value.Y;
				Width = other.Value.Width;
				Height = other.Value.Height;
			}
		}

		public void Dispose()
		{
		}

		public void Get(out Rect output)
		{
			output = new Rect();
			output.Set(ref this);
		}
	}
}
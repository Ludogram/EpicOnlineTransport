// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.PlayerDataStorage
{
	/// <summary>
	/// Data containing information about a query file list request
	/// </summary>
	public struct QueryFileListCallbackInfo : ICallbackInfo
	{
		/// <summary>
		/// Result code for the operation. <see cref="Result.Success" /> is returned for a successful request, other codes indicate an error
		/// </summary>
		public Result ResultCode { get; set; }

		/// <summary>
		/// Client-specified data passed into the file query request
		/// </summary>
		public object ClientData { get; set; }

		/// <summary>
		/// The Product User ID of the local user who initiated this request
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// A count of files that were found, if successful
		/// </summary>
		public uint FileCount { get; set; }

		public Result? GetResultCode()
		{
			return ResultCode;
		}

		internal void Set(ref QueryFileListCallbackInfoInternal other)
		{
			ResultCode = other.ResultCode;
			ClientData = other.ClientData;
			LocalUserId = other.LocalUserId;
			FileCount = other.FileCount;
		}
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct QueryFileListCallbackInfoInternal : ICallbackInfoInternal, IGettable<QueryFileListCallbackInfo>, ISettable<QueryFileListCallbackInfo>, System.IDisposable
	{
		private Result m_ResultCode;
		private System.IntPtr m_ClientData;
		private System.IntPtr m_LocalUserId;
		private uint m_FileCount;

		public Result ResultCode
		{
			get
			{
				return m_ResultCode;
			}

			set
			{
				m_ResultCode = value;
			}
		}

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

		public uint FileCount
		{
			get
			{
				return m_FileCount;
			}

			set
			{
				m_FileCount = value;
			}
		}

		public void Set(ref QueryFileListCallbackInfo other)
		{
			ResultCode = other.ResultCode;
			ClientData = other.ClientData;
			LocalUserId = other.LocalUserId;
			FileCount = other.FileCount;
		}

		public void Set(ref QueryFileListCallbackInfo? other)
		{
			if (other.HasValue)
			{
				ResultCode = other.Value.ResultCode;
				ClientData = other.Value.ClientData;
				LocalUserId = other.Value.LocalUserId;
				FileCount = other.Value.FileCount;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_ClientData);
			Helper.Dispose(ref m_LocalUserId);
		}

		public void Get(out QueryFileListCallbackInfo output)
		{
			output = new QueryFileListCallbackInfo();
			output.Set(ref this);
		}
	}
}
// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Auth
{
	/// <summary>
	/// Output parameters for the <see cref="AuthInterface.LinkAccount" /> Function.
	/// </summary>
	public struct LinkAccountCallbackInfo : ICallbackInfo
	{
		/// <summary>
		/// The <see cref="Result" /> code for the operation. <see cref="Result.Success" /> indicates that the operation succeeded; other codes indicate errors.
		/// </summary>
		public Result ResultCode { get; set; }

		/// <summary>
		/// Context that was passed into <see cref="AuthInterface.LinkAccount" />.
		/// </summary>
		public object ClientData { get; set; }

		/// <summary>
		/// The Epic Account ID of the local user whose account has been linked during login.
		/// </summary>
		public EpicAccountId LocalUserId { get; set; }

		/// <summary>
		/// Optional data that may be returned in the middle of the login flow, when neither the in-game overlay or a platform browser is used.
		/// This data is present when the ResultCode is <see cref="Result.AuthPinGrantCode" />.
		/// </summary>
		public PinGrantInfo? PinGrantInfo { get; set; }

		/// <summary>
		/// The Epic Account ID that has been previously selected to be used for the current application.
		/// Applications should use this ID to authenticate with online backend services that store game-scoped data for users.
		/// 
		/// Note: This ID may be different from LocalUserId if the user has previously merged Epic accounts into the account
		/// represented by LocalUserId, and one of the accounts that got merged had game data associated with it for the application.
		/// </summary>
		public EpicAccountId SelectedAccountId { get; set; }

		public Result? GetResultCode()
		{
			return ResultCode;
		}

		internal void Set(ref LinkAccountCallbackInfoInternal other)
		{
			ResultCode = other.ResultCode;
			ClientData = other.ClientData;
			LocalUserId = other.LocalUserId;
			PinGrantInfo = other.PinGrantInfo;
			SelectedAccountId = other.SelectedAccountId;
		}
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct LinkAccountCallbackInfoInternal : ICallbackInfoInternal, IGettable<LinkAccountCallbackInfo>, ISettable<LinkAccountCallbackInfo>, System.IDisposable
	{
		private Result m_ResultCode;
		private System.IntPtr m_ClientData;
		private System.IntPtr m_LocalUserId;
		private System.IntPtr m_PinGrantInfo;
		private System.IntPtr m_SelectedAccountId;

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

		public EpicAccountId LocalUserId
		{
			get
			{
				EpicAccountId value;
				Helper.Get(m_LocalUserId, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_LocalUserId);
			}
		}

		public PinGrantInfo? PinGrantInfo
		{
			get
			{
				PinGrantInfo? value;
				Helper.Get<PinGrantInfoInternal, PinGrantInfo>(m_PinGrantInfo, out value);
				return value;
			}

			set
			{
				Helper.Set<PinGrantInfo, PinGrantInfoInternal>(ref value, ref m_PinGrantInfo);
			}
		}

		public EpicAccountId SelectedAccountId
		{
			get
			{
				EpicAccountId value;
				Helper.Get(m_SelectedAccountId, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_SelectedAccountId);
			}
		}

		public void Set(ref LinkAccountCallbackInfo other)
		{
			ResultCode = other.ResultCode;
			ClientData = other.ClientData;
			LocalUserId = other.LocalUserId;
			PinGrantInfo = other.PinGrantInfo;
			SelectedAccountId = other.SelectedAccountId;
		}

		public void Set(ref LinkAccountCallbackInfo? other)
		{
			if (other.HasValue)
			{
				ResultCode = other.Value.ResultCode;
				ClientData = other.Value.ClientData;
				LocalUserId = other.Value.LocalUserId;
				PinGrantInfo = other.Value.PinGrantInfo;
				SelectedAccountId = other.Value.SelectedAccountId;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_ClientData);
			Helper.Dispose(ref m_LocalUserId);
			Helper.Dispose(ref m_PinGrantInfo);
			Helper.Dispose(ref m_SelectedAccountId);
		}

		public void Get(out LinkAccountCallbackInfo output)
		{
			output = new LinkAccountCallbackInfo();
			output.Set(ref this);
		}
	}
}
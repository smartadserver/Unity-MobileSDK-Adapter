using UnityEngine;
using System;
using System.Collections;

using SmartAdServer.Unity.Library.Models;

namespace SmartAdServer.Unity.Library.UI.Native
{
	/// <summary>
	/// Abstract class presenting a native ad view.
	/// 
	/// The native ad view is an ad view handled by a native SDK and is only valid
	/// for one particular platform type, thus there should be one NativeAdView
	/// subclass per supported platform.
	/// </summary>
	public abstract class NativeAdView
	{
		/// <summary>
		/// Request an ad.
		/// </summary>
		/// <param name="adConfig">Ad config.</param>
		public abstract void LoadAd (AdConfig adConfig);

		/// <summary>
		/// Display the ad to a specified position.
		/// </summary>
		/// <param name="adPosition">Ad position.</param>
		public abstract void DisplayBanner (AdPosition adPosition);

		/// <summary>
		/// Properly destroy the ad view instance.
		/// </summary>
		public abstract void Destroy ();

		/// <summary>
		/// Gets the default ad loading timeout.
		/// </summary>
		/// <returns>The default ad loading timeout.</returns>
		public abstract int GetDefaultAdLoadingTimeout ();

		/// <summary>
		/// Sets the default ad loading timeout.
		/// </summary>
		/// <param name="timeout">Timeout.</param>
		public abstract void SetDefaultAdLoadingTimeout (int timeout);

		/// <summary>
		/// Check if native SDK logging is enabled.
		/// </summary>
		/// <returns><c>true</c>, if is native SDK logging is enabled, <c>false</c> otherwise.</returns>
		public abstract bool GetIsLoggingEnabled ();

		/// <summary>
		/// Activates/disables the native SDK logging.
		/// </summary>
		/// <param name="enableLogging">Native SDK logging if set to <c>true</c>.</param>
		public abstract void SetIsLoggingEnabled (bool enableLogging);

		/// <summary>
		/// Occurs when native ad view loading is successful.
		/// </summary>
		public event EventHandler NativeAdViewLoadingSuccess;

		/// <summary>
		/// Occurs when native ad view loading is failed.
		/// </summary>
		public event EventHandler NativeAdViewLoadingFailure;

		/// <summary>
		/// Current ad type.
		/// </summary>
		protected AdType Type;

		/// <summary>
		/// Initializes a new instance of the <see cref="SmartAdServer.Unity.Library.UI.Native.NativeAdView"/> class.
		/// </summary>
		/// <param name="type">Ad type.</param>
		public NativeAdView (AdType type)
		{
			this.Type = type;
		}

		/// <summary>
		/// Notifies the loading success.
		/// </summary>
		protected void NotifyLoadingSuccess ()
		{
			if (NativeAdViewLoadingSuccess != null) {
				NativeAdViewLoadingSuccess (this, new EventArgs ());
			}
		}

		/// <summary>
		/// Notifies the loading failure.
		/// </summary>
		protected void NotifyLoadingFailure ()
		{
			if (NativeAdViewLoadingFailure != null) {
				NativeAdViewLoadingFailure (this, new EventArgs ());
			}
		}

	}
}

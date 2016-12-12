using UnityEngine;
using System.Collections;

using SmartAdServer.Unity.Library.Models;
using SmartAdServer.Unity.Library.UI.Factory;
using SmartAdServer.Unity.Library.UI.Native;
using System;

namespace SmartAdServer.Unity.Library.UI
{
	/// <summary>
	/// This class represents an ad view.
	/// 
	/// The main logic of the ad logic is similar between a banner and an interstitial and is handled
	/// this class.
	/// It acts as a base class for BannerView or InterstitialView and cannot be instantiated.
	/// </summary>
	public abstract class AdView
	{
		/// <summary>
		/// Occurs when the ad view is successfully loaded.
		/// </summary>
		public event EventHandler AdViewLoadingSuccess;

		/// <summary>
		/// Occurs when the ad view has failed to load.
		/// </summary>
		public event EventHandler AdViewLoadingFailure;

		/// <summary>
		/// Instance representing a native ad view.
		/// </summary>
		protected NativeAdView NativeAdView;

		/// <summary>
		/// Instance of an ad view factory that will be used to create the right NativeAdView object.
		/// </summary>
		private NativeAdViewFactory _factory;

		/// <summary>
		/// Creates the native view.
		/// This method should not be called outside of the GetNativeAdView() method.
		/// </summary>
		protected abstract void CreateNativeView ();

		////////////////////////////////////
		// Public API
		////////////////////////////////////

		/// <summary>
		/// Request an ad.
		/// </summary>
		/// <param name="adConfig">The configuration of the ad call.</param>
		public void LoadAd (AdConfig adConfig)
		{
			GetNativeAdView ().LoadAd (adConfig);
		}

		/// <summary>
		/// Destroy the AdView instance.
		/// This method must be called when the ad view is not used anymore to avoid crashes.
		/// </summary>
		public void Destroy ()
		{
			GetNativeAdView ().Destroy ();
		}

		/// <summary>
		/// Handle the ad call timeout.
		/// </summary>
		/// <value>Ad call loading timeout.</value>
		public int DefaultAdLoadingTimeout {
			get {
				return GetNativeAdView ().GetDefaultAdLoadingTimeout ();
			}
			set {
				GetNativeAdView ().SetDefaultAdLoadingTimeout (value);
			}
		}

		/// <summary>
		/// Enable or disable native SDK logging.
		/// </summary>
		/// <value><c>true</c> to activate SDK logging; otherwise, <c>false</c>.</value>
		public bool IsLoggingEnabled {
			get {
				return GetNativeAdView ().GetIsLoggingEnabled ();
			}
			set {
				GetNativeAdView ().SetIsLoggingEnabled (value);
			}
		}

		
		////////////////////////////////////
		// Private fields
		////////////////////////////////////

		// Native SDK events

		/// <summary>
		/// Event called when the ad call is successful.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event argument.</param>
		void NativeAdViewLoadingSuccess (object sender, EventArgs e)
		{
			Debug.Log ("SmartAdServer.Unity.Library.UI.AdView: NativeAdViewLoadingSuccess");
			if (AdViewLoadingSuccess != null) {
				AdViewLoadingSuccess (this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Event called when the ad call is failed.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event argument.</param>
		void NativeAdViewLoadingFailure (object sender, EventArgs e)
		{
			Debug.Log ("SmartAdServer.Unity.Library.UI.AdView: NativeAdViewLoadingFailure");
			if (AdViewLoadingFailure != null) {
				AdViewLoadingFailure (this, EventArgs.Empty);
			}
		}

		
		////////////////////////////////////
		// NativeAdView management
		////////////////////////////////////

		/// <summary>
		/// Gets the native ad view and instanciate it if necessary.
		/// </summary>
		/// <returns>The native ad view.</returns>
		protected NativeAdView GetNativeAdView ()
		{
			if (NativeAdView == null) {
				CreateNativeView ();

				// Registering events
				NativeAdView.NativeAdViewLoadingSuccess += NativeAdViewLoadingSuccess;
				NativeAdView.NativeAdViewLoadingFailure += NativeAdViewLoadingFailure;
			}
			return NativeAdView;
		}

		/// <summary>
		/// Gets the factory corresponding to the current plaform and instanciates it if necessary.
		/// </summary>
		/// <returns>The factory corresponding to the current platform.</returns>
		protected NativeAdViewFactory GetFactory ()
		{
			if (_factory == null) {
				PlatformType platform = PlatformType.Default;
				if (Application.platform == RuntimePlatform.Android) {
					platform = PlatformType.Android;
				} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
					platform = PlatformType.iOS;
				}
				_factory = new NativeAdViewFactory (platform);
			}

			return _factory;
		}
	}
}

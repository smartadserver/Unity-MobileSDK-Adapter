using UnityEngine;
using System;
using System.Collections;

using SmartAdServer.Unity.Library.Constants;
using SmartAdServer.Unity.Library.Models;

namespace SmartAdServer.Unity.Library.UI.Native
{
#if UNITY_ANDROID
	/// <summary>
	/// Android native ad view implementation.
	/// </summary>
	public class AndroidNativeAdView : NativeAdView
	{
		/// <summary>
		/// NOT YET IMPLEMENTED.
		/// </summary>
		private bool _isLoggingEnabled = false;

		/// <summary>
		/// The current placement configuration.
		/// </summary>
		private AdConfig _currentAdConfig;

		/// <summary>
		/// The position where the ad needs to be displayed.
		/// </summary>
		private AdPosition _currentAdPosition;

		/// <summary>
		/// The java object representing the ad view.
		/// </summary>
		private AndroidJavaObject _adViewObject;

		/// <summary>
		/// The java object representing the activity displaying the game.
		/// </summary>
		private AndroidJavaObject _unityActivity;

		/// <summary>
		/// The java class representing the ad view.
		/// </summary>
		private static AndroidJavaClass _adViewClass;

		/// <summary>
		/// The Android frame layout used to display the ad as an interstitial.
		/// </summary>
		private AndroidJavaObject _interstitialFrameLayout;


		////////////////////////////////////
		// Public overriden methods
		////////////////////////////////////

		public AndroidNativeAdView (AdType type) : base(type)
		{
			Debug.Log ("AndroidNativeAdView > DefaultNativeAdView(" + type + ")");
			RunOnJavaUiThread (InitializeBannerViewOnUiThread);
		}
		
		override public void LoadAd (AdConfig adConfig)
		{
			Debug.Log ("AndroidNativeAdView > LoadAd(" + adConfig + ")");
			_currentAdConfig = adConfig;
			RunOnJavaUiThread (LoadAdOnUiThread);
		}
		
		override public void Destroy ()
		{
			Debug.Log ("AndroidNativeAdView > Destroy()");
			RunOnJavaUiThread (DestroyOnUiThread);
		}
		
		override public int GetDefaultAdLoadingTimeout ()
		{
			Debug.Log ("AndroidNativeAdView > GetDefaultAdLoadingTimeout()");
			return -1; // NOT YET IMPLEMENTED
		}
		
		override public void SetDefaultAdLoadingTimeout (int timeout)
		{
			Debug.Log ("AndroidNativeAdView > SetDefaultAdLoadingTimeout(" + timeout + ")");
			// NOT YET IMPLEMENTED
		}
		
		override public bool GetIsLoggingEnabled ()
		{
			Debug.Log ("AndroidNativeAdView > GetIsLoggingEnabled()");
			return _isLoggingEnabled;
		}
		
		override public void SetIsLoggingEnabled (bool enableLogging)
		{
			Debug.Log ("AndroidNativeAdView > SetIsLoggingEnabled(" + enableLogging + ")");

			if (enableLogging) {
				AndroidJNIHelper.debug = true;
				GetAdViewClass ().CallStatic (JavaMethod.EnableLogging);
				_isLoggingEnabled = true;
			} else if (_isLoggingEnabled == true && enableLogging == false) {
				Debug.LogWarning ("Android SDK Debugging can't be deactivated once it has been enabled!");
			}
		}
		
		override public void DisplayBanner (AdPosition adPosition)
		{
			Debug.Log ("AndroidNativeAdView > DisplayBanner(" + adPosition + ")");
			_currentAdPosition = adPosition;
			RunOnJavaUiThread (AddBannerToHierarchyOnUiThread);
		}

		
		////////////////////////////////////
		// UI interaction methods
		////////////////////////////////////

		/// <summary>
		/// Instantiate the ad view object.
		/// </summary>
		void InitializeBannerViewOnUiThread ()
		{
			Debug.Log ("SmartAdServer.Unity.Library.UI.Native.AndroidNativeAdView: initializing AdView");
			GetAdViewClass().CallStatic (JavaMethod.SetUnityModeEnabled, true);
			_adViewObject = new AndroidJavaObject (Type == AdType.Banner ? JavaClass.SASBannerView : JavaClass.SASInterstitialView, GetUnityActivity ());

			if (Type == AdType.Interstitial) {
				var loader = new AndroidJavaObject (JavaClass.SASRotatingImageLoader, GetUnityActivity ());
				_adViewObject.Call (JavaMethod.SetLoaderView, loader);
			}
		}

		/// <summary>
		/// Load an ad using the native SDK and set an AdResponseHandler.
		/// </summary>
		void LoadAdOnUiThread ()
		{
			Debug.Log ("SmartAdServer.Unity.Library.UI.Native.AndroidNativeAdView: loading ad…");
			GetAdViewObject ().Call (
				JavaMethod.LoadAd,
				_currentAdConfig.SiteId,
				_currentAdConfig.PageId,
				_currentAdConfig.FormatId,
				_currentAdConfig.Master,
				_currentAdConfig.Target,
				new AdResponseHandler (this)
			);
		}

		/// <summary>
		/// Destroy properly the current ad view object.
		/// </summary>
		void DestroyOnUiThread ()
		{
			GetAdViewObject ().Call (JavaMethod.OnDestroy);
		}

		/// <summary>
		/// Adds the view to the top or the bottom of the Unity activity.
		/// </summary>
		void AddBannerToHierarchyOnUiThread ()
		{
			var gravityString = _currentAdPosition == AdPosition.Top ? JavaFlag.GravityTop : JavaFlag.GravityBottom;

			var matchParentObject = new AndroidJavaClass (JavaClass.FrameLayoutLayoutParam).GetStatic<int> (JavaFlag.MatchParent);
			
			var density = GetUnityActivity ().Call<AndroidJavaObject> (JavaMethod.GetResources).Call<AndroidJavaObject> (JavaMethod.GetDisplayMetrics).Get<float> (JavaField.Density);

			var frameLayoutParamObject = new AndroidJavaObject (JavaClass.FrameLayoutLayoutParam, matchParentObject, (int)(50 * density));

			var gravity = new AndroidJavaClass (JavaClass.Gravity).GetStatic<int> (gravityString);
			var gravityCenterHorizontal = new AndroidJavaClass (JavaClass.Gravity).GetStatic<int> (JavaFlag.GravityCenterHorizontal);

			frameLayoutParamObject.Set (JavaField.Gravity, gravity | gravityCenterHorizontal);
			
			GetUnityActivity ().Call (JavaMethod.AddContentView, GetAdViewObject (), frameLayoutParamObject);
		}

		
		////////////////////////////////////
		// SDK ad response handler
		////////////////////////////////////

		/// <summary>
		/// Class that will act as a java listener to handle ad call success & failure.
		/// </summary>
		class AdResponseHandler : AndroidJavaProxy
		{
			AndroidNativeAdView callerAdView;

			public AdResponseHandler (AndroidNativeAdView adView) : base(JavaClass.SASAdViewAdResponseHandler)
			{
				callerAdView = adView;
			}
			
			void adLoadingCompleted (AndroidJavaObject adElement)
			{
				callerAdView.NotifyLoadingSuccess ();
			}
			
			void adLoadingFailed (AndroidJavaObject exception)
			{
				callerAdView.NotifyLoadingFailure ();
			}

			string toString ()
			{
				return "AdResponseHandler " + this;
			}
		}

		
		////////////////////////////////////
		// Interaction with Java SDK
		////////////////////////////////////

		/// <summary>
		/// Runs some code on Android UI thread.
		/// </summary>
		/// <param name="method">The method to run on UI thread.</param>
		void RunOnJavaUiThread (Action method)
		{
			GetUnityActivity ().Call (JavaMethod.RunOnUiThread, new AndroidJavaRunnable (method));
		}

		/// <summary>
		/// Gets the java object representing the ad view.
		/// </summary>
		/// <returns>The java object representing the ad view.</returns>
		AndroidJavaObject GetAdViewObject ()
		{
			return _adViewObject;
		}

		/// <summary>
		/// Gets the activity displaying the game.
		/// </summary>
		/// <returns>The activity displaying the game.</returns>
		AndroidJavaObject GetUnityActivity ()
		{
			if (_unityActivity == null) {
				var unityPlayer = new AndroidJavaClass (JavaClass.UnityPlayer); 
				_unityActivity = unityPlayer.GetStatic<AndroidJavaObject> (JavaMethod.CurrentActivity);
			}
			return _unityActivity;
		}

		/// <summary>
		/// Gets the java class representing the ad view.
		/// </summary>
		/// <returns>The java class representing the ad view.</returns>
		static AndroidJavaClass GetAdViewClass ()
		{
			if (_adViewClass == null) {
				_adViewClass = new AndroidJavaClass (JavaClass.SASAdView);
			}
			return _adViewClass;
		}
	}
#endif
}

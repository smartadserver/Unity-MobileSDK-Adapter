using UnityEngine;
using System.Collections;

using SmartAdServer.Unity.Library.Models;

namespace SmartAdServer.Unity.Library.UI.Native
{
	/// <summary>
	/// Default native ad view implementation.
	/// This is a dummy implementation that does nothing except ad call loading.
	/// </summary>
	public class DefaultNativeAdView : NativeAdView
	{
		public DefaultNativeAdView (AdType type) : base(type)
		{
			Debug.Log ("DefaultNativeAdView > DefaultNativeAdView(" + type + ")");
		}
		
		override public void LoadAd (AdConfig adConfig)
		{
			Debug.Log ("DefaultNativeAdView > LoadAd(" + adConfig + ")");
		}
		
		override public void Destroy ()
		{
			Debug.Log ("DefaultNativeAdView > Destroy()");
		}
		
		override public int GetDefaultAdLoadingTimeout ()
		{
			Debug.Log ("DefaultNativeAdView > GetDefaultAdLoadingTimeout()");
			return -1;
		}
		
		override public void SetDefaultAdLoadingTimeout (int timeout)
		{
			Debug.Log ("DefaultNativeAdView > SetDefaultAdLoadingTimeout(" + timeout + ")");
		}
		
		override public bool GetIsLoggingEnabled ()
		{
			Debug.Log ("DefaultNativeAdView > GetIsLoggingEnabled()");
			return false;
		}
		
		override public void SetIsLoggingEnabled (bool enableLogging)
		{
			Debug.Log ("DefaultNativeAdView > SetIsLoggingEnabled(" + enableLogging + ")");
		}
		
		override public void DisplayBanner (AdPosition adPosition)
		{
			Debug.Log ("DefaultNativeAdView > DisplayBanner(" + adPosition + ")");
		}
	}
}

using UnityEngine;
using System.Collections;

using SmartAdServer.Unity.Library.UI.Native;
using SmartAdServer.Unity.Library.Models;

namespace SmartAdServer.Unity.Library.UI.Factory
{
	#if UNITY_IOS
	/// <summary>
	/// Class responsible for building the ad view instance for iOS.
	/// </summary>
	public class iOSAdViewBuilder : NativeAdViewBuilder
	{
		/// <summary>
		/// Builds the instance.
		/// </summary>
		/// <returns>The instance.</returns>
		/// <param name="type">Ad type.</param>
		override public NativeAdView BuildInstance (AdType type)
		{
			return new iOSNativeAdView (type);
		}
	}
	#endif
}

using UnityEngine;
using System.Collections;

using SmartAdServer.Unity.Library.UI.Native;
using SmartAdServer.Unity.Library.Models;

namespace SmartAdServer.Unity.Library.UI.Factory
{
	/// <summary>
	/// Class responsible for building the ad view instance for unsupported platforms.
	/// </summary>
	public class DefaultAdViewBuilder : NativeAdViewBuilder
	{
		/// <summary>
		/// Builds the instance.
		/// </summary>
		/// <returns>The instance.</returns>
		/// <param name="type">Ad type.</param>
		override public NativeAdView BuildInstance (AdType type)
		{
			return new DefaultNativeAdView (type);
		}
	}
}

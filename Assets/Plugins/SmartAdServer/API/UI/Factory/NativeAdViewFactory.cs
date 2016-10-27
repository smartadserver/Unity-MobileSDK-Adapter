using UnityEngine;
using System.Collections;

using SmartAdServer.Unity.Library.UI.Native;
using SmartAdServer.Unity.Library.Models;

namespace SmartAdServer.Unity.Library.UI.Factory
{
	/// <summary>
	/// Factory class for builder generation
	/// </summary>
	public class NativeAdViewFactory
	{

		private PlatformType _currentPlatform;
		private NativeAdViewBuilder _builder;

		/// <summary>
		/// Initializes a new instance of the <see cref="SmartAdServer.Unity.Library.UI.Factory.NativeAdViewFactory"/> class.
		/// </summary>
		/// <param name="platform">Platform type.</param>
		public NativeAdViewFactory (PlatformType platform)
		{
			ConfigurePlatform (platform);
		}

		/// <summary>
		/// Configures native ad view factory depending of the platform used.
		/// </summary>
		/// <param name="platform">Platform type.</param>
		public void ConfigurePlatform (PlatformType platform)
		{
			_currentPlatform = platform;

			switch (platform) {
#if UNITY_ANDROID
			case PlatformType.Android:
				_builder = new AndroidAdViewBuilder ();
				break;
#endif
#if UNITY_IOS
			case PlatformType.iOS:
				_builder = new iOSAdViewBuilder ();
				break;
#endif
			default:
				_builder = new DefaultAdViewBuilder ();
				break;
			}
		}

		/// <summary>
		/// Builds an ad view instance.
		/// </summary>
		/// <returns>The instance.</returns>
		/// <param name="type">Ad type.</param>
		public NativeAdView BuildInstance (AdType type)
		{
			if (_builder == null) {
				Debug.Log ("NativeAdViewFactory > No adview builder found, default one used instead!");
				ConfigurePlatform (PlatformType.Default);
			}
			return _builder.BuildInstance (type);
		}

		/// <summary>
		/// Gets the current platform type.
		/// </summary>
		/// <returns>The current platform type.</returns>
		public PlatformType GetCurrentPlatform ()
		{
			return _currentPlatform;
		}

	}
}

using UnityEngine;
using System.Collections;

using SmartAdServer.Unity.Library.Models;
using SmartAdServer.Unity.Library.UI.Native;

namespace SmartAdServer.Unity.Library.UI
{
	/// <summary>
	/// This class represents a banner view.
	/// </summary>
	public class BannerView : AdView
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SmartAdServer.Unity.Library.UI.BannerView"/> class.
		/// </summary>
		public BannerView () : base()
		{
		}

		/// <summary>
		/// Creates the native view.
		/// This method should only be called by the base class.
		/// </summary>
		override protected void CreateNativeView ()
		{
			NativeAdView = GetFactory ().BuildInstance (AdType.Banner);
		}

		/// <summary>
		/// Displays the banner.
		/// </summary>
		/// <param name="adPosition">Position of the banner on screen.</param>
		public void DisplayBanner (AdPosition adPosition)
		{
			GetNativeAdView ().DisplayBanner (adPosition);
		}

	}
}

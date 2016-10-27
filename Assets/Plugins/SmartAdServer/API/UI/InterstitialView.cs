using UnityEngine;
using System.Collections;

using SmartAdServer.Unity.Library.Models;

namespace SmartAdServer.Unity.Library.UI
{
	/// <summary>
	/// This class represents an interstitial view.
	/// </summary>
	public class InterstitialView : AdView
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SmartAdServer.Unity.Library.UI.InterstitialView"/> class.
		/// </summary>
		public InterstitialView () : base()
		{
		}

		/// <summary>
		/// Creates the native view.
		/// This method should only be called by the base class.
		/// </summary>
		override protected void CreateNativeView ()
		{
			NativeAdView = GetFactory ().BuildInstance (AdType.Interstitial);
		}
	}
}

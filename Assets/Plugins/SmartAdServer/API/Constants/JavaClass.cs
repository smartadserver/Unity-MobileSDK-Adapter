using UnityEngine;
using System.Collections;

namespace SmartAdServer.Unity.Library.Constants
{
	/// <summary>
	/// This class is used in the Android implementation to represent class names.
	/// </summary>
	public class JavaClass
	{
		// Android
		public static readonly string View = "android.view.View";
		public static readonly string Gravity = "android.view.Gravity";
		public static readonly string FrameLayout = "android.widget.FrameLayout";
		public static readonly string FrameLayoutLayoutParam = "android.widget.FrameLayout$LayoutParams";
		public static readonly string Color = "android.graphics.Color";

		// Smart AdServer
		public static readonly string SASAdView = JavaPackage.Ui + "/SASAdView";
		public static readonly string SASAdViewAdResponseHandler = JavaPackage.Ui + "/SASAdView$AdResponseHandler";
		public static readonly string SASAdViewOnRewardListener = JavaPackage.Ui + "/SASAdView$OnRewardListener";
		public static readonly string SASBannerView = JavaPackage.Base + "/SASBannerView";
		public static readonly string SASInterstitialView = JavaPackage.Base + "/SASInterstitialView";
		public static readonly string SASRotatingImageLoader = JavaPackage.Ui + "/SASRotatingImageLoader";

		// Unity
		public static readonly string UnityPlayer = JavaPackage.UnityPlayer + ".UnityPlayer";
	}
}

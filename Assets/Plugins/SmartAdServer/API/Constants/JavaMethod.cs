using UnityEngine;
using System.Collections;

namespace SmartAdServer.Unity.Library.Constants
{
	/// <summary>
	/// This class is used in the Android implementation to represent class methods.
	/// </summary>
	public class JavaMethod
	{
		// Android
		public static readonly string GetResources = "getResources";
		public static readonly string GetDisplayMetrics = "getDisplayMetrics";
		public static readonly string AddContentView = "addContentView";
		public static readonly string SetVisibility = "setVisibility";
		
		public static readonly string RunOnUiThread = "runOnUiThread";
		public static readonly string CurrentActivity = "currentActivity";

		// Smart AdServer
		public static readonly string GetBaseUrl = "getBaseUrl";
		public static readonly string SetBaseUrl = "setBaseUrl";
		public static readonly string EnableLogging = "enableLogging";
		public static readonly string SetUnityModeEnabled = "setUnityModeEnabled";
		public static readonly string LoadAd = "loadAd";
		public static readonly string OnDestroy = "onDestroy";
		public static readonly string AddRewardListener = "addRewardListener";

		public static readonly string SetExpandParentContainer = "setExpandParentContainer";
		public static readonly string SetLoaderView = "setLoaderView";

		public static readonly string GetAmount = "getAmount";
		public static readonly string GetCurrency = "getCurrency";
	}
}


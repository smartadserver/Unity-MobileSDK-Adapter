using UnityEngine;
using System.Collections;

using SmartAdServer.Unity.Library.UI.Native;
using SmartAdServer.Unity.Library.Models;

namespace SmartAdServer.Unity.Library.UI.Factory
{
	/// <summary>
	/// Abstract native ad view builder.
	/// </summary>
	public abstract class NativeAdViewBuilder
	{
		/// <summary>
		/// Builds the instance.
		/// </summary>
		/// <returns>The instance.</returns>
		/// <param name="type">Ad type.</param>
		public abstract NativeAdView BuildInstance (AdType type);
	}
}

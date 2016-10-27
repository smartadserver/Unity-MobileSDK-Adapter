using UnityEngine;
using System.Collections;

namespace SmartAdServer.Unity.Library.Constants
{
	/// <summary>
	/// This class is used in the Android implementation to represent java packages.
	/// </summary>
	public class JavaPackage
	{
		// Smart AdServer
		public static readonly string Base = "com/smartadserver/android/library";
		public static readonly string Exception = Base + "/exception";
		public static readonly string Model = Base + "/model";
		public static readonly string Provider = Base + "/provider";
		public static readonly string Ui = Base + "/ui";

		// Unity
		public static readonly string Unity = "com.unity3d";
		public static readonly string UnityPlayer = Unity + ".player";
	}
}

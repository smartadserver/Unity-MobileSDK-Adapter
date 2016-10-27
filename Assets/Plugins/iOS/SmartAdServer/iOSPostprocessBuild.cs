#if UNITY_EDITOR_OSX
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor.iOS.Xcode;

/// <summary>
/// This class acts as a post process build script to fix some details in the generated Xcode project.
/// </summary>
public class iOSPostprocessBuild {

	[PostProcessBuild]
	public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) 
	{
		// Add required iOS frameworks to the project file
		LinkLibraries (target, pathToBuiltProject);

		// Deactivate iOS 9 ATS feature to allow the SDK to request Smart AdServer 
		// without using HTTPS connection.
		DeactivateATS (target, pathToBuiltProject);
	}

	/// <summary>
	/// Automatically add links the required libraries and frameworks in the Xcode project file
	/// </summary>
	/// <param name="target">Target.</param>
	/// <param name="pathToBuiltProject">Path where the project is built.</param>
	public static void LinkLibraries(BuildTarget target, string pathToBuiltProject)
	{
		if (target == BuildTarget.iOS) {
			string projectFile = pathToBuiltProject + "/Unity-iPhone.xcodeproj/project.pbxproj";
			string contents = File.ReadAllText(projectFile);

			Regex rx = new Regex("OTHER_LDFLAGS = (.*?);", RegexOptions.Singleline);
			contents = rx.Replace(contents, "OTHER_LDFLAGS = (\"-weak_framework\",SafariServices,\"-weak_framework\",SceneKit,\"-weak_framework\",SpriteKit,\"-framework\",CoreMotion,\"-framework\",EventKit,\"-framework\",WebKit,\"-framework\",Accelerate,\"-framework\",AdSupport,\"-framework\",StoreKit,\"-framework\",CoreMedia,\"-framework\",AVFoundation,\"-weak-lSystem\",);");

			File.WriteAllText(projectFile, contents);
		}
	}

	/// <summary>
	/// Automatically deactivate Apple ATS to allow HTTP ad calls.
	/// </summary>
	/// <param name="target">Target.</param>
	/// <param name="pathToBuiltProject">Path where the project is built.</param>
	public static void DeactivateATS(BuildTarget target, string pathToBuiltProject)
	{
		if (target == BuildTarget.iOS) {
			string plistPath = pathToBuiltProject + "/Info.plist";
			PlistDocument plist = new PlistDocument();
			plist.ReadFromString(File.ReadAllText(plistPath));

			PlistElementDict rootDict = plist.root;

			PlistElementDict appTransportSecurity = rootDict.CreateDict("NSAppTransportSecurity");
			appTransportSecurity.SetBoolean("NSAllowsArbitraryLoads", true);

			File.WriteAllText(plistPath, plist.WriteToString());
		}
	}

}
#endif

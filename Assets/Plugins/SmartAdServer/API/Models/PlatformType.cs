using UnityEngine;
using System.Collections;

namespace SmartAdServer.Unity.Library.Models
{
	/// <summary>
	/// The type of the current platform.
	/// The 'Default' platform is used to represent any platform not handled by this wrapper
	/// on which no ad will be displayed.
	/// </summary>
	public enum PlatformType
	{
		Android,
		iOS,
		Default
	}
}

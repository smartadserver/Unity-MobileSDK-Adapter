using UnityEngine;
using System.Collections;

namespace SmartAdServer.Unity.Library.Models
{
	/// <summary>
	/// The AdConfig class represents the configuration of an ad call.
	/// It will hold all the parameters you can expect with any other Smart AdServer ad call.
	/// </summary>
	public class AdConfig
	{
		private string _baseUrl;
		private int _siteId;
		private string _pageId;
		private int _formatId;
		private bool _master;
		private string _target;

		/// <summary>
		/// Initializes a new instance of the <see cref="SmartAdServer.Unity.Library.Models.AdConfig"/> class.
		/// </summary>
		/// <param name="baseUrl">Base URL (required).</param>
		/// <param name="siteId">Site ID (required).</param>
		/// <param name="pageId">Page ID (required).</param>
		/// <param name="formatId">Format ID (required).</param>
		/// <param name="master">If set to <c>true</c>, the call will be considered as Master (required).</param>
		/// <param name="target">Target string (optional).</param>
		public AdConfig (string baseUrl, int siteId, string pageId, int formatId, bool master, string target)
		{
			_baseUrl = baseUrl;
			_siteId = siteId;
			_pageId = pageId;
			_formatId = formatId;
			_master = master;
			_target = target;
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="SmartAdServer.Unity.Library.Models.AdConfig"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="SmartAdServer.Unity.Library.Models.AdConfig"/>.</returns>
		override public string ToString ()
		{
			return "AdConfig(baseUrl: " + _baseUrl 
				+ ", siteId: " + _siteId 
				+ ", pageId: " + _pageId 
				+ ", formatId: " + _formatId 
				+ ", master: " + _master 
				+ ", target: " + _target + ")";
		}

		/// <summary>
		/// Gets the base URL.
		/// </summary>
		/// <value>The base URL.</value>
		public string BaseUrl {
			get {
				return _baseUrl;
			}
		}

		/// <summary>
		/// Gets the site ID.
		/// </summary>
		/// <value>The site ID.</value>
		public int SiteId {
			get {
				return _siteId;
			}
		}

		/// <summary>
		/// Gets the page ID.
		/// </summary>
		/// <value>The page ID.</value>
		public string PageId {
			get {
				return _pageId;
			}
		}

		/// <summary>
		/// Gets the format ID.
		/// </summary>
		/// <value>The format ID.</value>
		public int FormatId {
			get {
				return _formatId;
			}
		}

		/// <summary>
		/// Gets a value indicating whether a call will be a Master call.
		/// </summary>
		/// <value><c>true</c> if Master call; otherwise, <c>false</c>.</value>
		public bool Master {
			get {
				return _master;
			}
		}

		/// <summary>
		/// Gets the target string if defined.
		/// </summary>
		/// <value>The target string if defined.</value>
		public string Target {
			get {
				return _target;
			}
		}

	}
}

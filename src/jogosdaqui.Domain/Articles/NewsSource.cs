using System;

namespace jogosdaqui.Domain.Articles
{
	/// <summary>
	/// Represents a news source.
	/// </summary>
	public class NewsSource
	{
		#region Properties
		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the URL.
		/// </summary>
		/// <value>The URL.</value>
		public string Url { get; set; }
		#endregion
	}
}


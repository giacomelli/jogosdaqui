using System;

namespace jogosdaqui.Domain.Articles
{
	/// <summary>
	/// Represents a news.
	/// </summary>
	public class News : ArticleBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.News"/> class.
		/// </summary>
		public News()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.News"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		public News(long key) : base(key)
		{
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the source.
		/// </summary>
		/// <value>The source.</value>
		public NewsSource Source { get; set; }
		#endregion
	}
}


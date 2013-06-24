using System;

namespace jogosdaqui.Domain.Articles
{
	/// <summary>
	/// Represents an event article.
	/// </summary>
	public class Event : ArticleBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.Event"/> class.
		/// </summary>
		public Event()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.Event"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		public Event(long key) : base(key)
		{
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the begin date.
		/// </summary>
		/// <value>The begin date.</value>
		public DateTime? BeginDate { get; set; }

		/// <summary>
		/// Gets or sets the end date.
		/// </summary>
		/// <value>The end date.</value>
		public DateTime? EndDate { get; set; }
		#endregion
	}
}


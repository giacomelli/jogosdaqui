using System;

namespace jogosdaqui.Domain.Articles
{
	/// <summary>
	/// Represents a game preview.
	/// </summary>
	public class Preview : ArticleBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.Preview"/> class.
		/// </summary>
		public Preview()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.News"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		public Preview(long key) : base(key)
		{
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the game evaluation identifier.
		/// </summary>
		/// <value>The game evaluation identifier.</value>
		public int? GameEvaluationId { get; set; }

		/// <summary>
		/// Gets or sets the expected date release.
		/// </summary>
		/// <value>The expected date release.</value>
		public DateTime? ExpectedDateRelease { get; set; }
		#endregion
	}
}


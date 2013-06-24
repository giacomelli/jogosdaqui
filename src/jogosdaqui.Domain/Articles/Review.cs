using System;

namespace jogosdaqui.Domain.Articles
{
	/// <summary>
	/// Represents a review.
	/// </summary>
	public class Review : ArticleBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.Review"/> class.
		/// </summary>
		public Review()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.Review"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		public Review(long key) : base(key)
		{
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the game evaluation identifier.
		/// </summary>
		/// <value>The game evaluation identifier.</value>
		public int GameEvaluationId { get; set; }

		/// <summary>
		/// Gets or sets the expected date release.
		/// </summary>
		/// <value>The expected date release.</value>
		public DateTime? ExpectedDateRelease { get; set; }
		#endregion
	}
}


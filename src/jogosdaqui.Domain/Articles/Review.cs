using System;

namespace jogosdaqui.Domain.Articles
{
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
		public int GameEvaluationId { get; set; }
		public DateTime? ExpectedDateRelease { get; set; }
		#endregion
	}
}


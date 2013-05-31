using System;

namespace jogosdaqui.Domain
{
	public class ReviewArticle : ArticleBase
	{
		#region Properties
		public int GameEvaluationId { get; set; }
		public DateTime? ExpectedDateRelease { get; set; }
		#endregion
	}
}


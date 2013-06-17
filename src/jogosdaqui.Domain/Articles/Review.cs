using System;

namespace jogosdaqui.Domain.Articles
{
	public class Review : ArticleBase
	{
		#region Properties
		public int GameEvaluationId { get; set; }
		public DateTime? ExpectedDateRelease { get; set; }
		#endregion
	}
}


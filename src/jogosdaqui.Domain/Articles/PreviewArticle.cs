using System;

namespace jogosdaqui.Domain
{
	public class PreviewArticle : ArticleBase
	{
		#region Properties
		public int? GameEvaluationId { get; set; }
		public DateTime? ExpectedDateRelease { get; set; }
		#endregion
	}
}


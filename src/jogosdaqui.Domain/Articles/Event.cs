using System;

namespace jogosdaqui.Domain.Articles
{
	public class Event : ArticleBase
	{
		#region Properties
		public DateTime BeginDate { get; set; }
		public DateTime EndDate { get; set; }
		#endregion
	}
}


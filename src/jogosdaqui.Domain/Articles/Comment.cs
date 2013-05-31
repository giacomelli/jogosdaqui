using System;

namespace jogosdaqui.Domain
{
	public class Comment
	{
		#region Properties
		public string Title { get; set; }
		public string Text { get; set; }
		public DateTime CreationDate { get; set; }
		public Person Author { get; set; }
		public ArticleBase Article { get; set; }
		#endregion
	}
}


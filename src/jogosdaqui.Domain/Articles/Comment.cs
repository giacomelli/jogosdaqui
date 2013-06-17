using System;
using jogosdaqui.Domain.Persons;
using Skahal.Infrastructure.Framework.Domain;

namespace jogosdaqui.Domain.Articles
{
	public class Comment : EntityBase<long>, IAggregateRoot<long>
	{
		#region Properties
		public long ReplyToCommentId { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public DateTime CreationDate { get; set; }
		public Person Author { get; set; }
		public long ArticleKey { get; set; }
		#endregion
	}
}


using System;
using jogosdaqui.Domain.Persons;
using Skahal.Infrastructure.Framework.Domain;

namespace jogosdaqui.Domain.Articles
{
	/// <summary>
	/// An article comment.
	/// </summary>
	public class Comment : EntityBase<long>, IAggregateRoot<long>
	{
		#region Properties
		/// <summary>
		/// Gets or sets the reply to comment identifier.
		/// </summary>
		/// <value>The reply to comment identifier.</value>
		public long ReplyToCommentId { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the text.
		/// </summary>
		/// <value>The text.</value>
		public string Text { get; set; }

		/// <summary>
		/// Gets or sets the creation date.
		/// </summary>
		/// <value>The creation date.</value>
		public DateTime CreationDate { get; set; }

		/// <summary>
		/// Gets or sets the author.
		/// </summary>
		/// <value>The author.</value>
		public Person Author { get; set; }

		/// <summary>
		/// Gets or sets the article key.
		/// </summary>
		/// <value>The article key.</value>
		public long ArticleKey { get; set; }
		#endregion
	}
}


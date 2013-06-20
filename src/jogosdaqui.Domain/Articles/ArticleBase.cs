using System;
using System.Collections.Generic;
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Persons;
using Skahal.Infrastructure.Framework.Domain;

namespace jogosdaqui.Domain.Articles
{
	#region Enums
	public enum ArticleStatus
	{
		Draft,
		Published,
		Unpublished
	}
	#endregion

	public abstract class ArticleBase : EntityBase<long>, IAggregateRoot<long>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.ArticleBase"/> class.
		/// </summary>
		protected ArticleBase()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.ArticleBase"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		protected ArticleBase(long key) : base(key)
		{
		}
		#endregion

		#region Properties
		public string Title { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? PublicationDate { get; set; }
		public IList<Person> Authors { get; private set; }
		public ArticleStatus Status { get; set; }
		public IList<Game> GamesRelated { get; private set; }
		#endregion
	}
}
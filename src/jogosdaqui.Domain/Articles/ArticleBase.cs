using System;
using System.Collections.Generic;
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Persons;
using Skahal.Infrastructure.Framework.Domain;

namespace jogosdaqui.Domain.Articles
{
	#region Enums
	/// <summary>
	/// Article status.
	/// </summary>
	public enum ArticleStatus
	{
		/// <summary>
		/// The article is a draft.
		/// </summary>
		Draft,

		/// <summary>
		/// The article is published.
		/// </summary>
		Published,

		/// <summary>
		/// The article is unpublished.
		/// </summary>
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
			Authors = new List<Person> ();
			GamesRelated = new List<Game> ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.ArticleBase"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		protected ArticleBase(long key) : base(key)
		{
			Authors = new List<Person> ();
			GamesRelated = new List<Game> ();
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the creation date.
		/// </summary>
		/// <value>The creation date.</value>
		public DateTime CreationDate { get; set; }

		/// <summary>
		/// Gets or sets the publication date.
		/// </summary>
		/// <value>The publication date.</value>
		public DateTime? PublicationDate { get; set; }

		/// <summary>
		/// Gets the authors.
		/// </summary>
		/// <value>The authors.</value>
		public IList<Person> Authors { get; private set; }

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		public ArticleStatus Status { get; set; }

		/// <summary>
		/// Gets the games related.
		/// </summary>
		/// <value>The games related.</value>
		public IList<Game> GamesRelated { get; private set; }
		#endregion
	}
}
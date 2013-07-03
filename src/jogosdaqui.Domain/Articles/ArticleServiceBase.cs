using System;
using System.Collections.Generic;
using System.Linq;
using KissSpecifications;
using Skahal.Infrastructure.Framework.Domain;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Games.Specifications;

namespace jogosdaqui.Domain.Articles
{
	/// <summary>
	/// Article service base.
	/// </summary>
	public abstract class ArticleServiceBase<TEntity, TRepository> 
		: ServiceBase<TEntity, long, TRepository, IUnitOfWork<long>>
			where TEntity : ArticleBase
			where TRepository : IRepository<TEntity, long>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.ArticleServiceBase`1"/> class.
		/// </summary>
		protected ArticleServiceBase()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.ArticleServiceBase`1"/> class.
		/// </summary>
		/// <param name="repository">Repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		protected ArticleServiceBase(TRepository repository, IUnitOfWork<long> unitOfWork) 
			: base(repository, unitOfWork)
		{
		}
		#endregion

		#region Methods
		protected IList<TEntity> GetEntitiesByGameKey(long gameKey)
		{
			var gameService = new GameService ();
			var game = gameService.GetGameByKey (gameKey);

			SpecificationService.ThrowIfAnySpecificationIsNotSatisfiedBy (game, new GameExistsSpecification ());

			return MainRepository.FindAll (e => e.GamesRelated.Contains(game)).ToList();
		}
		#endregion
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using HelperSharp;
using KissSpecifications;
using Skahal.Infrastructure.Framework.Commons;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games.Specifications;

namespace jogosdaqui.Domain.Games
{
	/// <summary>
	/// Game service.
	/// </summary>
	public sealed class GameService
	{	
		#region Fields
		private IGameRepository m_repository;
		private IUnitOfWork<long> m_unitOfwork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Games.GameService"/> class.
		/// </summary>
		public GameService() 
			: this(DependencyService.Create<IGameRepository>(), DependencyService.Create<IUnitOfWork<long>>())
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Games.GameService"/> class.
		/// </summary>
		/// <param name="gameRepository">Game repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public GameService(IGameRepository gameRepository, IUnitOfWork<long> unitOfWork)
		{
			m_repository = gameRepository;
			m_unitOfwork = unitOfWork;
			m_repository.SetUnitOfWork (m_unitOfwork);
		}
		#endregion

		#region Methods
		/// <summary>
		/// Gets the game by key.
		/// </summary>
		/// <returns>The game by key.</returns>
		/// <param name="key">The key.</param>
		public Game GetGameByKey(long key)
		{
			return m_repository.FindAll (g => g.Key == key).FirstOrDefault ();
		}

		/// <summary>
		/// Gets all games.
		/// </summary>
		/// <returns>The all games.</returns>
		public IList<Game> GetAllGames()
		{
			return m_repository.FindAll(g => true).ToList();
		}

		/// <summary>
		/// Counts all games.
		/// </summary>
		public long CountAllGames()
		{
			return m_repository.CountAll (g => true);
		}

		/// <summary>
		/// Saves the game.
		/// </summary>
		/// <param name="game">Game.</param>
		public void SaveGame(Game game)
		{
			ExceptionHelper.ThrowIfNull ("game", game);

			m_repository [game.Key] = game;

			m_unitOfwork.Commit ();
		}

		/// <summary>
		/// Deletes the game.
		/// </summary>
		/// <param name="key">The key.</param>
		public void DeleteGame (long key)
		{
			var game = GetGameByKey (key);
			SpecificationService.ThrowIfAnySpecificationIsNotSatisfiedBy (game, new GameDeletionSpecification ());

			m_repository.Remove (game);
			m_unitOfwork.Commit ();
		}
		#endregion
	}
}
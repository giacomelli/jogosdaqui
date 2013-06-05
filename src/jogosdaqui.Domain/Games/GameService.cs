using System;
using System.Collections.Generic;
using System.Linq;
using HelperSharp;
using Skahal.Infrastructure.Framework.Commons;
using KissSpecifications;
using jogosdaqui.Domain.Games.Specifications;

namespace jogosdaqui.Domain.Games
{
	/// <summary>
	/// Game service.
	/// </summary>
	public static class GameService
	{	
		#region Methods
		/// <summary>
		/// Gets the game by identifier.
		/// </summary>
		/// <returns>The game by identifier.</returns>
		/// <param name="id">Identifier.</param>
		public static Game GetGameById(long id)
		{
			return DependencyService.Create<IGameRepository> ().FindAll (g => g.Id == id).FirstOrDefault ();
		}

		/// <summary>
		/// Gets all games.
		/// </summary>
		/// <returns>The all games.</returns>
		public static IList<Game> GetAllGames()
		{
			return DependencyService.Create<IGameRepository> ().FindAll(g => true).ToList();
		}

		/// <summary>
		/// Counts all games.
		/// </summary>
		public static long CountAllGames()
		{
			return DependencyService.Create<IGameRepository> ().CountAll (g => true);
		}

		/// <summary>
		/// Saves the game.
		/// </summary>
		/// <param name="game">Game.</param>
		public static void SaveGame(Game game)
		{
			ExceptionHelper.ThrowIfNull ("game", game);

			var repository = DependencyService.Create<IGameRepository> ();
			var oldGame = GetGameById (game.Id);

			if (oldGame == null) {
				repository.Create (game);
			} else {
				repository.Modify (game);
			}
		}

		/// <summary>
		/// Deletes the game.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public static void DeleteGame (long id)
		{
			var game = GetGameById (id);
			SpecificationService.ThrowIfAnySpecificationIsNotSatisfiedBy (game, new GameDeletionSpecification ());

			DependencyService.Create<IGameRepository> ().Delete (game);
		}
		#endregion
	}
}
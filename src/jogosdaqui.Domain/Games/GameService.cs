using System;
using System.Linq;
using Skahal.Infrastructure.Framework.Commons;
using System.Collections.Generic;

namespace jogosdaqui.Domain.Games
{
	public static class GameService
	{
		#region Methods
		public static Game GetGameById(long id)
		{
			return DependencyService.Create<IGameRepository> ().FindAll ((g) => g.Id == id).FirstOrDefault ();
		}

		public static IEnumerable<Game> GetAllGames()
		{
			return DependencyService.Create<IGameRepository> ().FindAll ((g) => true);
		}

		public static void SaveGame(Game game)
		{
			var repository = DependencyService.Create<IGameRepository> ();
			var oldGame = GetGameById (game.Id);

			if (oldGame == null) {
				repository.Create (game);
			} else {
				repository.Modify (game);
			}
		}
		#endregion
	}
}
using System;
using jogosdaqui.Domain.Games;
using System.Collections.Generic;
using System.Linq;

namespace jogosdaqui.Infrastructure.Repositories
{
	public class GameRepository : IGameRepository
	{
		#region Fields
		private static List<Game> s_games = new List<Game>();
		private static long s_currentId = 1;
		#endregion

		public Game Create (Game entity)
		{
			entity.Id = s_currentId++;
			s_games.Add (entity);

			return entity;
		}

		public void Delete (Game entity)
		{
			s_games.Remove (entity);
		}

		public void Delete (int id)
		{
			throw new NotImplementedException ();
		}

		public IEnumerable<Game> FindAll (Func<Game, bool> filter)
		{
			return s_games.Where((g) => filter(g));
		}

		public void Modify (Game entity)
		{

		}
	}
}
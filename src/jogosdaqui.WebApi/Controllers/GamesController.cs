using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AspNetWebApi.ApiGee.Filters;
using jogosdaqui.Domain;
using jogosdaqui.Domain.Games;

namespace jogosdaqui.WebApi.Controllers
{
	/// <summary>
	/// Jogos.
	/// </summary>
    public class GamesController : ApiController
    {
		#region Fields
		private GameService m_service;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.WebApi.Controllers.GamesController"/> class.
		/// </summary>
		public GamesController()
		{
			m_service = new GameService ();
		}
		#endregion

		/// <summary>
		/// Obtém todos os jogos existentes.
		/// </summary>
        public IEnumerable<Game> Get()
        {
			return m_service.GetAllGames ();
        }

		/// <summary>
		/// Cria um novo jogo.
		/// </summary>
		/// <param name="game">O jogo a ser criado.</param>
		/// <returns>O criado com o key informado.</returns>
		public Game Post(Game game)
		{
			m_service.SaveGame (game);

			return game;
		}

		/// <summary>
		/// Atualiza um jogo existente.
		/// </summary>
		/// <param name="key">O key do jogo a ser atualizado.</param>
		/// <param name="game">O jogo.</param>
		public Game Put(long key, Game game)
		{
	        game.Key = key;
			m_service.SaveGame (game);

			return game;
		}

		/// <summary>
		/// Exclui o jogo com o key informado.
		/// </summary>
		/// <param name="key">O key do jogo a ser excluído.</param>
	    [SuccessHandlingFilter]
        public void Delete(long key)
		{
			m_service.DeleteGame (key);
		}
    }
}

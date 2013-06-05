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
		/// <summary>
		/// Obtém todos os jogos existentes.
		/// </summary>
        public IEnumerable<Game> Get()
        {
			return GameService.GetAllGames ();
        }

		/// <summary>
		/// Cria um novo jogo.
		/// </summary>
		/// <param name="game">O jogo a ser criado.</param>
		/// <returns>O criado com o ID informado.</returns>
		public Game Post(Game game)
		{
			GameService.SaveGame (game);

			return game;
		}

		/// <summary>
		/// Atualiza um jogo existente.
		/// </summary>
		/// <param name="id">O id do jogo a ser atualizado.</param>
		/// <param name="game">O jogo.</param>
		public Game Put(long id, Game game)
		{
            game.Id = id;
			GameService.SaveGame (game);

			return game;
		}

		/// <summary>
		/// Exclui o jogo com o id informado.
		/// </summary>
		/// <param name="id">O id do jogo a ser excluído.</param>
	    [SuccessHandlingFilter]
        public void Delete(long id)
		{
			GameService.DeleteGame (id);
		}
    }
}

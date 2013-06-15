 
  
   
   

   

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
	/// Games.
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
		/// Get all Games
		/// </summary>
        public IEnumerable<Game> Get()
        {
			return m_service.GetAllGames ();
        }

		/// <summary>
		/// Creates a new Game.
		/// </summary>
		/// <param name="game">The Game to create.</param>
		/// <returns>The created Game with the key.</returns>
		public Game Post(Game game)
		{
			m_service.SaveGame (game);

			return game;
		}

		/// <summary>
		/// Updates an existing Game.
		/// </summary>
		/// <param name="key">The Game's key.</param>
		/// <param name="game">The Game with updated informations.</param>
		public Game Put(long key, Game game)
		{
	        game.Key = key;
			m_service.SaveGame (game);

			return game;
		}

		/// <summary>
		/// Deletes the Game with the specified key.
		/// </summary>
		/// <param name="key">The key of the Game to be deleted.</param>
	    [SuccessHandlingFilter]
        public void Delete(long key)
		{
			m_service.DeleteGame (key);
		}
    }
}

namespace jogosdaqui.WebApi.Controllers
{
	/// <summary>
	/// GameCategories.
	/// </summary>
    public class GameCategoriesController : ApiController
    {
		#region Fields
		private GameCategoryService m_service;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.WebApi.Controllers.GameCategoriesController"/> class.
		/// </summary>
		public GameCategoriesController()
		{
			m_service = new GameCategoryService ();
		}
		#endregion

		/// <summary>
		/// Get all GameCategories
		/// </summary>
        public IEnumerable<GameCategory> Get()
        {
			return m_service.GetAllGameCategories ();
        }

		/// <summary>
		/// Creates a new GameCategory.
		/// </summary>
		/// <param name="gamecategory">The GameCategory to create.</param>
		/// <returns>The created GameCategory with the key.</returns>
		public GameCategory Post(GameCategory gamecategory)
		{
			m_service.SaveGameCategory (gamecategory);

			return gamecategory;
		}

		/// <summary>
		/// Updates an existing GameCategory.
		/// </summary>
		/// <param name="key">The GameCategory's key.</param>
		/// <param name="gamecategory">The GameCategory with updated informations.</param>
		public GameCategory Put(long key, GameCategory gamecategory)
		{
	        gamecategory.Key = key;
			m_service.SaveGameCategory (gamecategory);

			return gamecategory;
		}

		/// <summary>
		/// Deletes the GameCategory with the specified key.
		/// </summary>
		/// <param name="key">The key of the GameCategory to be deleted.</param>
	    [SuccessHandlingFilter]
        public void Delete(long key)
		{
			m_service.DeleteGameCategory (key);
		}
    }
}
 
		
		
 
   
#region Usings   
using System;  
using System.Collections.Generic;    
using System.IO;    
using System.Linq;   
using jogosdaqui.Domain.Games; 
using Skahal.Infrastructure.Framework.Commons;
using Skahal.Infrastructure.Framework.Repositories;
using HelperSharp;
using KissSpecifications;
#endregion        

    
 
 

	#region Services classes
 
namespace jogosdaqui.Domain.Games
{
	public partial interface IGameRepository : IRepository<Game, long>
	{
		}

	// <summary>
	/// Domain layer game service.
	/// </summary>
	public partial class GameService
	{ 
		#region Fields	 
        private IGameRepository m_repository;
        private IUnitOfWork<long> m_unitOfWork; 
		#endregion 
		  
		#region Constructors 
      	/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Games. GameService"/> class.
		/// </summary>
		public  GameService() 
			: this(DependencyService.Create<IGameRepository>(), DependencyService.Create<IUnitOfWork<long>>())
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Games. GameService"/> class.
		/// </summary>
		/// <param name="gameRepository"> Game repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  GameService(IGameRepository gameRepository, IUnitOfWork<long> unitOfWork)
		{
			m_repository = gameRepository; 
			m_unitOfWork = unitOfWork;
			m_repository.SetUnitOfWork (m_unitOfWork);
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
		/// Gets all Games. 
		/// </summary>
		/// <returns>The all Games.</returns>
		public IList<Game> GetAllGames()
		{
			return m_repository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Games.
		/// </summary>
		public long CountAllGames() 
		{ 
			return m_repository.CountAll (g => true); 
		}

		/// <summary>
		/// Saves the game.
		/// </summary>
		/// <param name="game">The game.</param>
		public void SaveGame(Game game)
		{
			ExceptionHelper.ThrowIfNull ("game", game);

			m_repository [game.Key] = game;

			m_unitOfWork.Commit (); 
		}

		/// <summary>
		/// Executes the deletion specification.
		/// </summary>
		partial void ExecuteDeletionSpecification(Game game);
		
		/// <summary>  
		/// Deletes the game.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeleteGame (long key)
		{
			var game = GetGameByKey (key);
			ExecuteDeletionSpecification (game);

			m_repository.Remove (game);
			m_unitOfWork.Commit ();
		}
		#endregion
	}
	
}
#endregion
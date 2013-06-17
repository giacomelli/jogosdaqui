 
 
  
   
   
  
   
  
#region Usings    
using System;  
using System.Collections.Generic;    
using System.IO;        
using System.Linq;    
using jogosdaqui.Domain.Games; 
using jogosdaqui.Domain.Platforms; 
using Skahal.Infrastructure.Framework.Commons;
using Skahal.Infrastructure.Framework.Repositories;
using HelperSharp; 
using KissSpecifications; 
#endregion        
       
   
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
   
namespace jogosdaqui.Domain.Games
{
	public partial interface IGameCategoryRepository : IRepository<GameCategory, long>
	{
		}

	// <summary>
	/// Domain layer gamecategory service.
	/// </summary>
	public partial class GameCategoryService
	{ 
		#region Fields	 
        private IGameCategoryRepository m_repository;
        private IUnitOfWork<long> m_unitOfWork; 
		#endregion 
		  
		#region Constructors 
      	/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.GameCategories. GameCategoryService"/> class.
		/// </summary>
		public  GameCategoryService() 
			: this(DependencyService.Create<IGameCategoryRepository>(), DependencyService.Create<IUnitOfWork<long>>())
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.GameCategories. GameCategoryService"/> class.
		/// </summary>
		/// <param name="gamecategoryRepository"> GameCategory repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  GameCategoryService(IGameCategoryRepository gamecategoryRepository, IUnitOfWork<long> unitOfWork)
		{
			m_repository = gamecategoryRepository; 
			m_unitOfWork = unitOfWork;
			m_repository.SetUnitOfWork (m_unitOfWork);
		}
        #endregion
		
		#region Methods
		
		/// <summary>
		/// Gets the gamecategory by key.
		/// </summary>
		/// <returns>The gamecategory by key.</returns>
		/// <param name="key">The key.</param>
		public GameCategory GetGameCategoryByKey(long key)
		{
			return m_repository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all GameCategories. 
		/// </summary>
		/// <returns>The all GameCategories.</returns>
		public IList<GameCategory> GetAllGameCategories()
		{
			return m_repository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all GameCategories.
		/// </summary>
		public long CountAllGameCategories() 
		{ 
			return m_repository.CountAll (g => true); 
		}

		/// <summary>
		/// Saves the gamecategory.
		/// </summary>
		/// <param name="gamecategory">The gamecategory.</param>
		public void SaveGameCategory(GameCategory gamecategory)
		{
			ExceptionHelper.ThrowIfNull ("gamecategory", gamecategory);

			m_repository [gamecategory.Key] = gamecategory;

			m_unitOfWork.Commit (); 
		}

		/// <summary>
		/// Executes the deletion specification.
		/// </summary>
		partial void ExecuteDeletionSpecification(GameCategory gamecategory);
		
		/// <summary>  
		/// Deletes the gamecategory.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeleteGameCategory (long key)
		{
			var gamecategory = GetGameCategoryByKey (key);
			ExecuteDeletionSpecification (gamecategory);

			m_repository.Remove (gamecategory);
			m_unitOfWork.Commit ();
		}
		#endregion
	}
}
   
namespace jogosdaqui.Domain.Platforms
{
	public partial interface IPlatformRepository : IRepository<Platform, long>
	{
		}

	// <summary>
	/// Domain layer platform service.
	/// </summary>
	public partial class PlatformService
	{ 
		#region Fields	 
        private IPlatformRepository m_repository;
        private IUnitOfWork<long> m_unitOfWork; 
		#endregion 
		  
		#region Constructors 
      	/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Platforms. PlatformService"/> class.
		/// </summary>
		public  PlatformService() 
			: this(DependencyService.Create<IPlatformRepository>(), DependencyService.Create<IUnitOfWork<long>>())
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Platforms. PlatformService"/> class.
		/// </summary>
		/// <param name="platformRepository"> Platform repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  PlatformService(IPlatformRepository platformRepository, IUnitOfWork<long> unitOfWork)
		{
			m_repository = platformRepository; 
			m_unitOfWork = unitOfWork;
			m_repository.SetUnitOfWork (m_unitOfWork);
		}
        #endregion
		
		#region Methods
		
		/// <summary>
		/// Gets the platform by key.
		/// </summary>
		/// <returns>The platform by key.</returns>
		/// <param name="key">The key.</param>
		public Platform GetPlatformByKey(long key)
		{
			return m_repository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Platforms. 
		/// </summary>
		/// <returns>The all Platforms.</returns>
		public IList<Platform> GetAllPlatforms()
		{
			return m_repository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Platforms.
		/// </summary>
		public long CountAllPlatforms() 
		{ 
			return m_repository.CountAll (g => true); 
		}

		/// <summary>
		/// Saves the platform.
		/// </summary>
		/// <param name="platform">The platform.</param>
		public void SavePlatform(Platform platform)
		{
			ExceptionHelper.ThrowIfNull ("platform", platform);

			m_repository [platform.Key] = platform;

			m_unitOfWork.Commit (); 
		}

		/// <summary>
		/// Executes the deletion specification.
		/// </summary>
		partial void ExecuteDeletionSpecification(Platform platform);
		
		/// <summary>  
		/// Deletes the platform.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeletePlatform (long key)
		{
			var platform = GetPlatformByKey (key);
			ExecuteDeletionSpecification (platform);

			m_repository.Remove (platform);
			m_unitOfWork.Commit ();
		}
		#endregion
	}
}


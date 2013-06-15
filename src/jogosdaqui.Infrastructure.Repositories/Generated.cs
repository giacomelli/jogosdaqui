 
  
   
   

   

using System;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;
	 

namespace jogosdaqui.Infrastructure.Repositories.Testing
{
	/// <summary>
	/// Testing Game repository.  
	/// </summary>
	public class TestingGameRepository : MemoryRepository<Game, long>, IGameRepository
	{
		#region Fields
		private static long s_lastKey; 
		private static object s_lock = new Object();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingGameRepository"/> class.
		/// </summary>
		public TestingGameRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}

namespace jogosdaqui.Infrastructure.Repositories.Testing
{
	/// <summary>
	/// Testing GameCategory repository.  
	/// </summary>
	public class TestingGameCategoryRepository : MemoryRepository<GameCategory, long>, IGameCategoryRepository
	{
		#region Fields
		private static long s_lastKey; 
		private static object s_lock = new Object();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingGameCategoryRepository"/> class.
		/// </summary>
		public TestingGameCategoryRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}
 
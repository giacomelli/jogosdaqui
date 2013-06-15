 
  
   
   
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
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingGameRepository"/> class.
		/// </summary>
		public TestingGameRepository() : base((g) => { return DateTime.Now.Ticks; })
		{
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
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingGameCategoryRepository"/> class.
		/// </summary>
		public TestingGameCategoryRepository() : base((g) => { return DateTime.Now.Ticks; })
		{
		}
		#endregion
	}
}
 
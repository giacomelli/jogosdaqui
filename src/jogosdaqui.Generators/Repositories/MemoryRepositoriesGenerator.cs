 
 
 
 
 
  
  
  
   
   
   
   
	
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Platforms;
using jogosdaqui.Domain.Companies;
using jogosdaqui.Domain.Languages;
using jogosdaqui.Domain.Persons;
using jogosdaqui.Domain.Articles;
using jogosdaqui.Domain.Tags;
   

using System;
using Skahal.Infrastructure.Framework.Repositories;

	  
 
      
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
	/// Testing Platform repository.  
	/// </summary>
	public class TestingPlatformRepository : MemoryRepository<Platform, long>, IPlatformRepository
	{
		#region Fields
		private static long s_lastKey; 
		private static object s_lock = new Object();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingPlatformRepository"/> class.
		/// </summary>
		public TestingPlatformRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.Testing
{  
	/// <summary> 
	/// Testing Company repository.  
	/// </summary>
	public class TestingCompanyRepository : MemoryRepository<Company, long>, ICompanyRepository
	{
		#region Fields
		private static long s_lastKey; 
		private static object s_lock = new Object();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingCompanyRepository"/> class.
		/// </summary>
		public TestingCompanyRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.Testing
{  
	/// <summary> 
	/// Testing Language repository.  
	/// </summary>
	public class TestingLanguageRepository : MemoryRepository<Language, long>, ILanguageRepository
	{
		#region Fields
		private static long s_lastKey; 
		private static object s_lock = new Object();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingLanguageRepository"/> class.
		/// </summary>
		public TestingLanguageRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.Testing
{  
	/// <summary> 
	/// Testing Person repository.  
	/// </summary>
	public class TestingPersonRepository : MemoryRepository<Person, long>, IPersonRepository
	{
		#region Fields
		private static long s_lastKey; 
		private static object s_lock = new Object();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingPersonRepository"/> class.
		/// </summary>
		public TestingPersonRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.Testing
{  
	/// <summary> 
	/// Testing Comment repository.  
	/// </summary>
	public class TestingCommentRepository : MemoryRepository<Comment, long>, ICommentRepository
	{
		#region Fields
		private static long s_lastKey; 
		private static object s_lock = new Object();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingCommentRepository"/> class.
		/// </summary>
		public TestingCommentRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.Testing
{  
	/// <summary> 
	/// Testing Event repository.  
	/// </summary>
	public class TestingEventRepository : MemoryRepository<Event, long>, IEventRepository
	{
		#region Fields
		private static long s_lastKey; 
		private static object s_lock = new Object();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingEventRepository"/> class.
		/// </summary>
		public TestingEventRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.Testing
{  
	/// <summary> 
	/// Testing Interview repository.  
	/// </summary>
	public class TestingInterviewRepository : MemoryRepository<Interview, long>, IInterviewRepository
	{
		#region Fields
		private static long s_lastKey; 
		private static object s_lock = new Object();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingInterviewRepository"/> class.
		/// </summary>
		public TestingInterviewRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.Testing
{  
	/// <summary> 
	/// Testing News repository.  
	/// </summary>
	public class TestingNewsRepository : MemoryRepository<News, long>, INewsRepository
	{
		#region Fields
		private static long s_lastKey; 
		private static object s_lock = new Object();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingNewsRepository"/> class.
		/// </summary>
		public TestingNewsRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.Testing
{  
	/// <summary> 
	/// Testing Preview repository.  
	/// </summary>
	public class TestingPreviewRepository : MemoryRepository<Preview, long>, IPreviewRepository
	{
		#region Fields
		private static long s_lastKey; 
		private static object s_lock = new Object();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingPreviewRepository"/> class.
		/// </summary>
		public TestingPreviewRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.Testing
{  
	/// <summary> 
	/// Testing Review repository.  
	/// </summary>
	public class TestingReviewRepository : MemoryRepository<Review, long>, IReviewRepository
	{
		#region Fields
		private static long s_lastKey; 
		private static object s_lock = new Object();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingReviewRepository"/> class.
		/// </summary>
		public TestingReviewRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.Testing
{  
	/// <summary> 
	/// Testing Tag repository.  
	/// </summary>
	public class TestingTagRepository : MemoryRepository<Tag, long>, ITagRepository
	{
		#region Fields
		private static long s_lastKey; 
		private static object s_lock = new Object();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingTagRepository"/> class.
		/// </summary>
		public TestingTagRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.Testing
{  
	/// <summary> 
	/// Testing AppliedTag repository.  
	/// </summary>
	public class TestingAppliedTagRepository : MemoryRepository<AppliedTag, long>, IAppliedTagRepository
	{
		#region Fields
		private static long s_lastKey; 
		private static object s_lock = new Object();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingAppliedTagRepository"/> class.
		/// </summary>
		public TestingAppliedTagRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}
 
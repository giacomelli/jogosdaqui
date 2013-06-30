 
 
 
 
 
  
  
  
   
   
   
   
	
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Platforms;
using jogosdaqui.Domain.Companies;
using jogosdaqui.Domain.Languages;
using jogosdaqui.Domain.Persons;
using jogosdaqui.Domain.Articles;
using jogosdaqui.Domain.Tags;
   

using System;
using Skahal.Infrastructure.Framework.Repositories;

	  
 
      
namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{  
	/// <summary>
	/// MongoDB Game repository.   
	/// </summary>
	public class MongoDBGameRepository : MongoDBRepositoryBase<Game>,  IGameRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.MongoDB.MongoDBGameRepository"/> class.
		/// </summary>
		public MongoDBGameRepository() : base("Games")
		{
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{  
	/// <summary>
	/// MongoDB Platform repository.   
	/// </summary>
	public class MongoDBPlatformRepository : MongoDBRepositoryBase<Platform>,  IPlatformRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.MongoDB.MongoDBPlatformRepository"/> class.
		/// </summary>
		public MongoDBPlatformRepository() : base("Platforms")
		{
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{  
	/// <summary>
	/// MongoDB Company repository.   
	/// </summary>
	public class MongoDBCompanyRepository : MongoDBRepositoryBase<Company>,  ICompanyRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.MongoDB.MongoDBCompanyRepository"/> class.
		/// </summary>
		public MongoDBCompanyRepository() : base("Companies")
		{
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{  
	/// <summary>
	/// MongoDB Language repository.   
	/// </summary>
	public class MongoDBLanguageRepository : MongoDBRepositoryBase<Language>,  ILanguageRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.MongoDB.MongoDBLanguageRepository"/> class.
		/// </summary>
		public MongoDBLanguageRepository() : base("Languages")
		{
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{  
	/// <summary>
	/// MongoDB Person repository.   
	/// </summary>
	public class MongoDBPersonRepository : MongoDBRepositoryBase<Person>,  IPersonRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.MongoDB.MongoDBPersonRepository"/> class.
		/// </summary>
		public MongoDBPersonRepository() : base("Persons")
		{
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{  
	/// <summary>
	/// MongoDB Comment repository.   
	/// </summary>
	public class MongoDBCommentRepository : MongoDBRepositoryBase<Comment>,  ICommentRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.MongoDB.MongoDBCommentRepository"/> class.
		/// </summary>
		public MongoDBCommentRepository() : base("Comments")
		{
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{  
	/// <summary>
	/// MongoDB Event repository.   
	/// </summary>
	public class MongoDBEventRepository : MongoDBRepositoryBase<Event>,  IEventRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.MongoDB.MongoDBEventRepository"/> class.
		/// </summary>
		public MongoDBEventRepository() : base("Events")
		{
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{  
	/// <summary>
	/// MongoDB Interview repository.   
	/// </summary>
	public class MongoDBInterviewRepository : MongoDBRepositoryBase<Interview>,  IInterviewRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.MongoDB.MongoDBInterviewRepository"/> class.
		/// </summary>
		public MongoDBInterviewRepository() : base("Interviews")
		{
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{  
	/// <summary>
	/// MongoDB News repository.   
	/// </summary>
	public class MongoDBNewsRepository : MongoDBRepositoryBase<News>,  INewsRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.MongoDB.MongoDBNewsRepository"/> class.
		/// </summary>
		public MongoDBNewsRepository() : base("News")
		{
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{  
	/// <summary>
	/// MongoDB Preview repository.   
	/// </summary>
	public class MongoDBPreviewRepository : MongoDBRepositoryBase<Preview>,  IPreviewRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.MongoDB.MongoDBPreviewRepository"/> class.
		/// </summary>
		public MongoDBPreviewRepository() : base("Previews")
		{
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{  
	/// <summary>
	/// MongoDB Review repository.   
	/// </summary>
	public class MongoDBReviewRepository : MongoDBRepositoryBase<Review>,  IReviewRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.MongoDB.MongoDBReviewRepository"/> class.
		/// </summary>
		public MongoDBReviewRepository() : base("Reviews")
		{
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{  
	/// <summary>
	/// MongoDB Tag repository.   
	/// </summary>
	public class MongoDBTagRepository : MongoDBRepositoryBase<Tag>,  ITagRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.MongoDB.MongoDBTagRepository"/> class.
		/// </summary>
		public MongoDBTagRepository() : base("Tags")
		{
		}
		#endregion
	}
}
 
      
namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{  
	/// <summary>
	/// MongoDB AppliedTag repository.   
	/// </summary>
	public class MongoDBAppliedTagRepository : MongoDBRepositoryBase<AppliedTag>,  IAppliedTagRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.MongoDB.MongoDBAppliedTagRepository"/> class.
		/// </summary>
		public MongoDBAppliedTagRepository() : base("AppliedTags")
		{
		}
		#endregion
	}
}
 
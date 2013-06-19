 
 
 
 
 
  
  
  
   
   
using jogosdaqui.Domain;   
using jogosdaqui.Domain.Articles; 
using jogosdaqui.Domain.Companies; 
using jogosdaqui.Domain.Games; 
using jogosdaqui.Domain.Languages; 
using jogosdaqui.Domain.Persons; 
using jogosdaqui.Domain.Platforms; 
using jogosdaqui.Domain.Tags; 
  
   
  
#region Usings    
using System;  
using System.Collections.Generic;    
using System.IO;        
using System.Linq;    
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
			
			if(game == null)
			{
				throw new ArgumentException("Game with key '{0}' does not exists.".With(key));
			}
			
			ExecuteDeletionSpecification (game);

			m_repository.Remove (game);
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
			
			if(platform == null)
			{
				throw new ArgumentException("Platform with key '{0}' does not exists.".With(key));
			}
			
			ExecuteDeletionSpecification (platform);

			m_repository.Remove (platform);
			m_unitOfWork.Commit ();
		}
		#endregion
	}
}
     
namespace jogosdaqui.Domain.Companies
{  
	public partial interface ICompanyRepository : IRepository<Company, long>
	{
		}  

	// <summary>
	/// Domain layer company service.
	/// </summary>
	public partial class CompanyService
	{ 
		#region Fields	 
        private ICompanyRepository m_repository;
        private IUnitOfWork<long> m_unitOfWork; 
		#endregion 
		  
		#region Constructors 
      	/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Companies. CompanyService"/> class.
		/// </summary>
		public  CompanyService() 
			: this(DependencyService.Create<ICompanyRepository>(), DependencyService.Create<IUnitOfWork<long>>())
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Companies. CompanyService"/> class.
		/// </summary>
		/// <param name="companyRepository"> Company repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  CompanyService(ICompanyRepository companyRepository, IUnitOfWork<long> unitOfWork)
		{
			m_repository = companyRepository; 
			m_unitOfWork = unitOfWork;
			m_repository.SetUnitOfWork (m_unitOfWork);
		}
        #endregion
		
		#region Methods
		
		/// <summary>
		/// Gets the company by key.
		/// </summary>
		/// <returns>The company by key.</returns>
		/// <param name="key">The key.</param>
		public Company GetCompanyByKey(long key)
		{
			return m_repository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Companies. 
		/// </summary>
		/// <returns>The all Companies.</returns>
		public IList<Company> GetAllCompanies()
		{
			return m_repository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Companies.
		/// </summary>
		public long CountAllCompanies() 
		{ 
			return m_repository.CountAll (g => true); 
		}

		/// <summary>
		/// Saves the company.
		/// </summary>
		/// <param name="company">The company.</param>
		public void SaveCompany(Company company)
		{
			ExceptionHelper.ThrowIfNull ("company", company);

			m_repository [company.Key] = company;

			m_unitOfWork.Commit (); 
		}

		/// <summary>
		/// Executes the deletion specification.
		/// </summary>
		partial void ExecuteDeletionSpecification(Company company);
		
		/// <summary>  
		/// Deletes the company.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeleteCompany (long key)
		{
			var company = GetCompanyByKey (key);
			
			if(company == null)
			{
				throw new ArgumentException("Company with key '{0}' does not exists.".With(key));
			}
			
			ExecuteDeletionSpecification (company);

			m_repository.Remove (company);
			m_unitOfWork.Commit ();
		}
		#endregion
	}
}
     
namespace jogosdaqui.Domain.Languages
{  
	public partial interface ILanguageRepository : IRepository<Language, long>
	{
		}  

	// <summary>
	/// Domain layer language service.
	/// </summary>
	public partial class LanguageService
	{ 
		#region Fields	 
        private ILanguageRepository m_repository;
        private IUnitOfWork<long> m_unitOfWork; 
		#endregion 
		  
		#region Constructors 
      	/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Languages. LanguageService"/> class.
		/// </summary>
		public  LanguageService() 
			: this(DependencyService.Create<ILanguageRepository>(), DependencyService.Create<IUnitOfWork<long>>())
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Languages. LanguageService"/> class.
		/// </summary>
		/// <param name="languageRepository"> Language repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  LanguageService(ILanguageRepository languageRepository, IUnitOfWork<long> unitOfWork)
		{
			m_repository = languageRepository; 
			m_unitOfWork = unitOfWork;
			m_repository.SetUnitOfWork (m_unitOfWork);
		}
        #endregion
		
		#region Methods
		
		/// <summary>
		/// Gets the language by key.
		/// </summary>
		/// <returns>The language by key.</returns>
		/// <param name="key">The key.</param>
		public Language GetLanguageByKey(long key)
		{
			return m_repository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Languages. 
		/// </summary>
		/// <returns>The all Languages.</returns>
		public IList<Language> GetAllLanguages()
		{
			return m_repository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Languages.
		/// </summary>
		public long CountAllLanguages() 
		{ 
			return m_repository.CountAll (g => true); 
		}

		/// <summary>
		/// Saves the language.
		/// </summary>
		/// <param name="language">The language.</param>
		public void SaveLanguage(Language language)
		{
			ExceptionHelper.ThrowIfNull ("language", language);

			m_repository [language.Key] = language;

			m_unitOfWork.Commit (); 
		}

		/// <summary>
		/// Executes the deletion specification.
		/// </summary>
		partial void ExecuteDeletionSpecification(Language language);
		
		/// <summary>  
		/// Deletes the language.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeleteLanguage (long key)
		{
			var language = GetLanguageByKey (key);
			
			if(language == null)
			{
				throw new ArgumentException("Language with key '{0}' does not exists.".With(key));
			}
			
			ExecuteDeletionSpecification (language);

			m_repository.Remove (language);
			m_unitOfWork.Commit ();
		}
		#endregion
	}
}
     
namespace jogosdaqui.Domain.Persons
{  
	public partial interface IPersonRepository : IRepository<Person, long>
	{
		}  

	// <summary>
	/// Domain layer person service.
	/// </summary>
	public partial class PersonService
	{ 
		#region Fields	 
        private IPersonRepository m_repository;
        private IUnitOfWork<long> m_unitOfWork; 
		#endregion 
		  
		#region Constructors 
      	/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Persons. PersonService"/> class.
		/// </summary>
		public  PersonService() 
			: this(DependencyService.Create<IPersonRepository>(), DependencyService.Create<IUnitOfWork<long>>())
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Persons. PersonService"/> class.
		/// </summary>
		/// <param name="personRepository"> Person repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  PersonService(IPersonRepository personRepository, IUnitOfWork<long> unitOfWork)
		{
			m_repository = personRepository; 
			m_unitOfWork = unitOfWork;
			m_repository.SetUnitOfWork (m_unitOfWork);
		}
        #endregion
		
		#region Methods
		
		/// <summary>
		/// Gets the person by key.
		/// </summary>
		/// <returns>The person by key.</returns>
		/// <param name="key">The key.</param>
		public Person GetPersonByKey(long key)
		{
			return m_repository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Persons. 
		/// </summary>
		/// <returns>The all Persons.</returns>
		public IList<Person> GetAllPersons()
		{
			return m_repository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Persons.
		/// </summary>
		public long CountAllPersons() 
		{ 
			return m_repository.CountAll (g => true); 
		}

		/// <summary>
		/// Saves the person.
		/// </summary>
		/// <param name="person">The person.</param>
		public void SavePerson(Person person)
		{
			ExceptionHelper.ThrowIfNull ("person", person);

			m_repository [person.Key] = person;

			m_unitOfWork.Commit (); 
		}

		/// <summary>
		/// Executes the deletion specification.
		/// </summary>
		partial void ExecuteDeletionSpecification(Person person);
		
		/// <summary>  
		/// Deletes the person.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeletePerson (long key)
		{
			var person = GetPersonByKey (key);
			
			if(person == null)
			{
				throw new ArgumentException("Person with key '{0}' does not exists.".With(key));
			}
			
			ExecuteDeletionSpecification (person);

			m_repository.Remove (person);
			m_unitOfWork.Commit ();
		}
		#endregion
	}
}
     
namespace jogosdaqui.Domain.Articles
{  
	public partial interface ICommentRepository : IRepository<Comment, long>
	{
		}  

	// <summary>
	/// Domain layer comment service.
	/// </summary>
	public partial class CommentService
	{ 
		#region Fields	 
        private ICommentRepository m_repository;
        private IUnitOfWork<long> m_unitOfWork; 
		#endregion 
		  
		#region Constructors 
      	/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Comments. CommentService"/> class.
		/// </summary>
		public  CommentService() 
			: this(DependencyService.Create<ICommentRepository>(), DependencyService.Create<IUnitOfWork<long>>())
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Comments. CommentService"/> class.
		/// </summary>
		/// <param name="commentRepository"> Comment repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  CommentService(ICommentRepository commentRepository, IUnitOfWork<long> unitOfWork)
		{
			m_repository = commentRepository; 
			m_unitOfWork = unitOfWork;
			m_repository.SetUnitOfWork (m_unitOfWork);
		}
        #endregion
		
		#region Methods
		
		/// <summary>
		/// Gets the comment by key.
		/// </summary>
		/// <returns>The comment by key.</returns>
		/// <param name="key">The key.</param>
		public Comment GetCommentByKey(long key)
		{
			return m_repository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Comments. 
		/// </summary>
		/// <returns>The all Comments.</returns>
		public IList<Comment> GetAllComments()
		{
			return m_repository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Comments.
		/// </summary>
		public long CountAllComments() 
		{ 
			return m_repository.CountAll (g => true); 
		}

		/// <summary>
		/// Saves the comment.
		/// </summary>
		/// <param name="comment">The comment.</param>
		public void SaveComment(Comment comment)
		{
			ExceptionHelper.ThrowIfNull ("comment", comment);

			m_repository [comment.Key] = comment;

			m_unitOfWork.Commit (); 
		}

		/// <summary>
		/// Executes the deletion specification.
		/// </summary>
		partial void ExecuteDeletionSpecification(Comment comment);
		
		/// <summary>  
		/// Deletes the comment.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeleteComment (long key)
		{
			var comment = GetCommentByKey (key);
			
			if(comment == null)
			{
				throw new ArgumentException("Comment with key '{0}' does not exists.".With(key));
			}
			
			ExecuteDeletionSpecification (comment);

			m_repository.Remove (comment);
			m_unitOfWork.Commit ();
		}
		#endregion
	}
}
     
namespace jogosdaqui.Domain.Articles
{  
	public partial interface IInterviewRepository : IRepository<Interview, long>
	{
		}  

	// <summary>
	/// Domain layer interview service.
	/// </summary>
	public partial class InterviewService
	{ 
		#region Fields	 
        private IInterviewRepository m_repository;
        private IUnitOfWork<long> m_unitOfWork; 
		#endregion 
		  
		#region Constructors 
      	/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Interviews. InterviewService"/> class.
		/// </summary>
		public  InterviewService() 
			: this(DependencyService.Create<IInterviewRepository>(), DependencyService.Create<IUnitOfWork<long>>())
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Interviews. InterviewService"/> class.
		/// </summary>
		/// <param name="interviewRepository"> Interview repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  InterviewService(IInterviewRepository interviewRepository, IUnitOfWork<long> unitOfWork)
		{
			m_repository = interviewRepository; 
			m_unitOfWork = unitOfWork;
			m_repository.SetUnitOfWork (m_unitOfWork);
		}
        #endregion
		
		#region Methods
		
		/// <summary>
		/// Gets the interview by key.
		/// </summary>
		/// <returns>The interview by key.</returns>
		/// <param name="key">The key.</param>
		public Interview GetInterviewByKey(long key)
		{
			return m_repository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Interviews. 
		/// </summary>
		/// <returns>The all Interviews.</returns>
		public IList<Interview> GetAllInterviews()
		{
			return m_repository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Interviews.
		/// </summary>
		public long CountAllInterviews() 
		{ 
			return m_repository.CountAll (g => true); 
		}

		/// <summary>
		/// Saves the interview.
		/// </summary>
		/// <param name="interview">The interview.</param>
		public void SaveInterview(Interview interview)
		{
			ExceptionHelper.ThrowIfNull ("interview", interview);

			m_repository [interview.Key] = interview;

			m_unitOfWork.Commit (); 
		}

		/// <summary>
		/// Executes the deletion specification.
		/// </summary>
		partial void ExecuteDeletionSpecification(Interview interview);
		
		/// <summary>  
		/// Deletes the interview.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeleteInterview (long key)
		{
			var interview = GetInterviewByKey (key);
			
			if(interview == null)
			{
				throw new ArgumentException("Interview with key '{0}' does not exists.".With(key));
			}
			
			ExecuteDeletionSpecification (interview);

			m_repository.Remove (interview);
			m_unitOfWork.Commit ();
		}
		#endregion
	}
}
     
namespace jogosdaqui.Domain.Articles
{  
	public partial interface INewsRepository : IRepository<News, long>
	{
		}  

	// <summary>
	/// Domain layer news service.
	/// </summary>
	public partial class NewsService
	{ 
		#region Fields	 
        private INewsRepository m_repository;
        private IUnitOfWork<long> m_unitOfWork; 
		#endregion 
		  
		#region Constructors 
      	/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.News. NewsService"/> class.
		/// </summary>
		public  NewsService() 
			: this(DependencyService.Create<INewsRepository>(), DependencyService.Create<IUnitOfWork<long>>())
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.News. NewsService"/> class.
		/// </summary>
		/// <param name="newsRepository"> News repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  NewsService(INewsRepository newsRepository, IUnitOfWork<long> unitOfWork)
		{
			m_repository = newsRepository; 
			m_unitOfWork = unitOfWork;
			m_repository.SetUnitOfWork (m_unitOfWork);
		}
        #endregion
		
		#region Methods
		
		/// <summary>
		/// Gets the news by key.
		/// </summary>
		/// <returns>The news by key.</returns>
		/// <param name="key">The key.</param>
		public News GetNewsByKey(long key)
		{
			return m_repository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all News. 
		/// </summary>
		/// <returns>The all News.</returns>
		public IList<News> GetAllNews()
		{
			return m_repository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all News.
		/// </summary>
		public long CountAllNews() 
		{ 
			return m_repository.CountAll (g => true); 
		}

		/// <summary>
		/// Saves the news.
		/// </summary>
		/// <param name="news">The news.</param>
		public void SaveNews(News news)
		{
			ExceptionHelper.ThrowIfNull ("news", news);

			m_repository [news.Key] = news;

			m_unitOfWork.Commit (); 
		}

		/// <summary>
		/// Executes the deletion specification.
		/// </summary>
		partial void ExecuteDeletionSpecification(News news);
		
		/// <summary>  
		/// Deletes the news.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeleteNews (long key)
		{
			var news = GetNewsByKey (key);
			
			if(news == null)
			{
				throw new ArgumentException("News with key '{0}' does not exists.".With(key));
			}
			
			ExecuteDeletionSpecification (news);

			m_repository.Remove (news);
			m_unitOfWork.Commit ();
		}
		#endregion
	}
}
     
namespace jogosdaqui.Domain.Articles
{  
	public partial interface IPreviewRepository : IRepository<Preview, long>
	{
		}  

	// <summary>
	/// Domain layer preview service.
	/// </summary>
	public partial class PreviewService
	{ 
		#region Fields	 
        private IPreviewRepository m_repository;
        private IUnitOfWork<long> m_unitOfWork; 
		#endregion 
		  
		#region Constructors 
      	/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Previews. PreviewService"/> class.
		/// </summary>
		public  PreviewService() 
			: this(DependencyService.Create<IPreviewRepository>(), DependencyService.Create<IUnitOfWork<long>>())
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Previews. PreviewService"/> class.
		/// </summary>
		/// <param name="previewRepository"> Preview repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  PreviewService(IPreviewRepository previewRepository, IUnitOfWork<long> unitOfWork)
		{
			m_repository = previewRepository; 
			m_unitOfWork = unitOfWork;
			m_repository.SetUnitOfWork (m_unitOfWork);
		}
        #endregion
		
		#region Methods
		
		/// <summary>
		/// Gets the preview by key.
		/// </summary>
		/// <returns>The preview by key.</returns>
		/// <param name="key">The key.</param>
		public Preview GetPreviewByKey(long key)
		{
			return m_repository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Previews. 
		/// </summary>
		/// <returns>The all Previews.</returns>
		public IList<Preview> GetAllPreviews()
		{
			return m_repository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Previews.
		/// </summary>
		public long CountAllPreviews() 
		{ 
			return m_repository.CountAll (g => true); 
		}

		/// <summary>
		/// Saves the preview.
		/// </summary>
		/// <param name="preview">The preview.</param>
		public void SavePreview(Preview preview)
		{
			ExceptionHelper.ThrowIfNull ("preview", preview);

			m_repository [preview.Key] = preview;

			m_unitOfWork.Commit (); 
		}

		/// <summary>
		/// Executes the deletion specification.
		/// </summary>
		partial void ExecuteDeletionSpecification(Preview preview);
		
		/// <summary>  
		/// Deletes the preview.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeletePreview (long key)
		{
			var preview = GetPreviewByKey (key);
			
			if(preview == null)
			{
				throw new ArgumentException("Preview with key '{0}' does not exists.".With(key));
			}
			
			ExecuteDeletionSpecification (preview);

			m_repository.Remove (preview);
			m_unitOfWork.Commit ();
		}
		#endregion
	}
}
     
namespace jogosdaqui.Domain.Articles
{  
	public partial interface IReviewRepository : IRepository<Review, long>
	{
		}  

	// <summary>
	/// Domain layer review service.
	/// </summary>
	public partial class ReviewService
	{ 
		#region Fields	 
        private IReviewRepository m_repository;
        private IUnitOfWork<long> m_unitOfWork; 
		#endregion 
		  
		#region Constructors 
      	/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Reviews. ReviewService"/> class.
		/// </summary>
		public  ReviewService() 
			: this(DependencyService.Create<IReviewRepository>(), DependencyService.Create<IUnitOfWork<long>>())
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Reviews. ReviewService"/> class.
		/// </summary>
		/// <param name="reviewRepository"> Review repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  ReviewService(IReviewRepository reviewRepository, IUnitOfWork<long> unitOfWork)
		{
			m_repository = reviewRepository; 
			m_unitOfWork = unitOfWork;
			m_repository.SetUnitOfWork (m_unitOfWork);
		}
        #endregion
		
		#region Methods
		
		/// <summary>
		/// Gets the review by key.
		/// </summary>
		/// <returns>The review by key.</returns>
		/// <param name="key">The key.</param>
		public Review GetReviewByKey(long key)
		{
			return m_repository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Reviews. 
		/// </summary>
		/// <returns>The all Reviews.</returns>
		public IList<Review> GetAllReviews()
		{
			return m_repository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Reviews.
		/// </summary>
		public long CountAllReviews() 
		{ 
			return m_repository.CountAll (g => true); 
		}

		/// <summary>
		/// Saves the review.
		/// </summary>
		/// <param name="review">The review.</param>
		public void SaveReview(Review review)
		{
			ExceptionHelper.ThrowIfNull ("review", review);

			m_repository [review.Key] = review;

			m_unitOfWork.Commit (); 
		}

		/// <summary>
		/// Executes the deletion specification.
		/// </summary>
		partial void ExecuteDeletionSpecification(Review review);
		
		/// <summary>  
		/// Deletes the review.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeleteReview (long key)
		{
			var review = GetReviewByKey (key);
			
			if(review == null)
			{
				throw new ArgumentException("Review with key '{0}' does not exists.".With(key));
			}
			
			ExecuteDeletionSpecification (review);

			m_repository.Remove (review);
			m_unitOfWork.Commit ();
		}
		#endregion
	}
}
     
namespace jogosdaqui.Domain.Tags
{  
	public partial interface ITagRepository : IRepository<Tag, long>
	{
		}  

	// <summary>
	/// Domain layer tag service.
	/// </summary>
	public partial class TagService
	{ 
		#region Fields	 
        private ITagRepository m_repository;
        private IUnitOfWork<long> m_unitOfWork; 
		#endregion 
		  
		#region Constructors 
      	/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Tags. TagService"/> class.
		/// </summary>
		public  TagService() 
			: this(DependencyService.Create<ITagRepository>(), DependencyService.Create<IUnitOfWork<long>>())
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Tags. TagService"/> class.
		/// </summary>
		/// <param name="tagRepository"> Tag repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  TagService(ITagRepository tagRepository, IUnitOfWork<long> unitOfWork)
		{
			m_repository = tagRepository; 
			m_unitOfWork = unitOfWork;
			m_repository.SetUnitOfWork (m_unitOfWork);
		}
        #endregion
		
		#region Methods
		
		/// <summary>
		/// Gets the tag by key.
		/// </summary>
		/// <returns>The tag by key.</returns>
		/// <param name="key">The key.</param>
		public Tag GetTagByKey(long key)
		{
			return m_repository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Tags. 
		/// </summary>
		/// <returns>The all Tags.</returns>
		public IList<Tag> GetAllTags()
		{
			return m_repository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Tags.
		/// </summary>
		public long CountAllTags() 
		{ 
			return m_repository.CountAll (g => true); 
		}

		/// <summary>
		/// Saves the tag.
		/// </summary>
		/// <param name="tag">The tag.</param>
		public void SaveTag(Tag tag)
		{
			ExceptionHelper.ThrowIfNull ("tag", tag);

			m_repository [tag.Key] = tag;

			m_unitOfWork.Commit (); 
		}

		/// <summary>
		/// Executes the deletion specification.
		/// </summary>
		partial void ExecuteDeletionSpecification(Tag tag);
		
		/// <summary>  
		/// Deletes the tag.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeleteTag (long key)
		{
			var tag = GetTagByKey (key);
			
			if(tag == null)
			{
				throw new ArgumentException("Tag with key '{0}' does not exists.".With(key));
			}
			
			ExecuteDeletionSpecification (tag);

			m_repository.Remove (tag);
			m_unitOfWork.Commit ();
		}
		#endregion
	}
}
     
namespace jogosdaqui.Domain.Tags
{  
	public partial interface IAppliedTagRepository : IRepository<AppliedTag, long>
	{
		}  

	// <summary>
	/// Domain layer appliedtag service.
	/// </summary>
	public partial class AppliedTagService
	{ 
		#region Fields	 
        private IAppliedTagRepository m_repository;
        private IUnitOfWork<long> m_unitOfWork; 
		#endregion 
		  
		#region Constructors 
      	/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.AppliedTags. AppliedTagService"/> class.
		/// </summary>
		public  AppliedTagService() 
			: this(DependencyService.Create<IAppliedTagRepository>(), DependencyService.Create<IUnitOfWork<long>>())
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.AppliedTags. AppliedTagService"/> class.
		/// </summary>
		/// <param name="appliedtagRepository"> AppliedTag repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  AppliedTagService(IAppliedTagRepository appliedtagRepository, IUnitOfWork<long> unitOfWork)
		{
			m_repository = appliedtagRepository; 
			m_unitOfWork = unitOfWork;
			m_repository.SetUnitOfWork (m_unitOfWork);
		}
        #endregion
		
		#region Methods
		
		/// <summary>
		/// Gets the appliedtag by key.
		/// </summary>
		/// <returns>The appliedtag by key.</returns>
		/// <param name="key">The key.</param>
		public AppliedTag GetAppliedTagByKey(long key)
		{
			return m_repository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all AppliedTags. 
		/// </summary>
		/// <returns>The all AppliedTags.</returns>
		public IList<AppliedTag> GetAllAppliedTags()
		{
			return m_repository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all AppliedTags.
		/// </summary>
		public long CountAllAppliedTags() 
		{ 
			return m_repository.CountAll (g => true); 
		}

		/// <summary>
		/// Saves the appliedtag.
		/// </summary>
		/// <param name="appliedtag">The appliedtag.</param>
		public void SaveAppliedTag(AppliedTag appliedtag)
		{
			ExceptionHelper.ThrowIfNull ("appliedtag", appliedtag);

			m_repository [appliedtag.Key] = appliedtag;

			m_unitOfWork.Commit (); 
		}

		/// <summary>
		/// Executes the deletion specification.
		/// </summary>
		partial void ExecuteDeletionSpecification(AppliedTag appliedtag);
		
		/// <summary>  
		/// Deletes the appliedtag.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeleteAppliedTag (long key)
		{
			var appliedtag = GetAppliedTagByKey (key);
			
			if(appliedtag == null)
			{
				throw new ArgumentException("AppliedTag with key '{0}' does not exists.".With(key));
			}
			
			ExecuteDeletionSpecification (appliedtag);

			m_repository.Remove (appliedtag);
			m_unitOfWork.Commit ();
		}
		#endregion
	}
}


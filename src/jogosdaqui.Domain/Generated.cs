﻿ 
 
 
 
 
  
  
  
   
   
   
   
  
#region Usings    
using System;  
using System.Collections.Generic;    
using System.IO;        
using System.Linq;    
using Skahal.Infrastructure.Framework.Commons; 
using Skahal.Infrastructure.Framework.Domain;
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
	public partial class GameService : ServiceBase<Game, long, IGameRepository, IUnitOfWork<long>>
	{ 
		#region Constructors 
      	/// <summary> 
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Games. GameService"/> class.
		/// </summary>
		public  GameService()  
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Games. GameService"/> class.
		/// </summary>
		/// <param name="gameRepository"> Game repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  GameService(IGameRepository gameRepository, IUnitOfWork<long> unitOfWork)
		: base(gameRepository, unitOfWork)
		{
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
			return MainRepository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Games. 
		/// </summary>
		/// <returns>The all Games.</returns>
		public IList<Game> GetAllGames()
		{
			return MainRepository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Games.
		/// </summary>
		public long CountAllGames() 
		{ 
			return MainRepository.CountAll (g => true); 
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		partial void ExecuteSaveSpecification(Game game);
		
		/// <summary>
		/// Saves the game.
		/// </summary>
		/// <param name="game">The game.</param>
		public void SaveGame(Game game)
		{
			ExceptionHelper.ThrowIfNull ("game", game);

			ExecuteSaveSpecification (game);
			
			MainRepository [game.Key] = game;
			UnitOfWork.Commit (); 
		} 

		/// <summary> 
		/// Executes the delete specification.
		/// </summary>
		partial void ExecuteDeleteSpecification(long gameKey, Game game);
		  
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
			
			ExecuteDeleteSpecification (key, game);

			MainRepository.Remove (game); 
			UnitOfWork.Commit ();
		}
		#endregion
	}
}
 
namespace jogosdaqui.Domain.Games.Specifications 
{
	/// <summary>
	/// Game exists specification.
	/// </summary>
	public class GameExistsSpecification : SpecificationBase<Game>
	{
		#region Fields
		private long m_gameKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Games.Specifications.GameExistsSpecification"/> class.
		/// </summary>
		/// <param name="gameKey">Game key.</param>
		public GameExistsSpecification(long gameKey)
		{
			m_gameKey = gameKey;
		}
		#endregion 
  
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Game target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "Game with key '{0}' does not exists.".With (m_gameKey);
				return false;
			}

			return true;
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
	public partial class PlatformService : ServiceBase<Platform, long, IPlatformRepository, IUnitOfWork<long>>
	{ 
		#region Constructors 
      	/// <summary> 
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Platforms. PlatformService"/> class.
		/// </summary>
		public  PlatformService()  
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Platforms. PlatformService"/> class.
		/// </summary>
		/// <param name="platformRepository"> Platform repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  PlatformService(IPlatformRepository platformRepository, IUnitOfWork<long> unitOfWork)
		: base(platformRepository, unitOfWork)
		{
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
			return MainRepository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Platforms. 
		/// </summary>
		/// <returns>The all Platforms.</returns>
		public IList<Platform> GetAllPlatforms()
		{
			return MainRepository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Platforms.
		/// </summary>
		public long CountAllPlatforms() 
		{ 
			return MainRepository.CountAll (g => true); 
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		partial void ExecuteSaveSpecification(Platform platform);
		
		/// <summary>
		/// Saves the platform.
		/// </summary>
		/// <param name="platform">The platform.</param>
		public void SavePlatform(Platform platform)
		{
			ExceptionHelper.ThrowIfNull ("platform", platform);

			ExecuteSaveSpecification (platform);
			
			MainRepository [platform.Key] = platform;
			UnitOfWork.Commit (); 
		} 

		/// <summary> 
		/// Executes the delete specification.
		/// </summary>
		partial void ExecuteDeleteSpecification(long platformKey, Platform platform);
		  
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
			
			ExecuteDeleteSpecification (key, platform);

			MainRepository.Remove (platform); 
			UnitOfWork.Commit ();
		}
		#endregion
	}
}
 
namespace jogosdaqui.Domain.Platforms.Specifications 
{
	/// <summary>
	/// Platform exists specification.
	/// </summary>
	public class PlatformExistsSpecification : SpecificationBase<Platform>
	{
		#region Fields
		private long m_platformKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Platforms.Specifications.PlatformExistsSpecification"/> class.
		/// </summary>
		/// <param name="platformKey">Platform key.</param>
		public PlatformExistsSpecification(long platformKey)
		{
			m_platformKey = platformKey;
		}
		#endregion 
  
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Platform target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "Platform with key '{0}' does not exists.".With (m_platformKey);
				return false;
			}

			return true;
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
	public partial class CompanyService : ServiceBase<Company, long, ICompanyRepository, IUnitOfWork<long>>
	{ 
		#region Constructors 
      	/// <summary> 
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Companies. CompanyService"/> class.
		/// </summary>
		public  CompanyService()  
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Companies. CompanyService"/> class.
		/// </summary>
		/// <param name="companyRepository"> Company repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  CompanyService(ICompanyRepository companyRepository, IUnitOfWork<long> unitOfWork)
		: base(companyRepository, unitOfWork)
		{
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
			return MainRepository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Companies. 
		/// </summary>
		/// <returns>The all Companies.</returns>
		public IList<Company> GetAllCompanies()
		{
			return MainRepository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Companies.
		/// </summary>
		public long CountAllCompanies() 
		{ 
			return MainRepository.CountAll (g => true); 
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		partial void ExecuteSaveSpecification(Company company);
		
		/// <summary>
		/// Saves the company.
		/// </summary>
		/// <param name="company">The company.</param>
		public void SaveCompany(Company company)
		{
			ExceptionHelper.ThrowIfNull ("company", company);

			ExecuteSaveSpecification (company);
			
			MainRepository [company.Key] = company;
			UnitOfWork.Commit (); 
		} 

		/// <summary> 
		/// Executes the delete specification.
		/// </summary>
		partial void ExecuteDeleteSpecification(long companyKey, Company company);
		  
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
			
			ExecuteDeleteSpecification (key, company);

			MainRepository.Remove (company); 
			UnitOfWork.Commit ();
		}
		#endregion
	}
}
 
namespace jogosdaqui.Domain.Companies.Specifications 
{
	/// <summary>
	/// Company exists specification.
	/// </summary>
	public class CompanyExistsSpecification : SpecificationBase<Company>
	{
		#region Fields
		private long m_companyKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Companies.Specifications.CompanyExistsSpecification"/> class.
		/// </summary>
		/// <param name="companyKey">Company key.</param>
		public CompanyExistsSpecification(long companyKey)
		{
			m_companyKey = companyKey;
		}
		#endregion 
  
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Company target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "Company with key '{0}' does not exists.".With (m_companyKey);
				return false;
			}

			return true;
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
	public partial class LanguageService : ServiceBase<Language, long, ILanguageRepository, IUnitOfWork<long>>
	{ 
		#region Constructors 
      	/// <summary> 
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Languages. LanguageService"/> class.
		/// </summary>
		public  LanguageService()  
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Languages. LanguageService"/> class.
		/// </summary>
		/// <param name="languageRepository"> Language repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  LanguageService(ILanguageRepository languageRepository, IUnitOfWork<long> unitOfWork)
		: base(languageRepository, unitOfWork)
		{
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
			return MainRepository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Languages. 
		/// </summary>
		/// <returns>The all Languages.</returns>
		public IList<Language> GetAllLanguages()
		{
			return MainRepository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Languages.
		/// </summary>
		public long CountAllLanguages() 
		{ 
			return MainRepository.CountAll (g => true); 
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		partial void ExecuteSaveSpecification(Language language);
		
		/// <summary>
		/// Saves the language.
		/// </summary>
		/// <param name="language">The language.</param>
		public void SaveLanguage(Language language)
		{
			ExceptionHelper.ThrowIfNull ("language", language);

			ExecuteSaveSpecification (language);
			
			MainRepository [language.Key] = language;
			UnitOfWork.Commit (); 
		} 

		/// <summary> 
		/// Executes the delete specification.
		/// </summary>
		partial void ExecuteDeleteSpecification(long languageKey, Language language);
		  
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
			
			ExecuteDeleteSpecification (key, language);

			MainRepository.Remove (language); 
			UnitOfWork.Commit ();
		}
		#endregion
	}
}
 
namespace jogosdaqui.Domain.Languages.Specifications 
{
	/// <summary>
	/// Language exists specification.
	/// </summary>
	public class LanguageExistsSpecification : SpecificationBase<Language>
	{
		#region Fields
		private long m_languageKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Languages.Specifications.LanguageExistsSpecification"/> class.
		/// </summary>
		/// <param name="languageKey">Language key.</param>
		public LanguageExistsSpecification(long languageKey)
		{
			m_languageKey = languageKey;
		}
		#endregion 
  
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Language target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "Language with key '{0}' does not exists.".With (m_languageKey);
				return false;
			}

			return true;
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
	public partial class PersonService : ServiceBase<Person, long, IPersonRepository, IUnitOfWork<long>>
	{ 
		#region Constructors 
      	/// <summary> 
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Persons. PersonService"/> class.
		/// </summary>
		public  PersonService()  
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Persons. PersonService"/> class.
		/// </summary>
		/// <param name="personRepository"> Person repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  PersonService(IPersonRepository personRepository, IUnitOfWork<long> unitOfWork)
		: base(personRepository, unitOfWork)
		{
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
			return MainRepository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Persons. 
		/// </summary>
		/// <returns>The all Persons.</returns>
		public IList<Person> GetAllPersons()
		{
			return MainRepository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Persons.
		/// </summary>
		public long CountAllPersons() 
		{ 
			return MainRepository.CountAll (g => true); 
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		partial void ExecuteSaveSpecification(Person person);
		
		/// <summary>
		/// Saves the person.
		/// </summary>
		/// <param name="person">The person.</param>
		public void SavePerson(Person person)
		{
			ExceptionHelper.ThrowIfNull ("person", person);

			ExecuteSaveSpecification (person);
			
			MainRepository [person.Key] = person;
			UnitOfWork.Commit (); 
		} 

		/// <summary> 
		/// Executes the delete specification.
		/// </summary>
		partial void ExecuteDeleteSpecification(long personKey, Person person);
		  
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
			
			ExecuteDeleteSpecification (key, person);

			MainRepository.Remove (person); 
			UnitOfWork.Commit ();
		}
		#endregion
	}
}
 
namespace jogosdaqui.Domain.Persons.Specifications 
{
	/// <summary>
	/// Person exists specification.
	/// </summary>
	public class PersonExistsSpecification : SpecificationBase<Person>
	{
		#region Fields
		private long m_personKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Persons.Specifications.PersonExistsSpecification"/> class.
		/// </summary>
		/// <param name="personKey">Person key.</param>
		public PersonExistsSpecification(long personKey)
		{
			m_personKey = personKey;
		}
		#endregion 
  
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Person target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "Person with key '{0}' does not exists.".With (m_personKey);
				return false;
			}

			return true;
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
	public partial class CommentService : ServiceBase<Comment, long, ICommentRepository, IUnitOfWork<long>>
	{ 
		#region Constructors 
      	/// <summary> 
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Comments. CommentService"/> class.
		/// </summary>
		public  CommentService()  
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Comments. CommentService"/> class.
		/// </summary>
		/// <param name="commentRepository"> Comment repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  CommentService(ICommentRepository commentRepository, IUnitOfWork<long> unitOfWork)
		: base(commentRepository, unitOfWork)
		{
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
			return MainRepository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Comments. 
		/// </summary>
		/// <returns>The all Comments.</returns>
		public IList<Comment> GetAllComments()
		{
			return MainRepository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Comments.
		/// </summary>
		public long CountAllComments() 
		{ 
			return MainRepository.CountAll (g => true); 
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		partial void ExecuteSaveSpecification(Comment comment);
		
		/// <summary>
		/// Saves the comment.
		/// </summary>
		/// <param name="comment">The comment.</param>
		public void SaveComment(Comment comment)
		{
			ExceptionHelper.ThrowIfNull ("comment", comment);

			ExecuteSaveSpecification (comment);
			
			MainRepository [comment.Key] = comment;
			UnitOfWork.Commit (); 
		} 

		/// <summary> 
		/// Executes the delete specification.
		/// </summary>
		partial void ExecuteDeleteSpecification(long commentKey, Comment comment);
		  
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
			
			ExecuteDeleteSpecification (key, comment);

			MainRepository.Remove (comment); 
			UnitOfWork.Commit ();
		}
		#endregion
	}
}
 
namespace jogosdaqui.Domain.Articles.Specifications 
{
	/// <summary>
	/// Comment exists specification.
	/// </summary>
	public class CommentExistsSpecification : SpecificationBase<Comment>
	{
		#region Fields
		private long m_commentKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Comments.Specifications.CommentExistsSpecification"/> class.
		/// </summary>
		/// <param name="commentKey">Comment key.</param>
		public CommentExistsSpecification(long commentKey)
		{
			m_commentKey = commentKey;
		}
		#endregion 
  
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Comment target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "Comment with key '{0}' does not exists.".With (m_commentKey);
				return false;
			}

			return true;
		}

		#endregion
	}
}
     
namespace jogosdaqui.Domain.Articles
{  
	public partial interface IEventRepository : IRepository<Event, long>
	{
		}   

	// <summary>
	/// Domain layer event service.
	/// </summary>
	public partial class EventService : ArticleServiceBase<Event, IEventRepository>
	{ 
		#region Constructors 
      	/// <summary> 
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Events. EventService"/> class.
		/// </summary>
		public  EventService()  
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Events. EventService"/> class.
		/// </summary>
		/// <param name="eventRepository"> Event repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  EventService(IEventRepository eventRepository, IUnitOfWork<long> unitOfWork)
		: base(eventRepository, unitOfWork)
		{
		}
        #endregion
		
		#region Methods
		
		/// <summary>
		/// Gets the event by key.
		/// </summary>
		/// <returns>The event by key.</returns>
		/// <param name="key">The key.</param>
		public Event GetEventByKey(long key)
		{
			return MainRepository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Events. 
		/// </summary>
		/// <returns>The all Events.</returns>
		public IList<Event> GetAllEvents()
		{
			return MainRepository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Events.
		/// </summary>
		public long CountAllEvents() 
		{ 
			return MainRepository.CountAll (g => true); 
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		partial void ExecuteSaveSpecification(Event @event);
		
		/// <summary>
		/// Saves the event.
		/// </summary>
		/// <param name="event">The event.</param>
		public void SaveEvent(Event @event)
		{
			ExceptionHelper.ThrowIfNull ("event", @event);

			ExecuteSaveSpecification (@event);
			
			MainRepository [@event.Key] = @event;
			UnitOfWork.Commit (); 
		} 

		/// <summary> 
		/// Executes the delete specification.
		/// </summary>
		partial void ExecuteDeleteSpecification(long eventKey, Event @event);
		  
		/// <summary>  
		/// Deletes the event.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeleteEvent (long key)
		{ 
			var @event = GetEventByKey (key);
			
			if(@event == null)
			{
				throw new ArgumentException("Event with key '{0}' does not exists.".With(key));
			}
			
			ExecuteDeleteSpecification (key, @event);

			MainRepository.Remove (@event); 
			UnitOfWork.Commit ();
		}
		#endregion
	}
}
 
namespace jogosdaqui.Domain.Articles.Specifications 
{
	/// <summary>
	/// Event exists specification.
	/// </summary>
	public class EventExistsSpecification : SpecificationBase<Event>
	{
		#region Fields
		private long m_eventKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Events.Specifications.EventExistsSpecification"/> class.
		/// </summary>
		/// <param name="eventKey">Event key.</param>
		public EventExistsSpecification(long eventKey)
		{
			m_eventKey = eventKey;
		}
		#endregion 
  
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Event target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "Event with key '{0}' does not exists.".With (m_eventKey);
				return false;
			}

			return true;
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
	public partial class InterviewService : ArticleServiceBase<Interview, IInterviewRepository>
	{ 
		#region Constructors 
      	/// <summary> 
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Interviews. InterviewService"/> class.
		/// </summary>
		public  InterviewService()  
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Interviews. InterviewService"/> class.
		/// </summary>
		/// <param name="interviewRepository"> Interview repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  InterviewService(IInterviewRepository interviewRepository, IUnitOfWork<long> unitOfWork)
		: base(interviewRepository, unitOfWork)
		{
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
			return MainRepository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Interviews. 
		/// </summary>
		/// <returns>The all Interviews.</returns>
		public IList<Interview> GetAllInterviews()
		{
			return MainRepository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Interviews.
		/// </summary>
		public long CountAllInterviews() 
		{ 
			return MainRepository.CountAll (g => true); 
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		partial void ExecuteSaveSpecification(Interview interview);
		
		/// <summary>
		/// Saves the interview.
		/// </summary>
		/// <param name="interview">The interview.</param>
		public void SaveInterview(Interview interview)
		{
			ExceptionHelper.ThrowIfNull ("interview", interview);

			ExecuteSaveSpecification (interview);
			
			MainRepository [interview.Key] = interview;
			UnitOfWork.Commit (); 
		} 

		/// <summary> 
		/// Executes the delete specification.
		/// </summary>
		partial void ExecuteDeleteSpecification(long interviewKey, Interview interview);
		  
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
			
			ExecuteDeleteSpecification (key, interview);

			MainRepository.Remove (interview); 
			UnitOfWork.Commit ();
		}
		#endregion
	}
}
 
namespace jogosdaqui.Domain.Articles.Specifications 
{
	/// <summary>
	/// Interview exists specification.
	/// </summary>
	public class InterviewExistsSpecification : SpecificationBase<Interview>
	{
		#region Fields
		private long m_interviewKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Interviews.Specifications.InterviewExistsSpecification"/> class.
		/// </summary>
		/// <param name="interviewKey">Interview key.</param>
		public InterviewExistsSpecification(long interviewKey)
		{
			m_interviewKey = interviewKey;
		}
		#endregion 
  
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Interview target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "Interview with key '{0}' does not exists.".With (m_interviewKey);
				return false;
			}

			return true;
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
	public partial class NewsService : ArticleServiceBase<News, INewsRepository>
	{ 
		#region Constructors 
      	/// <summary> 
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.News. NewsService"/> class.
		/// </summary>
		public  NewsService()  
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.News. NewsService"/> class.
		/// </summary>
		/// <param name="newsRepository"> News repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  NewsService(INewsRepository newsRepository, IUnitOfWork<long> unitOfWork)
		: base(newsRepository, unitOfWork)
		{
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
			return MainRepository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all News. 
		/// </summary>
		/// <returns>The all News.</returns>
		public IList<News> GetAllNews()
		{
			return MainRepository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all News.
		/// </summary>
		public long CountAllNews() 
		{ 
			return MainRepository.CountAll (g => true); 
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		partial void ExecuteSaveSpecification(News news);
		
		/// <summary>
		/// Saves the news.
		/// </summary>
		/// <param name="news">The news.</param>
		public void SaveNews(News news)
		{
			ExceptionHelper.ThrowIfNull ("news", news);

			ExecuteSaveSpecification (news);
			
			MainRepository [news.Key] = news;
			UnitOfWork.Commit (); 
		} 

		/// <summary> 
		/// Executes the delete specification.
		/// </summary>
		partial void ExecuteDeleteSpecification(long newsKey, News news);
		  
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
			
			ExecuteDeleteSpecification (key, news);

			MainRepository.Remove (news); 
			UnitOfWork.Commit ();
		}
		#endregion
	}
}
 
namespace jogosdaqui.Domain.Articles.Specifications 
{
	/// <summary>
	/// News exists specification.
	/// </summary>
	public class NewsExistsSpecification : SpecificationBase<News>
	{
		#region Fields
		private long m_newsKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.News.Specifications.NewsExistsSpecification"/> class.
		/// </summary>
		/// <param name="newsKey">News key.</param>
		public NewsExistsSpecification(long newsKey)
		{
			m_newsKey = newsKey;
		}
		#endregion 
  
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (News target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "News with key '{0}' does not exists.".With (m_newsKey);
				return false;
			}

			return true;
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
	public partial class PreviewService : ArticleServiceBase<Preview, IPreviewRepository>
	{ 
		#region Constructors 
      	/// <summary> 
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Previews. PreviewService"/> class.
		/// </summary>
		public  PreviewService()  
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Previews. PreviewService"/> class.
		/// </summary>
		/// <param name="previewRepository"> Preview repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  PreviewService(IPreviewRepository previewRepository, IUnitOfWork<long> unitOfWork)
		: base(previewRepository, unitOfWork)
		{
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
			return MainRepository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Previews. 
		/// </summary>
		/// <returns>The all Previews.</returns>
		public IList<Preview> GetAllPreviews()
		{
			return MainRepository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Previews.
		/// </summary>
		public long CountAllPreviews() 
		{ 
			return MainRepository.CountAll (g => true); 
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		partial void ExecuteSaveSpecification(Preview preview);
		
		/// <summary>
		/// Saves the preview.
		/// </summary>
		/// <param name="preview">The preview.</param>
		public void SavePreview(Preview preview)
		{
			ExceptionHelper.ThrowIfNull ("preview", preview);

			ExecuteSaveSpecification (preview);
			
			MainRepository [preview.Key] = preview;
			UnitOfWork.Commit (); 
		} 

		/// <summary> 
		/// Executes the delete specification.
		/// </summary>
		partial void ExecuteDeleteSpecification(long previewKey, Preview preview);
		  
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
			
			ExecuteDeleteSpecification (key, preview);

			MainRepository.Remove (preview); 
			UnitOfWork.Commit ();
		}
		#endregion
	}
}
 
namespace jogosdaqui.Domain.Articles.Specifications 
{
	/// <summary>
	/// Preview exists specification.
	/// </summary>
	public class PreviewExistsSpecification : SpecificationBase<Preview>
	{
		#region Fields
		private long m_previewKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Previews.Specifications.PreviewExistsSpecification"/> class.
		/// </summary>
		/// <param name="previewKey">Preview key.</param>
		public PreviewExistsSpecification(long previewKey)
		{
			m_previewKey = previewKey;
		}
		#endregion 
  
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Preview target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "Preview with key '{0}' does not exists.".With (m_previewKey);
				return false;
			}

			return true;
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
	public partial class ReviewService : ArticleServiceBase<Review, IReviewRepository>
	{ 
		#region Constructors 
      	/// <summary> 
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Reviews. ReviewService"/> class.
		/// </summary>
		public  ReviewService()  
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Reviews. ReviewService"/> class.
		/// </summary>
		/// <param name="reviewRepository"> Review repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  ReviewService(IReviewRepository reviewRepository, IUnitOfWork<long> unitOfWork)
		: base(reviewRepository, unitOfWork)
		{
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
			return MainRepository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Reviews. 
		/// </summary>
		/// <returns>The all Reviews.</returns>
		public IList<Review> GetAllReviews()
		{
			return MainRepository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Reviews.
		/// </summary>
		public long CountAllReviews() 
		{ 
			return MainRepository.CountAll (g => true); 
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		partial void ExecuteSaveSpecification(Review review);
		
		/// <summary>
		/// Saves the review.
		/// </summary>
		/// <param name="review">The review.</param>
		public void SaveReview(Review review)
		{
			ExceptionHelper.ThrowIfNull ("review", review);

			ExecuteSaveSpecification (review);
			
			MainRepository [review.Key] = review;
			UnitOfWork.Commit (); 
		} 

		/// <summary> 
		/// Executes the delete specification.
		/// </summary>
		partial void ExecuteDeleteSpecification(long reviewKey, Review review);
		  
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
			
			ExecuteDeleteSpecification (key, review);

			MainRepository.Remove (review); 
			UnitOfWork.Commit ();
		}
		#endregion
	}
}
 
namespace jogosdaqui.Domain.Articles.Specifications 
{
	/// <summary>
	/// Review exists specification.
	/// </summary>
	public class ReviewExistsSpecification : SpecificationBase<Review>
	{
		#region Fields
		private long m_reviewKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Reviews.Specifications.ReviewExistsSpecification"/> class.
		/// </summary>
		/// <param name="reviewKey">Review key.</param>
		public ReviewExistsSpecification(long reviewKey)
		{
			m_reviewKey = reviewKey;
		}
		#endregion 
  
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Review target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "Review with key '{0}' does not exists.".With (m_reviewKey);
				return false;
			}

			return true;
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
	public partial class TagService : ServiceBase<Tag, long, ITagRepository, IUnitOfWork<long>>
	{ 
		#region Constructors 
      	/// <summary> 
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Tags. TagService"/> class.
		/// </summary>
		public  TagService()  
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Tags. TagService"/> class.
		/// </summary>
		/// <param name="tagRepository"> Tag repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  TagService(ITagRepository tagRepository, IUnitOfWork<long> unitOfWork)
		: base(tagRepository, unitOfWork)
		{
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
			return MainRepository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all Tags. 
		/// </summary>
		/// <returns>The all Tags.</returns>
		public IList<Tag> GetAllTags()
		{
			return MainRepository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Tags.
		/// </summary>
		public long CountAllTags() 
		{ 
			return MainRepository.CountAll (g => true); 
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		partial void ExecuteSaveSpecification(Tag tag);
		
		/// <summary>
		/// Saves the tag.
		/// </summary>
		/// <param name="tag">The tag.</param>
		public void SaveTag(Tag tag)
		{
			ExceptionHelper.ThrowIfNull ("tag", tag);

			ExecuteSaveSpecification (tag);
			
			MainRepository [tag.Key] = tag;
			UnitOfWork.Commit (); 
		} 

		/// <summary> 
		/// Executes the delete specification.
		/// </summary>
		partial void ExecuteDeleteSpecification(long tagKey, Tag tag);
		  
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
			
			ExecuteDeleteSpecification (key, tag);

			MainRepository.Remove (tag); 
			UnitOfWork.Commit ();
		}
		#endregion
	}
}
 
namespace jogosdaqui.Domain.Tags.Specifications 
{
	/// <summary>
	/// Tag exists specification.
	/// </summary>
	public class TagExistsSpecification : SpecificationBase<Tag>
	{
		#region Fields
		private long m_tagKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Tags.Specifications.TagExistsSpecification"/> class.
		/// </summary>
		/// <param name="tagKey">Tag key.</param>
		public TagExistsSpecification(long tagKey)
		{
			m_tagKey = tagKey;
		}
		#endregion 
  
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Tag target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "Tag with key '{0}' does not exists.".With (m_tagKey);
				return false;
			}

			return true;
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
	public partial class AppliedTagService : ServiceBase<AppliedTag, long, IAppliedTagRepository, IUnitOfWork<long>>
	{ 
		#region Constructors 
      	/// <summary> 
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.AppliedTags. AppliedTagService"/> class.
		/// </summary>
		public  AppliedTagService()  
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.AppliedTags. AppliedTagService"/> class.
		/// </summary>
		/// <param name="appliedtagRepository"> AppliedTag repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public  AppliedTagService(IAppliedTagRepository appliedtagRepository, IUnitOfWork<long> unitOfWork)
		: base(appliedtagRepository, unitOfWork)
		{
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
			return MainRepository.FindAll (g => g.Key == key).FirstOrDefault ();
		}
		
		/// <summary>
		/// Gets all AppliedTags. 
		/// </summary>
		/// <returns>The all AppliedTags.</returns>
		public IList<AppliedTag> GetAllAppliedTags()
		{
			return MainRepository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all AppliedTags.
		/// </summary>
		public long CountAllAppliedTags() 
		{ 
			return MainRepository.CountAll (g => true); 
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		partial void ExecuteSaveSpecification(AppliedTag appliedtag);
		
		/// <summary>
		/// Saves the appliedtag.
		/// </summary>
		/// <param name="appliedtag">The appliedtag.</param>
		public void SaveAppliedTag(AppliedTag appliedtag)
		{
			ExceptionHelper.ThrowIfNull ("appliedtag", appliedtag);

			ExecuteSaveSpecification (appliedtag);
			
			MainRepository [appliedtag.Key] = appliedtag;
			UnitOfWork.Commit (); 
		} 

		/// <summary> 
		/// Executes the delete specification.
		/// </summary>
		partial void ExecuteDeleteSpecification(long appliedtagKey, AppliedTag appliedtag);
		  
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
			
			ExecuteDeleteSpecification (key, appliedtag);

			MainRepository.Remove (appliedtag); 
			UnitOfWork.Commit ();
		}
		#endregion
	}
}
 
namespace jogosdaqui.Domain.Tags.Specifications 
{
	/// <summary>
	/// AppliedTag exists specification.
	/// </summary>
	public class AppliedTagExistsSpecification : SpecificationBase<AppliedTag>
	{
		#region Fields
		private long m_appliedtagKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.AppliedTags.Specifications.AppliedTagExistsSpecification"/> class.
		/// </summary>
		/// <param name="appliedtagKey">AppliedTag key.</param>
		public AppliedTagExistsSpecification(long appliedtagKey)
		{
			m_appliedtagKey = appliedtagKey;
		}
		#endregion 
  
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (AppliedTag target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "AppliedTag with key '{0}' does not exists.".With (m_appliedtagKey);
				return false;
			}

			return true;
		}

		#endregion
	}
}


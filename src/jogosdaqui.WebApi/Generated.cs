 
 
 
 
 
  
  
  
   
   
using jogosdaqui.Domain;   
using jogosdaqui.Domain.Articles; 
using jogosdaqui.Domain.Companies; 
using jogosdaqui.Domain.Games; 
using jogosdaqui.Domain.Languages; 
using jogosdaqui.Domain.Persons; 
using jogosdaqui.Domain.Platforms; 
using jogosdaqui.Domain.Tags; 
  
   
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http; 
using System.Web.Mvc;
using AspNetWebApi.ApiGee.Filters;
	          
 
    
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
		/// Get Game by key.
		/// </summary>  
		/// <param name="key">The Game's key.</param>
		/// <returns>The Game with the specified key.</returns>
        public Game Get(long key)
        {
			return m_service.GetGameByKey (key);
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
	/// Platforms. 
	/// </summary>
    public class PlatformsController : ApiController
    {
		#region Fields
		private PlatformService m_service;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.WebApi.Controllers.PlatformsController"/> class.
		/// </summary>
		public PlatformsController()
		{
			m_service = new PlatformService ();
		}
		#endregion

		/// <summary>
		/// Get all Platforms
		/// </summary>
        public IEnumerable<Platform> Get()
        {
			return m_service.GetAllPlatforms ();
        }
        
        /// <summary>  
		/// Get Platform by key.
		/// </summary>  
		/// <param name="key">The Platform's key.</param>
		/// <returns>The Platform with the specified key.</returns>
        public Platform Get(long key)
        {
			return m_service.GetPlatformByKey (key);
        }

		/// <summary>
		/// Creates a new Platform.
		/// </summary>
		/// <param name="platform">The Platform to create.</param>
		/// <returns>The created Platform with the key.</returns>
		public Platform Post(Platform platform)
		{
			m_service.SavePlatform (platform);

			return platform;
		}

		/// <summary>
		/// Updates an existing Platform.
		/// </summary>
		/// <param name="key">The Platform's key.</param>
		/// <param name="platform">The Platform with updated informations.</param>
		public Platform Put(long key, Platform platform)
		{
	        platform.Key = key;
			m_service.SavePlatform (platform);

			return platform;
		}

		/// <summary>
		/// Deletes the Platform with the specified key.
		/// </summary>
		/// <param name="key">The key of the Platform to be deleted.</param>
	    [SuccessHandlingFilter]
        public void Delete(long key)
		{
			m_service.DeletePlatform (key);
		}
    }
}
 
    
namespace jogosdaqui.WebApi.Controllers
{
	/// <summary>
	/// Companies. 
	/// </summary>
    public class CompaniesController : ApiController
    {
		#region Fields
		private CompanyService m_service;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.WebApi.Controllers.CompaniesController"/> class.
		/// </summary>
		public CompaniesController()
		{
			m_service = new CompanyService ();
		}
		#endregion

		/// <summary>
		/// Get all Companies
		/// </summary>
        public IEnumerable<Company> Get()
        {
			return m_service.GetAllCompanies ();
        }
        
        /// <summary>  
		/// Get Company by key.
		/// </summary>  
		/// <param name="key">The Company's key.</param>
		/// <returns>The Company with the specified key.</returns>
        public Company Get(long key)
        {
			return m_service.GetCompanyByKey (key);
        }

		/// <summary>
		/// Creates a new Company.
		/// </summary>
		/// <param name="company">The Company to create.</param>
		/// <returns>The created Company with the key.</returns>
		public Company Post(Company company)
		{
			m_service.SaveCompany (company);

			return company;
		}

		/// <summary>
		/// Updates an existing Company.
		/// </summary>
		/// <param name="key">The Company's key.</param>
		/// <param name="company">The Company with updated informations.</param>
		public Company Put(long key, Company company)
		{
	        company.Key = key;
			m_service.SaveCompany (company);

			return company;
		}

		/// <summary>
		/// Deletes the Company with the specified key.
		/// </summary>
		/// <param name="key">The key of the Company to be deleted.</param>
	    [SuccessHandlingFilter]
        public void Delete(long key)
		{
			m_service.DeleteCompany (key);
		}
    }
}
 
    
namespace jogosdaqui.WebApi.Controllers
{
	/// <summary>
	/// Languages. 
	/// </summary>
    public class LanguagesController : ApiController
    {
		#region Fields
		private LanguageService m_service;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.WebApi.Controllers.LanguagesController"/> class.
		/// </summary>
		public LanguagesController()
		{
			m_service = new LanguageService ();
		}
		#endregion

		/// <summary>
		/// Get all Languages
		/// </summary>
        public IEnumerable<Language> Get()
        {
			return m_service.GetAllLanguages ();
        }
        
        /// <summary>  
		/// Get Language by key.
		/// </summary>  
		/// <param name="key">The Language's key.</param>
		/// <returns>The Language with the specified key.</returns>
        public Language Get(long key)
        {
			return m_service.GetLanguageByKey (key);
        }

		/// <summary>
		/// Creates a new Language.
		/// </summary>
		/// <param name="language">The Language to create.</param>
		/// <returns>The created Language with the key.</returns>
		public Language Post(Language language)
		{
			m_service.SaveLanguage (language);

			return language;
		}

		/// <summary>
		/// Updates an existing Language.
		/// </summary>
		/// <param name="key">The Language's key.</param>
		/// <param name="language">The Language with updated informations.</param>
		public Language Put(long key, Language language)
		{
	        language.Key = key;
			m_service.SaveLanguage (language);

			return language;
		}

		/// <summary>
		/// Deletes the Language with the specified key.
		/// </summary>
		/// <param name="key">The key of the Language to be deleted.</param>
	    [SuccessHandlingFilter]
        public void Delete(long key)
		{
			m_service.DeleteLanguage (key);
		}
    }
}
 
    
namespace jogosdaqui.WebApi.Controllers
{
	/// <summary>
	/// Persons. 
	/// </summary>
    public class PersonsController : ApiController
    {
		#region Fields
		private PersonService m_service;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.WebApi.Controllers.PersonsController"/> class.
		/// </summary>
		public PersonsController()
		{
			m_service = new PersonService ();
		}
		#endregion

		/// <summary>
		/// Get all Persons
		/// </summary>
        public IEnumerable<Person> Get()
        {
			return m_service.GetAllPersons ();
        }
        
        /// <summary>  
		/// Get Person by key.
		/// </summary>  
		/// <param name="key">The Person's key.</param>
		/// <returns>The Person with the specified key.</returns>
        public Person Get(long key)
        {
			return m_service.GetPersonByKey (key);
        }

		/// <summary>
		/// Creates a new Person.
		/// </summary>
		/// <param name="person">The Person to create.</param>
		/// <returns>The created Person with the key.</returns>
		public Person Post(Person person)
		{
			m_service.SavePerson (person);

			return person;
		}

		/// <summary>
		/// Updates an existing Person.
		/// </summary>
		/// <param name="key">The Person's key.</param>
		/// <param name="person">The Person with updated informations.</param>
		public Person Put(long key, Person person)
		{
	        person.Key = key;
			m_service.SavePerson (person);

			return person;
		}

		/// <summary>
		/// Deletes the Person with the specified key.
		/// </summary>
		/// <param name="key">The key of the Person to be deleted.</param>
	    [SuccessHandlingFilter]
        public void Delete(long key)
		{
			m_service.DeletePerson (key);
		}
    }
}
 
    
namespace jogosdaqui.WebApi.Controllers
{
	/// <summary>
	/// Comments. 
	/// </summary>
    public class CommentsController : ApiController
    {
		#region Fields
		private CommentService m_service;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.WebApi.Controllers.CommentsController"/> class.
		/// </summary>
		public CommentsController()
		{
			m_service = new CommentService ();
		}
		#endregion

		/// <summary>
		/// Get all Comments
		/// </summary>
        public IEnumerable<Comment> Get()
        {
			return m_service.GetAllComments ();
        }
        
        /// <summary>  
		/// Get Comment by key.
		/// </summary>  
		/// <param name="key">The Comment's key.</param>
		/// <returns>The Comment with the specified key.</returns>
        public Comment Get(long key)
        {
			return m_service.GetCommentByKey (key);
        }

		/// <summary>
		/// Creates a new Comment.
		/// </summary>
		/// <param name="comment">The Comment to create.</param>
		/// <returns>The created Comment with the key.</returns>
		public Comment Post(Comment comment)
		{
			m_service.SaveComment (comment);

			return comment;
		}

		/// <summary>
		/// Updates an existing Comment.
		/// </summary>
		/// <param name="key">The Comment's key.</param>
		/// <param name="comment">The Comment with updated informations.</param>
		public Comment Put(long key, Comment comment)
		{
	        comment.Key = key;
			m_service.SaveComment (comment);

			return comment;
		}

		/// <summary>
		/// Deletes the Comment with the specified key.
		/// </summary>
		/// <param name="key">The key of the Comment to be deleted.</param>
	    [SuccessHandlingFilter]
        public void Delete(long key)
		{
			m_service.DeleteComment (key);
		}
    }
}
 
    
namespace jogosdaqui.WebApi.Controllers
{
	/// <summary>
	/// Interviews. 
	/// </summary>
    public class InterviewsController : ApiController
    {
		#region Fields
		private InterviewService m_service;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.WebApi.Controllers.InterviewsController"/> class.
		/// </summary>
		public InterviewsController()
		{
			m_service = new InterviewService ();
		}
		#endregion

		/// <summary>
		/// Get all Interviews
		/// </summary>
        public IEnumerable<Interview> Get()
        {
			return m_service.GetAllInterviews ();
        }
        
        /// <summary>  
		/// Get Interview by key.
		/// </summary>  
		/// <param name="key">The Interview's key.</param>
		/// <returns>The Interview with the specified key.</returns>
        public Interview Get(long key)
        {
			return m_service.GetInterviewByKey (key);
        }

		/// <summary>
		/// Creates a new Interview.
		/// </summary>
		/// <param name="interview">The Interview to create.</param>
		/// <returns>The created Interview with the key.</returns>
		public Interview Post(Interview interview)
		{
			m_service.SaveInterview (interview);

			return interview;
		}

		/// <summary>
		/// Updates an existing Interview.
		/// </summary>
		/// <param name="key">The Interview's key.</param>
		/// <param name="interview">The Interview with updated informations.</param>
		public Interview Put(long key, Interview interview)
		{
	        interview.Key = key;
			m_service.SaveInterview (interview);

			return interview;
		}

		/// <summary>
		/// Deletes the Interview with the specified key.
		/// </summary>
		/// <param name="key">The key of the Interview to be deleted.</param>
	    [SuccessHandlingFilter]
        public void Delete(long key)
		{
			m_service.DeleteInterview (key);
		}
    }
}
 
    
namespace jogosdaqui.WebApi.Controllers
{
	/// <summary>
	/// News. 
	/// </summary>
    public class NewsController : ApiController
    {
		#region Fields
		private NewsService m_service;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.WebApi.Controllers.NewsController"/> class.
		/// </summary>
		public NewsController()
		{
			m_service = new NewsService ();
		}
		#endregion

		/// <summary>
		/// Get all News
		/// </summary>
        public IEnumerable<News> Get()
        {
			return m_service.GetAllNews ();
        }
        
        /// <summary>  
		/// Get News by key.
		/// </summary>  
		/// <param name="key">The News's key.</param>
		/// <returns>The News with the specified key.</returns>
        public News Get(long key)
        {
			return m_service.GetNewsByKey (key);
        }

		/// <summary>
		/// Creates a new News.
		/// </summary>
		/// <param name="news">The News to create.</param>
		/// <returns>The created News with the key.</returns>
		public News Post(News news)
		{
			m_service.SaveNews (news);

			return news;
		}

		/// <summary>
		/// Updates an existing News.
		/// </summary>
		/// <param name="key">The News's key.</param>
		/// <param name="news">The News with updated informations.</param>
		public News Put(long key, News news)
		{
	        news.Key = key;
			m_service.SaveNews (news);

			return news;
		}

		/// <summary>
		/// Deletes the News with the specified key.
		/// </summary>
		/// <param name="key">The key of the News to be deleted.</param>
	    [SuccessHandlingFilter]
        public void Delete(long key)
		{
			m_service.DeleteNews (key);
		}
    }
}
 
    
namespace jogosdaqui.WebApi.Controllers
{
	/// <summary>
	/// Previews. 
	/// </summary>
    public class PreviewsController : ApiController
    {
		#region Fields
		private PreviewService m_service;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.WebApi.Controllers.PreviewsController"/> class.
		/// </summary>
		public PreviewsController()
		{
			m_service = new PreviewService ();
		}
		#endregion

		/// <summary>
		/// Get all Previews
		/// </summary>
        public IEnumerable<Preview> Get()
        {
			return m_service.GetAllPreviews ();
        }
        
        /// <summary>  
		/// Get Preview by key.
		/// </summary>  
		/// <param name="key">The Preview's key.</param>
		/// <returns>The Preview with the specified key.</returns>
        public Preview Get(long key)
        {
			return m_service.GetPreviewByKey (key);
        }

		/// <summary>
		/// Creates a new Preview.
		/// </summary>
		/// <param name="preview">The Preview to create.</param>
		/// <returns>The created Preview with the key.</returns>
		public Preview Post(Preview preview)
		{
			m_service.SavePreview (preview);

			return preview;
		}

		/// <summary>
		/// Updates an existing Preview.
		/// </summary>
		/// <param name="key">The Preview's key.</param>
		/// <param name="preview">The Preview with updated informations.</param>
		public Preview Put(long key, Preview preview)
		{
	        preview.Key = key;
			m_service.SavePreview (preview);

			return preview;
		}

		/// <summary>
		/// Deletes the Preview with the specified key.
		/// </summary>
		/// <param name="key">The key of the Preview to be deleted.</param>
	    [SuccessHandlingFilter]
        public void Delete(long key)
		{
			m_service.DeletePreview (key);
		}
    }
}
 
    
namespace jogosdaqui.WebApi.Controllers
{
	/// <summary>
	/// Reviews. 
	/// </summary>
    public class ReviewsController : ApiController
    {
		#region Fields
		private ReviewService m_service;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.WebApi.Controllers.ReviewsController"/> class.
		/// </summary>
		public ReviewsController()
		{
			m_service = new ReviewService ();
		}
		#endregion

		/// <summary>
		/// Get all Reviews
		/// </summary>
        public IEnumerable<Review> Get()
        {
			return m_service.GetAllReviews ();
        }
        
        /// <summary>  
		/// Get Review by key.
		/// </summary>  
		/// <param name="key">The Review's key.</param>
		/// <returns>The Review with the specified key.</returns>
        public Review Get(long key)
        {
			return m_service.GetReviewByKey (key);
        }

		/// <summary>
		/// Creates a new Review.
		/// </summary>
		/// <param name="review">The Review to create.</param>
		/// <returns>The created Review with the key.</returns>
		public Review Post(Review review)
		{
			m_service.SaveReview (review);

			return review;
		}

		/// <summary>
		/// Updates an existing Review.
		/// </summary>
		/// <param name="key">The Review's key.</param>
		/// <param name="review">The Review with updated informations.</param>
		public Review Put(long key, Review review)
		{
	        review.Key = key;
			m_service.SaveReview (review);

			return review;
		}

		/// <summary>
		/// Deletes the Review with the specified key.
		/// </summary>
		/// <param name="key">The key of the Review to be deleted.</param>
	    [SuccessHandlingFilter]
        public void Delete(long key)
		{
			m_service.DeleteReview (key);
		}
    }
}
 
    
namespace jogosdaqui.WebApi.Controllers
{
	/// <summary>
	/// Tags. 
	/// </summary>
    public class TagsController : ApiController
    {
		#region Fields
		private TagService m_service;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.WebApi.Controllers.TagsController"/> class.
		/// </summary>
		public TagsController()
		{
			m_service = new TagService ();
		}
		#endregion

		/// <summary>
		/// Get all Tags
		/// </summary>
        public IEnumerable<Tag> Get()
        {
			return m_service.GetAllTags ();
        }
        
        /// <summary>  
		/// Get Tag by key.
		/// </summary>  
		/// <param name="key">The Tag's key.</param>
		/// <returns>The Tag with the specified key.</returns>
        public Tag Get(long key)
        {
			return m_service.GetTagByKey (key);
        }

		/// <summary>
		/// Creates a new Tag.
		/// </summary>
		/// <param name="tag">The Tag to create.</param>
		/// <returns>The created Tag with the key.</returns>
		public Tag Post(Tag tag)
		{
			m_service.SaveTag (tag);

			return tag;
		}

		/// <summary>
		/// Updates an existing Tag.
		/// </summary>
		/// <param name="key">The Tag's key.</param>
		/// <param name="tag">The Tag with updated informations.</param>
		public Tag Put(long key, Tag tag)
		{
	        tag.Key = key;
			m_service.SaveTag (tag);

			return tag;
		}

		/// <summary>
		/// Deletes the Tag with the specified key.
		/// </summary>
		/// <param name="key">The key of the Tag to be deleted.</param>
	    [SuccessHandlingFilter]
        public void Delete(long key)
		{
			m_service.DeleteTag (key);
		}
    }
}
 
    
namespace jogosdaqui.WebApi.Controllers
{
	/// <summary>
	/// AppliedTags. 
	/// </summary>
    public partial class AppliedTagsController : ApiController
    {
		#region Fields
		private AppliedTagService m_service;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.WebApi.Controllers.AppliedTagsController"/> class.
		/// </summary>
		public AppliedTagsController()
		{
			m_service = new AppliedTagService ();
		}
		#endregion

		/// <summary>
		/// Get all AppliedTags
		/// </summary>
        public IEnumerable<AppliedTag> Get()
        {
			return m_service.GetAllAppliedTags ();
        }
        
        /// <summary>  
		/// Get AppliedTag by key.
		/// </summary>  
		/// <param name="key">The AppliedTag's key.</param>
		/// <returns>The AppliedTag with the specified key.</returns>
        public AppliedTag Get(long key)
        {
			return m_service.GetAppliedTagByKey (key);
        }

		/// <summary>
		/// Creates a new AppliedTag.
		/// </summary>
		/// <param name="appliedtag">The AppliedTag to create.</param>
		/// <returns>The created AppliedTag with the key.</returns>
		public AppliedTag Post(AppliedTag appliedtag)
		{
			m_service.SaveAppliedTag (appliedtag);

			return appliedtag;
		}

		/// <summary>
		/// Updates an existing AppliedTag.
		/// </summary>
		/// <param name="key">The AppliedTag's key.</param>
		/// <param name="appliedtag">The AppliedTag with updated informations.</param>
		public AppliedTag Put(long key, AppliedTag appliedtag)
		{
	        appliedtag.Key = key;
			m_service.SaveAppliedTag (appliedtag);

			return appliedtag;
		}

		/// <summary>
		/// Deletes the AppliedTag with the specified key.
		/// </summary>
		/// <param name="key">The key of the AppliedTag to be deleted.</param>
	    [SuccessHandlingFilter]
        public void Delete(long key)
		{
			m_service.DeleteAppliedTag (key);
		}
    }
}
 
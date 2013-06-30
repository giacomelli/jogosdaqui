 
 
 
 
 
  
  
  
   
   
   
   
  
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
			if(target == null || new GameService().GetGameByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Game with key '{0}' does not exists.".With (m_gameKey);
				return false;
			}

			return true;
		}

		#endregion
	}
	 
		/// <summary>
	/// Game unique name specification.
	/// </summary>
	public class GameUniqueNameSpecification : SpecificationBase<Game>
	{
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Game target)
		{
			var gameService = new GameService ();
			var otherGameWithSameName = gameService.GetGameByName (target.Name);

			if (otherGameWithSameName != null && otherGameWithSameName != target) {
				NotSatisfiedReason = "There is another Game with the name '{0}'. Games should have unique name.".With (target.Name);
				return false;
			} 

			return true;
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
			if(target == null || new PlatformService().GetPlatformByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Platform with key '{0}' does not exists.".With (m_platformKey);
				return false;
			}

			return true;
		}

		#endregion
	}
	 
		/// <summary>
	/// Platform unique name specification.
	/// </summary>
	public class PlatformUniqueNameSpecification : SpecificationBase<Platform>
	{
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Platform target)
		{
			var platformService = new PlatformService ();
			var otherPlatformWithSameName = platformService.GetPlatformByName (target.Name);

			if (otherPlatformWithSameName != null && otherPlatformWithSameName != target) {
				NotSatisfiedReason = "There is another Platform with the name '{0}'. Platforms should have unique name.".With (target.Name);
				return false;
			} 

			return true;
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
			if(target == null || new CompanyService().GetCompanyByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Company with key '{0}' does not exists.".With (m_companyKey);
				return false;
			}

			return true;
		}

		#endregion
	}
	 
		/// <summary>
	/// Company unique name specification.
	/// </summary>
	public class CompanyUniqueNameSpecification : SpecificationBase<Company>
	{
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Company target)
		{
			var companyService = new CompanyService ();
			var otherCompanyWithSameName = companyService.GetCompanyByName (target.Name);

			if (otherCompanyWithSameName != null && otherCompanyWithSameName != target) {
				NotSatisfiedReason = "There is another Company with the name '{0}'. Companies should have unique name.".With (target.Name);
				return false;
			} 

			return true;
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
			if(target == null || new LanguageService().GetLanguageByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Language with key '{0}' does not exists.".With (m_languageKey);
				return false;
			}

			return true;
		}

		#endregion
	}
	 
		/// <summary>
	/// Language unique name specification.
	/// </summary>
	public class LanguageUniqueNameSpecification : SpecificationBase<Language>
	{
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Language target)
		{
			var languageService = new LanguageService ();
			var otherLanguageWithSameName = languageService.GetLanguageByName (target.Name);

			if (otherLanguageWithSameName != null && otherLanguageWithSameName != target) {
				NotSatisfiedReason = "There is another Language with the name '{0}'. Languages should have unique name.".With (target.Name);
				return false;
			} 

			return true;
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
			if(target == null || new PersonService().GetPersonByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Person with key '{0}' does not exists.".With (m_personKey);
				return false;
			}

			return true;
		}

		#endregion
	}
	 
		/// <summary>
	/// Person unique name specification.
	/// </summary>
	public class PersonUniqueNameSpecification : SpecificationBase<Person>
	{
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Person target)
		{
			var personService = new PersonService ();
			var otherPersonWithSameName = personService.GetPersonByName (target.Name);

			if (otherPersonWithSameName != null && otherPersonWithSameName != target) {
				NotSatisfiedReason = "There is another Person with the name '{0}'. Persons should have unique name.".With (target.Name);
				return false;
			} 

			return true;
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
			if(target == null || new CommentService().GetCommentByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Comment with key '{0}' does not exists.".With (m_commentKey);
				return false;
			}

			return true;
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
			if(target == null || new EventService().GetEventByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Event with key '{0}' does not exists.".With (m_eventKey);
				return false;
			}

			return true;
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
			if(target == null || new InterviewService().GetInterviewByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Interview with key '{0}' does not exists.".With (m_interviewKey);
				return false;
			}

			return true;
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
			if(target == null || new NewsService().GetNewsByKey(target.Key) == null)
			{
				NotSatisfiedReason = "News with key '{0}' does not exists.".With (m_newsKey);
				return false;
			}

			return true;
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
			if(target == null || new PreviewService().GetPreviewByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Preview with key '{0}' does not exists.".With (m_previewKey);
				return false;
			}

			return true;
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
			if(target == null || new ReviewService().GetReviewByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Review with key '{0}' does not exists.".With (m_reviewKey);
				return false;
			}

			return true;
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
			if(target == null || new TagService().GetTagByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Tag with key '{0}' does not exists.".With (m_tagKey);
				return false;
			}

			return true;
		}

		#endregion
	}
	 
		/// <summary>
	/// Tag unique name specification.
	/// </summary>
	public class TagUniqueNameSpecification : SpecificationBase<Tag>
	{
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Tag target)
		{
			var tagService = new TagService ();
			var otherTagWithSameName = tagService.GetTagByName (target.Name);

			if (otherTagWithSameName != null && otherTagWithSameName != target) {
				NotSatisfiedReason = "There is another Tag with the name '{0}'. Tags should have unique name.".With (target.Name);
				return false;
			} 

			return true;
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
			if(target == null || new AppliedTagService().GetAppliedTagByKey(target.Key) == null)
			{
				NotSatisfiedReason = "AppliedTag with key '{0}' does not exists.".With (m_appliedtagKey);
				return false;
			}

			return true;
		}

		#endregion
	}
	 
	}


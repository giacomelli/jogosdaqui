 
 
 
 
 
  
  
  
  
   
   
   
   
  
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
				NotSatisfiedReason = "Game can't be null.";
				return false;
			}
			else if(new GameService().GetGameByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Game with key '{0}' does not exists.".With (target.Key);
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
     
namespace jogosdaqui.Domain.Evaluations.Specifications 
{ 
	/// <summary>
	/// Evaluation exists specification. 
	/// </summary>
	public class EvaluationExistsSpecification : SpecificationBase<Evaluation>
	{
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Evaluation target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "Evaluation can't be null.";
				return false;
			}
			else if(new EvaluationService().GetEvaluationByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Evaluation with key '{0}' does not exists.".With (target.Key);
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
				NotSatisfiedReason = "Platform can't be null.";
				return false;
			}
			else if(new PlatformService().GetPlatformByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Platform with key '{0}' does not exists.".With (target.Key);
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
				NotSatisfiedReason = "Company can't be null.";
				return false;
			}
			else if(new CompanyService().GetCompanyByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Company with key '{0}' does not exists.".With (target.Key);
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
				NotSatisfiedReason = "Language can't be null.";
				return false;
			}
			else if(new LanguageService().GetLanguageByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Language with key '{0}' does not exists.".With (target.Key);
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
				NotSatisfiedReason = "Person can't be null.";
				return false;
			}
			else if(new PersonService().GetPersonByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Person with key '{0}' does not exists.".With (target.Key);
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
				NotSatisfiedReason = "Comment can't be null.";
				return false;
			}
			else if(new CommentService().GetCommentByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Comment with key '{0}' does not exists.".With (target.Key);
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
				NotSatisfiedReason = "Event can't be null.";
				return false;
			}
			else if(new EventService().GetEventByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Event with key '{0}' does not exists.".With (target.Key);
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
				NotSatisfiedReason = "Interview can't be null.";
				return false;
			}
			else if(new InterviewService().GetInterviewByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Interview with key '{0}' does not exists.".With (target.Key);
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
				NotSatisfiedReason = "News can't be null.";
				return false;
			}
			else if(new NewsService().GetNewsByKey(target.Key) == null)
			{
				NotSatisfiedReason = "News with key '{0}' does not exists.".With (target.Key);
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
				NotSatisfiedReason = "Preview can't be null.";
				return false;
			}
			else if(new PreviewService().GetPreviewByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Preview with key '{0}' does not exists.".With (target.Key);
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
				NotSatisfiedReason = "Review can't be null.";
				return false;
			}
			else if(new ReviewService().GetReviewByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Review with key '{0}' does not exists.".With (target.Key);
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
				NotSatisfiedReason = "Tag can't be null.";
				return false;
			}
			else if(new TagService().GetTagByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Tag with key '{0}' does not exists.".With (target.Key);
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
				NotSatisfiedReason = "AppliedTag can't be null.";
				return false;
			}
			else if(new AppliedTagService().GetAppliedTagByKey(target.Key) == null)
			{
				NotSatisfiedReason = "AppliedTag with key '{0}' does not exists.".With (target.Key);
				return false;
			}
			
			return true;
		}

		#endregion
	}
	 
	}


 
 
 
 
 
  
  
  
  
   
   
   
   
	
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Games.Specifications;
using jogosdaqui.Domain.Evaluations;
using jogosdaqui.Domain.Evaluations.Specifications;
using jogosdaqui.Domain.Platforms;
using jogosdaqui.Domain.Platforms.Specifications;
using jogosdaqui.Domain.Companies;
using jogosdaqui.Domain.Companies.Specifications;
using jogosdaqui.Domain.Languages;
using jogosdaqui.Domain.Languages.Specifications;
using jogosdaqui.Domain.Persons;
using jogosdaqui.Domain.Persons.Specifications;
using jogosdaqui.Domain.Articles;
using jogosdaqui.Domain.Articles.Specifications;
using jogosdaqui.Domain.Tags;
using jogosdaqui.Domain.Tags.Specifications;
   
  
#region Usings    
using System;
using NUnit.Framework;
using TestSharp; 
using jogosdaqui.Domain.UnitTests; 
using Skahal.Infrastructure.Framework.Repositories; 
using Skahal.Infrastructure.Framework.Commons;
using jogosdaqui.Infrastructure.Repositories.Testing; 
#endregion      
        
     

namespace jogosdaqui.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class GameExistsSpecificationTest
	{

		#region Tests
		[Test] 
		public void IsSatisfiedBy_NullGame_False()
		{
			var target = new GameExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		}
		
		[Test]
		public void IsSatisfiedBy_NonExistsGame_False()
		{
			var target = new GameExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new Game()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsGame_True()
		{
			Stubs.Initialize ();
			Stubs.GameRepository.Add (new Game());
			Stubs.UnitOfWork.Commit ();
			
			var target = new GameExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Game(1)));
		}
		#endregion
	}
		[TestFixture()]
	public partial class GameUniqueNameSpecificationTest
	{

		#region Tests
		[Test]
		public void IsSatisfiedBy_ThereIsAnotherGameWithSameName_False()
		{
			Stubs.Initialize ();
			Stubs.GameRepository.Add (new Game(1) { Name = "Name" });
			Stubs.UnitOfWork.Commit ();
			var target = new GameUniqueNameSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(new Game(2) { Name = "Name" }));
		}
		
		[Test]
		public void IsSatisfiedBy_TheSameGameAlreadySavedWithSameName_True()
		{
			Stubs.Initialize ();
			Stubs.GameRepository.Add (new Game(1) { Name = "Name" });
			Stubs.UnitOfWork.Commit ();
			var target = new GameUniqueNameSpecification(); 
			
			Assert.IsTrue(target.IsSatisfiedBy(new Game(1) { Name = "Name" })); 
		}
		
		[Test]
		public void IsSatisfiedBy_ThereIsNoGameWithSameName_True()
		{
			Stubs.Initialize ();
			Stubs.GameRepository.Add (new Game(1) { Name = "Name 1" });
			Stubs.UnitOfWork.Commit ();
			var target = new GameUniqueNameSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Game(2) { Name = "Name" }));
		}
		#endregion
	}
	}



     

namespace jogosdaqui.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class EvaluationExistsSpecificationTest
	{

		#region Tests
		[Test] 
		public void IsSatisfiedBy_NullEvaluation_False()
		{
			var target = new EvaluationExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		}
		
		[Test]
		public void IsSatisfiedBy_NonExistsEvaluation_False()
		{
			var target = new EvaluationExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new Evaluation()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsEvaluation_True()
		{
			Stubs.Initialize ();
			Stubs.EvaluationRepository.Add (new Evaluation());
			Stubs.UnitOfWork.Commit ();
			
			var target = new EvaluationExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Evaluation(1)));
		}
		#endregion
	}
	}



     

namespace jogosdaqui.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class PlatformExistsSpecificationTest
	{

		#region Tests
		[Test] 
		public void IsSatisfiedBy_NullPlatform_False()
		{
			var target = new PlatformExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		}
		
		[Test]
		public void IsSatisfiedBy_NonExistsPlatform_False()
		{
			var target = new PlatformExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new Platform()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsPlatform_True()
		{
			Stubs.Initialize ();
			Stubs.PlatformRepository.Add (new Platform());
			Stubs.UnitOfWork.Commit ();
			
			var target = new PlatformExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Platform(1)));
		}
		#endregion
	}
		[TestFixture()]
	public partial class PlatformUniqueNameSpecificationTest
	{

		#region Tests
		[Test]
		public void IsSatisfiedBy_ThereIsAnotherPlatformWithSameName_False()
		{
			Stubs.Initialize ();
			Stubs.PlatformRepository.Add (new Platform(1) { Name = "Name" });
			Stubs.UnitOfWork.Commit ();
			var target = new PlatformUniqueNameSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(new Platform(2) { Name = "Name" }));
		}
		
		[Test]
		public void IsSatisfiedBy_TheSamePlatformAlreadySavedWithSameName_True()
		{
			Stubs.Initialize ();
			Stubs.PlatformRepository.Add (new Platform(1) { Name = "Name" });
			Stubs.UnitOfWork.Commit ();
			var target = new PlatformUniqueNameSpecification(); 
			
			Assert.IsTrue(target.IsSatisfiedBy(new Platform(1) { Name = "Name" })); 
		}
		
		[Test]
		public void IsSatisfiedBy_ThereIsNoPlatformWithSameName_True()
		{
			Stubs.Initialize ();
			Stubs.PlatformRepository.Add (new Platform(1) { Name = "Name 1" });
			Stubs.UnitOfWork.Commit ();
			var target = new PlatformUniqueNameSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Platform(2) { Name = "Name" }));
		}
		#endregion
	}
	}



     

namespace jogosdaqui.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class CompanyExistsSpecificationTest
	{

		#region Tests
		[Test] 
		public void IsSatisfiedBy_NullCompany_False()
		{
			var target = new CompanyExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		}
		
		[Test]
		public void IsSatisfiedBy_NonExistsCompany_False()
		{
			var target = new CompanyExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new Company()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsCompany_True()
		{
			Stubs.Initialize ();
			Stubs.CompanyRepository.Add (new Company());
			Stubs.UnitOfWork.Commit ();
			
			var target = new CompanyExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Company(1)));
		}
		#endregion
	}
		[TestFixture()]
	public partial class CompanyUniqueNameSpecificationTest
	{

		#region Tests
		[Test]
		public void IsSatisfiedBy_ThereIsAnotherCompanyWithSameName_False()
		{
			Stubs.Initialize ();
			Stubs.CompanyRepository.Add (new Company(1) { Name = "Name" });
			Stubs.UnitOfWork.Commit ();
			var target = new CompanyUniqueNameSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(new Company(2) { Name = "Name" }));
		}
		
		[Test]
		public void IsSatisfiedBy_TheSameCompanyAlreadySavedWithSameName_True()
		{
			Stubs.Initialize ();
			Stubs.CompanyRepository.Add (new Company(1) { Name = "Name" });
			Stubs.UnitOfWork.Commit ();
			var target = new CompanyUniqueNameSpecification(); 
			
			Assert.IsTrue(target.IsSatisfiedBy(new Company(1) { Name = "Name" })); 
		}
		
		[Test]
		public void IsSatisfiedBy_ThereIsNoCompanyWithSameName_True()
		{
			Stubs.Initialize ();
			Stubs.CompanyRepository.Add (new Company(1) { Name = "Name 1" });
			Stubs.UnitOfWork.Commit ();
			var target = new CompanyUniqueNameSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Company(2) { Name = "Name" }));
		}
		#endregion
	}
	}



     

namespace jogosdaqui.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class LanguageExistsSpecificationTest
	{

		#region Tests
		[Test] 
		public void IsSatisfiedBy_NullLanguage_False()
		{
			var target = new LanguageExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		}
		
		[Test]
		public void IsSatisfiedBy_NonExistsLanguage_False()
		{
			var target = new LanguageExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new Language()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsLanguage_True()
		{
			Stubs.Initialize ();
			Stubs.LanguageRepository.Add (new Language());
			Stubs.UnitOfWork.Commit ();
			
			var target = new LanguageExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Language(1)));
		}
		#endregion
	}
		[TestFixture()]
	public partial class LanguageUniqueNameSpecificationTest
	{

		#region Tests
		[Test]
		public void IsSatisfiedBy_ThereIsAnotherLanguageWithSameName_False()
		{
			Stubs.Initialize ();
			Stubs.LanguageRepository.Add (new Language(1) { Name = "Name" });
			Stubs.UnitOfWork.Commit ();
			var target = new LanguageUniqueNameSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(new Language(2) { Name = "Name" }));
		}
		
		[Test]
		public void IsSatisfiedBy_TheSameLanguageAlreadySavedWithSameName_True()
		{
			Stubs.Initialize ();
			Stubs.LanguageRepository.Add (new Language(1) { Name = "Name" });
			Stubs.UnitOfWork.Commit ();
			var target = new LanguageUniqueNameSpecification(); 
			
			Assert.IsTrue(target.IsSatisfiedBy(new Language(1) { Name = "Name" })); 
		}
		
		[Test]
		public void IsSatisfiedBy_ThereIsNoLanguageWithSameName_True()
		{
			Stubs.Initialize ();
			Stubs.LanguageRepository.Add (new Language(1) { Name = "Name 1" });
			Stubs.UnitOfWork.Commit ();
			var target = new LanguageUniqueNameSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Language(2) { Name = "Name" }));
		}
		#endregion
	}
	}



     

namespace jogosdaqui.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class PersonExistsSpecificationTest
	{

		#region Tests
		[Test] 
		public void IsSatisfiedBy_NullPerson_False()
		{
			var target = new PersonExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		}
		
		[Test]
		public void IsSatisfiedBy_NonExistsPerson_False()
		{
			var target = new PersonExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new Person()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsPerson_True()
		{
			Stubs.Initialize ();
			Stubs.PersonRepository.Add (new Person());
			Stubs.UnitOfWork.Commit ();
			
			var target = new PersonExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Person(1)));
		}
		#endregion
	}
		[TestFixture()]
	public partial class PersonUniqueNameSpecificationTest
	{

		#region Tests
		[Test]
		public void IsSatisfiedBy_ThereIsAnotherPersonWithSameName_False()
		{
			Stubs.Initialize ();
			Stubs.PersonRepository.Add (new Person(1) { Name = "Name" });
			Stubs.UnitOfWork.Commit ();
			var target = new PersonUniqueNameSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(new Person(2) { Name = "Name" }));
		}
		
		[Test]
		public void IsSatisfiedBy_TheSamePersonAlreadySavedWithSameName_True()
		{
			Stubs.Initialize ();
			Stubs.PersonRepository.Add (new Person(1) { Name = "Name" });
			Stubs.UnitOfWork.Commit ();
			var target = new PersonUniqueNameSpecification(); 
			
			Assert.IsTrue(target.IsSatisfiedBy(new Person(1) { Name = "Name" })); 
		}
		
		[Test]
		public void IsSatisfiedBy_ThereIsNoPersonWithSameName_True()
		{
			Stubs.Initialize ();
			Stubs.PersonRepository.Add (new Person(1) { Name = "Name 1" });
			Stubs.UnitOfWork.Commit ();
			var target = new PersonUniqueNameSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Person(2) { Name = "Name" }));
		}
		#endregion
	}
	}



     

namespace jogosdaqui.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class CommentExistsSpecificationTest
	{

		#region Tests
		[Test] 
		public void IsSatisfiedBy_NullComment_False()
		{
			var target = new CommentExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		}
		
		[Test]
		public void IsSatisfiedBy_NonExistsComment_False()
		{
			var target = new CommentExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new Comment()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsComment_True()
		{
			Stubs.Initialize ();
			Stubs.CommentRepository.Add (new Comment());
			Stubs.UnitOfWork.Commit ();
			
			var target = new CommentExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Comment(1)));
		}
		#endregion
	}
	}



     

namespace jogosdaqui.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class EventExistsSpecificationTest
	{

		#region Tests
		[Test] 
		public void IsSatisfiedBy_NullEvent_False()
		{
			var target = new EventExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		}
		
		[Test]
		public void IsSatisfiedBy_NonExistsEvent_False()
		{
			var target = new EventExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new Event()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsEvent_True()
		{
			Stubs.Initialize ();
			Stubs.EventRepository.Add (new Event());
			Stubs.UnitOfWork.Commit ();
			
			var target = new EventExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Event(1)));
		}
		#endregion
	}
	}



     

namespace jogosdaqui.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class InterviewExistsSpecificationTest
	{

		#region Tests
		[Test] 
		public void IsSatisfiedBy_NullInterview_False()
		{
			var target = new InterviewExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		}
		
		[Test]
		public void IsSatisfiedBy_NonExistsInterview_False()
		{
			var target = new InterviewExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new Interview()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsInterview_True()
		{
			Stubs.Initialize ();
			Stubs.InterviewRepository.Add (new Interview());
			Stubs.UnitOfWork.Commit ();
			
			var target = new InterviewExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Interview(1)));
		}
		#endregion
	}
	}



     

namespace jogosdaqui.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class NewsExistsSpecificationTest
	{

		#region Tests
		[Test] 
		public void IsSatisfiedBy_NullNews_False()
		{
			var target = new NewsExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		}
		
		[Test]
		public void IsSatisfiedBy_NonExistsNews_False()
		{
			var target = new NewsExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new News()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsNews_True()
		{
			Stubs.Initialize ();
			Stubs.NewsRepository.Add (new News());
			Stubs.UnitOfWork.Commit ();
			
			var target = new NewsExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new News(1)));
		}
		#endregion
	}
	}



     

namespace jogosdaqui.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class PreviewExistsSpecificationTest
	{

		#region Tests
		[Test] 
		public void IsSatisfiedBy_NullPreview_False()
		{
			var target = new PreviewExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		}
		
		[Test]
		public void IsSatisfiedBy_NonExistsPreview_False()
		{
			var target = new PreviewExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new Preview()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsPreview_True()
		{
			Stubs.Initialize ();
			Stubs.PreviewRepository.Add (new Preview());
			Stubs.UnitOfWork.Commit ();
			
			var target = new PreviewExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Preview(1)));
		}
		#endregion
	}
	}



     

namespace jogosdaqui.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class ReviewExistsSpecificationTest
	{

		#region Tests
		[Test] 
		public void IsSatisfiedBy_NullReview_False()
		{
			var target = new ReviewExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		}
		
		[Test]
		public void IsSatisfiedBy_NonExistsReview_False()
		{
			var target = new ReviewExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new Review()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsReview_True()
		{
			Stubs.Initialize ();
			Stubs.ReviewRepository.Add (new Review());
			Stubs.UnitOfWork.Commit ();
			
			var target = new ReviewExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Review(1)));
		}
		#endregion
	}
	}



     

namespace jogosdaqui.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class TagExistsSpecificationTest
	{

		#region Tests
		[Test] 
		public void IsSatisfiedBy_NullTag_False()
		{
			var target = new TagExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		}
		
		[Test]
		public void IsSatisfiedBy_NonExistsTag_False()
		{
			var target = new TagExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new Tag()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsTag_True()
		{
			Stubs.Initialize ();
			Stubs.TagRepository.Add (new Tag());
			Stubs.UnitOfWork.Commit ();
			
			var target = new TagExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Tag(1)));
		}
		#endregion
	}
		[TestFixture()]
	public partial class TagUniqueNameSpecificationTest
	{

		#region Tests
		[Test]
		public void IsSatisfiedBy_ThereIsAnotherTagWithSameName_False()
		{
			Stubs.Initialize ();
			Stubs.TagRepository.Add (new Tag(1) { Name = "Name" });
			Stubs.UnitOfWork.Commit ();
			var target = new TagUniqueNameSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(new Tag(2) { Name = "Name" }));
		}
		
		[Test]
		public void IsSatisfiedBy_TheSameTagAlreadySavedWithSameName_True()
		{
			Stubs.Initialize ();
			Stubs.TagRepository.Add (new Tag(1) { Name = "Name" });
			Stubs.UnitOfWork.Commit ();
			var target = new TagUniqueNameSpecification(); 
			
			Assert.IsTrue(target.IsSatisfiedBy(new Tag(1) { Name = "Name" })); 
		}
		
		[Test]
		public void IsSatisfiedBy_ThereIsNoTagWithSameName_True()
		{
			Stubs.Initialize ();
			Stubs.TagRepository.Add (new Tag(1) { Name = "Name 1" });
			Stubs.UnitOfWork.Commit ();
			var target = new TagUniqueNameSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Tag(2) { Name = "Name" }));
		}
		#endregion
	}
	}



     

namespace jogosdaqui.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class AppliedTagExistsSpecificationTest
	{

		#region Tests
		[Test] 
		public void IsSatisfiedBy_NullAppliedTag_False()
		{
			var target = new AppliedTagExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		}
		
		[Test]
		public void IsSatisfiedBy_NonExistsAppliedTag_False()
		{
			var target = new AppliedTagExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new AppliedTag()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsAppliedTag_True()
		{
			Stubs.Initialize ();
			Stubs.AppliedTagRepository.Add (new AppliedTag());
			Stubs.UnitOfWork.Commit ();
			
			var target = new AppliedTagExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new AppliedTag(1)));
		}
		#endregion
	}
	}



	

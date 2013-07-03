 
 
 
 
 
  
  
  
  
   
   
   
   
	
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
	public static class Stubs
	{
		#region Properties
		public static IUnitOfWork<long> UnitOfWork { get; set; }
 
 
		public static IGameRepository GameRepository { get; set; } 
 
		public static IEvaluationRepository EvaluationRepository { get; set; } 
 
		public static IPlatformRepository PlatformRepository { get; set; } 
 
		public static ICompanyRepository CompanyRepository { get; set; } 
 
		public static ILanguageRepository LanguageRepository { get; set; } 
 
		public static IPersonRepository PersonRepository { get; set; } 
 
		public static ICommentRepository CommentRepository { get; set; } 
 
		public static IEventRepository EventRepository { get; set; } 
 
		public static IInterviewRepository InterviewRepository { get; set; } 
 
		public static INewsRepository NewsRepository { get; set; } 
 
		public static IPreviewRepository PreviewRepository { get; set; } 
 
		public static IReviewRepository ReviewRepository { get; set; } 
 
		public static ITagRepository TagRepository { get; set; } 
 
		public static IAppliedTagRepository AppliedTagRepository { get; set; } 
		 
		#endregion 

		#region Methods
		public static void Initialize ()
		{
			DependencyService.Register<IUnitOfWork<long>> (UnitOfWork = new MemoryUnitOfWork<long>());
 
			DependencyService.Register<IGameRepository> (GameRepository = new TestingGameRepository());
			GameRepository.SetUnitOfWork (UnitOfWork);
 
			DependencyService.Register<IEvaluationRepository> (EvaluationRepository = new TestingEvaluationRepository());
			EvaluationRepository.SetUnitOfWork (UnitOfWork);
 
			DependencyService.Register<IPlatformRepository> (PlatformRepository = new TestingPlatformRepository());
			PlatformRepository.SetUnitOfWork (UnitOfWork);
 
			DependencyService.Register<ICompanyRepository> (CompanyRepository = new TestingCompanyRepository());
			CompanyRepository.SetUnitOfWork (UnitOfWork);
 
			DependencyService.Register<ILanguageRepository> (LanguageRepository = new TestingLanguageRepository());
			LanguageRepository.SetUnitOfWork (UnitOfWork);
 
			DependencyService.Register<IPersonRepository> (PersonRepository = new TestingPersonRepository());
			PersonRepository.SetUnitOfWork (UnitOfWork);
 
			DependencyService.Register<ICommentRepository> (CommentRepository = new TestingCommentRepository());
			CommentRepository.SetUnitOfWork (UnitOfWork);
 
			DependencyService.Register<IEventRepository> (EventRepository = new TestingEventRepository());
			EventRepository.SetUnitOfWork (UnitOfWork);
 
			DependencyService.Register<IInterviewRepository> (InterviewRepository = new TestingInterviewRepository());
			InterviewRepository.SetUnitOfWork (UnitOfWork);
 
			DependencyService.Register<INewsRepository> (NewsRepository = new TestingNewsRepository());
			NewsRepository.SetUnitOfWork (UnitOfWork);
 
			DependencyService.Register<IPreviewRepository> (PreviewRepository = new TestingPreviewRepository());
			PreviewRepository.SetUnitOfWork (UnitOfWork);
 
			DependencyService.Register<IReviewRepository> (ReviewRepository = new TestingReviewRepository());
			ReviewRepository.SetUnitOfWork (UnitOfWork);
 
			DependencyService.Register<ITagRepository> (TagRepository = new TestingTagRepository());
			TagRepository.SetUnitOfWork (UnitOfWork);
 
			DependencyService.Register<IAppliedTagRepository> (AppliedTagRepository = new TestingAppliedTagRepository());
			AppliedTagRepository.SetUnitOfWork (UnitOfWork);
	
		}
		#endregion
	}
}

         
     


namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class GameServiceTest
	{
		#region Fields
		private GameService m_target; 
		#endregion
 
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.GameRepository.Add (new Game());
			Stubs.GameRepository.Add (new Game());
			Stubs.GameRepository.Add (new Game());
			Stubs.GameRepository.Add (new Game());
			Stubs.UnitOfWork.Commit ();

			m_target = new GameService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllGames_NoArguments_AllGamesCounted()
		{
			var actual = m_target.CountAllGames ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeleteGame_GameNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("Game with key '0' does not exists."), () => {
				m_target.DeleteGame(0);
			});
		}
   
		[Test]
		public void DeleteGame_GameExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllGames ());

			m_target.DeleteGame(1);
			Assert.AreEqual (3, m_target.CountAllGames ());

			m_target.DeleteGame(2);
			Assert.AreEqual (2, m_target.CountAllGames ());

			m_target.DeleteGame(3);
			Assert.AreEqual (1, m_target.CountAllGames ());

			m_target.DeleteGame(4);
			Assert.AreEqual (0, m_target.CountAllGames ());
		}

		[Test]
		public void GetAllGames_NoArgs_AllGames ()
		{
			var actual = m_target.GetAllGames();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetGameByKey_KeyGameDoesNotExists_Null ()
		{
			var actual = m_target.GetGameByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetGameByKey_KeyGameExists_Game ()
		{
			var actual = m_target.GetGameByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetGameByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SaveGame_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("game"), () => {
				m_target.SaveGame (null);
			});
		}
 

 
		#endregion
	}
}



     


namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class EvaluationServiceTest
	{
		#region Fields
		private EvaluationService m_target; 
		#endregion
 
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.EvaluationRepository.Add (new Evaluation());
			Stubs.EvaluationRepository.Add (new Evaluation());
			Stubs.EvaluationRepository.Add (new Evaluation());
			Stubs.EvaluationRepository.Add (new Evaluation());
			Stubs.UnitOfWork.Commit ();

			m_target = new EvaluationService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllEvaluations_NoArguments_AllEvaluationsCounted()
		{
			var actual = m_target.CountAllEvaluations ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeleteEvaluation_EvaluationNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("Evaluation with key '0' does not exists."), () => {
				m_target.DeleteEvaluation(0);
			});
		}
   
		[Test]
		public void DeleteEvaluation_EvaluationExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllEvaluations ());

			m_target.DeleteEvaluation(1);
			Assert.AreEqual (3, m_target.CountAllEvaluations ());

			m_target.DeleteEvaluation(2);
			Assert.AreEqual (2, m_target.CountAllEvaluations ());

			m_target.DeleteEvaluation(3);
			Assert.AreEqual (1, m_target.CountAllEvaluations ());

			m_target.DeleteEvaluation(4);
			Assert.AreEqual (0, m_target.CountAllEvaluations ());
		}

		[Test]
		public void GetAllEvaluations_NoArgs_AllEvaluations ()
		{
			var actual = m_target.GetAllEvaluations();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetEvaluationByKey_KeyEvaluationDoesNotExists_Null ()
		{
			var actual = m_target.GetEvaluationByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetEvaluationByKey_KeyEvaluationExists_Evaluation ()
		{
			var actual = m_target.GetEvaluationByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetEvaluationByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SaveEvaluation_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("evaluation"), () => {
				m_target.SaveEvaluation (null);
			});
		}
 
		#endregion
	}
}



     


namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class PlatformServiceTest
	{
		#region Fields
		private PlatformService m_target; 
		#endregion
 
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.PlatformRepository.Add (new Platform());
			Stubs.PlatformRepository.Add (new Platform());
			Stubs.PlatformRepository.Add (new Platform());
			Stubs.PlatformRepository.Add (new Platform());
			Stubs.UnitOfWork.Commit ();

			m_target = new PlatformService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllPlatforms_NoArguments_AllPlatformsCounted()
		{
			var actual = m_target.CountAllPlatforms ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeletePlatform_PlatformNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("Platform with key '0' does not exists."), () => {
				m_target.DeletePlatform(0);
			});
		}
   
		[Test]
		public void DeletePlatform_PlatformExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllPlatforms ());

			m_target.DeletePlatform(1);
			Assert.AreEqual (3, m_target.CountAllPlatforms ());

			m_target.DeletePlatform(2);
			Assert.AreEqual (2, m_target.CountAllPlatforms ());

			m_target.DeletePlatform(3);
			Assert.AreEqual (1, m_target.CountAllPlatforms ());

			m_target.DeletePlatform(4);
			Assert.AreEqual (0, m_target.CountAllPlatforms ());
		}

		[Test]
		public void GetAllPlatforms_NoArgs_AllPlatforms ()
		{
			var actual = m_target.GetAllPlatforms();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetPlatformByKey_KeyPlatformDoesNotExists_Null ()
		{
			var actual = m_target.GetPlatformByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetPlatformByKey_KeyPlatformExists_Platform ()
		{
			var actual = m_target.GetPlatformByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetPlatformByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SavePlatform_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("platform"), () => {
				m_target.SavePlatform (null);
			});
		}
 
		[Test]  
		public void SavePlatform_PlatformDoesNotExists_Created()
		{
			var platform = new Platform ();
 
			m_target.SavePlatform (platform);

			Assert.AreEqual(5, m_target.CountAllPlatforms());
			Assert.AreEqual (5, m_target.GetPlatformByKey (platform.Key).Key);
		}
 
		[Test]
		public void SavePlatform_PlatformDoesExists_Updated()
		{
			var platform = new Platform () { 
				Key = 1 
			};

			m_target.SavePlatform (platform);

			Assert.AreEqual(4, m_target.CountAllPlatforms());
			Assert.AreEqual (1, m_target.GetPlatformByKey (platform.Key).Key);
		}
 
		#endregion
	}
}



     


namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class CompanyServiceTest
	{
		#region Fields
		private CompanyService m_target; 
		#endregion
 
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.CompanyRepository.Add (new Company());
			Stubs.CompanyRepository.Add (new Company());
			Stubs.CompanyRepository.Add (new Company());
			Stubs.CompanyRepository.Add (new Company());
			Stubs.UnitOfWork.Commit ();

			m_target = new CompanyService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllCompanies_NoArguments_AllCompaniesCounted()
		{
			var actual = m_target.CountAllCompanies ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeleteCompany_CompanyNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("Company with key '0' does not exists."), () => {
				m_target.DeleteCompany(0);
			});
		}
   
		[Test]
		public void DeleteCompany_CompanyExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllCompanies ());

			m_target.DeleteCompany(1);
			Assert.AreEqual (3, m_target.CountAllCompanies ());

			m_target.DeleteCompany(2);
			Assert.AreEqual (2, m_target.CountAllCompanies ());

			m_target.DeleteCompany(3);
			Assert.AreEqual (1, m_target.CountAllCompanies ());

			m_target.DeleteCompany(4);
			Assert.AreEqual (0, m_target.CountAllCompanies ());
		}

		[Test]
		public void GetAllCompanies_NoArgs_AllCompanies ()
		{
			var actual = m_target.GetAllCompanies();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetCompanyByKey_KeyCompanyDoesNotExists_Null ()
		{
			var actual = m_target.GetCompanyByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetCompanyByKey_KeyCompanyExists_Company ()
		{
			var actual = m_target.GetCompanyByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetCompanyByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SaveCompany_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("company"), () => {
				m_target.SaveCompany (null);
			});
		}
 
		[Test]
		public void SaveCompany_CompanyDoesExists_Updated()
		{
			var company = new Company () { 
				Key = 1 
			};

			m_target.SaveCompany (company);

			Assert.AreEqual(4, m_target.CountAllCompanies());
			Assert.AreEqual (1, m_target.GetCompanyByKey (company.Key).Key);
		}
 
		#endregion
	}
}



     


namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class LanguageServiceTest
	{
		#region Fields
		private LanguageService m_target; 
		#endregion
 
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.LanguageRepository.Add (new Language());
			Stubs.LanguageRepository.Add (new Language());
			Stubs.LanguageRepository.Add (new Language());
			Stubs.LanguageRepository.Add (new Language());
			Stubs.UnitOfWork.Commit ();

			m_target = new LanguageService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllLanguages_NoArguments_AllLanguagesCounted()
		{
			var actual = m_target.CountAllLanguages ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeleteLanguage_LanguageNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("Language with key '0' does not exists."), () => {
				m_target.DeleteLanguage(0);
			});
		}
   
		[Test]
		public void DeleteLanguage_LanguageExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllLanguages ());

			m_target.DeleteLanguage(1);
			Assert.AreEqual (3, m_target.CountAllLanguages ());

			m_target.DeleteLanguage(2);
			Assert.AreEqual (2, m_target.CountAllLanguages ());

			m_target.DeleteLanguage(3);
			Assert.AreEqual (1, m_target.CountAllLanguages ());

			m_target.DeleteLanguage(4);
			Assert.AreEqual (0, m_target.CountAllLanguages ());
		}

		[Test]
		public void GetAllLanguages_NoArgs_AllLanguages ()
		{
			var actual = m_target.GetAllLanguages();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetLanguageByKey_KeyLanguageDoesNotExists_Null ()
		{
			var actual = m_target.GetLanguageByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetLanguageByKey_KeyLanguageExists_Language ()
		{
			var actual = m_target.GetLanguageByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetLanguageByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SaveLanguage_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("language"), () => {
				m_target.SaveLanguage (null);
			});
		}
 
		[Test]  
		public void SaveLanguage_LanguageDoesNotExists_Created()
		{
			var language = new Language ();
 
			m_target.SaveLanguage (language);

			Assert.AreEqual(5, m_target.CountAllLanguages());
			Assert.AreEqual (5, m_target.GetLanguageByKey (language.Key).Key);
		}
 
		[Test]
		public void SaveLanguage_LanguageDoesExists_Updated()
		{
			var language = new Language () { 
				Key = 1 
			};

			m_target.SaveLanguage (language);

			Assert.AreEqual(4, m_target.CountAllLanguages());
			Assert.AreEqual (1, m_target.GetLanguageByKey (language.Key).Key);
		}
 
		#endregion
	}
}



     


namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class PersonServiceTest
	{
		#region Fields
		private PersonService m_target; 
		#endregion
 
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.PersonRepository.Add (new Person());
			Stubs.PersonRepository.Add (new Person());
			Stubs.PersonRepository.Add (new Person());
			Stubs.PersonRepository.Add (new Person());
			Stubs.UnitOfWork.Commit ();

			m_target = new PersonService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllPersons_NoArguments_AllPersonsCounted()
		{
			var actual = m_target.CountAllPersons ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeletePerson_PersonNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("Person with key '0' does not exists."), () => {
				m_target.DeletePerson(0);
			});
		}
   
		[Test]
		public void DeletePerson_PersonExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllPersons ());

			m_target.DeletePerson(1);
			Assert.AreEqual (3, m_target.CountAllPersons ());

			m_target.DeletePerson(2);
			Assert.AreEqual (2, m_target.CountAllPersons ());

			m_target.DeletePerson(3);
			Assert.AreEqual (1, m_target.CountAllPersons ());

			m_target.DeletePerson(4);
			Assert.AreEqual (0, m_target.CountAllPersons ());
		}

		[Test]
		public void GetAllPersons_NoArgs_AllPersons ()
		{
			var actual = m_target.GetAllPersons();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetPersonByKey_KeyPersonDoesNotExists_Null ()
		{
			var actual = m_target.GetPersonByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetPersonByKey_KeyPersonExists_Person ()
		{
			var actual = m_target.GetPersonByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetPersonByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SavePerson_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("person"), () => {
				m_target.SavePerson (null);
			});
		}
 
		[Test]  
		public void SavePerson_PersonDoesNotExists_Created()
		{
			var person = new Person ();
 
			m_target.SavePerson (person);

			Assert.AreEqual(5, m_target.CountAllPersons());
			Assert.AreEqual (5, m_target.GetPersonByKey (person.Key).Key);
		}
 
		[Test]
		public void SavePerson_PersonDoesExists_Updated()
		{
			var person = new Person () { 
				Key = 1 
			};

			m_target.SavePerson (person);

			Assert.AreEqual(4, m_target.CountAllPersons());
			Assert.AreEqual (1, m_target.GetPersonByKey (person.Key).Key);
		}
 
		#endregion
	}
}



     


namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class CommentServiceTest
	{
		#region Fields
		private CommentService m_target; 
		#endregion
 
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.CommentRepository.Add (new Comment());
			Stubs.CommentRepository.Add (new Comment());
			Stubs.CommentRepository.Add (new Comment());
			Stubs.CommentRepository.Add (new Comment());
			Stubs.UnitOfWork.Commit ();

			m_target = new CommentService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllComments_NoArguments_AllCommentsCounted()
		{
			var actual = m_target.CountAllComments ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeleteComment_CommentNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("Comment with key '0' does not exists."), () => {
				m_target.DeleteComment(0);
			});
		}
   
		[Test]
		public void DeleteComment_CommentExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllComments ());

			m_target.DeleteComment(1);
			Assert.AreEqual (3, m_target.CountAllComments ());

			m_target.DeleteComment(2);
			Assert.AreEqual (2, m_target.CountAllComments ());

			m_target.DeleteComment(3);
			Assert.AreEqual (1, m_target.CountAllComments ());

			m_target.DeleteComment(4);
			Assert.AreEqual (0, m_target.CountAllComments ());
		}

		[Test]
		public void GetAllComments_NoArgs_AllComments ()
		{
			var actual = m_target.GetAllComments();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetCommentByKey_KeyCommentDoesNotExists_Null ()
		{
			var actual = m_target.GetCommentByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetCommentByKey_KeyCommentExists_Comment ()
		{
			var actual = m_target.GetCommentByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetCommentByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SaveComment_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("comment"), () => {
				m_target.SaveComment (null);
			});
		}
 
		[Test]  
		public void SaveComment_CommentDoesNotExists_Created()
		{
			var comment = new Comment ();
 
			m_target.SaveComment (comment);

			Assert.AreEqual(5, m_target.CountAllComments());
			Assert.AreEqual (5, m_target.GetCommentByKey (comment.Key).Key);
		}
 
		[Test]
		public void SaveComment_CommentDoesExists_Updated()
		{
			var comment = new Comment () { 
				Key = 1 
			};

			m_target.SaveComment (comment);

			Assert.AreEqual(4, m_target.CountAllComments());
			Assert.AreEqual (1, m_target.GetCommentByKey (comment.Key).Key);
		}
 
		#endregion
	}
}



     


namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class EventServiceTest
	{
		#region Fields
		private EventService m_target; 
		#endregion
 
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.EventRepository.Add (new Event());
			Stubs.EventRepository.Add (new Event());
			Stubs.EventRepository.Add (new Event());
			Stubs.EventRepository.Add (new Event());
			Stubs.UnitOfWork.Commit ();

			m_target = new EventService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllEvents_NoArguments_AllEventsCounted()
		{
			var actual = m_target.CountAllEvents ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeleteEvent_EventNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("Event with key '0' does not exists."), () => {
				m_target.DeleteEvent(0);
			});
		}
   
		[Test]
		public void DeleteEvent_EventExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllEvents ());

			m_target.DeleteEvent(1);
			Assert.AreEqual (3, m_target.CountAllEvents ());

			m_target.DeleteEvent(2);
			Assert.AreEqual (2, m_target.CountAllEvents ());

			m_target.DeleteEvent(3);
			Assert.AreEqual (1, m_target.CountAllEvents ());

			m_target.DeleteEvent(4);
			Assert.AreEqual (0, m_target.CountAllEvents ());
		}

		[Test]
		public void GetAllEvents_NoArgs_AllEvents ()
		{
			var actual = m_target.GetAllEvents();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetEventByKey_KeyEventDoesNotExists_Null ()
		{
			var actual = m_target.GetEventByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetEventByKey_KeyEventExists_Event ()
		{
			var actual = m_target.GetEventByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetEventByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SaveEvent_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("event"), () => {
				m_target.SaveEvent (null);
			});
		}
 
		[Test]  
		public void SaveEvent_EventDoesNotExists_Created()
		{
			var @event = new Event ();
 
			m_target.SaveEvent (@event);

			Assert.AreEqual(5, m_target.CountAllEvents());
			Assert.AreEqual (5, m_target.GetEventByKey (@event.Key).Key);
		}
 
		[Test]
		public void SaveEvent_EventDoesExists_Updated()
		{
			var @event = new Event () { 
				Key = 1 
			};

			m_target.SaveEvent (@event);

			Assert.AreEqual(4, m_target.CountAllEvents());
			Assert.AreEqual (1, m_target.GetEventByKey (@event.Key).Key);
		}
 
		#endregion
	}
}



     


namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class InterviewServiceTest
	{
		#region Fields
		private InterviewService m_target; 
		#endregion
 
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.InterviewRepository.Add (new Interview());
			Stubs.InterviewRepository.Add (new Interview());
			Stubs.InterviewRepository.Add (new Interview());
			Stubs.InterviewRepository.Add (new Interview());
			Stubs.UnitOfWork.Commit ();

			m_target = new InterviewService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllInterviews_NoArguments_AllInterviewsCounted()
		{
			var actual = m_target.CountAllInterviews ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeleteInterview_InterviewNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("Interview with key '0' does not exists."), () => {
				m_target.DeleteInterview(0);
			});
		}
   
		[Test]
		public void DeleteInterview_InterviewExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllInterviews ());

			m_target.DeleteInterview(1);
			Assert.AreEqual (3, m_target.CountAllInterviews ());

			m_target.DeleteInterview(2);
			Assert.AreEqual (2, m_target.CountAllInterviews ());

			m_target.DeleteInterview(3);
			Assert.AreEqual (1, m_target.CountAllInterviews ());

			m_target.DeleteInterview(4);
			Assert.AreEqual (0, m_target.CountAllInterviews ());
		}

		[Test]
		public void GetAllInterviews_NoArgs_AllInterviews ()
		{
			var actual = m_target.GetAllInterviews();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetInterviewByKey_KeyInterviewDoesNotExists_Null ()
		{
			var actual = m_target.GetInterviewByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetInterviewByKey_KeyInterviewExists_Interview ()
		{
			var actual = m_target.GetInterviewByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetInterviewByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SaveInterview_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("interview"), () => {
				m_target.SaveInterview (null);
			});
		}
 
		[Test]  
		public void SaveInterview_InterviewDoesNotExists_Created()
		{
			var interview = new Interview ();
 
			m_target.SaveInterview (interview);

			Assert.AreEqual(5, m_target.CountAllInterviews());
			Assert.AreEqual (5, m_target.GetInterviewByKey (interview.Key).Key);
		}
 
		[Test]
		public void SaveInterview_InterviewDoesExists_Updated()
		{
			var interview = new Interview () { 
				Key = 1 
			};

			m_target.SaveInterview (interview);

			Assert.AreEqual(4, m_target.CountAllInterviews());
			Assert.AreEqual (1, m_target.GetInterviewByKey (interview.Key).Key);
		}
 
		#endregion
	}
}



     


namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class NewsServiceTest
	{
		#region Fields
		private NewsService m_target; 
		#endregion
 
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.NewsRepository.Add (new News());
			Stubs.NewsRepository.Add (new News());
			Stubs.NewsRepository.Add (new News());
			Stubs.NewsRepository.Add (new News());
			Stubs.UnitOfWork.Commit ();

			m_target = new NewsService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllNews_NoArguments_AllNewsCounted()
		{
			var actual = m_target.CountAllNews ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeleteNews_NewsNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("News with key '0' does not exists."), () => {
				m_target.DeleteNews(0);
			});
		}
   
		[Test]
		public void DeleteNews_NewsExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllNews ());

			m_target.DeleteNews(1);
			Assert.AreEqual (3, m_target.CountAllNews ());

			m_target.DeleteNews(2);
			Assert.AreEqual (2, m_target.CountAllNews ());

			m_target.DeleteNews(3);
			Assert.AreEqual (1, m_target.CountAllNews ());

			m_target.DeleteNews(4);
			Assert.AreEqual (0, m_target.CountAllNews ());
		}

		[Test]
		public void GetAllNews_NoArgs_AllNews ()
		{
			var actual = m_target.GetAllNews();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetNewsByKey_KeyNewsDoesNotExists_Null ()
		{
			var actual = m_target.GetNewsByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetNewsByKey_KeyNewsExists_News ()
		{
			var actual = m_target.GetNewsByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetNewsByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SaveNews_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("news"), () => {
				m_target.SaveNews (null);
			});
		}
 
		[Test]  
		public void SaveNews_NewsDoesNotExists_Created()
		{
			var news = new News ();
 
			m_target.SaveNews (news);

			Assert.AreEqual(5, m_target.CountAllNews());
			Assert.AreEqual (5, m_target.GetNewsByKey (news.Key).Key);
		}
 
		[Test]
		public void SaveNews_NewsDoesExists_Updated()
		{
			var news = new News () { 
				Key = 1 
			};

			m_target.SaveNews (news);

			Assert.AreEqual(4, m_target.CountAllNews());
			Assert.AreEqual (1, m_target.GetNewsByKey (news.Key).Key);
		}
 
		#endregion
	}
}



     


namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class PreviewServiceTest
	{
		#region Fields
		private PreviewService m_target; 
		#endregion
 
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.PreviewRepository.Add (new Preview());
			Stubs.PreviewRepository.Add (new Preview());
			Stubs.PreviewRepository.Add (new Preview());
			Stubs.PreviewRepository.Add (new Preview());
			Stubs.UnitOfWork.Commit ();

			m_target = new PreviewService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllPreviews_NoArguments_AllPreviewsCounted()
		{
			var actual = m_target.CountAllPreviews ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeletePreview_PreviewNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("Preview with key '0' does not exists."), () => {
				m_target.DeletePreview(0);
			});
		}
   
		[Test]
		public void DeletePreview_PreviewExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllPreviews ());

			m_target.DeletePreview(1);
			Assert.AreEqual (3, m_target.CountAllPreviews ());

			m_target.DeletePreview(2);
			Assert.AreEqual (2, m_target.CountAllPreviews ());

			m_target.DeletePreview(3);
			Assert.AreEqual (1, m_target.CountAllPreviews ());

			m_target.DeletePreview(4);
			Assert.AreEqual (0, m_target.CountAllPreviews ());
		}

		[Test]
		public void GetAllPreviews_NoArgs_AllPreviews ()
		{
			var actual = m_target.GetAllPreviews();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetPreviewByKey_KeyPreviewDoesNotExists_Null ()
		{
			var actual = m_target.GetPreviewByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetPreviewByKey_KeyPreviewExists_Preview ()
		{
			var actual = m_target.GetPreviewByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetPreviewByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SavePreview_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("preview"), () => {
				m_target.SavePreview (null);
			});
		}
 
		[Test]  
		public void SavePreview_PreviewDoesNotExists_Created()
		{
			var preview = new Preview ();
 
			m_target.SavePreview (preview);

			Assert.AreEqual(5, m_target.CountAllPreviews());
			Assert.AreEqual (5, m_target.GetPreviewByKey (preview.Key).Key);
		}
 
		[Test]
		public void SavePreview_PreviewDoesExists_Updated()
		{
			var preview = new Preview () { 
				Key = 1 
			};

			m_target.SavePreview (preview);

			Assert.AreEqual(4, m_target.CountAllPreviews());
			Assert.AreEqual (1, m_target.GetPreviewByKey (preview.Key).Key);
		}
 
		#endregion
	}
}



     


namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class ReviewServiceTest
	{
		#region Fields
		private ReviewService m_target; 
		#endregion
 
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.ReviewRepository.Add (new Review());
			Stubs.ReviewRepository.Add (new Review());
			Stubs.ReviewRepository.Add (new Review());
			Stubs.ReviewRepository.Add (new Review());
			Stubs.UnitOfWork.Commit ();

			m_target = new ReviewService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllReviews_NoArguments_AllReviewsCounted()
		{
			var actual = m_target.CountAllReviews ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeleteReview_ReviewNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("Review with key '0' does not exists."), () => {
				m_target.DeleteReview(0);
			});
		}
   
		[Test]
		public void DeleteReview_ReviewExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllReviews ());

			m_target.DeleteReview(1);
			Assert.AreEqual (3, m_target.CountAllReviews ());

			m_target.DeleteReview(2);
			Assert.AreEqual (2, m_target.CountAllReviews ());

			m_target.DeleteReview(3);
			Assert.AreEqual (1, m_target.CountAllReviews ());

			m_target.DeleteReview(4);
			Assert.AreEqual (0, m_target.CountAllReviews ());
		}

		[Test]
		public void GetAllReviews_NoArgs_AllReviews ()
		{
			var actual = m_target.GetAllReviews();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetReviewByKey_KeyReviewDoesNotExists_Null ()
		{
			var actual = m_target.GetReviewByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetReviewByKey_KeyReviewExists_Review ()
		{
			var actual = m_target.GetReviewByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetReviewByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SaveReview_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("review"), () => {
				m_target.SaveReview (null);
			});
		}
 
		[Test]  
		public void SaveReview_ReviewDoesNotExists_Created()
		{
			var review = new Review ();
 
			m_target.SaveReview (review);

			Assert.AreEqual(5, m_target.CountAllReviews());
			Assert.AreEqual (5, m_target.GetReviewByKey (review.Key).Key);
		}
 
		[Test]
		public void SaveReview_ReviewDoesExists_Updated()
		{
			var review = new Review () { 
				Key = 1 
			};

			m_target.SaveReview (review);

			Assert.AreEqual(4, m_target.CountAllReviews());
			Assert.AreEqual (1, m_target.GetReviewByKey (review.Key).Key);
		}
 
		#endregion
	}
}



     


namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class TagServiceTest
	{
		#region Fields
		private TagService m_target; 
		#endregion
 
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.TagRepository.Add (new Tag());
			Stubs.TagRepository.Add (new Tag());
			Stubs.TagRepository.Add (new Tag());
			Stubs.TagRepository.Add (new Tag());
			Stubs.UnitOfWork.Commit ();

			m_target = new TagService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllTags_NoArguments_AllTagsCounted()
		{
			var actual = m_target.CountAllTags ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeleteTag_TagNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("Tag with key '0' does not exists."), () => {
				m_target.DeleteTag(0);
			});
		}
   
		[Test]
		public void DeleteTag_TagExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllTags ());

			m_target.DeleteTag(1);
			Assert.AreEqual (3, m_target.CountAllTags ());

			m_target.DeleteTag(2);
			Assert.AreEqual (2, m_target.CountAllTags ());

			m_target.DeleteTag(3);
			Assert.AreEqual (1, m_target.CountAllTags ());

			m_target.DeleteTag(4);
			Assert.AreEqual (0, m_target.CountAllTags ());
		}

		[Test]
		public void GetAllTags_NoArgs_AllTags ()
		{
			var actual = m_target.GetAllTags();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetTagByKey_KeyTagDoesNotExists_Null ()
		{
			var actual = m_target.GetTagByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetTagByKey_KeyTagExists_Tag ()
		{
			var actual = m_target.GetTagByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetTagByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SaveTag_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("tag"), () => {
				m_target.SaveTag (null);
			});
		}
 
		[Test]  
		public void SaveTag_TagDoesNotExists_Created()
		{
			var tag = new Tag ();
 
			m_target.SaveTag (tag);

			Assert.AreEqual(5, m_target.CountAllTags());
			Assert.AreEqual (5, m_target.GetTagByKey (tag.Key).Key);
		}
 
		[Test]
		public void SaveTag_TagDoesExists_Updated()
		{
			var tag = new Tag () { 
				Key = 1 
			};

			m_target.SaveTag (tag);

			Assert.AreEqual(4, m_target.CountAllTags());
			Assert.AreEqual (1, m_target.GetTagByKey (tag.Key).Key);
		}
 
		#endregion
	}
}



     


namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class AppliedTagServiceTest
	{
		#region Fields
		private AppliedTagService m_target; 
		#endregion
 
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.AppliedTagRepository.Add (new AppliedTag());
			Stubs.AppliedTagRepository.Add (new AppliedTag());
			Stubs.AppliedTagRepository.Add (new AppliedTag());
			Stubs.AppliedTagRepository.Add (new AppliedTag());
			Stubs.UnitOfWork.Commit ();

			m_target = new AppliedTagService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllAppliedTags_NoArguments_AllAppliedTagsCounted()
		{
			var actual = m_target.CountAllAppliedTags ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeleteAppliedTag_AppliedTagNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("AppliedTag with key '0' does not exists."), () => {
				m_target.DeleteAppliedTag(0);
			});
		}
   
		[Test]
		public void DeleteAppliedTag_AppliedTagExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllAppliedTags ());

			m_target.DeleteAppliedTag(1);
			Assert.AreEqual (3, m_target.CountAllAppliedTags ());

			m_target.DeleteAppliedTag(2);
			Assert.AreEqual (2, m_target.CountAllAppliedTags ());

			m_target.DeleteAppliedTag(3);
			Assert.AreEqual (1, m_target.CountAllAppliedTags ());

			m_target.DeleteAppliedTag(4);
			Assert.AreEqual (0, m_target.CountAllAppliedTags ());
		}

		[Test]
		public void GetAllAppliedTags_NoArgs_AllAppliedTags ()
		{
			var actual = m_target.GetAllAppliedTags();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetAppliedTagByKey_KeyAppliedTagDoesNotExists_Null ()
		{
			var actual = m_target.GetAppliedTagByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetAppliedTagByKey_KeyAppliedTagExists_AppliedTag ()
		{
			var actual = m_target.GetAppliedTagByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetAppliedTagByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SaveAppliedTag_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("appliedtag"), () => {
				m_target.SaveAppliedTag (null);
			});
		}
 
		#endregion
	}
}



	

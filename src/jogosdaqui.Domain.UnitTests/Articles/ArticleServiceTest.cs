using System;
using NUnit.Framework;
using jogosdaqui.Domain.Articles;
using jogosdaqui.Domain.Games;
using TestSharp;
using KissSpecifications;

namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public class ArticleServiceTest
	{
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
		}
		#endregion

		#region Tests
		[Test()]
		public void GetArticlesByGameKey_GameDoesNotExists_Exception ()
		{
			var target = new ArticleService ();

			ExceptionAssert.IsThrowing(new SpecificationNotSatisfiedException("Game can't be null."), () => {
				target.GetArticlesByGameKey(0);
			});
		}

		[Test()]
		public void GetArticlesByGameKey_Key_ArticlesOfManyTypes ()
		{
			var game = new Game (1);
			Stubs.GameRepository.Add (game);
			Stubs.GameRepository.Add (new Game(11));

			var interview = new Interview (2) { Title = "Entrevista" };
			interview.GamesRelated.Add (game);
			Stubs.InterviewRepository.Add (interview);

			interview = new Interview (22);
			Stubs.InterviewRepository.Add (interview);

			var news = new News (3) { Title = "Notícia" };
			news.GamesRelated.Add (game);
			Stubs.NewsRepository.Add (news);

			news = new News (33);
			Stubs.NewsRepository.Add (news);

			var preview = new Preview (4) { Title = "Preview" };
			preview.GamesRelated.Add (game);
			Stubs.PreviewRepository.Add (preview);

			preview = new Preview (44);
			Stubs.PreviewRepository.Add (preview);

			var review = new Review (5) { Title = "Análise" };
			review.GamesRelated.Add (game);
			Stubs.ReviewRepository.Add (review);

			review = new Review (55);
			Stubs.ReviewRepository.Add (review);

			var @event = new Event (6) { Title = "Evento" };
			@event.GamesRelated.Add (game);
			Stubs.EventRepository.Add (@event);

			Stubs.UnitOfWork.Commit ();

			var target = new ArticleService ();
			var actual = target.GetArticlesByGameKey (game.Key);

			Assert.AreEqual (5, actual.Count);
			Assert.AreEqual ("Análise", actual [0].Title);
			Assert.AreEqual ("Entrevista", actual [1].Title);
			Assert.AreEqual ("Evento", actual [2].Title);
			Assert.AreEqual ("Notícia", actual [3].Title);
			Assert.AreEqual ("Preview", actual [4].Title);
		}
		#endregion
	}
}
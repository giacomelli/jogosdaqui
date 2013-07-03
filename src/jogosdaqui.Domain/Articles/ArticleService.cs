using System;
using System.Collections.Generic;
using KissSpecifications;
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Articles.Specifications;
using jogosdaqui.Domain.Games.Specifications;
using System.Linq;

namespace jogosdaqui.Domain.Articles
{
	public partial class ArticleService
	{
		#region Methods

		public IList<ArticleBase> GetArticlesByGameKey(long gameKey)
		{
			var gameService = new GameService ();
			var game = gameService.GetGameByKey (gameKey);

			SpecificationService.ThrowIfAnySpecificationIsNotSatisfiedBy (game, new GameExistsSpecification ());

			var eventService = new EventService ();
			var interviewService = new InterviewService ();
			var newsService = new NewsService ();
			var previewService = new PreviewService ();
			var reviewService = new ReviewService ();
			

			var articles = new List<ArticleBase> ();
			articles.AddRange (eventService.GetEventsByGameKey(gameKey));
			articles.AddRange (interviewService.GetInterviewsByGameKey(gameKey));
			articles.AddRange (newsService.GeNewsByGameKey(gameKey));
			articles.AddRange (previewService.GetPreviewsByGameKey(gameKey));
			articles.AddRange (reviewService.GetReviewsByGameKey(gameKey));


			return articles.OrderBy(a => a.Title).ToList();
		}
		#endregion
	}
}


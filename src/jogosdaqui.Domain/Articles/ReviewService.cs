using System;
using System.Collections.Generic;
using System.Linq;
using KissSpecifications;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Games.Specifications;

namespace jogosdaqui.Domain.Articles
{
	public partial class ReviewService
	{
		/// <summary>
		/// Gets the reviews by game key.
		/// </summary>
		/// <returns>The reviews by game key.</returns>
		/// <param name="gameKey">Game key.</param>
		public IList<Review> GetReviewsByGameKey(long gameKey)
		{
			return base.GetEntitiesByGameKey (gameKey);
		}
	}
}
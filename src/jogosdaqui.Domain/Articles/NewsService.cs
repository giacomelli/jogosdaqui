using System;
using System.Collections.Generic;
using System.Linq;
using KissSpecifications;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Games.Specifications;

namespace jogosdaqui.Domain.Articles
{
	public partial class NewsService
	{
		/// <summary>
		/// Ges the news by game key.
		/// </summary>
		/// <returns>The news by game key.</returns>
		/// <param name="gameKey">Game key.</param>
		public IList<News> GeNewsByGameKey(long gameKey)
		{
			return base.GetEntitiesByGameKey (gameKey);
		}
	}
}
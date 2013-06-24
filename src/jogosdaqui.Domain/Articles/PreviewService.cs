using System;
using System.Collections.Generic;
using System.Linq;
using KissSpecifications;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Games.Specifications;

namespace jogosdaqui.Domain.Articles
{
	public partial class PreviewService
	{
		/// <summary>
		/// Ges the previews by game key.
		/// </summary>
		/// <returns>The previews by game key.</returns>
		/// <param name="gameKey">Game key.</param>
		public IList<Preview> GetPreviewsByGameKey(long gameKey)
		{
			return base.GetEntitiesByGameKey (gameKey);
		}
	}
}
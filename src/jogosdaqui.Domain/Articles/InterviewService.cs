using System;
using System.Collections.Generic;
using System.Linq;
using KissSpecifications;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Games.Specifications;

namespace jogosdaqui.Domain.Articles
{
	public partial class InterviewService
	{
		/// <summary>
		/// Gets the interviews by game key.
		/// </summary>
		/// <returns>The interviews by game key.</returns>
		/// <param name="gameKey">Game key.</param>
		public IList<Interview> GetInterviewsByGameKey(long gameKey)
		{
			return base.GetEntitiesByGameKey (gameKey);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using KissSpecifications;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Games.Specifications;

namespace jogosdaqui.Domain.Articles
{
	public partial class EventService
	{
		/// <summary>
		/// Gets the events by game key.
		/// </summary>
		/// <returns>The events by game key.</returns>
		/// <param name="gameKey">Game key.</param>
		public IList<Event> GetEventsByGameKey(long gameKey)
		{
			return base.GetEntitiesByGameKey (gameKey);
		}
	}
}
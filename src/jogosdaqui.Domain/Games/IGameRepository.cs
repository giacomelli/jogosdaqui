using System;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;

namespace jogosdaqui.Domain.Games
{
	/// <summary>
	/// Defines an interface for game repository.
	/// </summary>
	public partial interface IGameRepository : IRepository<Game, long>
	{
	}
}
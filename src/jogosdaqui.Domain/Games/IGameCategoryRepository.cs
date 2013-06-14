using System;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;

namespace jogosdaqui.Domain.Games
{
	/// <summary>
	/// Defines an interface for game category repository.
	/// </summary>
	public partial interface IGameCategoryRepository : IRepository<GameCategory, long>
	{
	}
}
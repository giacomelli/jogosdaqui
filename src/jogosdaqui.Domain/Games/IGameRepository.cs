using System;
using Skahal.Infrastructure.Framework.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace jogosdaqui.Domain.Games
{
	/// <summary>
	/// Defines a repository for Game entities.
	/// </summary>
	public interface IGameRepository : IRepository<Game>
	{
	}
}
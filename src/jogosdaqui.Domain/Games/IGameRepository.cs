using System;
using Skahal.Infrastructure.Framework.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace jogosdaqui.Domain.Games
{
	/// <summary>
	/// Defines a repository for Game entities.
	/// </summary>
	public interface IGameRepository : IRepository<Game, long>
	{
	}
}
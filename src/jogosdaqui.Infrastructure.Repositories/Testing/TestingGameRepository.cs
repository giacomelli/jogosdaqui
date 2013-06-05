using System;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;

namespace jogosdaqui.Infrastructure.Repositories.Testing
{
	/// <summary>
	/// Testing game repository.
	/// </summary>
	public class TestingGameRepository : MemoryRepository<Game>, IGameRepository
	{
	}
}
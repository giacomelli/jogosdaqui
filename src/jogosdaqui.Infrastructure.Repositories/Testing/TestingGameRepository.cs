using System;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;

namespace jogosdaqui.Infrastructure.Repositories.Testing
{
	/// <summary>
	/// Testing game repository.
	/// </summary>
	public class TestingGameRepository : MemoryRepository<Game, long>, IGameRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.Testing.TestingGameRepository"/> class.
		/// </summary>
		public TestingGameRepository() : base((g) => { return DateTime.Now.Ticks; })
		{
		}
		#endregion
	}
}
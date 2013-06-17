using System;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;

namespace jogosdaqui.Domain.Languages
{
	/// <summary>
	/// Defines an interface for language repository.
	/// </summary>
	public partial interface ILanguageRepository : IRepository<Language, long>
	{
	}
}
using System;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;

namespace jogosdaqui.Domain.Persons
{
	/// <summary>
	/// Defines an interface for person repository.
	/// </summary>
	public partial interface IPersonRepository : IRepository<Person, long>
	{
	}
}
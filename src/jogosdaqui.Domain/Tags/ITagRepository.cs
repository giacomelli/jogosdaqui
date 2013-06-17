using System;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;

namespace jogosdaqui.Domain.Tags
{
	/// <summary>
	/// Defines an interface for tag repository.
	/// </summary>
	public partial interface ITagRepository : IRepository<Tag, long>
	{
	}
}
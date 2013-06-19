using System;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;

namespace jogosdaqui.Domain.Tags
{
	/// <summary>
	/// Defines an interface for a applied tag repository.
	/// </summary>
	public partial interface IAppliedTagRepository : IRepository<AppliedTag, long>
	{
	}
}
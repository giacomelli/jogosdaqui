using System;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games;

namespace jogosdaqui.Domain.Evaluations
{
	/// <summary>
	/// Defines an interface for game evaluation repository.
	/// </summary>
	public partial interface IEvaluationRepository : IRepository<Evaluation, long>
	{
	}
}
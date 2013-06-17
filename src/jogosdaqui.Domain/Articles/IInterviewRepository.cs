using System;
using Skahal.Infrastructure.Framework.Repositories;

namespace jogosdaqui.Domain.Articles
{
	public partial interface IInterviewRepository : IRepository<Interview, long>
	{
	}
}
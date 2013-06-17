using System;
using Skahal.Infrastructure.Framework.Repositories;

namespace jogosdaqui.Domain.Articles
{
	public partial interface IEventRepository : IRepository<Event, long>
	{
	}
}
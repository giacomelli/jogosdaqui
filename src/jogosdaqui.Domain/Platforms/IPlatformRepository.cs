using System;
using Skahal.Infrastructure.Framework.Repositories;

namespace jogosdaqui.Domain.Platforms
{
	public partial interface IPlatformRepository : IRepository<Platform, long>
	{
	}
}
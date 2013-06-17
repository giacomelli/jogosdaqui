using System;
using Skahal.Infrastructure.Framework.Repositories;

namespace jogosdaqui.Domain.Articles
{
	public partial interface IPreviewRepository : IRepository<Preview, long>
	{
	}
}
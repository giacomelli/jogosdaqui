using System;
using Skahal.Infrastructure.Framework.Repositories;

namespace jogosdaqui.Domain.Companies
{
	public partial interface ICompanyRepository : IRepository<Company, long>
	{
	}
}
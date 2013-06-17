using System;
using System.Collections.Generic;
using Skahal.Infrastructure.Framework.Domain;
using jogosdaqui.Domain.Companies;

namespace jogosdaqui.Domain.Platforms
{
	public class Platform : EntityBase<long>, IAggregateRoot<long>
	{
		#region Properties
		public string Name { get; set; }
		public DateTime? ReleaseDate { get; set; }
		public IList<Company> DevelopersCompanies { get; private set; } 
		#endregion
	}
}
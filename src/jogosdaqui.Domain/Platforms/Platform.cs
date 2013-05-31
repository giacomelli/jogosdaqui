using System;
using System.Collections.Generic;

namespace jogosdaqui.Domain
{
	public class Platform
	{
		#region Properties
		public string Name { get; set; }
		public DateTime? ReleaseDate { get; set; }
		public IList<Company> DevelopersCompanies { get; private set; } 
		#endregion
	}
}
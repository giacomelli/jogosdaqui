using System;
using System.Collections.Generic;
using Skahal.Infrastructure.Framework.Repositories;
using System.Linq;

namespace jogosdaqui.Domain.Tags
{
	public partial class AppliedTagService
	{
		public IList<AppliedTag> GetAppliedTags(string entityName)
		{
			if(String.IsNullOrWhiteSpace(entityName))
			{
				throw new ArgumentNullException ("entityName");
			}

			return m_repository
					.FindAll ((a) => a.EntityName.Equals(entityName, StringComparison.OrdinalIgnoreCase))
					.ToList ();
		}
	}
}
using System;
using Skahal.Infrastructure.Framework.Domain;

namespace jogosdaqui.Domain.Companies
{
	public class Company : EntityBase<long>, IAggregateRoot<long>
	{
		#region Properties
		public string Name { get; set; }
		#endregion

		#region Methods
		public bool IsDeveloper()
		{
			throw new NotImplementedException();
		}

		public bool IsPublisher()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}


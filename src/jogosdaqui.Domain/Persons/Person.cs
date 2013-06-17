using System;
using Skahal.Infrastructure.Framework.Domain;

namespace jogosdaqui.Domain.Persons
{
	public class Person : EntityBase<long>, IAggregateRoot<long>
	{
		#region Properties
		public string Name { get; set; }
		#endregion
	}
}


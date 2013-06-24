using System;
using Skahal.Infrastructure.Framework.Domain;

namespace jogosdaqui.Domain.Companies
{
	/// <summary>
	/// Represents a company.
	/// </summary>
	public class Company : EntityBase<long>, IAggregateRoot<long>
	{
		#region Properties
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
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


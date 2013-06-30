using System;
using Skahal.Infrastructure.Framework.Domain;

namespace jogosdaqui.Domain.Persons
{
	/// <summary>
	/// Represents a person.
	/// </summary>
	public class Person : EntityBase<long>, IAggregateRoot<long>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Persons.Person"/> class.
		/// </summary>
		public Person()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Personss.Person"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		public Person(long key) : base(key)
		{
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }
		#endregion
	}
}


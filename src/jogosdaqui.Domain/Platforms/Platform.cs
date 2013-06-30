using System;
using System.Collections.Generic;
using Skahal.Infrastructure.Framework.Domain;
using jogosdaqui.Domain.Companies;

namespace jogosdaqui.Domain.Platforms
{
	public class Platform : EntityBase<long>, IAggregateRoot<long>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Platforms.Platform"/> class.
		/// </summary>
		public Platform()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Platforms.Platform"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		public Platform(long key) : base(key)
		{
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the release date.
		/// </summary>
		/// <value>The release date.</value>
		public DateTime? ReleaseDate { get; set; }

		/// <summary>
		/// Gets the developers companies.
		/// </summary>
		/// <value>The developers companies.</value>
		public IList<Company> DevelopersCompanies { get; private set; } 
		#endregion
	}
}
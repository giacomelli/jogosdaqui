using System;
using Skahal.Infrastructure.Framework.Domain;
using System.Diagnostics;

namespace jogosdaqui.Domain.Tags
{
	/// <summary>
	/// Represents a game category.
	/// </summary>
	[DebuggerDisplay("{Key}: {Name}")]
	public class Tag : EntityBase<long>, IAggregateRoot<long>
	{
		#region Properties
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }
		#endregion
	}
}


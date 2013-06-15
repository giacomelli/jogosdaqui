using System;
using Skahal.Infrastructure.Framework.Domain;
using System.Diagnostics;

namespace jogosdaqui.Domain.Games
{
	/// <summary>
	/// Represents a game category.
	/// </summary>
	[DebuggerDisplay("{Key}: {Name}")]
	public class GameCategory : EntityBase<long>, IAggregateRoot<long>
	{
		#region Properties
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }
		#endregion
	}
}


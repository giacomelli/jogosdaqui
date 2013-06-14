using System;
using Skahal.Infrastructure.Framework.Domain;

namespace jogosdaqui.Domain.Games
{
	public class GameCategory : EntityBase<long>
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


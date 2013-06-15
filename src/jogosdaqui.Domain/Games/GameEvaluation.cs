using System;
using System.Collections.Generic;
using Skahal.Infrastructure.Framework.Domain;
using System.Diagnostics;

namespace jogosdaqui.Domain.Games
{
	/// <summary>
	/// Game evaluation.
	/// </summary>
	[DebuggerDisplay("{Key}: {GameId}")]
	public class GameEvaluation : EntityBase<long>
	{
		#region Properties
		/// <summary>
		/// Gets or sets the game identifier.
		/// </summary>
		/// <value>The game identifier.</value>
		public long GameId { get; set; }

		/// <summary>
		/// Gets or sets the game version.
		/// </summary>
		/// <value>The game version.</value>
		public string GameVersion { get; set; }

		/// <summary>
		/// Gets the pros.
		/// </summary>
		/// <value>The pros.</value>
		public IList<string> Pros { get; private set; }

		/// <summary>
		/// Gets the cons.
		/// </summary>
		/// <value>The cons.</value>
		public IList<string> Cons { get; private set; }
		#endregion
	}
}
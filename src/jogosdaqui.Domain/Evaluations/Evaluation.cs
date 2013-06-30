using System;
using System.Collections.Generic;
using Skahal.Infrastructure.Framework.Domain;
using System.Diagnostics;

namespace jogosdaqui.Domain.Evaluations
{
	/// <summary>
	/// Game evaluation.
	/// </summary>
	[DebuggerDisplay("{Key}: {GameId}")]
	public class Evaluation : EntityBase<long>, IAggregateRoot<long>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Games.Evaluation"/> class.
		/// </summary>
		public Evaluation()
		{
			Pros = new List<string> ();
			Cons = new List<string> ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Games.Evaluation"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		public Evaluation(long key) : base(key)
		{
			Pros = new List<string> ();
			Cons = new List<string> ();
		}
		#endregion

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
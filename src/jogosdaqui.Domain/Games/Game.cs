using System;
using System.Collections.Generic;
using Skahal.Infrastructure.Framework.Domain;
using System.Diagnostics;
using jogosdaqui.Domain.Platforms;
using jogosdaqui.Domain.Companies;
using jogosdaqui.Domain.Persons;

namespace jogosdaqui.Domain.Games
{
	/// <summary>
	/// Represents a game.
	/// </summary>
	[DebuggerDisplay("{Key}: {Name}")]
	public class Game : EntityBase<long>, IAggregateRoot<long>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Games.Game"/> class.
		/// </summary>
		public Game() : this(0)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Games.Game"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		public Game(long key) : base(key)
		{
			PlatformKeys = new List<long> ();
			DeveloperCompanyKeys = new List<long> ();
			PublisherCompanyKeys = new List<long> ();
			ProgrammerKeys = new List<long> ();
			GameDesignerKeys = new List<long> ();
			ArtistKeys = new List<long> ();
			DirectorKeys = new List<long> ();
			ProducerKeys = new List<long> ();
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
		/// Gets the platform keys
		/// </summary>
		/// <value>The platform keys.</value>
		public IList<long> PlatformKeys { get; private set; } 

		/// <summary>
		/// Gets the developer company keys.
		/// </summary>
		/// <value>The developers companies.</value>
		public IList<long> DeveloperCompanyKeys { get; private set; } 

		/// <summary>
		/// Gets the publisher company.
		/// </summary>
		/// <value>The publisher company keys.</value>
		public IList<long> PublisherCompanyKeys { get; private set; }

		/// <summary>
		/// Gets the programmer keys.
		/// </summary>
		/// <value>The programmer keys.</value>
		public IList<long> ProgrammerKeys { get; private set; } 

		/// <summary>
		/// Gets the game designer keys.
		/// </summary>
		/// <value>The game designer keys.</value>
		public IList<long> GameDesignerKeys { get; private set; } 

		/// <summary>
		/// Gets the artist keys.
		/// </summary>
		/// <value>The artists.</value>
		public IList<long> ArtistKeys { get; private set; } 

		/// <summary>
		/// Gets the director keys.
		/// </summary>
		/// <value>The director keys.</value>
		public IList<long> DirectorKeys { get; private set; } 

		/// <summary>
		/// Gets the producer keys.
		/// </summary>
		/// <value>The producer keys.</value>
		public IList<long> ProducerKeys { get; private set; } 
		#endregion
	}
}
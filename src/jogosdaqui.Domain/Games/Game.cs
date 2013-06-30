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
		public Game()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Games.Game"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		public Game(long key) : base(key)
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
		/// Gets the platform ids
		/// </summary>
		/// <value>The platform ids.</value>
		public IList<long> PlatformIds { get; private set; } 

		/// <summary>
		/// Gets the developer company ids.
		/// </summary>
		/// <value>The developers companies.</value>
		public IList<long> DeveloperCompanyIds { get; private set; } 

		/// <summary>
		/// Gets the publisher company.
		/// </summary>
		/// <value>The publisher company ids.</value>
		public IList<long> PublisherCompanyIds { get; private set; }

		/// <summary>
		/// Gets the programmer ids.
		/// </summary>
		/// <value>The programmer ids.</value>
		public IList<long> ProgrammerIds { get; private set; } 

		/// <summary>
		/// Gets the game designer ids.
		/// </summary>
		/// <value>The game designer ids.</value>
		public IList<long> GameDesignerIds { get; private set; } 

		/// <summary>
		/// Gets the artist ids.
		/// </summary>
		/// <value>The artists.</value>
		public IList<long> ArtistIds { get; private set; } 

		/// <summary>
		/// Gets the director ids.
		/// </summary>
		/// <value>The director ids.</value>
		public IList<long> DirectorIds { get; private set; } 

		/// <summary>
		/// Gets the producer ids.
		/// </summary>
		/// <value>The producer ids.</value>
		public IList<long> ProducerIds { get; private set; } 
		#endregion
	}
}
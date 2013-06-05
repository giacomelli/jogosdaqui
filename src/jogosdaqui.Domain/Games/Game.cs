using System;
using System.Collections.Generic;
using Skahal.Infrastructure.Framework.Domain;

namespace jogosdaqui.Domain.Games
{
	/// <summary>
	/// Represents a game.
	/// </summary>
	public class Game : EntityBase, IAggregateRoot
	{
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
		/// Gets the categories.
		/// </summary>
		/// <value>The categories.</value>
		public IList<GameCategory> Categories { get; private set; } 

		/// <summary>
		/// Gets the platforms.
		/// </summary>
		/// <value>The platforms.</value>
		public IList<Platform> Platforms { get; private set; } 

		/// <summary>
		/// Gets the developers companies.
		/// </summary>
		/// <value>The developers companies.</value>
		public IList<Company> DevelopersCompanies { get; private set; } 

		/// <summary>
		/// Gets the publishers companies.
		/// </summary>
		/// <value>The publishers companies.</value>
		public IList<Company> PublishersCompanies { get; private set; }

		/// <summary>
		/// Gets the programmers.
		/// </summary>
		/// <value>The programmers.</value>
		public IList<Person> Programmers { get; private set; } 

		/// <summary>
		/// Gets the game designers.
		/// </summary>
		/// <value>The game designers.</value>
		public IList<Person> GameDesigners { get; private set; } 

		/// <summary>
		/// Gets the artists.
		/// </summary>
		/// <value>The artists.</value>
		public IList<Person> Artists { get; private set; } 

		/// <summary>
		/// Gets the directors.
		/// </summary>
		/// <value>The directors.</value>
		public IList<Person> Directors { get; private set; } 

		/// <summary>
		/// Gets the producers.
		/// </summary>
		/// <value>The producers.</value>
		public IList<Person> Producers { get; private set; } 
		#endregion
	}
}
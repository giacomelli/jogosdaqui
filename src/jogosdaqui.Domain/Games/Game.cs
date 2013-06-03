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
		public IList<Company> DevelopersCompanies { get; private set; } 
		public IList<Company> PublishersCompanies { get; private set; } 
		public IList<Person> Programmers { get; private set; } 
		public IList<Person> GameDesigners { get; private set; } 
		public IList<Person> Artists { get; private set; } 
		public IList<Person> Directors { get; private set; } 
		public IList<Person> Producers { get; private set; } 
		#endregion
	}
}
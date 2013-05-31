using System;
using System.Collections.Generic;
using Skahal.Infrastructure.Framework.Domain;

namespace jogosdaqui.Domain
{
	public class Game : EntityBase
	{
		#region Properties
		public string Name { get; set; }
		public DateTime? ReleaseDate { get; set; }
		public IList<GameCategory> Categories { get; private set; } 
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
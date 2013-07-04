using System;
using KissSpecifications;
using jogosdaqui.Domain.Platforms;
using HelperSharp;
using System.Linq;
using jogosdaqui.Domain.Commons.Specifications;
using jogosdaqui.Domain.Companies;

namespace jogosdaqui.Domain.Games.Specifications
{
	/// <summary>
	/// Game valid developer companies specification.
	/// </summary>
	public class GameValidDeveloperCompaniesSpecification : ValidChildEntitiyKeysSpecificationBase<Game, Company>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Domain.Games.Specifications.GameValidDeveloperCompaniesSpecification"/> class.
		/// </summary>
		public GameValidDeveloperCompaniesSpecification() : base("developer company", "developer companies")
		{
		}
		#endregion
	}
}
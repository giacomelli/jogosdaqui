using System;
using KissSpecifications;
using jogosdaqui.Domain.Companies.Specifications;

namespace jogosdaqui.Domain.Companies
{
	public partial class CompanyService
	{
		/// <summary>
		/// Executes the save specification.
		/// </summary>
		/// <param name="company">Company.</param>
		partial void ExecuteSaveSpecification (Company company)
		{
			SpecificationService.ThrowIfAnySpecificationIsNotSatisfiedBy(
				company, 
				new CompanyUniqueNameSpecification());
		}
	}
}
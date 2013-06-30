using System;
using NUnit.Framework;
using jogosdaqui.Domain.Companies;
using TestSharp;
using KissSpecifications;

namespace jogosdaqui.Domain.UnitTests
{
	public partial class CompanyServiceTest
	{
		[Test]  
		public void SaveCompany_CompanyDoesNotExists_Created()
		{
			var company = new Company () { Name = "New name 5" };

			m_target.SaveCompany (company);

			Assert.AreEqual(5, m_target.CountAllCompanies());
			Assert.AreEqual (5, m_target.GetCompanyByKey (company.Key).Key);
		}

		[Test]  
		public void SaveCompany_ThereIsAnotherCompanyWithSameName_Exception()
		{
			var company = new Company () { Name = "Name" };
			m_target.SaveCompany (company);

			ExceptionAssert.IsThrowing (
				new SpecificationNotSatisfiedException ("There is another Company with the name 'Name'. Companies should have unique name."), () => {
				m_target.SaveCompany (new Company () { Name = "Name" });
			});
		}
	}
}


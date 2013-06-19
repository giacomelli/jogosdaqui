using System;
using Skahal.Infrastructure.Framework.Commons;
using jogosdaqui.Domain.Tags;
using jogosdaqui.Infrastructure.Repositories.Testing;
using Skahal.Infrastructure.Framework.Repositories;

namespace jogosdaqui.Domain.UnitTests
{
	public static class Stubs
	{
		#region Properties
		public static IAppliedTagRepository AppliedTagRepository { get; set; } 
		public static IUnitOfWork<long> UnitOfWork { get; set; }
		#endregion

		#region Methods
		public static void Initialize ()
		{
			DependencyService.Register<IUnitOfWork<long>> (UnitOfWork = new MemoryUnitOfWork<long>());
			DependencyService.Register<IAppliedTagRepository> (AppliedTagRepository = new TestingAppliedTagRepository());
		
			AppliedTagRepository.SetUnitOfWork (UnitOfWork);
		}
		#endregion
	}
}


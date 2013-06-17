using System;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using Skahal.Infrastructure.Framework.Commons;
using Swagger.Net;
using jogosdaqui.Domain.Games;
using jogosdaqui.Infrastructure.Repositories;
using jogosdaqui.Infrastructure.Repositories.Testing;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Platforms;

[assembly: WebActivator.PreApplicationStartMethod(typeof(App_Start.DomainConfig), "PreStart")]
[assembly: WebActivator.PostApplicationStartMethod(typeof(App_Start.DomainConfig), "PostStart")]
namespace App_Start 
{
	/// <summary>
	/// Domain config.
	/// </summary>
	public static class DomainConfig 
	{
		/// <summary>
		/// Executa antes do start real da app.
		/// </summary>
		/// <returns>The start.</returns>
		public static void PreStart() 
		{
			DependencyService.Register<IGameRepository> (new TestingGameRepository());
			DependencyService.Register<IGameCategoryRepository> (new TestingGameCategoryRepository());
			DependencyService.Register<IPlatformRepository> (new TestingPlatformRepository());
			DependencyService.Register<IUnitOfWork<long>>(() => { return new MemoryUnitOfWork<long>(); });
		}

		/// <summary>
		/// Executa após o start real dapp.
		/// </summary>
		/// <returns>The start.</returns>
		public static void PostStart() 
		{

		}
	}
}
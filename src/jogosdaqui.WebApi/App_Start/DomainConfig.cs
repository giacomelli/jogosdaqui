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
using jogosdaqui.Domain.Companies;
using jogosdaqui.Domain.Persons;
using jogosdaqui.Domain.Languages;
using jogosdaqui.Domain.Articles;
using jogosdaqui.Domain.Tags;
using jogosdaqui.Infrastructure.Repositories.MongoDB;

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
			DependencyService.Register<ICompanyRepository> (new TestingCompanyRepository());
			DependencyService.Register<IGameRepository> (new TestingGameRepository());
			DependencyService.Register<ILanguageRepository> (new TestingLanguageRepository());

			DependencyService.Register<INewsRepository> (new TestingNewsRepository());
			DependencyService.Register<IInterviewRepository> (new TestingInterviewRepository());
			DependencyService.Register<IPreviewRepository> (new TestingPreviewRepository());
			DependencyService.Register<ICommentRepository> (new TestingCommentRepository());
			DependencyService.Register<IReviewRepository> (new TestingReviewRepository());
		
			DependencyService.Register<IPlatformRepository> (new TestingPlatformRepository());			
			DependencyService.Register<IPersonRepository> (new TestingPersonRepository());

			//DependencyService.Register<ITagRepository> (new TestingTagRepository());
			DependencyService.Register<ITagRepository> (new MongoDBTagRepository());
			DependencyService.Register<IAppliedTagRepository> (new TestingAppliedTagRepository());



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
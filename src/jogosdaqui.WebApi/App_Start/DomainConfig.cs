using System;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using Skahal.Infrastructure.Framework.Commons;
using Skahal.Infrastructure.Framework.Repositories;
using Swagger.Net;
using jogosdaqui.Domain.Articles;
using jogosdaqui.Domain.Companies;
using jogosdaqui.Domain.Evaluations;
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Languages;
using jogosdaqui.Domain.Persons;
using jogosdaqui.Domain.Platforms;
using jogosdaqui.Domain.Tags;
using jogosdaqui.Infrastructure.Repositories;
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
			MongoDBBootStrapper.Start ();

			DependencyService.Register<ICompanyRepository> (() => { return new MongoDBCompanyRepository(); });
			DependencyService.Register<IGameRepository> (() => { return new MongoDBGameRepository(); });
			DependencyService.Register<ILanguageRepository> (() => { return new MongoDBLanguageRepository(); });

			DependencyService.Register<INewsRepository> (() => { return new MongoDBNewsRepository(); });
			DependencyService.Register<IInterviewRepository> (() => { return new MongoDBInterviewRepository(); });
			DependencyService.Register<IPreviewRepository> (() => { return new MongoDBPreviewRepository(); });
			DependencyService.Register<ICommentRepository> (() => { return new MongoDBCommentRepository(); });
			DependencyService.Register<IReviewRepository> (() => { return new MongoDBReviewRepository(); });
			DependencyService.Register<IEventRepository> (() => { return new MongoDBEventRepository(); });
		
			DependencyService.Register<IPlatformRepository> (() => { return new MongoDBPlatformRepository(); });			
			DependencyService.Register<IPersonRepository> (() => { return new MongoDBPersonRepository(); });


			DependencyService.Register<ITagRepository> (() => { return new MongoDBTagRepository(); });
			DependencyService.Register<IAppliedTagRepository> (() => { return new MongoDBAppliedTagRepository(); });

			DependencyService.Register<IEvaluationRepository> (() => { return new MongoDBEvaluationRepository(); });


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
using System;
using System.IO;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Skahal.Infrastructure.Framework.Commons;
using Swagger.Net;
using jogosdaqui.Domain.Games;
using jogosdaqui.Infrastructure.Repositories;

[assembly: WebActivator.PreApplicationStartMethod(typeof(App_Start.WebApiConfig), "PreStart")]
[assembly: WebActivator.PostApplicationStartMethod(typeof(App_Start.WebApiConfig), "PostStart")]
namespace App_Start 
{
	/// <summary>
	/// WebApiConfig config.
	/// </summary>
	public static class WebApiConfig 
	{
		/// <summary>
		/// Executa antes do start real da app.
		/// </summary>
		/// <returns>The start.</returns>
		public static void PreStart() 
		{

		}

		/// <summary>
		/// Executa após o start real dapp.
		/// </summary>
		/// <returns>The start.</returns>
		public static void PostStart() 
		{
			RegisterGlobalFilters (GlobalFilters.Filters);

			var config = GlobalConfiguration.Configuration;
			RegisterRoutes (config);
			RegisterFormatters (config);
		}

		/// <summary>
		/// Registers the routes.
		/// </summary>
		/// <param name="config">Config.</param>
		public static void RegisterRoutes (HttpConfiguration config)
		{
			var routes = config.Routes;

			routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "{controller}/{id}",
				defaults: new
				{
				id = RouteParameter.Optional,
				action = RouteParameter.Optional
			});
		}

		/// <summary>
		/// Registers the formatters.
		/// </summary>
		/// <param name="config">Config.</param>
		private static void RegisterFormatters (HttpConfiguration config)
		{
			var json = config.Formatters.JsonFormatter;
			json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			// A resposta será em JSON quando as chamadas tiverem a extensão .json.
			json.AddUriPathExtensionMapping("json", "application/json");

			// Configura JSON como a resposta padrão.
			json.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

			// Permite que as enumerações sejam serializadas como string.
			json.SerializerSettings.Converters.Add(new StringEnumConverter());
		}

		/// <summary>
		/// Registers the global filters.
		/// </summary>
		/// <param name="filters">Filters.</param>
		public static void RegisterGlobalFilters (GlobalFilterCollection filters)
		{
			filters.Add (new HandleErrorAttribute());
		}
	}
}
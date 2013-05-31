using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json.Converters;

namespace jogosdaqui.WebApi
{
	/// <summary>
	/// Enter point.
	/// </summary>
	public class MvcApplication : System.Web.HttpApplication
	{
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
		void RegisterFormatters (HttpConfiguration config)
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

		/// <summary>
		/// Application_s the start.
		/// </summary>
		protected void Application_Start ()
		{
			AreaRegistration.RegisterAllAreas ();
			RegisterGlobalFilters (GlobalFilters.Filters);

			var config = GlobalConfiguration.Configuration;
			config.EnableQuerySupport ();
			RegisterRoutes (config);
			RegisterFormatters (config);
		}
	}
}

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
	public class MvcApplication : System.Web.HttpApplication
	{
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

		public static void RegisterGlobalFilters (GlobalFilterCollection filters)
		{
			filters.Add (new HandleErrorAttribute());
		}

		protected void Application_Start ()
		{
			AreaRegistration.RegisterAllAreas ();
			RegisterGlobalFilters (GlobalFilters.Filters);
			RegisterRoutes (GlobalConfiguration.Configuration);
			RegisterFormatters (GlobalConfiguration.Configuration);
		}
	}
}

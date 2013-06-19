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
using App_Start;

namespace jogosdaqui.WebApi
{
	/// <summary>
	/// Enter point.
	/// </summary>
	public class MvcApplication : System.Web.HttpApplication
	{
		/// <summary>
		/// Application_s the start.
		/// </summary>
		protected void Application_Start ()
		{
			AreaRegistration.RegisterAllAreas ();
			WebApiConfig.PostStart ();
			SwaggerConfig.PostStart ();
		}
	}
}

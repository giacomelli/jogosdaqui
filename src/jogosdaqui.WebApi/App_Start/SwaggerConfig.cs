using System;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using Swagger.Net;

[assembly: WebActivator.PreApplicationStartMethod(typeof(App_Start.SwaggerConfig), "PreStart")]
//[assembly: WebActivator.PostApplicationStartMethod(typeof(App_Start.SwaggerConfig), "PostStart")]
namespace App_Start 
{
	/// <summary>
	/// Inicializador do Swagger.NET.
	/// </summary>
    public static class SwaggerConfig 
    {
        /// <summary>
        /// Executa antes do start real da app.
        /// </summary>
        /// <returns>The start.</returns>
		public static void PreStart() 
        {
            RouteTable.Routes.MapHttpRoute(
                name: "SwaggerApi",
                routeTemplate: "api/docs/{controller}",
                defaults: new { swagger = true }
            );            
        }
        
		/// <summary>
		/// Executa após o start real dapp.
		/// </summary>
		/// <returns>The start.</returns>
        public static void PostStart() 
        {
            var config = GlobalConfiguration.Configuration;

            config.Filters.Add(new SwaggerActionFilter());
            
            try
            {
                config.Services.Replace(typeof(IDocumentationProvider),
                    new XmlCommentDocumentationProvider(HttpContext.Current.Server.MapPath("~/bin/jogosdaqui.WebApi.xml")));
            }
            catch (FileNotFoundException)
            {
                throw new Exception("Please enable \"XML documentation file\" in project properties with default (bin\\.XML) value or edit value in App_Start\\SwaggerNet.cs");
            }
        }
    }
}
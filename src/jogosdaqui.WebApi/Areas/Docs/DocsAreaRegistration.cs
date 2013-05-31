using System.Web.Mvc;

namespace jogosdaqui.WebApi.Areas.Docs
{
	/// <summary>
	/// Define o registro da área de documentação.
	/// </summary>
	public class DocsAreaRegistration : AreaRegistration
	{
		/// <summary>
		/// Gets the name of the area to register.
		/// </summary>
		/// <returns>The name of the area to register.</returns>
		public override string AreaName
		{
			get
			{
				return "Docs";
			}
		}

		/// <summary>
		/// Registers an area in an ASP.NET MVC application using the specified area's context information.
		/// </summary>
		/// <param name="context">Encapsulates the information that is required in order to register the area.</param>
		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				"Docs_default",
				"Docs/{action}/{id}",
				new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);

			context.MapRoute(
				"Login_default",
				"Login/{action}/{id}",
				new { controller = "Login", action = "Index", id = UrlParameter.Optional });
		}
	}
}

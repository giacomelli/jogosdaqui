using System.Web.Mvc;
using System.Web.Routing;
using System.Text.RegularExpressions;

namespace jogosdaqui.WebApi.Areas.Docs.Controllers
{
	/// <summary>
	/// Classe responsável pela entrega do Hotsite da AdAPI
	/// </summary>
	public class HomeController : Controller
	{

		/// <summary>
		/// Inicialização de variáveis.
		/// </summary>
		protected override void Initialize(RequestContext rc)
		{
			base.Initialize(rc);
			ViewData["AbsolutePath"] = Regex.Replace(Request.ApplicationPath, "(/*)$", "");
		}

		/// <summary>
		/// URL base da api, mosra a index do hotsite.
		/// </summary>
		public ActionResult Index()
		{   
			return View();
		}

		/// <summary>
		/// URL para o console Swagger da API.
		/// </summary>
		public ActionResult Console()
		{
			return View();
		}

		/// <summary>
		/// URL para a página de release notes.
		/// </summary>
		public ActionResult ReleaseNotes()
		{
			return View();
		}

		/// <summary>
		/// URL para a página de introdução.
		/// </summary>
		public ActionResult Intro()
		{
			return View();
		}
	}
}

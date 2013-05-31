using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using jogosdaqui.Domain;

namespace jogosdaqui.WebApi.Controllers
{
	/// <summary>
	/// Jogos.
	/// </summary>
    public class GamesController : ApiController
    {
		/// <summary>
		/// Obtém todos os jogos existentes.
		/// </summary>
        public IEnumerable<Game> Get()
        {
			return new Game [] {
				new Game() {Name = "1"},
				new Game() {Name = "2"}
			};
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jogosdaqui.Domain.Tags;
using System.Web.Http;

namespace jogosdaqui.WebApi.Controllers
{
    public partial class AppliedTagsController
    {
		/// <summary>
		/// Gets the applied tags for the entity with the specify name.
		/// </summary>
		/// <returns>The applied tags for the entity.</returns>
		/// <param name="entityName">Entity name.</param>
        public IEnumerable<AppliedTag> GetByEntityName(string entityName)
        {
			var service = new AppliedTagService ();
			return service.GetAppliedTags (entityName);
        }
    }
}

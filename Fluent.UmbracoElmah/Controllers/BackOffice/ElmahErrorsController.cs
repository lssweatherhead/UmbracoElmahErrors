using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fluent.UmbracoElmah.Actions;
using Umbraco.Web.Mvc;

namespace Fluent.UmbracoElmah.Controllers.BackOffice
{
    public class ElmahErrorsController : UmbracoAuthorizedController
    {
        // GET: ElmahErrors
        public ActionResult Index(string type)
        {
            return new ElmahActionResult(type);
        }
    }
}
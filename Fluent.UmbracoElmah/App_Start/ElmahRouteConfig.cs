using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;

namespace Fluent.UmbracoElmah
{
    public class ElmahRouteConfig : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            RouteTable.Routes.MapRoute(
                "Elmah",
                "umbraco/backoffice/plugins/elmah-errors/{type}",
                new
                {
                    controller = "ElmahErrors",
                    action = "Index",
                    type = UrlParameter.Optional
                });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fluent.UmbracoElmah.Actions
{
    public class ElmahActionResult : ActionResult
    {
        private readonly string _elmahResourceType;

        public ElmahActionResult(string type)
        {
            _elmahResourceType = type;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var factory = new Elmah.ErrorLogPageFactory();

            if (!string.IsNullOrEmpty(_elmahResourceType))
            {
                var pathInfo = "/" + _elmahResourceType;
                context.HttpContext.RewritePath(FilePath(context), pathInfo, context.HttpContext.Request.QueryString.ToString());
            }

            var currentApplication = (HttpApplication)context.HttpContext.GetService(typeof(HttpApplication));
            if (currentApplication == null) return;

            var currentContext = currentApplication.Context;

            var httpHandler = factory.GetHandler(currentContext, null, null, null);
            switch (httpHandler)
            {
                case null:
                    return;
                case IHttpAsyncHandler asyncHttpHandler:
                    asyncHttpHandler.BeginProcessRequest(currentContext, (r) => { }, null);
                    break;
                default:
                    httpHandler.ProcessRequest(currentContext);
                    break;
            }
        }

        private string FilePath(ControllerContext context)
        {
            return _elmahResourceType != "stylesheet" ? context.HttpContext.Request.Path.Replace($"/{_elmahResourceType}", string.Empty) : context.HttpContext.Request.Path;
        }
    }
}
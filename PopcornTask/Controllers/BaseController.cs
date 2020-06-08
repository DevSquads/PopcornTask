using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PopcornTask.Shared;

namespace PopcornTask.Controllers
{
    public class BaseController : Controller
    {
		protected override void OnAuthorization(AuthorizationContext filterContext) {
			base.OnAuthorization(filterContext);
			if(filterContext != null && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName != "Account" &&
				filterContext.ActionDescriptor.ControllerDescriptor.ControllerName != "Base" && SessionContainer.User == null) {
				if(filterContext.HttpContext.Request.IsAjaxRequest())
				{
					//If the request was made via ajax
					var JSResult = new JavaScriptResult();
					JSResult.Script = "location.reload(true)"; //return javascript refresh code
					filterContext.Result = JSResult;
				} else {
					filterContext.Result = new RedirectResult(
						new UrlHelper(filterContext.RequestContext)
						.Action("Login", "Account",
							new { @to = filterContext.HttpContext.Request.Url.PathAndQuery }
					));
				}
			}
		}

	}
}
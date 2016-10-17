using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI.Infrastructure
{
    public class DateCheckerAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var rvd = filterContext.RequestContext.RouteData.Values;
            if (filterContext.ActionParameters["dtBeg"] == null || filterContext.ActionParameters["dtEnd"] == null)
            {
                var url = UrlHelper.GenerateUrl("", "Index", "Home", rvd, RouteTable.Routes,
                    HttpContext.Current.Request.RequestContext, false);
                HttpContext.Current.Response.Redirect(url);
            }
        }
        public void Dispose() { }
    }
}
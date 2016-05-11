using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace DneWebSite.Helper
{
    class RoleAuthorizeAttribute:AuthorizeAttribute
    {

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }else
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller="Error", action="NoPermission"})
                        );
            }

            //else do normal process
            
        }
    }
}

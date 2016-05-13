using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DneWebSite.Helper
{
    class ClaimsAuthorizeAttribute:AuthorizeAttribute
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        //public ClaimsAuthorizeAttribute(string type, string value)
        //{
        //    this.claimType = type;
        //    this.claimValue = value;
        //}

        protected override bool AuthorizeCore(HttpContextBase context)
        {
            var isAuthorized = context.User.Identity.IsAuthenticated
                && ((ClaimsIdentity)context.User.Identity).HasClaim(x => x.Type.Equals(ClaimType)
                            && x.Value.Equals(ClaimValue));

            return isAuthorized;
        }

        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {

            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Error", action = "NoPermission" })
                        );
            }

            //else do normal process


        }
    }
}

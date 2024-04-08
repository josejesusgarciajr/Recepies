using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.ClientInfo.Repository;
using System;
using System.Web;
using System.Web.Mvc;

namespace PersonalPlayGround.Documents
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // get the current controller context
            var controllerContext = httpContext.Request.RequestContext.HttpContext;

            // Check if the user is an admin
            var username = controllerContext.User.Identity.Name;
            IClientService clientService = DependencyResolver.Current.GetService<IClientService>();
            Client client = clientService.GetClientByUsername(username);

            if(client == null)
            {
                return false;
            }

            return client.IsAdmin;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Redirect to login or access denied page
            filterContext.Result = new HttpUnauthorizedResult("Access Denied");
        }
    }
}
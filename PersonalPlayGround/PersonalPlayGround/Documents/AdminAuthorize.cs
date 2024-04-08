using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.ClientInfo.Repository;
using System;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace PersonalPlayGround.Documents
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        private Cache runtimecache = HttpRuntime.Cache;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // get the current controller context
            var controllerContext = httpContext.Request.RequestContext.HttpContext;
            var username = controllerContext.User.Identity.Name;

            // check if cache exists
            string userSpecificCacheKey = "IsAdmin_" + username;
            if(runtimecache.Get(userSpecificCacheKey) != null)
            {
                return Convert.ToBoolean(runtimecache.Get(userSpecificCacheKey));
            }

            // no cache exists fetch information and cache it
            IClientService clientService = DependencyResolver.Current.GetService<IClientService>();
            Client client = clientService.GetClientByUsername(username);

            if (client == null)
            {
                return false;
            }

            runtimecache.Add(userSpecificCacheKey, client.IsAdmin, null, Cache.NoAbsoluteExpiration,
                new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);

            return client.IsAdmin;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Redirect to login or access denied page
            filterContext.Result = new HttpUnauthorizedResult("Access Denied");
        }
    }
}
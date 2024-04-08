using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.ClientInfo.Repository;
using System.Web.Caching;
using System.Web;
using System.Web.Mvc;
using System;

namespace PersonalPlayGround.Controllers
{
    public class BaseController : Controller
    {
        private IClientService _clientService;
        private Cache runtimecache = HttpRuntime.Cache;
        public BaseController() { }
        public BaseController(IClientService clientService)
        {
            _clientService = clientService;
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string username = User.Identity.Name;
            string userSpecificCacheKey = "IsAdmin_" + username;
            if (runtimecache.Get(userSpecificCacheKey) != null)
            {
                ViewBag.IsAdmin = Convert.ToBoolean(runtimecache.Get(userSpecificCacheKey));
                return;
            }

            bool isAdmin = false; // Logic to determine if the user is an admin

            if(_clientService == null)
            {
                _clientService = DependencyResolver.Current.GetService<IClientService>();
            }

            Client client = _clientService.GetClientByUsername(username);

            if(client != null)
            {
                isAdmin = client.IsAdmin;
            }

            ViewBag.IsAdmin = isAdmin;
            runtimecache.Add(userSpecificCacheKey, client.IsAdmin, null, Cache.NoAbsoluteExpiration,
                new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);

            base.OnActionExecuting(filterContext);
        }
    }
}
using Microsoft.AspNetCore.Identity;
using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.ClientInfo.Repository;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonalPlayGround.Controllers
{
    public class BaseController : Controller
    {
        private IClientService _clientService;
        public BaseController() { }
        public BaseController(IClientService clientService)
        {
            _clientService = clientService;
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isAdmin = false; // Logic to determine if the user is an admin

            if(_clientService == null)
            {
                _clientService = DependencyResolver.Current.GetService<IClientService>();
            }

            Client client = _clientService.GetClientByUsername(User.Identity.Name);

            if(client != null)
            {
                isAdmin = client.IsAdmin;
            }

            ViewBag.IsAdmin = isAdmin;
            base.OnActionExecuting(filterContext);
        }
    }
}
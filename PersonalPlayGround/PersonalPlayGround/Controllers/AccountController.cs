using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.ClientInfo.Repository;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonalPlayGround.Controllers
{
    public class AccountController : Controller
    {
        private readonly IClientService _clientService;
        public AccountController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: Account
        public ActionResult LogIn(string message = "")
        {
            ViewBag.ErrorMessage = message;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            bool authorizedClient = _clientService.AuthorizeClient(username, password);

            // Validate username and password here (e.g., against a database)
            if (authorizedClient)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return RedirectToAction("Index", "Home"); // Redirect to the homepage after successful login
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        public ActionResult AddAccount(Client client)
        {
            bool addedClient = _clientService.AddClient(client);

            if(!addedClient)
            {
                string message = $"Client {client.UserName} already exists. Please Log In";
                return RedirectToAction("Login", "Account", new { message = message });
            }

            return RedirectToAction("LogIn");
        }
    }
}
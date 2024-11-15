using Microsoft.AspNet.Identity;
using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.ClientInfo.Repository;
using System;
using System.Linq;
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

        public ActionResult CreateAccount(string message = "")
        {
            ViewBag.ErrorMessage = message;
            return View();
        }

        public ActionResult AddAccount(string name, string username, string password)
        {
            Tuple<IdentityResult, Client> data = AspNetIdentityUser.CreateClientUser(name, username, password);

            IdentityResult identityResult = data.Item1;
            Client client = data.Item2;

            // redirect back with error message
            if(!identityResult.Succeeded)
            {
                string message = identityResult.Errors.FirstOrDefault();
                return RedirectToAction("CreateAccount", "Account", new { message = message });
            }

            // add client to database
            _clientService.AddClient(client);

            // redirect client back to login 
            return RedirectToAction("LogIn");
        }
    }
}
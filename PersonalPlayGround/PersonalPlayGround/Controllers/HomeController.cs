﻿using Microsoft.AspNet.Identity.EntityFramework;
using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.Extensions;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PersonalPlayGround.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            string maui = "MAUI";
            string reversed = maui.Reverse(); // returns "IUAM"

            string tattarrattat = "Tattarrattat";
            bool ordinalPalindrome = tattarrattat.IsPalindrome(StringComparison.Ordinal); // returns false
            bool ordinalIgnoreCasePalindrome = tattarrattat.IsPalindrome(StringComparison.OrdinalIgnoreCase); // returns true

            string awesomeSoftwareEngineer = "jose jesus garcia jr";
            string pascalCase = awesomeSoftwareEngineer.ToPascalCase(); // returns JoseJesusGarciaJr

            List<IdentityUser> users = AspNetIdentityUser.GetAllClientUsers();

            return RedirectToAction("Index", "Recipe");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using PersonalPlayGround.Extensions;
using System;
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

            return View();
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
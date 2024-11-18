using System.Web.Mvc;

namespace PersonalPlayGround.Controllers
{
    public class ErrorHandlerController : Controller
    {
        public ActionResult PageNotFoundError()
        {
            return View();
        }
    }
}
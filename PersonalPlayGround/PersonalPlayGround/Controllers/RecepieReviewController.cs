using PersonalPlayGround.Documents;
using PersonalPlayGround.RecepieData;
using PersonalPlayGround.RecepieData.Service;
using PersonalPlayGround.RecepieReviewData;
using PersonalPlayGround.RecepieReviewData.Service;
using System.Web.Mvc;

namespace PersonalPlayGround.Controllers
{
    public class RecepieReviewController : Controller
    {
        private readonly IRecepieService _recepieService;
        private readonly IRecepieReviewService _recepieReviewService;
        public RecepieReviewController() { }
        public RecepieReviewController(IRecepieService recepieService, IRecepieReviewService recepieReviewService)
        {
            _recepieService = recepieService;
            _recepieReviewService = recepieReviewService;
        }
        public ActionResult AddRecepieReview(int recepieId)
        {
            Recepie recepie = _recepieService.GetRecepieById(recepieId);

            // check if recepie exists
            if (recepie == null)
            {
                return RedirectToAction("Index", "Recepie");
            }

            // check if recepie is active
            if (!recepie.Active)
            {
                return RedirectToAction("Index", "Recepie");
            }

            if (string.IsNullOrEmpty(recepie.ImageURL))
            {
                recepie.ImageURL = FileDirectory.Image_Needed;
            }

            ViewBag.Recepie = recepie;
            return View();
        }

        public ActionResult AddRecepieReviewToDatabase(RecepieReview recepieReview)
        {
            string clientUsername = User.Identity.Name;
            _recepieReviewService.AddRecepieReview(recepieReview, clientUsername);

            return RedirectToAction("GetRecepieById", "Recepie", new { recepieId = recepieReview.RecepieId });
        }
    }
}
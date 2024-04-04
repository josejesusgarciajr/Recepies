using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using PersonalPlayGround.ClientInfo.Repository;
using PersonalPlayGround.Documents;
using PersonalPlayGround.RecepieData;
using PersonalPlayGround.RecepieData.Service;
using PersonalPlayGround.RecepieReviewData;
using PersonalPlayGround.RecepieReviewData.Service;

namespace PersonalPlayGround.Controllers
{
    [Authorize]
    public class RecepieController : Controller
    {
        private readonly IRecepieService _recepieService;
        private readonly IRecepieReviewService _recepieReviewService;
        private readonly IClientService _clientService;
        public RecepieController() { }
        public RecepieController(IRecepieService recepieService, IRecepieReviewService recepieReviewService, IClientService clientService)
        {
            _recepieService = recepieService;
            _recepieReviewService = recepieReviewService;
            _clientService = clientService;
        }

        // GET: Recepie
        public ActionResult Index()
        {
            List<Recepie> recepies = _recepieService.GetActiveRecepies();

            return View(recepies);
        }

        // GET: Recepie/Id
        public ActionResult GetRecepieById(int? recepieId)
        {
            if (recepieId == null)
            {
                return Index();
            }
            
            Recepie recepie = _recepieService.GetRecepieById(recepieId.Value);

            if(string.IsNullOrEmpty(recepie.ImageURL))
            {
                recepie.ImageURL = Path.Combine("~", FileDirectory.RecepiesDatabaseFolder, FileDirectory.Image_Needed);
            }

            recepie.Ratings = _recepieReviewService.GetRecepieReviewsByRecepieId(recepieId.Value);

            foreach(RecepieReview recepieReview in recepie.Ratings)
            {
                recepieReview.Client = _clientService.GetClientById(recepieReview.ClientId);
            }

            return View(recepie);
        }

        public ActionResult AddRecepieReview(int recepieId)
        {
            Recepie recepie = _recepieService.GetRecepieById(recepieId);

            ViewBag.Recepie = recepie;
            return View();
        }

        public ActionResult AddRecepieReviewToDatabase(RecepieReview recepieReview)
        {
            string clientUsername = User.Identity.Name;
            _recepieReviewService.AddRecepieReview(recepieReview, clientUsername);

            return RedirectToAction("GetRecepieById", new { recepieId = recepieReview.RecepieId });
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.ClientInfo.Repository;
using PersonalPlayGround.Documents;
using PersonalPlayGround.RecepieData;
using PersonalPlayGround.RecepieData.Service;
using PersonalPlayGround.RecepieReviewData;
using PersonalPlayGround.RecepieReviewData.Service;

namespace PersonalPlayGround.Controllers
{
    [Authorize]
    public class RecepieController : BaseController
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
            
            // Get Recepie
            Recepie recepie = _recepieService.GetRecepieById(recepieId.Value);

            // check if recepie exists
            if(recepie == null)
            {
                return RedirectToAction("Index", "Recepie");
            }

            // check if recepie is active
            if(!recepie.Active)
            {
                return RedirectToAction("Index", "Recepie");
            }

            if(string.IsNullOrEmpty(recepie.ImageURL))
            {
                recepie.ImageURL = Path.Combine("~", FileDirectory.RecepiesDatabaseFolder, FileDirectory.Image_Needed);
            }

            // Get Recepie Rating/Review
            recepie.Ratings = _recepieReviewService.GetRecepieReviewsByRecepieId(recepieId.Value);

            foreach(RecepieReview recepieReview in recepie.Ratings)
            {
                // Get Client by Recepie Review
                recepieReview.Client = _clientService.GetClientById(recepieReview.ClientId);
            }

            // Check if client left a review 
            Client client = _clientService.GetClientByUsername(User.Identity.Name);
            bool clientLeftReview = _clientService.ClientLeftReview(client.Id, recepieId.Value);

            ViewBag.ClientLeftReview = clientLeftReview;
            return View(recepie);
        }

    }
}
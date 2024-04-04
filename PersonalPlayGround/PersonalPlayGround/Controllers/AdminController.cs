using PersonalPlayGround.Documents;
using PersonalPlayGround.RecepieData;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace PersonalPlayGround.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IRecepieService _recepieService;
        public AdminController() { }
        public AdminController(IRecepieService recepieService)
        {
            _recepieService = recepieService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectRecepie(string task)
        {
            ViewData["Action"] = task;
            List<Recepie> recepies = _recepieService.GetRecepies();

            return View(recepies);
        }

        public ActionResult UpdateRecepie(int recepieId)
        {
            Recepie recepie = _recepieService.GetRecepieById(recepieId);

            if(string.IsNullOrEmpty(recepie.ImageURL))
            {
                recepie.ImageURL = Path.Combine("~", FileDirectory.RecepiesDatabaseFolder, FileDirectory.Image_Needed);
            }

            return View(recepie);
        }

        public ActionResult UpdateRecepieInDatabase(Recepie recepie, HttpPostedFileBase uploadImage)
        {
            if(uploadImage  != null)
            {
                UploadHelper.UploadRecepieImage(uploadImage);
                recepie.ImageURL = Path.Combine("~", FileDirectory.RecepiesDatabaseFolder, uploadImage.FileName);
            }

            _recepieService.UpdateRecepie(recepie);

            return RedirectToAction("GetRecepieById", "Recepie", new { recepieId = recepie.Id });
        }

        public ActionResult AddRecepie()
        {
            return View();
        }

        public ActionResult AddRecepieToDatabase(Recepie recepie, HttpPostedFileBase uploadImage)
        {
            int newRecepieId = _recepieService.AddRecepie(recepie, uploadImage);

            return RedirectToAction("GetRecepieById", "Recepie", new { recepieId = newRecepieId });
        }

        public ActionResult DeleteRecepie(int recepieId)
        {
            _recepieService.DeleteRecepie(recepieId);

            return RedirectToAction("SelectRecepie", new { task = "Delete" });
        }
    }
}
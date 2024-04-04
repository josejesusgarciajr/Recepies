using PersonalPlayGround.Documents;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace PersonalPlayGround.RecepieData
{
    public class RecepieService : IRecepieService
    {
        private readonly IRecepieRepository _recepieRepository;
        public RecepieService(IRecepieRepository recepieRepository)
        {
            _recepieRepository = recepieRepository;
        }

        public List<Recepie> GetRecepies()
        {
            return _recepieRepository.GetRecepies();
        }

        public List<Recepie> GetActiveRecepies()
        {
            return _recepieRepository.GetActiveRecepies();
        }

        public List<Recepie> GetRecepieBySearch(string search)
        {
            return _recepieRepository.GetRecepieBySearch(search);
        }

        public Recepie GetRecepieById(int recepieId)
        {
            return _recepieRepository.GetRecepieById(recepieId);
        }

        public Recepie UpdateRecepie(Recepie recepie)
        {
            return _recepieRepository.UpdateRecepie(recepie);
        }

        public int AddRecepie(Recepie recepie, HttpPostedFileBase uploadImage)
        {
            if(uploadImage != null)
            {
                UploadHelper.UploadRecepieImage(uploadImage);
                recepie.ImageURL = Path.Combine("~", FileDirectory.RecepiesDatabaseFolder, uploadImage.FileName);
            }

            return _recepieRepository.AddRecepie(recepie);
        }

        public void DeleteRecepie(int recepieId)
        {
            _recepieRepository.DeleteRecepie(recepieId);
        }
    }
}
using System.Collections.Generic;
using System.Web;

namespace PersonalPlayGround.RecepieData.Service
{
    public interface IRecepieService
    {
        List<Recepie> GetRecepies();
        List<Recepie> GetActiveRecepies();
        List<Recepie> GetRecepieBySearch(string search);
        Recepie GetRecepieById(int recepieId);
        Recepie UpdateRecepie(Recepie recepie);
        int AddRecepie(Recepie recepie, HttpPostedFileBase uploadImage);
        void DeleteRecepie(int recepieId);
    }
}

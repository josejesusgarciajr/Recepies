using System.Collections.Generic;

namespace PersonalPlayGround.RecepieData
{
    public interface IRecepieRepository
    {
        List<Recepie> GetRecepies();
        List<Recepie> GetActiveRecepies();
        List<Recepie> GetRecepieBySearch(string search);
        Recepie GetRecepieById(int recepieId);
        Recepie UpdateRecepie(Recepie recepie);
        int AddRecepie(Recepie recepie);
        void DeleteRecepie(int recepieId);
    }
}

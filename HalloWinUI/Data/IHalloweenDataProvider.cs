using HalloWinUI.Models;
using HalloWinUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloWinUI.Data
{
    public interface IHalloweenDataProvider
    {
        List<Maison> GetMaisons();
        List<Enfant> GetEnfants();

        List<MaisonVisiteeViewModel> GetMaisonsVisiteesParEnfant(int enfantId);
        void AjouterMaison(Maison maison);
        void SupprimerMaison(int maisonId);

    }
}

using HalloWinUI.Models;
using HalloWinUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloWinUI.Data
{
    public class HalloweenDataProvider : IHalloweenDataProvider
    {
        private static List<Maison> _maisons;
        private static List<Enfant> _enfants;
        private static List<Visite> _visites;

        public HalloweenDataProvider()
        {
            if (_maisons == null)
            {
                InitialiserDonnees();
            }
        }

        private void InitialiserDonnees()
        {
            _maisons = new List<Maison>
            {
                new Maison(adresse:"123 Rue des Fantômes", estSignalee:true),
                new Maison(adresse:"456 Avenue des Citrouilles", estSignalee:false),
                new Maison(adresse : "789 Boulevard Hanté", estSignalee:false),
                new Maison(adresse : "321 Chemin des Sorcières", estSignalee:false)
            };

            _enfants = new List<Enfant>
            {
                new Enfant(1, "Sophie"),
                new Enfant(2, "Lucas"),
                new Enfant(3, "Emma")
            };

            _visites = new List<Visite>
            {
                new Visite(1, 1, DateTime.Now.AddMinutes(-30)),
                new Visite(1, 2, DateTime.Now.AddMinutes(-20)),
                new Visite(1, 4, DateTime.Now.AddMinutes(-10)),

                new Visite(2, 2, DateTime.Now.AddMinutes(-25)),
                new Visite(2, 3, DateTime.Now.AddMinutes(-5)),

                new Visite(3, 1, DateTime.Now.AddMinutes(-50)),
                new Visite(3, 2, DateTime.Now.AddMinutes(-40)),
                new Visite(3, 3, DateTime.Now.AddMinutes(-30)),
                new Visite(3, 4, DateTime.Now.AddMinutes(-15))
            };
        }

        public List<Maison> GetMaisons()
        {
            return new List<Maison>(_maisons);
        }

        public List<Enfant> GetEnfants()
        {
            return new List<Enfant>(_enfants);
        }

        /// <summary>
        /// Permet de récupérer toutes les maisons visitées par un enfant donné
        /// </summary>
        /// <param name="enfantId">L'identifiant de l'enfant</param>
        /// <returns></returns>
        public List<MaisonVisiteeViewModel> GetMaisonsVisiteesParEnfant(int enfantId)
        {
            List<Visite> visites = _visites.Where(v => v.EnfantId == enfantId).ToList();

            var result = visites
                .Select(v =>
                {
                    // Trouver la maison correspondant à la visite
                    Maison maison = _maisons.FirstOrDefault(m => m.Id == v.MaisonId);
                    if (maison != null)
                        return new MaisonVisiteeViewModel(maison, v.DateVisite);
                    return null;
                })
                .Where(vm => vm != null)
                .ToList();

            return result;
        }

        public void AjouterMaison(Maison maison)
        {
            _maisons.Add(maison);
        }

        public void SupprimerMaison(int maisonId)
        {
            Maison? maison = _maisons.FirstOrDefault(m => m.Id == maisonId);
            if (maison != null)
            {
                _maisons.Remove(maison);
            }
        }

    }
}

using HalloWinUI.Data;
using HalloWinUI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HalloWinUI.ViewModels.Pages
{
    public class MainMaisonsViewModel : BaseViewModel
    {
        private readonly IHalloweenDataProvider _dataProvider;
        private MaisonViewModel? _maisonSelectionnee;

        public MaisonViewModel MaisonSelectionnee
        {
            get => _maisonSelectionnee;
            set
            {
                if (_maisonSelectionnee != value)
                {
                    _maisonSelectionnee = value;
                    // TODO: Binding twoway ==> RaisePrpertyChanged()
                }
            }
        }

        public ObservableCollection<MaisonViewModel> Maisons { get; }

        // TODO: RaisePropertyChanged ici aussi, après avoir fait le binding dans xaml.
        //          C'est cette propriété qui doit être ajoutée à
        //          Maisons dans une méthode Ajouter.
        public string NouvelleMaison { get; set; }

        public MainMaisonsViewModel(IHalloweenDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Maisons = new ObservableCollection<MaisonViewModel>();
        }

        public void ChargerMaisons()
        {
            Maisons.Clear();
            List<Maison> maisons = _dataProvider.GetMaisons();

            if (maisons != null)
            {
                foreach (Maison maison in maisons)
                {
                    Maisons.Add(new MaisonViewModel(maison));
                }
            }
        }

        public void SupprimerMaison()
        {
            if (MaisonSelectionnee != null)
            {
                Maisons.Remove(MaisonSelectionnee); 
            }
        }

        public void AjouterMaison()
        {
            // TODO: != null -> IsNullOrWhiteSpace pour éviter d'ajouter les espaces vides aussi.
            if (NouvelleMaison != null)
            {
                // TODO: utiliser le DataProvider
                Maisons.Add(new MaisonViewModel(new Maison(NouvelleMaison)));
            }
        }
    }
}

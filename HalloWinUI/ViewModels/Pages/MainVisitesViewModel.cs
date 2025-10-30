using HalloWinUI.Data;
using HalloWinUI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HalloWinUI.ViewModels.Pages
{
    public class MainVisitesViewModel : BaseViewModel
    {
        private readonly IHalloweenDataProvider _dataProvider;
        private EnfantViewModel _enfantSelectionne;

        public List<EnfantViewModel> Enfants { get; }
        public ObservableCollection<MaisonVisiteeViewModel> MaisonsVisitees { get; }

        public EnfantViewModel EnfantSelectionne
        {
            get => _enfantSelectionne;
            set
            {
                if (_enfantSelectionne != value)
                {
                    _enfantSelectionne = value;
                    RaisePropertyChanged();
                    ChargerMaisonsVisitees();
                }
            }
        }


        public MainVisitesViewModel(IHalloweenDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Enfants = new List<EnfantViewModel>();
            MaisonsVisitees = new ObservableCollection<MaisonVisiteeViewModel>();
        }

        public void ChargerDonnees()
        {
            Enfants.Clear();


            List<Enfant> enfants = _dataProvider.GetEnfants();
            if (enfants != null)
            {
                foreach (Enfant enfant in enfants)
                {
                    Enfants.Add(new EnfantViewModel(enfant));
                }
            }
        }

        private void ChargerMaisonsVisitees()
        {
            MaisonsVisitees.Clear();
            if (EnfantSelectionne != null)
            {
                List<MaisonVisiteeViewModel> maisonsVisiteesVM = _dataProvider.GetMaisonsVisiteesParEnfant(EnfantSelectionne.Id);
                foreach (MaisonVisiteeViewModel vm in maisonsVisiteesVM)
                {
                    MaisonsVisitees.Add(vm);
                }
            }
        }

    }
}

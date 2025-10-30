using HalloWinUI.Models;

namespace HalloWinUI.ViewModels
{
    public class EnfantViewModel : BaseViewModel
    {
        private Enfant _enfant;

        public EnfantViewModel(Enfant enfant)
        {
            _enfant = enfant;
        }

        public int Id
        {
            get => _enfant.Id;
        }

        public string Nom
        {
            get => _enfant.Nom;
            set
            {
                if (_enfant.Nom != value)
                {
                    _enfant.Nom = value;
                    RaisePropertyChanged();
                }
            }
        }

    }
}

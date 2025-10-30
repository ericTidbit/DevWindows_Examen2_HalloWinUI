using HalloWinUI.Models;

namespace HalloWinUI.ViewModels
{
    public class MaisonViewModel : BaseViewModel
    {
        private Maison _maison;

        public MaisonViewModel(Maison maison)
        {
            _maison = maison;
        }

        public int Id
        {
            get => _maison.Id;
        }

        public string Adresse
        {
            get => _maison.Adresse;
            set
            {
                if (_maison.Adresse != value)
                {
                    _maison.Adresse = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool EstSignalee
        {
            get => _maison.EstSignalee;
            set
            {
                if (_maison.EstSignalee != value)
                {
                    _maison.EstSignalee = value;
                    RaisePropertyChanged(nameof(StatutCouleur));
                }
            }
        }

        public string StatutTexte
        {
            get
            {
                if (_maison.EstSignalee)
                {
                    return "SIGNALÉE";
                }
                else
                {
                    return "Sécuritaire";
                }

            }
        }

        public string StatutCouleur
        {
            get 
            { 
                if (_maison.EstSignalee)
                {
                    return "Red";
                } 
                else
                {
                    return "Green";
                }
            }
        }

    }
}

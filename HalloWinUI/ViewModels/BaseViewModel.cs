using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HalloWinUI.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Évènement lancé lorsqu'une propriété est modifiée
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Déclenche l'événement PropertyChanged pour notifier l'interface utilisateur 
        /// qu'une propriété du ViewModel a été modifiée.
        /// </summary>
        /// <param name="propriete">Nom de la propriété ayant changé. Ce paramètre est automatiquement fourni 
        /// par l’attribut CallerMemberName, donc il n’a généralement pas besoin d’être spécifié.
        /// </param>
        protected virtual void RaisePropertyChanged([CallerMemberName] string? propriete = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriete));
        }
    }
}

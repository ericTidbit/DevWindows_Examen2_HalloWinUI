using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloWinUI.Models
{
    public class Maison
    {
        public int Id { get; set; }
        public string Adresse { get; set; }
        public bool EstSignalee { get; set; }

        private static int _prochainIdMaison = 1;


        public Maison(string adresse) : this(adresse, false) { }

        public Maison(string adresse, bool estSignalee)
        {
            Id = _prochainIdMaison++;
            Adresse = adresse;
            EstSignalee = estSignalee;
        }

    }
}

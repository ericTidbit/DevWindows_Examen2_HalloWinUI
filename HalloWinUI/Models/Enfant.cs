using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloWinUI.Models
{
    public class Enfant
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public Enfant(int id, string nom = "")
        {
            Id = id;
            Nom = nom;
        }

    }
}

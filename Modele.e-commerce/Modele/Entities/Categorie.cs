using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.e_commerce.Modele.Entities
{
    public class Categorie
    {
        public int IDCategorie { get; set; }
        public string Libelle { get; set; }
        public Boolean Actif { get; set; }
    }
}

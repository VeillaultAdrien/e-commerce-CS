using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.e_commerce.Modele.Entities
{
    public class Produit
    {
        public int IDProduit { get; set; }
        public int Code { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public Boolean Actif { get; set; }
        public int Stock { get; set; }
        public float Prix { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.e_commerce.Modele.Entities
{
    public class Produit
    {
        public int IDProduit { get; set; }
        public int Code { get; set; }

        [Display(Name = "Libellé")]
        public string Libelle { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Actif")]
        public Boolean Actif { get; set; }
        [Display(Name = "Stock")]
        public int Stock { get; set; }
        [Display(Name = "Prix")]
        public float Prix { get; set; }
        public int CategorieId { get; set; }
        [Display(Name = "Categorie")]
        public Categorie Categorie { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.e_commerce.Modele.Entities
{
    public class CommandeProduit
    {
        public int ProduitID { get; set; }
        public Produit Produit { get; set; }
        public int CommandeID { get; set; }
        public Commande Commande {get;set;}
        public int Quantite { get; set; }
    }
}

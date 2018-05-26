using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.e_commerce.Modele.Entities
{
    public class LogProduit
    {
        public int LogId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int ProduitId { get; set; }
        public Produit Produit { get; set; }
    }
}

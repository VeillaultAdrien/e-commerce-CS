using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.e_commerce.Modele.Entities
{
    public class Commande
    {
        public int IdCommande { get; set; }
        public DateTime DateCommande { get; set; }
        public string Observation { get; set; }
        public int StatutId { get; set; }
        public Statut Statut { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}

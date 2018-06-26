using System.Collections.Generic;
using Modele.e_commerce.Modele.Entities;

namespace WebEcommerce.Models
{
    public class HomeViewModel
    {
        public List<Produit> ListeProduits { get; set; }

        public List<Commande> ListeCommandes { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.e_commerce;
using Modele.e_commerce;
using Modele.e_commerce.Modele.Entities;

namespace Modele.Console.e_commerce
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessManager bm = BusinessManager.Instance;
            List<Categorie> categories = bm.GetAllCategorie();

            System.Console.WriteLine("---- LISTE DES CATEGORIES -----");
            foreach (Categorie c in categories)
            {
                System.Console.WriteLine("Catégorie ID {0} : {1}", c.IDCategorie, c.Libelle);
            }

            List<Produit> produits = bm.GetAllProduit();
            System.Console.WriteLine("---- LISTE DES PRODUITS -----");
            foreach (Produit p in produits)
            {
                System.Console.WriteLine("Produit ID {0} : {1} - {2} euros", p.IDProduit, p.Libelle, p.Prix);
            }
        }
    }
}

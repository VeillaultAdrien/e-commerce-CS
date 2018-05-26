using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.e_commerce;
using Modele.e_commerce.Modele.Entities;

namespace Modele.e_commerce.Modele.Initialisation
{
    class ContextInitializer : DropCreateDatabaseAlways<Context>
    {
        /// <summary>
        /// Initialiser des données à la création du contexte
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(Context context)
        {
            IList<Categorie> defaultCategories = new List<Categorie>();

            defaultCategories.Add(new Categorie() { Libelle = "Carte Mère" , Actif = true});
            defaultCategories.Add(new Categorie() { Libelle = "Processeur", Actif = true});
            defaultCategories.Add(new Categorie() { Libelle = "RAM", Actif = true});

            foreach (Categorie categ in defaultCategories)
                context.Categories.Add(categ);

            context.SaveChanges();
            IList<Produit> defaultProduits = new List<Produit>();

            defaultProduits.Add(new Produit()
            {
                Actif = true,
                CategorieId = context.Categories.Find(1).IDCategorie,
                Categorie = context.Categories.Find(1),
                Code = 0001,
                Description = "Carte mère interessante pour son prix",
                Libelle = "MSI Z170 Gaming Pro Carbon",
                Prix = 169.90F,
                Stock = 5
            });

            defaultProduits.Add(new Produit()
            {
                Actif = true,
                CategorieId = context.Categories.Find(2).IDCategorie,
                Categorie = context.Categories.Find(2),
                Code = 0002,
                Description = "Un ancien processeur toujours interessant pour son prix",
                Libelle = "Intel Core i5 6600K",
                Prix = 200.00F,
                Stock = 2
            });

            defaultProduits.Add(new Produit()
            {
                Actif = true,
                CategorieId = context.Categories.Find(2).IDCategorie,
                Categorie = context.Categories.Find(2),
                Code = 0003,
                Description = "Un des meilleurs processeur du moment avec ses 6 coeurs et 6 threads",
                Libelle = "Intel Core i7 8700K",
                Prix = 370.00F,
                Stock = 10
            });

            defaultProduits.Add(new Produit()
            {
                Actif = true,
                CategorieId = context.Categories.Find(3).IDCategorie,
                Categorie = context.Categories.Find(3),
                Code = 0004,
                Description = "Ahhh ca pique le cul 16Go de RAM a 230 boulasse",
                Libelle = "GSkill Ripsraw V, 2 x 8 GO 2666 MHz",
                Prix = 230.00F,
                Stock = 15
            });

            foreach (Produit prod in defaultProduits)
                context.Produits.Add(prod);

            base.Seed(context);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Modele.e_commerce;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modele.e_commerce.Modele.Entities;

namespace Modele.Test.e_commerce
{
    [TestClass]
    public class CategorieTest
    {
        private Context context = new Context();

        [TestMethod]
        public void Ajouter()
        {
            IList<Categorie> defaultCategories = new List<Categorie>();

            defaultCategories.Add(new Categorie() {Libelle = "Carte Mère", Actif = true});
            defaultCategories.Add(new Categorie() {Libelle = "Processeur", Actif = true});
            defaultCategories.Add(new Categorie() {Libelle = "RAM", Actif = true});
            defaultCategories.Add(new Categorie() {Libelle = "Boitier", Actif = true});

            foreach (Categorie categ in defaultCategories)
                context.Categories.Add(categ);

            int nbr = context.Categories.ToList().Count;

            Assert.AreEqual(nbr, 4);
        }


        [TestMethod]
        public void Modifier()
        {
            string newLibelle = "Random Access Memoy";

            Categorie cat = context.Categories.Find(3);
            cat.Libelle = newLibelle;
            context.SaveChanges();

            Categorie catBis = context.Categories.Find(3);
            Assert.AreEqual(catBis.Libelle, newLibelle);
        }

        [TestMethod]
        public void Supprimer()
        {
            Categorie cat = context.Categories.Find(1);
            context.Categories.Remove(cat);
            context.SaveChanges();

            int nbr = context.Categories.ToList().Count;

            Assert.AreEqual(nbr, 3);
        }

        [TestMethod]
        public void Lister()
        {
            List<Categorie> cat = context.Categories.ToList();

            Assert.IsNotNull(cat);

        }
    }
}

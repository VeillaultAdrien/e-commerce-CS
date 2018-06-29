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
            defaultCategories.Add(new Categorie() { Libelle = "Boitier", Actif = true });

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
                Description = "Un des meilleurs processeur du moment avec ses 6 coeurs et 12 threads",
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

            defaultProduits.Add(new Produit()
            {
                Actif = true,
                CategorieId = context.Categories.Find(4).IDCategorie,
                Categorie = context.Categories.Find(4),
                Code = 0005,
                Description = "Un boitier pour des configurations bureautique (ou gaming) silencieuses",
                Libelle = "Be Quiet - Silent base 600",
                Prix = 109.90F,
                Stock = 4
            });

            defaultProduits.Add(new Produit()
            {
                Actif = true,
                CategorieId = context.Categories.Find(2).IDCategorie,
                Categorie = context.Categories.Find(2),
                Code = 0006,
                Description = "Un processeur symbolique pour les 40 ans de l'architecture x86 et du premier 8086 ainsi que les 50 ans d'Intel",
                Libelle = "Intel Core i7 8086K",
                Prix = 450.00F,
                Stock = 5
            });

            foreach (Produit prod in defaultProduits)
                context.Produits.Add(prod);


            context.Clients.Add(new Client() { Actif = true, Nom = "Forever", Prenom = "Michel" });

            context.SaveChanges();

            IList<Statut> defaultStatut = new List<Statut>();

            defaultStatut.Add(new Statut() { Libelle = "Validée" });
            defaultStatut.Add(new Statut() {Libelle = "Préparation" });
            defaultStatut.Add(new Statut() { Libelle = "Envoyé" });

            foreach (Statut stat in defaultStatut)
                context.Statuts.Add(stat);

            context.SaveChanges();


            IList<Commande> defaultCommande = new List<Commande>();

            defaultCommande.Add(new Commande() { Client = context.Clients.Find(1), ClientId = context.Clients.Find(1).Id, Statut = context.Statuts.Find(1), StatutId = context.Statuts.Find(1).IdStatut, DateCommande = new DateTime(2018,5,1,8,30,52), Observation = "J'adore les patates" });
            defaultCommande.Add(new Commande() { Client = context.Clients.Find(1), ClientId = context.Clients.Find(1).Id, Statut = context.Statuts.Find(2), StatutId = context.Statuts.Find(2).IdStatut, DateCommande = new DateTime(2018, 6, 1, 8, 30, 52), Observation = "J'adore la raclette" });
            defaultCommande.Add(new Commande() { Client = context.Clients.Find(1), ClientId = context.Clients.Find(1).Id, Statut = context.Statuts.Find(3), StatutId = context.Statuts.Find(3).IdStatut, DateCommande = new DateTime(2018, 4, 1, 8, 30, 52), Observation = "J'adore la pizza" });
            defaultCommande.Add(new Commande() { Client = context.Clients.Find(1), ClientId = context.Clients.Find(1).Id, Statut = context.Statuts.Find(1), StatutId = context.Statuts.Find(1).IdStatut, DateCommande = new DateTime(2018, 3, 1, 8, 30, 52), Observation = "J'adore les chipolatas" });
            defaultCommande.Add(new Commande() { Client = context.Clients.Find(1), ClientId = context.Clients.Find(1).Id, Statut = context.Statuts.Find(2), StatutId = context.Statuts.Find(2).IdStatut, DateCommande = new DateTime(2018, 7, 1, 8, 30, 52), Observation = "J'adore le confit de canard" });
            defaultCommande.Add(new Commande() { Client = context.Clients.Find(1), ClientId = context.Clients.Find(1).Id, Statut = context.Statuts.Find(3), StatutId = context.Statuts.Find(3).IdStatut, DateCommande = new DateTime(2018, 9, 1, 8, 30, 52), Observation = "J'adore le magret de canard" });

            foreach (Commande commande in defaultCommande)
                context.Commandes.Add(commande);

            context.SaveChanges();

            IList<CommandeProduit> defaultCommandeProduit = new List<CommandeProduit>();

            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(1), Commande = context.Commandes.Find(1), CommandeID = context.Commandes.Find(1).IdCommande, ProduitID = context.Produits.Find(1).IDProduit, Quantite = 1 });
            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(2), Commande = context.Commandes.Find(1), CommandeID = context.Commandes.Find(1).IdCommande, ProduitID = context.Produits.Find(2).IDProduit, Quantite = 1 });
            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(4), Commande = context.Commandes.Find(1), CommandeID = context.Commandes.Find(1).IdCommande, ProduitID = context.Produits.Find(4).IDProduit, Quantite = 1 });
            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(5), Commande = context.Commandes.Find(1), CommandeID = context.Commandes.Find(1).IdCommande, ProduitID = context.Produits.Find(5).IDProduit, Quantite = 1 });

            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(2), Commande = context.Commandes.Find(2), CommandeID = context.Commandes.Find(2).IdCommande, ProduitID = context.Produits.Find(2).IDProduit, Quantite = 1 });
            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(4), Commande = context.Commandes.Find(2), CommandeID = context.Commandes.Find(2).IdCommande, ProduitID = context.Produits.Find(4).IDProduit, Quantite = 1 });
            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(5), Commande = context.Commandes.Find(2), CommandeID = context.Commandes.Find(2).IdCommande, ProduitID = context.Produits.Find(5).IDProduit, Quantite = 1 });

            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(4), Commande = context.Commandes.Find(3), CommandeID = context.Commandes.Find(3).IdCommande, ProduitID = context.Produits.Find(4).IDProduit, Quantite = 4 });
            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(6), Commande = context.Commandes.Find(3), CommandeID = context.Commandes.Find(1).IdCommande, ProduitID = context.Produits.Find(6).IDProduit, Quantite = 4 });

            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(5), Commande = context.Commandes.Find(4), CommandeID = context.Commandes.Find(4).IdCommande, ProduitID = context.Produits.Find(5).IDProduit, Quantite = 1 });
            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(6), Commande = context.Commandes.Find(4), CommandeID = context.Commandes.Find(4).IdCommande, ProduitID = context.Produits.Find(6).IDProduit, Quantite = 1 });

            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(3), Commande = context.Commandes.Find(5), CommandeID = context.Commandes.Find(5).IdCommande, ProduitID = context.Produits.Find(3).IDProduit, Quantite = 2 });
            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(4), Commande = context.Commandes.Find(5), CommandeID = context.Commandes.Find(5).IdCommande, ProduitID = context.Produits.Find(4).IDProduit, Quantite = 2 });

            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(3), Commande = context.Commandes.Find(6), CommandeID = context.Commandes.Find(6).IdCommande, ProduitID = context.Produits.Find(3).IDProduit, Quantite = 1 });
            defaultCommandeProduit.Add(new CommandeProduit() { Produit = context.Produits.Find(5), Commande = context.Commandes.Find(6), CommandeID = context.Commandes.Find(6).IdCommande, ProduitID = context.Produits.Find(5).IDProduit, Quantite = 1 });


            foreach (CommandeProduit commandeProduit in defaultCommandeProduit)
                context.CommandeProduits.Add(commandeProduit);

            context.SaveChanges();



            base.Seed(context);
        }
    }
}

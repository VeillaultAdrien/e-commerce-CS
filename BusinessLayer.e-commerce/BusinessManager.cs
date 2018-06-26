using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.e_commerce.Commands;
using BusinessLayer.e_commerce.Container;
using BusinessLayer.e_commerce.Queries;
using Modele.e_commerce;
using Modele.e_commerce.Modele.Entities;

namespace BusinessLayer.e_commerce
{
    public class BusinessManager
    {
        private readonly Context contexte;
        private static BusinessManager _businessManager = null;

        /// <summary>
        /// Constructeur, initialisation du contexte EF
        /// </summary>
        private BusinessManager()
        {
            contexte = new Context();
        }

        /// <summary>
        /// Récupérer l'instance du pattern Singleton
        /// </summary>
        public static BusinessManager Instance
        {
            get
            {
                if (_businessManager == null)
                    _businessManager = new BusinessManager();
                return _businessManager;
            }
        }

        #region Produit

        /// <summary>
        /// Récupérer la liste de tous les produits en base
        /// </summary>
        /// <returns>Liste de Produit</returns>
        public List<Produit> GetAllProduit()
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            return pq.GetAll().ToList();
        }

        /// <summary>
        /// Récupérer une liste de produits en fontcion du nom passé en paramètre
        /// </summary>
        /// <returns>Liste de Produit</returns>
        public List<Produit> SearchProduit(String nomProduit)
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            return pq.GetProduitsByName(nomProduit).ToList();
        }

        /// <summary>
        /// Récupére les 5 produits les plus vendus
        /// </summary>
        /// <returns>Liste de Produit</returns>
        public List<Produit> MostSoldProduits()
        {
            ProduitQuery produitquery = new ProduitQuery(contexte);
            List<ProduitQuantite> listpq = produitquery.GetTotalProduitsCommande();
            List<Produit> listProduit = new List<Produit>();
            foreach (var pq in listpq)
            {
                listProduit.Add(GetProduit(pq.ProduitID));
            }

            return listProduit;
        }

        /// <summary>
        /// Récupére le stock d'un produit avec son code passé en paramètre
        /// </summary>
        /// <returns>Le stock</returns>
        public int Stock(int Code)
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            IQueryable<Produit> p = pq.GetByCode(Code);
            return p.Select(prod => prod.Stock).FirstOrDefault();
        }

        /// <summary>
        /// Ajouter un produit en base
        /// </summary>
        /// <param name="p">Produit à ajouter</param>
        /// <returns>identifiant du nouveau produit</returns>
        public int AjouterProduit(Produit p)
        {
            // TODO : ajouter des contrôles sur le produit (exemple : vérification de champ, etc.)
            ProduitCommand pc = new ProduitCommand(contexte);
            return pc.Ajouter(p);
        }

        /// <summary>
        /// Modifier un produit en base
        /// </summary>
        /// <param name="p">Produit à modifier</param>
        public void ModifierProduit(Produit p)
        {
            // TODO : ajouter des contrôles sur le produit (exemple : vérification de champ, etc.)
            ProduitCommand pc = new ProduitCommand(contexte);
            pc.Modifier(p);
        }

        /// <summary>
        /// Supprimer une produit en base
        /// </summary>
        /// <param name="produitID">Identifiant du produit à supprimer</param>
        public void SupprimerProduit(int produitID)
        {
            ProduitCommand pc = new ProduitCommand(contexte);
            pc.Supprimer(produitID);
        }

        public Produit GetProduit(int idProduit)
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            return pq.GetByID(idProduit).SingleOrDefault();
        }

        #endregion

        #region Categorie

        /// <summary>
        /// Récupérer toutes les catégories de la base
        /// </summary>
        /// <returns>Liste de Categorie</returns>
        public List<Categorie> GetAllCategorie()
        {
            CategorieQuery pq = new CategorieQuery(contexte);
            return pq.GetAll().ToList();
        }

        #endregion

        #region Commande

        /// <summary>
        /// Récupérer toutes les commandes
        /// </summary>
        /// <returns>Liste de Commandes</returns>
        public List<Commande> GetAllCommandes()
        {
            CommandeQuery cq = new CommandeQuery(contexte);
            return cq.GetAll().ToList();
        }


        /// <summary>
        /// Récupérer les 5 dernière commandes
        /// </summary>
        /// <returns>Liste de Commandes</returns>
        public List<Commande> LastCommandes()
        {
            CommandeQuery cq = new CommandeQuery(contexte);
            return cq.Get5LastCommandes().ToList();
        }

        #endregion
    }
}

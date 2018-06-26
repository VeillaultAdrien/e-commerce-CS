using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.e_commerce.Container;
using Modele.e_commerce;
using Modele.e_commerce.Modele.Entities;

namespace BusinessLayer.e_commerce.Queries
{
    class ProduitQuery
    {

        private readonly Context _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public ProduitQuery(Context contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer tous les produits
        /// </summary>
        /// <returns>IQueryable de Produit</returns>
        public IQueryable<Produit> GetAll()
        {
            return _contexte.Produits;
        }

        /// <summary>
        /// Récupérer tous les produits ayant dans leur libelle l'attribut nom
        /// </summary>
        ///  <param name="nom">String que doit contenir le libellé d'un produit pour le récupérer</param>
        /// <returns>IQueryable de Produit</returns>
        public IQueryable<Produit> GetProduitsByName(String nom)
        {
            return _contexte.Produits.Where(p => p.Libelle.ToLower().Contains(nom.ToLower()));
        }

        /// <summary>
        /// Récupére des les id des produits des plus vendu au moins vendu;
        /// </summary>
        /// <returns>IQueryable de Produit</returns>
        public List<ProduitQuantite> GetTotalProduitsCommande()
        {
            return _contexte.CommandeProduits.GroupBy(p => p.ProduitID)
                .Select(p => new ProduitQuantite() {ProduitID = p.Key, Quantite = p.Sum(i => i.Quantite)})
                .OrderByDescending(pq => pq.Quantite).Take(5).ToList();
        }

        /// <summary>
        /// Récupérer un produit par son ID
        /// </summary>
        /// <param name="id">Identifiant du produit à récupérer</param>
        /// <returns>IQueryable de Produit</returns>
        public IQueryable<Produit> GetByID(int id)
        {
            return _contexte.Produits.Where(p => p.IDProduit == id);
        }

        /// <summary>
        /// Récupérer un produit par son Code
        /// </summary>
        /// <param name="Code">Code du produit à récupérer</param>
        /// <returns>IQueryable de Produit</returns>
        public IQueryable<Produit> GetByCode(int Code)
        {
            return _contexte.Produits.Where(p => p.Code == Code);
        }
    }
}

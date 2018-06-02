﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.e_commerce.Commands;
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
        /// Récupérer une liste de produit en base
        /// </summary>
        /// <returns>Liste de Produit</returns>
        public List<Produit> GetAllProduit()
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            return pq.GetAll().ToList();
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

        #endregion

        #region Categorie

        /// <summary>
        /// Récupérer une liste de catégories en base
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
        /// Récupérer une liste de catégories en base
        /// </summary>
        /// <returns>Liste de Categorie</returns>
        public List<Commande> GetAllCommandes()
        {
            CommandeQuery cq = new CommandeQuery(contexte);
            return cq.GetAll().ToList();
        }

        #endregion
    }
}

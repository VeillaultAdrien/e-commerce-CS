using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.e_commerce;
using Modele.e_commerce.Modele.Entities;

namespace BusinessLayer.e_commerce.Queries
{
    class CommandeQuery
    {

        private readonly Context _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public CommandeQuery(Context contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer tous les produits
        /// </summary>
        /// <returns>IQueryable de Produit</returns>
        public IQueryable<Commande> GetAll()
        {
            return _contexte.Commandes;
        }

        /// <summary>
        /// Récupérer un produit par son ID
        /// </summary>
        /// <param name="id">Identifiant du produit à récupérer</param>
        /// <returns>IQueryable de Produit</returns>
        public IQueryable<Commande> GetByID(int id)
        {
            return _contexte.Commandes.Where(c => c.IdCommande == id);
        }
    }
}

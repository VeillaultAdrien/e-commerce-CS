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
        /// Récupérer toute les commandes
        /// </summary>
        /// <returns>IQueryable de Produit</returns>
        public IQueryable<Commande> GetAll()
        {
            return _contexte.Commandes;
        }

        /// <summary>
        /// Récupérer les 5 dernière commande
        /// </summary>
        /// <returns>IQueryable de Produit</returns>
        public IQueryable<Commande> Get5LastCommandes()
        {
            return _contexte.Commandes.OrderByDescending(c => c.DateCommande).Take(5);
        }

        /// <summary>
        /// Récupérer une commande par son ID
        /// </summary>
        /// <param name="id">Identifiant de la commande à récupérer</param>
        /// <returns>IQueryable de Commande</returns>
        public IQueryable<Commande> GetByID(int id)
        {
            return _contexte.Commandes.Where(c => c.IdCommande == id);
        }
    }
}

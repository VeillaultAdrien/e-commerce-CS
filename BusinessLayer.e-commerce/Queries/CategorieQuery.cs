using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.e_commerce;
using Modele.e_commerce.Modele.Entities;

namespace BusinessLayer.e_commerce.Queries
{
    class CategorieQuery
    {
        private readonly Context _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public CategorieQuery(Context contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer toutes les catégories
        /// </summary>
        /// <returns>IQueryable de Categorie</returns>
        public IQueryable<Categorie> GetAll()
        {
            return _contexte.Categories;
        }

        /// <summary>
        /// Récupérer une catégorie par son ID
        /// </summary>
        /// <param name="id">Identifiant de la catégorie à récupérer</param>
        /// <returns>IQueryable de Categorie</returns>
        public IQueryable<Categorie> GetByID(int id)
        {
            return _contexte.Categories.Where(p => p.IDCategorie == id);
        }
    }
}

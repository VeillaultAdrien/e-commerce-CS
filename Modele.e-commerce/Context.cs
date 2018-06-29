using Modele.e_commerce.Modele.Entities;
using Modele.e_commerce.Modele.Fluent;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Modele.e_commerce.Modele.Initialisation;

namespace Modele.e_commerce
{
    public class Context : DbContext
    {
        public Context() : base("name=testDatabase")
        {
            Database.SetInitializer<Context>(new ContextInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("database");
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Mes Clients
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Mes Produits
        /// </summary>
        public DbSet<Produit> Produits { get; set; }

        /// <summary>
        /// Mes Catégories
        /// </summary>
        public DbSet<Categorie> Categories { get; set; }

        /// <summary>
        /// Mes Commandes
        /// </summary>
        public DbSet<Commande> Commandes { get; set; }

        /// <summary>
        /// Mes Statuts
        /// </summary>
        public DbSet<Statut> Statuts { get; set; }

        /// <summary>
        /// </summary>
        public DbSet<CommandeProduit> CommandeProduits { get; set; }
    }
}

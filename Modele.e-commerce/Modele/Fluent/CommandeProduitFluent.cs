using Modele.e_commerce.Modele.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.e_commerce.Modele.Fluent
{
    class CommandeProduitFluent : EntityTypeConfiguration<CommandeProduit>
    {
        public CommandeProduitFluent()
        {
            ToTable("APP_COMMANDEPRODUIT");
            HasKey(c => new { c.ProduitID, c.CommandeID });

            Property(c => c.ProduitID).HasColumnName("CPD_PRODUITID").IsRequired();
            Property(c => c.CommandeID).HasColumnName("CPD_COMMANDEID").IsRequired();
            Property(c => c.Quantite).HasColumnName("CPD_QUANTITE").IsRequired();

            HasRequired(c => c.Produit).WithMany().HasForeignKey(c => c.ProduitID);
            HasRequired(c => c.Commande).WithMany().HasForeignKey(c => c.CommandeID);
        }
    }
}

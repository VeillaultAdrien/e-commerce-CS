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
    class ProduitFluent : EntityTypeConfiguration<Produit>
    {
        public ProduitFluent()
        {
            ToTable("APP_Produit");
            HasKey(p => p.IDProduit);

            Property(p => p.IDProduit).HasColumnName("PRO_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Code).HasColumnName("PRO_CODE").IsRequired();
            Property(p => p.Libelle).HasColumnName("PRO_LIBELLE").IsRequired().HasMaxLength(50);
            Property(p => p.Description).HasColumnName("PRO_DESCRIPTION").IsRequired().HasMaxLength(500);
            Property(p => p.Actif).HasColumnName("PRO_ACTIF").IsRequired();
            Property(p => p.Stock).HasColumnName("PRO_STOCK").IsRequired();
            Property(p => p.Prix).HasColumnName("PRO_PRIX").IsRequired();
            Property(p => p.CategorieId).HasColumnName("PRO_CATEGORIEID").IsRequired();

            HasRequired(p => p.Categorie).WithMany().HasForeignKey(c => c.CategorieId);
        }

    }
}

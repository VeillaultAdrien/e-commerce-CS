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
    public class LogProduit_Fluent : EntityTypeConfiguration<LogProduit>
    {

        public LogProduit_Fluent()
        {
            ToTable("APP_LOGPRODUIT");
            HasKey(l => l.LogId);

            Property(l => l.LogId).HasColumnName("LOG_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(l => l.Message).HasColumnName("LOG_MESSAGE").IsRequired().HasMaxLength(50);
            Property(l => l.Date).HasColumnName("LOG_DATE").IsRequired();
            Property(l => l.ProduitId).HasColumnName("LOG_PRODUITID").IsRequired();

            HasRequired(c => c.Produit).WithMany().HasForeignKey(c => c.ProduitId);
        }
    }
}

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
    public class Commande_Fluent : EntityTypeConfiguration<Commande>
    {
        public Commande_Fluent()
        {
            ToTable("APP_COMMANDE");
            HasKey(c => c.IdCommande);

            Property(c => c.IdCommande).HasColumnName("CMD_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.DateCommande).HasColumnName("CMD_DATECOMMANDE").IsRequired();
            Property(c => c.Observation).HasColumnName("CMD_OBSERVATION").IsRequired().HasMaxLength(50);
            Property(c => c.StatutId).HasColumnName("CMD_STATUTID").IsRequired();
            Property(c => c.ClientId).HasColumnName("CMD_CLIENTID").IsRequired();

            HasRequired(c => c.Statut).WithMany().HasForeignKey(c => c.StatutId);
            HasRequired(c => c.Client).WithMany().HasForeignKey(c => c.ClientId);
        }
    }
}

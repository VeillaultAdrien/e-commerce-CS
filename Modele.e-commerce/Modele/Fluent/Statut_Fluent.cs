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
    public class Statut_Fluent : EntityTypeConfiguration<Statut>
    {
        public Statut_Fluent()
        {
            ToTable("APP_STATUT");
            HasKey(c => c.IdStatut);

            Property(c => c.IdStatut).HasColumnName("STA_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Libelle).HasColumnName("STA_LIBELLE").IsRequired();


            // HasMany(c => c.Comptes).WithRequired(cc => cc.Client).HasForeignKey(cc => cc.ClientId);
        }
    }
}

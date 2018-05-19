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
    class Client_Fluent : EntityTypeConfiguration<Client>
    {
        public Client_Fluent()
        {
            ToTable("APP_Client");
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("CLI_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nom).HasColumnName("CLI_NOM").IsRequired().HasMaxLength(50);
            Property(c => c.Prenom).HasColumnName("CLI_PRENOM").IsRequired().HasMaxLength(50);
            Property(c => c.Actif).HasColumnName("CLI_ACTIF").IsRequired();

           // HasMany(c => c.Comptes).WithRequired(cc => cc.Client).HasForeignKey(cc => cc.ClientId);
        }
    }
}

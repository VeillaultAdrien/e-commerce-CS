using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiceECommerce.DataContract
{
    [DataContract]
    public class DataCommande
    {
        [DataMember]
        public int IdCommande { get; set; }
        [DataMember]
        public DateTime DateCommande { get; set; }
        [DataMember]
        public int StatutId { get; set; }
        [DataMember]
        public int ClientId { get; set; }

        public DataCommande(int IdCommande, DateTime DateCommande, int StatutId, int ClientId)
        {
            this.IdCommande = IdCommande;
            this.DateCommande = DateCommande;
            this.StatutId = StatutId;
            this.ClientId = ClientId;
        }
    }
}
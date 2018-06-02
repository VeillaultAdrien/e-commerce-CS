using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiceECommerce.DataContract
{
    [DataContract]
    public class DataProduit
    {
        [DataMember]
        public int IDProduit { get; set; }
        [DataMember]
        public int Code { get; set; }
        [DataMember]
        public string Libelle { get; set; }
        [DataMember]
        public float Prix { get; set; }

        public DataProduit(int IDProduit, int Code, string Libelle, float Prix)
        {
            this.IDProduit = IDProduit;
            this.Code = Code;
            this.Libelle = Libelle;
            this.Prix =  Prix;
        }
    }
}
using ServiceECommerce.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServiceECommerce.DataContract;
using Modele.e_commerce.Modele.Entities;
using BusinessLayer.e_commerce;

namespace ServiceECommerce
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceECommerce : IECommerce
    {
        
        public List<DataCommande> ListCommande()
        {
            List<DataCommande> response = new List<DataCommande>();
            List<Commande> res = BusinessManager.Instance.GetAllCommandes();
            foreach (Commande command in res)
            {
                response.Add(new DataCommande(command.IdCommande, command.DateCommande, command.StatutId, command.ClientId));
            }

            return response;
        }

        public List<DataProduit> ListProduit()
        {
            List<DataProduit> response = new List<DataProduit>();
            List<Produit> res = BusinessManager.Instance.GetAllProduit();
            foreach (Produit produit in res)
            {
                response.Add(new DataProduit(produit.IDProduit, produit.Code, produit.Libelle, produit.Prix));
            }

            return response;
        }

        public int Stock(string Code)
        {
            return BusinessManager.Instance.Stock(int.Parse(Code));
        }
    }
}

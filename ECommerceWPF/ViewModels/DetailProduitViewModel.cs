using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Modele.e_commerce.Modele.Entities;
using BusinessLayer.e_commerce;

namespace ECommerceWPF.ViewModels
{
    public class DetailProduitViewModel : BaseViewModel
    {
        #region Variables

        private string _code;
        private string _nom;
        private int _idProduit;
        private RelayCommand _modifyOperation;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// <param name="p">Produit à transformer en DetailProduitViewModel</param>
        /// </summary>
        public DetailProduitViewModel(Produit p) // à adapater à la BD
        {
            _code = p.Code.ToString();
            _nom = p.Libelle;
            _idProduit = p.IDProduit;
        }

        #endregion

        #region Data Bindings

        /// <summary>
        /// Code du produit
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// <summary>
        /// Nom du produit
        /// </summary>
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        /// <summary>
        /// Nom du produit
        /// </summary>
        public int IDProduit
        {
            get { return _idProduit; }
            set { _idProduit = value; }
        }

        #endregion

        #region Commandes

        //<summary>
        // Commande pour ouvrir la fenêtre pour ajouter une opération
        // </summary>
        public ICommand ModifyOperation
        {
            get
            {
                if (_modifyOperation == null)
                    _modifyOperation = new RelayCommand(() => this.UpdateProduit());
                return _modifyOperation;
            }
        }

        public void UpdateProduit()
        {
            Produit p = BusinessManager.Instance.GetProduit(_idProduit);
            p.Code = Int32.Parse(_code);
            p.Libelle = _nom;
            BusinessManager.Instance.ModifierProduit(p);

        }

        #endregion
    }
}


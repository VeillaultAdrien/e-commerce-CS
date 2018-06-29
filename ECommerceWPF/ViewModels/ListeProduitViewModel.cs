using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BusinessLayer.e_commerce;
using Modele.e_commerce.Modele.Entities;

namespace ECommerceWPF.ViewModels
{
    public class ListeProduitViewModel : BaseViewModel
    {
        #region Variables

        private ObservableCollection<DetailProduitViewModel> _produits = null;
        private DetailProduitViewModel _selectedProduit;
        private RelayCommand _suppProduit;
        private String _productFilter;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ListeProduitViewModel() // à adapater avec la bd
        {
            // on appelle le mock pour initialiser une liste de produits
            InitializeList();
        }

        #endregion

        public void InitializeList()
        {
            _produits = new ObservableCollection<DetailProduitViewModel>();
            foreach (Produit p in BusinessManager.Instance.GetAllProduit())
            {
                _produits.Add(new DetailProduitViewModel(p));
            }

            if (_produits != null && _produits.Count > 0)
                _selectedProduit = _produits.ElementAt(0);

        }

        #region Data Bindings

        /// <summary>
        /// Obtient ou définit une collection de DetailProduitViewModel (Observable)
        /// </summary>
        public ObservableCollection<DetailProduitViewModel> Produits
        {
            get { return _produits; }
            set
            {
                _produits = value;
                OnPropertyChanged("Produits");
            }
        }

        /// <summary>
        /// Obtient ou défini le produit en cours de sélection dans la liste de DetailProduitViewModel
        /// </summary>
        public DetailProduitViewModel SelectedProduit
        {
            get { return _selectedProduit; }
            set
            {
                _selectedProduit = value;
                OnPropertyChanged("SelectedProduit");
            }
        }

        public ICommand SuppProduit
        {
            get
            {
                if (_suppProduit == null)
                    _suppProduit = new RelayCommand(() => this.SuppProductData());
                return _suppProduit;
            }
        }

        private void SuppProductData()
        {
            if (_selectedProduit == null)
            {
                return;
            }
            BusinessManager.Instance.SupprimerProduit((_selectedProduit).IDProduit);
            _produits.Remove(_selectedProduit);
            OnPropertyChanged("Produits");
        }

        public String FilterProduct
        {
            get { return _productFilter; }
            set
            {
                _productFilter = value;
                _produits.Clear();
                foreach (Produit p in BusinessManager.Instance.SearchProduit(_productFilter))
                {
                    _produits.Add(new DetailProduitViewModel(p));
                }

                if (_productFilter == "")
                {
                    InitializeList();
                }
                OnPropertyChanged("Produits");
            }
        }


        #endregion
    }
}
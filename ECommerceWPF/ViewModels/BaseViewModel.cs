using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ECommerceWPF.ViewModels
{
    /// <summary>
    /// Classe de base pour tous les Vues-Modèles de l'application
    /// Elle fournit la gestion du PropertyChanged via l'interface INotifyPropertyChanged
    /// Classe abstraite
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        #region Constructeurs
        protected BaseViewModel()
        {

        }
        #endregion

        #region Membres de INotifyPropertyChanged

        /// <summary>
        /// Se déclenche lorsqu'une propriété de cet objet a une nouvelle valeur
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Déclenche l'évènement sur  l'évènement PropertyChanged
        /// </summary>
        /// <param name="propertyName">La propriété qui a une nouvelle valeur</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion

    }
}

using Enchere2022.Modeles;
using Enchere2022.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Enchere2022.VuesModeles
{
    class ListeProduitVueModele
    {
        #region Attributs
        private ObservableCollection<Produit> _maListeProduits;
        private readonly Api _apiServices = new Api();

        #endregion

        #region Constructeurs

        public ListeProduitVueModele()
        {
            GetListeProduits();
        }


        #endregion

        #region Getters/Setters
        public ObservableCollection<Produit> MaListeProduits { get => _maListeProduits; set => _maListeProduits = value; }

        #endregion

        #region Methodes
        public async void GetListeProduits()
        {
           MaListeProduits = await _apiServices.GetAllAsync<Produit>
                  ("api/getProduits", Produit.CollClasse);
        }
        #endregion


    }
}

using Enchere2022.Modeles;
using Enchere2022.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Enchere2022.VuesModeles
{
    class ListeProduitVueModele : BaseVueModele
    {
        #region Attributs
        private ObservableCollection<Produit> _maListeProduits;
        private readonly Api _apiServices = new Api();
        private int _resultat;
        #endregion

        #region Constructeurs

        public ListeProduitVueModele()
        {
            Resultat = 0;
            this.GetListeProduits();
            //PostProduit(new Produit(0, "test","test",10));
            //GetListeProduits();
        }


        #endregion

        #region Getters/Setters
        public ObservableCollection<Produit> MaListeProduits { get => _maListeProduits; set => _maListeProduits = value; }
        public int Resultat { get => _resultat; set => _resultat = value; }

        #endregion

        #region Methodes
        public async void GetListeProduits()
        {
           MaListeProduits = await _apiServices.GetAllAsync<Produit>
                  ("api/getProduits", Produit.CollClasse);
        }

        public async void PostProduit(Produit unProduit)
        {

            Resultat = await _apiServices.PostAsync<Produit>
                   (unProduit,"api/postProduit");
        }
        #endregion


    }
}

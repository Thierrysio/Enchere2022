using Enchere2022.Modeles;
using Enchere2022.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Enchere2022.VuesModeles
{
    class EnchereVueModele : BaseVueModele
    {
        #region Attributs
        private readonly Api _apiServices = new Api();
        private ObservableCollection<Enchere> _maListeEnchere;

        #endregion

        #region Constructeurs

        public EnchereVueModele()
        {
            this.GetEnchere();
            //this.GetOneEnchere(new Enchere(7, DateTime.Now, DateTime.Now,0,null));
        }


        #endregion

        #region Getters/Setters
        public ObservableCollection<Enchere> MaListeEnchere 
        {
            get { return _maListeEnchere; }
            set { SetProperty(ref _maListeEnchere, value); }
        }

        #endregion

        #region Methodes
        public async void GetOneEnchere(Enchere uneEnchere)
        {
            Enchere.CollClasse.Clear();
            //Enchere res = await _apiServices.GetOneAsync<Enchere> ("api/getEnchereTestObjet", Enchere.CollClasse, uneEnchere.Id);
        }

        public async void GetEnchere()
        {
            Enchere.CollClasse.Clear();
           MaListeEnchere = await _apiServices.GetAllAsync<Enchere>
                   ("api/getEnchere", Enchere.CollClasse );
        }
        #endregion
    }
}

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
            this.GetOneEnchere(new Enchere(7, DateTime.Now, DateTime.Now, 0, 0, 0));
        }


        #endregion

        #region Getters/Setters
        public ObservableCollection<Enchere> MaListeEnchere { get => _maListeEnchere; set => _maListeEnchere = value; }

        #endregion

        #region Methodes
        public async void GetOneEnchere(Enchere uneEnchere)
        {
            Enchere.CollClasse.Clear();
            MaListeEnchere = await _apiServices.GetOneAsync<Enchere>
                   ("api/getEnchere", Enchere.CollClasse, uneEnchere);
        }
        #endregion
    }
}

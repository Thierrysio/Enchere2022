using Enchere2022.Modeles;
using Enchere2022.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enchere2022.VuesModeles
{
    class InscriptionVueModele : BaseVueModele
    {

        #region Attributs

        private readonly Api _apiServices = new Api();
        private User _monUser;
        #endregion

        #region Constructeurs

        public InscriptionVueModele()
        {
        }

        #endregion

        #region Getters/Setters
        public User MonUser
        {
            get { return _monUser; ; }
            set { SetProperty(ref _monUser, value); }
        }

        #endregion

        #region Methodes
        public async void PostUser(User unUser)
        {

            int resultat = await _apiServices.PostAsync<User>(unUser, "api/postUser");
        }


        #endregion

    }
}

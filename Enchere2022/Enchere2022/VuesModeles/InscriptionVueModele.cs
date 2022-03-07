using Enchere2022.Modeles;
using Enchere2022.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enchere2022.VuesModeles
{
    class InscriptionVueModele : BaseVueModele
    {

            #region Attributs

        private readonly Api _apiServices = new Api();

        #endregion

        #region Constructeurs

        public InscriptionVueModele()
        {
            PostUser(new User("tes1t", "tes1t", "test", "test"));
        }

        #endregion

        #region Getters/Setters

        #endregion

        #region Methodes
        public async void PostUser(User unUser)
        {
            
            int resultat = await _apiServices.PostAsync<User>(unUser, "api/postUser");
        }
        #endregion

    }
}

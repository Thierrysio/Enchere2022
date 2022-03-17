using Enchere2022.Modeles;
using Enchere2022.Services;
using System;
using System.Collections.Generic;
using System.Text;
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
            //PostUser(new User("tes1t", "tes1t", "test", "test"));
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

        public async Task<User> GetUser( string email,string password)
        {
            return await _apiServices.GetOneAsync<User>("api/getUserByMailAndPass", User.CollClasse, email,password);
        }
        #endregion

    }
}

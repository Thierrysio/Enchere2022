using Enchere2022.Modeles;
using Enchere2022.Services;
using Enchere2022.Vues;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Enchere2022.VuesModeles
{
    class AuthentificationVueModele : BaseVueModele
    {
        #region Attributs
        private readonly Api _apiServices = new Api();
        private string _email;
        private string _password;
        private bool auth = false;

        #endregion

        #region Constructeurs

        public AuthentificationVueModele()
        {
        }

        #endregion

        #region Getters/Setters
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        #endregion

        #region Methodes
        public async void ActionPageAuthentification()
        {
            User unUser = new User(Email, Password, "nd", "nd",0);
            unUser = await _apiServices.GetOneAsync<User>("api/getUserByMailAndPass", User.CollClasse, unUser);

            if (unUser != null )
            {
                auth = true;
                Storage.StockerMotDePasse(unUser.Id.ToString());
                Application.Current.MainPage = new EnchereVue();

            }
            else
            {
                auth = false;
                await Application.Current.MainPage.DisplayAlert("Login No", "Echec", "OK");
            }
            #endregion
        }
    }
}

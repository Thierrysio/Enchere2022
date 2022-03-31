using Enchere2022.Modeles;
using Enchere2022.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Enchere2022.VuesModeles
{
    class GagnantVueModele : BaseVueModele
    {
        #region Attributs
        private readonly Api _apiServices = new Api();
        User _unUser;

        #endregion

        #region Constructeurs

        public GagnantVueModele(string param)
        {
            this.GetGagnant(param);
        }

        #endregion

        #region Getters/Setters

        public User UnUser
        {
            get
            {
                return _unUser;
            }
            set
            {
                SetProperty(ref _unUser, value);
            }
        }


        #endregion

        #region Methodes

        public async void GetGagnant(string param)
        {
            UnUser = await _apiServices.GetOneAsyncID<User>("api/getGagnant", User.CollClasse, param );
            
            User.CollClasse.Clear();
        }

        #endregion
    }
}

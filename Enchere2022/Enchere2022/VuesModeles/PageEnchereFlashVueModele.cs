using Enchere2022.Modeles;
using Enchere2022.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Essentials;

namespace Enchere2022.VuesModeles
{
    class PageEnchereFlashVueModele : BaseVueModele
    {
        #region Attributs
        private readonly Api _apiServices = new Api();

        Enchere _monEnchere;
        private string _bName;
        private Color _bColor;
        private string _bNameParticiper;
        private Color _bColorParticiper;
        private string _bIsVisibleParticiper;
        private string _photo;
        #endregion

        #region Constructeurs

        public PageEnchereFlashVueModele(Enchere param)
        {
            MonEnchere = param;
            BName = "Jouer";
            BColor = Color.DarkRed;
            BNameParticiper = "Participer";
            BColorParticiper = Color.OrangeRed;
            this.GetParticiper();
        }

        #endregion

        #region Getters/Setters
        public Enchere MonEnchere
        {
            get { return _monEnchere; }
            set { SetProperty(ref _monEnchere, value);}
        }
        public string BName
        {
            get => _bName;
            set { SetProperty(ref _bName, value); }
        }
        public Color BColor
        {
            get => _bColor;
            set { SetProperty(ref _bColor, value); }
        }
        public string BNameParticiper
        {
            get => _bNameParticiper;
            set { SetProperty(ref _bNameParticiper, value); }
        }
        public Color BColorParticiper
        {
            get => _bColorParticiper;
            set { SetProperty(ref _bColorParticiper, value); }
        }
        public string BIsVisibleParticiper
        {
            get => _bIsVisibleParticiper;
            set { SetProperty(ref _bIsVisibleParticiper, value); }
        }

        public string Photo { 
            get => _photo; 
            set { SetProperty(ref _photo, value); }
        }
        #endregion

        #region Methodes
        public async void Participer()
        {
            EnchereFlash uneEnchereFlash = new EnchereFlash("", await SecureStorage.GetAsync("ID"), MonEnchere.Id.ToString(), "", false, "");

            int resultat = await _apiServices.PostAsync<EnchereFlash>(uneEnchereFlash, "api/postPlayerFlash");

            if (resultat != 0) this.GetParticiper();
        }
        public void Jouer()
        {

        }
        public async void GetParticiper()
        {
            EnchereFlash uneEnchereFlash = new EnchereFlash("", await SecureStorage.GetAsync("ID"),MonEnchere.Id.ToString(), "",false,"");
            EnchereFlash monuser = await _apiServices.GetOneAsync<EnchereFlash>("api/getPlayerFlashByID", EnchereFlash.CollClasse,uneEnchereFlash);
            if(monuser == null)
            { BIsVisibleParticiper = "true"; }
            else 
            { BIsVisibleParticiper = "false"; }
        }
        #endregion
    }
}

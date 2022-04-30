using Enchere2022.Modeles;
using Enchere2022.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Enchere2022.VuesModeles
{
    class PageEnchereFlashVueModele : BaseVueModele
    {
        #region Attributs
        private readonly Api _apiServices = new Api();
        public DecompteTimer tmps;
        private int _tempsRestantJour;
        private int _tempsRestantHeures;
        private int _tempsRestantMinutes;
        private int _tempsRestantSecondes;

        Enchere _monEnchere;
        private string _bName;
        private Color _bColor;
        private string _bNameParticiper;
        private Color _bColorParticiper;
        private string _bIsVisibleParticiper;
        private string _photo;
        private string _prixActuel;
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
            this.GetValeurActuelle();
        }

        #endregion

        #region Getters/Setters
        private bool OnCancel = false;

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
        public string PrixActuel
        {
            get { return _prixActuel; }
            set { SetProperty(ref _prixActuel, value); }
        }
        public int TempsRestantHeures
        {
            get { return _tempsRestantHeures; }
            set { SetProperty(ref _tempsRestantHeures, value); }
        }
        public int TempsRestantJour
        {
            get { return _tempsRestantJour; }
            set { SetProperty(ref _tempsRestantJour, value); }
        }
        public int TempsRestantMinutes
        {
            get { return _tempsRestantMinutes; }
            set { SetProperty(ref _tempsRestantMinutes, value); }
        }
        public int TempsRestantSecondes
        {
            get { return _tempsRestantSecondes; }
            set { SetProperty(ref _tempsRestantSecondes, value); }
        }
        #endregion

        #region Methodes
        public async void Participer()
        {
            EnchereFlash uneEnchereFlash = new EnchereFlash("", await SecureStorage.GetAsync("ID"), MonEnchere.Id.ToString(), "", false, "",MonEnchere.TableauFlash);

            int resultat = await _apiServices.PostAsync<EnchereFlash>(uneEnchereFlash, "api/postPlayerFlash");

            if (resultat != 0) this.GetParticiper();
        }
        public void Jouer()
        {

        }
        public async void GetParticiper()
        {
            EnchereFlash uneEnchereFlash = new EnchereFlash("", await SecureStorage.GetAsync("ID"),MonEnchere.Id.ToString(), "",false,"","");
            EnchereFlash monuser = await _apiServices.GetOneAsync<EnchereFlash>("api/getPlayerFlashByID", EnchereFlash.CollClasse,uneEnchereFlash);
            if(monuser == null)
            { BIsVisibleParticiper = "true"; }
            else 
            { BIsVisibleParticiper = "false"; }
        }
        public async void Rencherir()
        {
            EnchereFlash uneEnchereFlash = new EnchereFlash("", await SecureStorage.GetAsync("ID"), MonEnchere.Id.ToString(), "", false, "",MonEnchere.TableauFlash);

            int resultat = await _apiServices.PostAsync<EnchereFlash>(uneEnchereFlash, "api/postEncherirFlashManuel");
            uneEnchereFlash = await _apiServices.GetOneAsync<EnchereFlash>("api/getPlayerFlashByID", EnchereFlash.CollClasse, uneEnchereFlash);
            uneEnchereFlash = await _apiServices.GetOneAsync<EnchereFlash>("api/getJoueurActif", EnchereFlash.CollClasse, uneEnchereFlash);

        }
        public async void RencherirJePasse()
        {
            EnchereFlash uneEnchereFlash = new EnchereFlash("", await SecureStorage.GetAsync("ID"), MonEnchere.Id.ToString(), "", false, "", MonEnchere.TableauFlash);

            int resultat = await _apiServices.PostAsync<EnchereFlash>(uneEnchereFlash, "api/postEncherirFlashJePasse");
            uneEnchereFlash = await _apiServices.GetOneAsync<EnchereFlash>("api/getPlayerFlashByID", EnchereFlash.CollClasse, uneEnchereFlash);
            uneEnchereFlash = await _apiServices.GetOneAsync<EnchereFlash>("api/getJoueurActif", EnchereFlash.CollClasse, uneEnchereFlash);

        }
        public void GetValeurActuelle()
        {
            Task.Run(async () =>
            {
                while (OnCancel == false)
                {
                    Encherir resultat = await _apiServices.GetOneAsyncID<Encherir>("api/getActualPrice", Encherir.CollClasse, MonEnchere.Id.ToString());
                    PrixActuel = resultat.PrixEnchere.ToString();
                    Encherir.CollClasse.Clear();
                    Thread.Sleep(2000);
                }

            });


        }
        public void GestionPhaseEncherir()
        {
           tmps = new DecompteTimer();
            DateTime datefin = DateTime.Now.AddSeconds(30);
            TimeSpan interval = datefin - DateTime.Now;
            tmps.Start(interval);
            this.GetTimerRemaining();
        }
        public void GetTimerRemaining()
        {
            Task.Run(async () =>
            {

                while (OnCancel == false)
                {
                    TempsRestantJour = tmps.TempsRestant.Days;
                    TempsRestantHeures = tmps.TempsRestant.Hours;
                    TempsRestantMinutes = tmps.TempsRestant.Minutes;
                    TempsRestantSecondes = tmps.TempsRestant.Seconds;

                    if (tmps.TempsRestant <= TimeSpan.Zero)
                    {
                        tmps.Stop();
                    }
                }

            });


        }
        #endregion
    }
}

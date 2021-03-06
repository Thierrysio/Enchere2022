using Enchere2022.Modeles;
using Enchere2022.Services;
using Enchere2022.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Enchere2022.VuesModeles
{
    class PageEnchereVueModele : BaseVueModele
    {
        #region attributs
        private readonly Api _apiServices = new Api();
        public DecompteTimer tmps;
        private Enchere _monEnchere;
        private int _tempsRestantJour;
        private int _tempsRestantHeures;
        private int _tempsRestantMinutes;
        private int _tempsRestantSecondes;
        private ObservableCollection<Encherir> _maListeSixDernieresEncheres;
        private Encherir _prixActuel;
        private string _idUser;
        private float _plafond;
        private float _saisieSecondes;
        private User _unUser;
        private bool _visibleGagnant;
        public bool OnCancel = false;

        #endregion
        #region Constructeurs

        public PageEnchereVueModele(Enchere param)
        {
            
            _monEnchere = param;
            tmps = new DecompteTimer();
            DateTime datefin = param.Datefin;
            TimeSpan interval = datefin - DateTime.Now;
            tmps.Start(interval);

            
            this.GetTimerRemaining();
            this.GetValeurActuelle();
            this.SetEnchereAuto();
            this.SixDernieresEncheres();
            this.GetGagnant(MonEnchere.Id.ToString());
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

        public Enchere MonEnchere
        {
            get
            {
                return _monEnchere;
            }
            set
            {
                SetProperty(ref _monEnchere, value);
            }
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

        public Encherir PrixActuel
        {
            get { return _prixActuel; }
            set { SetProperty(ref _prixActuel, value); }
        }

        public string IdUser
        {
            get => _idUser;
            set => _idUser = value;
        }
        public ObservableCollection<Encherir> MaListeSixDernieresEncheres
        {
            get => _maListeSixDernieresEncheres;
            set { SetProperty(ref _maListeSixDernieresEncheres, value); }
        }

        public float Plafond
        {
            get => _plafond;
            set { SetProperty(ref _plafond, value); }
        }

        public float SaisieSecondes
        {
            get => _saisieSecondes;
            set { SetProperty(ref _saisieSecondes, value); }
        }
        public bool VisibleGagnant
        { 
             get => _visibleGagnant;
            set
            {
                SetProperty(ref _visibleGagnant, value);
            }
        }
    #endregion
    #region methodes
        public   void GetTimerRemaining()
        {
           



           Task.Run(async() =>
                        {

                            while (OnCancel==false)
                            {
                                TempsRestantJour = tmps.TempsRestant.Days;
                                TempsRestantHeures = tmps.TempsRestant.Hours;
                                TempsRestantMinutes = tmps.TempsRestant.Minutes;
                                TempsRestantSecondes = tmps.TempsRestant.Seconds;

                                if (tmps.TempsRestant <= TimeSpan.Zero)
                                {
                                    OnCancel = true;
                                }
                            }

                        });


        }
        public void GetValeurActuelle()
        {
            Task.Run(async () =>
            {
                while (OnCancel == false)
                {
                    PrixActuel = await _apiServices.GetOneAsyncID<Encherir>("api/getActualPrice", Encherir.CollClasse, MonEnchere.Id.ToString());
                    Encherir.CollClasse.Clear();
                    Thread.Sleep(2000);
                }

            });


        }
        public void SixDernieresEncheres()
        {
            Task.Run(async () =>
            {
                while (OnCancel == false)
                {
                    Encherir.CollClasse.Clear();
                    MaListeSixDernieresEncheres = await _apiServices.GetAllAsyncID<Encherir>("api/getLastSixOffer", Encherir.CollClasse, "Id", MonEnchere.Id);

                    Thread.Sleep(2000);
                }
            });
        }
        public void SetEnchereAuto()
        {

            Task.Run(async () =>
            {
                IdUser = await SecureStorage.GetAsync("ID");

                while (OnCancel == false)
                {

                    if (tmps.TempsRestant.TotalSeconds < SaisieSecondes)
                    {
                        if (Plafond > 0)
                        {
                            if (PrixActuel != null && PrixActuel.Id != int.Parse(IdUser) && PrixActuel.PrixEnchere < Plafond)
                            {
                                float paramValeur = PrixActuel.PrixEnchere + 1;
                                int resultat = await _apiServices.PostAsync<Encherir>(new Encherir(paramValeur, int.Parse(IdUser), MonEnchere.Id, 0, ""), "api/postEncherir");

                            }
                        }
                        else
                        {
                            if (PrixActuel != null && PrixActuel.Id != int.Parse(IdUser))
                            {
                                float paramValeur = PrixActuel.PrixEnchere + 1;
                                int resultat = await _apiServices.PostAsync<Encherir>(new Encherir(paramValeur, int.Parse(IdUser), MonEnchere.Id, 0, ""), "api/postEncherir");

                            }
                        }
                    }
                    Thread.Sleep(1000);
                }
            });
        }
        public async void EncherirManuel(float param)
        {
            IdUser = await SecureStorage.GetAsync("ID");

            if (PrixActuel != null)
            {
                int resultat = await _apiServices.PostAsync<Encherir>(new Encherir(param, int.Parse(IdUser), MonEnchere.Id, 0, ""), "api/postEncherir");

            }
        }
        public void GetPlafond(string param)
        {
            Plafond = float.Parse(param);
        }
        public void GetSecondes(string param)
        {
            SaisieSecondes = float.Parse(param);

        }
        public void GetGagnant(string param)
        {
            bool fin = false;
            Task.Run(async () =>
            {
                while (fin == false)
                {
                    if(tmps.TempsRestant <= TimeSpan.Zero)  UnUser = await _apiServices.GetOneAsyncID<User>("api/getGagnant", User.CollClasse, param);
                    if (UnUser != null)
                    {
                        User.CollClasse.Clear();
                        VisibleGagnant = true;
                        fin = true;
                    }
                }
            });


        }
        #endregion

    }
}

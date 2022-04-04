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
    class PageEnchereInverseVueModele :BaseVueModele
    {
        #region attributs
        private readonly Api _apiServices = new Api();
        private DecompteTimer tmps;
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


        #endregion
        #region Constructeurs

        public PageEnchereInverseVueModele(Enchere param)
        {
            _monEnchere = param;

            tmps = new DecompteTimer();
            this.GetTimerRemaining(param.Datefin);
            this.GetValeurActuelle();
            this.SetEnchereAuto();
        }
        #endregion
        #region Getters/Setters

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
        #endregion
        #region methodes
        public  void GetTimerRemaining(DateTime param)
        {
            DateTime datefin = param;
            TimeSpan interval = datefin - DateTime.Now;


            var task = Task.Run( () =>
            {
                tmps.Start(interval);
                while (true)
                {
                    TempsRestantJour = tmps.TempsRestant.Days;
                    TempsRestantHeures = tmps.TempsRestant.Hours;
                    TempsRestantMinutes = tmps.TempsRestant.Minutes;
                    TempsRestantSecondes = tmps.TempsRestant.Seconds;

                }

            });


        }
        public void SetGagnant()
        {
            Application.Current.MainPage = new GagnantVue(MonEnchere.Id.ToString());

        }
        public void GetValeurActuelle()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    PrixActuel = await _apiServices.GetOneAsyncID<Encherir>("api/getActualPrice", Encherir.CollClasse, MonEnchere.Id.ToString());
                    Encherir.CollClasse.Clear();
                    Thread.Sleep(20000);
                }

            });


        }


        public void SetEnchereAuto()
        {

            Task.Run(async () =>
            {
                IdUser = await SecureStorage.GetAsync("ID");

                while (true)
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
        #endregion

    }
}

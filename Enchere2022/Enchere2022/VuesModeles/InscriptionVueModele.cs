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
        private int _tempsRestantHeures;
        private int _tempsRestantMinutes;
        private int _tempsRestantSecondes;


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

        public int TempsRestantHeures
        {
            get { return _tempsRestantHeures; }
            set { SetProperty(ref _tempsRestantHeures, value); }
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
        public async void PostUser(User unUser)
        {
            
            int resultat = await _apiServices.PostAsync<User>(unUser, "api/postUser");
        }

        public async Task<User> GetUser( string email,string password)
        {
            return await _apiServices.GetOneAsync<User>("api/getUserByMailAndPass", User.CollClasse, email,password);
        }

        public  void GetTimerRemaining()
        {
            DateTime datefin = new DateTime(2022, 3, 21, 16, 58, 0);
            TimeSpan interval = datefin - DateTime.Now;
            DecompteTimer tmps = new DecompteTimer();
            
            Task.Run(() =>
            { 
            tmps.Start(interval);
             while (tmps.TempsRestant > TimeSpan.Zero)
                {
                    TempsRestantHeures = tmps.TempsRestant.Hours;
                    TempsRestantMinutes = tmps.TempsRestant.Minutes;
                    TempsRestantSecondes = tmps.TempsRestant.Seconds;
                    Thread.Sleep(800);
                }
            });
        }
        #endregion

    }
}

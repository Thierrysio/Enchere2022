using Enchere2022.Modeles;
using Enchere2022.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Enchere2022.VuesModeles
{
    class EnchereVueModele : BaseVueModele
    {
        #region Attributs
        private ObservableCollection<Enchere> _maListeEncheres;
        private ObservableCollection<Enchere> _maListeEncheresEnCoursTypeClassique;
        private ObservableCollection<Enchere> _maListeEncheresEnCoursTypeInverse;
        private ObservableCollection<Enchere> _maListeEncheresEnCoursTypeFlash;
        private bool _visibleEnchereEnCoursTypeClassique = true;
        private bool _visibleEnchereEnCoursTypeInverse = true;
        private bool _visibleEnchereEnCoursTypeFlash = true;

        private readonly Api _apiServices = new Api();

        #endregion
        #region Constructeur
        public EnchereVueModele()
        {
            VisibleEnchereEnCoursTypeClassique = true;
            VisibleEnchereEnCoursTypeInverse = false;
            VisibleEnchereEnCoursTypeFlash = false;

            GetListeEnCheresEnCoursTypeClassique(1);
            GetListeEncheresEnCoursTypeInverse(2);
            GetListeEncheresEnCoursTypeFlash(3);
        }


        #endregion
        #region Getters/Setters
        public ObservableCollection<Enchere> MaListeEncheres
        {
            get { return _maListeEncheres; }
            set { SetProperty(ref _maListeEncheres, value); }
        }

        public ObservableCollection<Enchere> MaListeEncheresEnCoursTypeClassique
        {
            get { return _maListeEncheresEnCoursTypeClassique; }
            set { SetProperty(ref _maListeEncheresEnCoursTypeClassique, value); }
        }

        public ObservableCollection<Enchere> MaListeEncheresEnCoursTypeInverse
        {
            get { return _maListeEncheresEnCoursTypeInverse; }
            set { SetProperty(ref _maListeEncheresEnCoursTypeInverse, value); }
        }

        public ObservableCollection<Enchere> MaListeEncheresEnCoursTypeFlash
        {
            get { return _maListeEncheresEnCoursTypeFlash; }
            set { SetProperty(ref _maListeEncheresEnCoursTypeFlash, value); }
        }

        public bool VisibleEnchereEnCoursTypeClassique
        {
            get { return _visibleEnchereEnCoursTypeClassique; }
            set { SetProperty(ref _visibleEnchereEnCoursTypeClassique, value); }
        }

        public bool VisibleEnchereEnCoursTypeInverse
        {
            get { return _visibleEnchereEnCoursTypeInverse; }
            set { SetProperty(ref _visibleEnchereEnCoursTypeInverse, value); }
        }
        public bool VisibleEnchereEnCoursTypeFlash
        {
            get { return _visibleEnchereEnCoursTypeFlash; }
            set { SetProperty(ref _visibleEnchereEnCoursTypeFlash, value); }
        }


        #endregion
        #region Méthode
        public async void GetListeEncheres()
        {

            MaListeEncheres = await _apiServices.GetAllAsync<Enchere>
                ("api/getEncheresEnCours", Enchere.CollClasse);
            Enchere.CollClasse.Clear();

        }
        public async void GetListeEnCheresEnCoursTypeClassique(int id)
        {
            MaListeEncheresEnCoursTypeClassique = await _apiServices.GetAllAsyncID<Enchere>
                ("api/getEncheresEnCours", Enchere.CollClasse, "IdTypeEnchere", id);
            Enchere.CollClasse.Clear();

        }

        public async void GetListeEncheresEnCoursTypeInverse(int id)
        {
            MaListeEncheresEnCoursTypeInverse = await _apiServices.GetAllAsyncID<Enchere>
                ("api/getEncheresEnCours", Enchere.CollClasse, "IdTypeEnchere", id);
            Enchere.CollClasse.Clear();
        }
        public async void GetListeEncheresEnCoursTypeFlash(int id)
        {
            MaListeEncheresEnCoursTypeFlash = await _apiServices.GetAllAsyncID<Enchere>
                ("api/getEncheresEnCours", Enchere.CollClasse, "IdTypeEnchere", id);
            Enchere.CollClasse.Clear();
        }
        #endregion
    }
}

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
        private readonly Api _apiServices = new Api();
        private ObservableCollection<Enchere> _maListeEnchere;
        private bool _visibleEnchereEnCoursTypeClassique = false;
        #endregion

        #region Constructeurs

        public EnchereVueModele()
        {
            VisibleEnchereEnCoursTypeClassique = false;
            GetListeEncheres();

        }


        #endregion

        #region Getters/Setters
        public ObservableCollection<Enchere> MaListeEnchere 
        {
            get { return _maListeEnchere; }
            set { SetProperty(ref _maListeEnchere, value); }
        }

        public bool VisibleEnchereEnCoursTypeClassique
        {
            get { return _visibleEnchereEnCoursTypeClassique; }
            set { SetProperty(ref _visibleEnchereEnCoursTypeClassique, value); }
        }
        #endregion

        #region Methodes
        public async void GetListeEncheres()
        {
            VisibleEnchereEnCoursTypeClassique = false;
            MaListeEnchere = await _apiServices.GetAllAsync<Enchere>
                ("api/getEncheresEnCours", Enchere.CollClasse);
            Enchere.CollClasse.Clear();

        }
        #endregion
    }
}

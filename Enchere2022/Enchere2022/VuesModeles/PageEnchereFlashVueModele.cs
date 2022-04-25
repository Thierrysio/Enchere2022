using Enchere2022.Modeles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Enchere2022.VuesModeles
{
    class PageEnchereFlashVueModele : BaseVueModele
    {
        #region Attributs
        Enchere _monEnchere;
        private string _bName;
        private Color _bColor;
        private string _bNameParticiper;
        private Color _bColorParticiper;
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

        public string Photo { 
            get => _photo; 
            set { SetProperty(ref _photo, value); }
        }
        #endregion

        #region Methodes

        #endregion
    }
}

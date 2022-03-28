using Enchere2022.Modeles;
using Enchere2022.VuesModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enchere2022.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEnchereVue : ContentPage
    {

        PageEnchereVueModele VuesModele;
        public PageEnchereVue(Enchere param)
        {
            InitializeComponent();
            BindingContext = VuesModele = new PageEnchereVueModele(param);

        }

        private void ButtonValiderEnchere_Clicked(object sender, EventArgs e)
        {
            VuesModele.EncherirManuel(float.Parse(SaisieEnchere.Text));
        }
    }
}
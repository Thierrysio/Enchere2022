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
    public partial class PageEnchereInverseVue : ContentPage
    {
        PageEnchereInverseVueModele  VueModele;
        public PageEnchereInverseVue(Enchere param)
        {
            InitializeComponent();
            BindingContext = VueModele = new PageEnchereInverseVueModele(param);
        }

        protected override void OnAppearing()

        {
            
            base.OnAppearing();

        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new EnchereVue();

        }



        private void ButtonValiderEnchere_Clicked(object sender, EventArgs e)
        {
            if (SaisieEnchere.Text != null) VueModele.EncherirManuel(float.Parse(SaisieEnchere.Text));

        }
    }
}
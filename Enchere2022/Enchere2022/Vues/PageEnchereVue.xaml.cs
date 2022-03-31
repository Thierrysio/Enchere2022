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
          if(SaisieEnchere.Text != null)  VuesModele.EncherirManuel(float.Parse(SaisieEnchere.Text));
        }

        private void SaisiePlafond_Unfocused(object sender, FocusEventArgs e)
        {
            if (SaisiePlafond.Text != null) VuesModele.GetPlafond(SaisiePlafond.Text);
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new EnchereVue();

        }

        private void SaisieSecondes_Unfocused(object sender, FocusEventArgs e)
        {
            if (SaisieSecondes.Text != null) VuesModele.GetSecondes(SaisieSecondes.Text);

        }

        private async void Remonte_Clicked(object sender, EventArgs e)
        {
            await remote.ScrollToAsync(0, 0, true);
        }
    }
}
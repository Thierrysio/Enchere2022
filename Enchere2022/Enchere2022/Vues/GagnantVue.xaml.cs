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
    public partial class GagnantVue : ContentPage
    {
        GagnantVueModele VueModele;
        public GagnantVue(string param)
        {
            InitializeComponent();
            BindingContext = VueModele = new GagnantVueModele(param);
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new EnchereVue();

        }
    }
}
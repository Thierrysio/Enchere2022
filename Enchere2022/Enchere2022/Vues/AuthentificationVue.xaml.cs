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
    public partial class AuthentificationVue : ContentPage
    {
        AuthentificationVueModele vueModele;
        public AuthentificationVue()
        {
            InitializeComponent();
            BindingContext = vueModele = new AuthentificationVueModele();
        }

        private void authentification_Clicked(object sender, EventArgs e)
        {
            vueModele.ActionPageAuthentification();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void EntryEmail_Unfocused(object sender, FocusEventArgs e)
        {
            EntryPassword.Focus();
        }

        private void EntryPassword_Unfocused(object sender, FocusEventArgs e)
        {

        }
    }
}
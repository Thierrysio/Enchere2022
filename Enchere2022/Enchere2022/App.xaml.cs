using Enchere2022.Vues;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enchere2022
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // page de demarrage
            MainPage = new ListeProduitVue();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

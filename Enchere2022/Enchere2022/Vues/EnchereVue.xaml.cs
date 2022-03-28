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
    public partial class EnchereVue : ContentPage
    {
        EnchereVueModele vueModel;
        public EnchereVue()
        {
            InitializeComponent();
            BindingContext = vueModel = new EnchereVueModele();

        }

        private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var current = (Enchere)e.CurrentSelection.FirstOrDefault();
            Application.Current.MainPage = new PageEnchereVue(current);
        }

        private void classique_Clicked(object sender, EventArgs e)
        {
            vueModel.VisibleEnchereEnCoursTypeClassique = true;
            vueModel.VisibleEnchereEnCoursTypeInverse = false;
            vueModel.VisibleEnchereEnCoursTypeFlash = false;

        }

        private void inverse_Clicked(object sender, EventArgs e)
        {
            vueModel.VisibleEnchereEnCoursTypeClassique = false;
            vueModel.VisibleEnchereEnCoursTypeInverse = true;
            vueModel.VisibleEnchereEnCoursTypeFlash = false;
        }

        private void flash_Clicked(object sender, EventArgs e)
        {
            vueModel.VisibleEnchereEnCoursTypeClassique = false;
            vueModel.VisibleEnchereEnCoursTypeInverse = false;
            vueModel.VisibleEnchereEnCoursTypeFlash = true;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await remote.ScrollToAsync(0, 0, true);

        }
    }
}
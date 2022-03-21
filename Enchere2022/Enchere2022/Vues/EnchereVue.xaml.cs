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

        private void EnvoiCommande_Clicked(object sender, EventArgs e)
        {
            vueModel.GetOneEnchere(new Enchere(7, DateTime.Now, DateTime.Now, 0,null));
            this.BackgroundColor = Color.Red;
        }

        private void EnvoiCommande2_Clicked(object sender, EventArgs e)
        {
        }  

        private void CollViews_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                var  current = (Enchere) e.CurrentSelection.FirstOrDefault();

        
            
        }
    }
}
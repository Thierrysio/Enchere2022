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
    public partial class PageEnchereFlashVue : ContentPage
    {
        PageEnchereFlashVueModele VuesModele;
        public PageEnchereFlashVue()
        {
            InitializeComponent();
            BindingContext = VuesModele = new PageEnchereFlashVueModele();
            InitialialiserGrille();
        }
        public void InitialialiserGrille()
        {
            Grid grid = new Grid
            {

                RowSpacing = 0,
                ColumnSpacing = 0,
                RowDefinitions =
            {
                new RowDefinition  { Height = new GridLength(80) },
                new RowDefinition  { Height = new GridLength(80) },
                new RowDefinition  { Height = new GridLength(80) },
                new RowDefinition  { Height = new GridLength(80) }
            },
                ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(80) },
                new ColumnDefinition { Width = new GridLength(80) },
                new ColumnDefinition { Width = new GridLength(80) },
                new ColumnDefinition { Width = new GridLength(80) }
            }
            };

            // Row 0
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    var button = new Button();
                    button.Text = i.ToString();
                    button.Clicked += OnButtonClicked;

                    grid.Children.Add(button,j,i);
                }

            }
        


            Title = "Grid alignment demo";
            Content = grid;
        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button b = (Button)sender;
            await  b.RelRotateTo(360, 1000);
        }
    }
}
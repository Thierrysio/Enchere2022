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

                RowSpacing = 1,
                ColumnSpacing = 1,
                RowDefinitions =
            {
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition()
            },
                ColumnDefinitions =
            {
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition()
            }
            };

            // Row 0
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; i++)
                {
                    grid.Children.Add(new BoxView
                    {
                        Color = Color.AliceBlue
                    }, i , j);
                }
            }
    

            Title = "Grid alignment demo";
            Content = grid;
        }
    }
}
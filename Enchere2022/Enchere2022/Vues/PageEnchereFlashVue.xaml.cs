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
    public partial class PageEnchereFlashVue : ContentPage
    {


        PageEnchereFlashVueModele VuesModele;
        public PageEnchereFlashVue(Enchere param)
        {
            InitializeComponent();
            BindingContext = VuesModele = new PageEnchereFlashVueModele(param);
            initialiserStackLayout();

        }
        public Label InitialiserLeTitre()
        {
            Label labelTitre = new Label();
            labelTitre.Text = "Vente FLASH";
            labelTitre.FontAttributes = FontAttributes.Bold ;
            labelTitre.FontAttributes = FontAttributes.Italic;

            labelTitre.FontSize = 20;
            labelTitre.Margin = 20;
            labelTitre.HorizontalOptions = LayoutOptions.Center;
            labelTitre.TextColor = Color.Black;

            //labelTitre.SetBinding(Label.TextProperty, new Binding(VuesModele.MonEnchere.LeProduit.Nom));
            return labelTitre;
        }
        public RelativeLayout InitialiserGrille()
        {
            Image img = new Image();

            img.Source = ImageSource.FromFile(VuesModele.Photo);
            img.Aspect = Aspect.AspectFit;
            img.HeightRequest = 320;
            img.WidthRequest = 320;

            img.VerticalOptions = LayoutOptions.Start;
            img.HorizontalOptions = LayoutOptions.Center;

            StackLayout stack = new StackLayout();

            Grid grid = new Grid
            {

                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,

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
            grid.Children.Add(img);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    var button = new Button();
                    button.Text = i.ToString();
                    button.Clicked += OnButtonClicked;

                    grid.Children.Add(button, j, i);
                }

            }

            var relativeLayout = new RelativeLayout();

            relativeLayout.HorizontalOptions = LayoutOptions.Start;
            relativeLayout.VerticalOptions = LayoutOptions.StartAndExpand;

            relativeLayout.Children.Add(img,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            relativeLayout.Children.Add(grid,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            return relativeLayout;
        }
        public BoxView InitialiserBoxView()
        {
            BoxView boxview = new BoxView();
            boxview.Color = Color.Red;
            boxview.HeightRequest = 2;
            boxview.WidthRequest = 300;


            return boxview;
        }
        public Button InitialiserButtonParticiper()
        {
            var button = new Button();
            button.SetBinding(Button.TextProperty, new Binding("BNameParticiper"));
            button.SetBinding(Button.BackgroundColorProperty, new Binding("BColorParticiper"));
            button.TextColor = Color.White;
            button.CornerRadius = 15;
            button.Clicked += OnButtonParticiper;

            return button;
        }
        public Button InitialiserButtonJouer()
        {
            var button = new Button();
            button.SetBinding(Button.TextProperty, new Binding("BName"));
            button.SetBinding(Button.BackgroundColorProperty, new Binding("BColor"));
            button.TextColor = Color.White;
            button.CornerRadius = 15;
            button.Clicked += OnButtonJouer;

            return button;
        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button b = (Button)sender;
            await b.RelRotateTo(360, 1000);

            int x = Grid.GetRow(b);
            int y = Grid.GetColumn(b);

        }
        async void OnButtonJouer(object sender, EventArgs args)
        {

        }
        async void OnButtonParticiper(object sender, EventArgs args)
        {

        }
        public void initialiserStackLayout()
        {
            var rl = new RelativeLayout();
            rl.Children.Add(this.InitialiserLeTitre(),
               Constraint.Constant(0),
               Constraint.Constant(20),
               Constraint.RelativeToParent((parent) => { return parent.Width; }),
               Constraint.RelativeToParent((parent) => { return parent.Height; }));

            rl.Children.Add(this.InitialiserButtonParticiper(),
    Constraint.Constant(50),
    Constraint.Constant(80),
    Constraint.RelativeToParent((parent) => { return parent.Width - 100; }),
    Constraint.RelativeToParent((parent) => { return 50; }));

            rl.Children.Add(this.InitialiserGrille(),
                Constraint.Constant(0),
                Constraint.Constant(150),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            rl.Children.Add(this.InitialiserBoxView(),
                Constraint.Constant(0),
                Constraint.Constant(500),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return 2; }));

            rl.Children.Add(this.InitialiserButtonJouer(),
                Constraint.Constant(50),
                Constraint.Constant(530),
                Constraint.RelativeToParent((parent) => { return parent.Width - 100; }),
                Constraint.RelativeToParent((parent) => { return 50; }));

            ScrollView scrollView = new ScrollView { Content = rl };
            Content = scrollView;
        }
    }
}
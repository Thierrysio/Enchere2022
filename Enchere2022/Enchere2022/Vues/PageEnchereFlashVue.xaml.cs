using Enchere2022.Modeles;
using Enchere2022.Services;
using Enchere2022.VuesModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enchere2022.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEnchereFlashVue : ContentPage
    {
        private bool OnCancel = false;
        private readonly Api _apiServices = new Api();

        PageEnchereFlashVueModele VuesModele;
        public List<Button> ListeButton = new List<Button>();
        public PageEnchereFlashVue(Enchere param)
        {
            InitializeComponent();
            BindingContext = VuesModele = new PageEnchereFlashVueModele(param);
            initialiserStackLayout();
            GetJoueurActif();
        }
        public Label InitialiserLeTitre()
        {
            Label labelTitre = new Label();
            labelTitre.Text = "Vente FLASH";
            labelTitre.FontAttributes = FontAttributes.Bold;
            labelTitre.FontAttributes = FontAttributes.Italic;

            labelTitre.FontSize = 20;
            labelTitre.Margin = 20;
            labelTitre.HorizontalOptions = LayoutOptions.Center;
            labelTitre.TextColor = Color.Black;

            //labelTitre.SetBinding(Label.TextProperty, new Binding(VuesModele.MonEnchere.LeProduit.Nom));
            return labelTitre;
        }
        public Label InitialiserLePrix()
        {
            Label labelPrix = new Label();
            labelPrix.Text = "Vente FLASH";
            labelPrix.FontAttributes = FontAttributes.Bold;
            labelPrix.FontAttributes = FontAttributes.Italic;

            labelPrix.FontSize = 20;
            labelPrix.Margin = 20;
            labelPrix.HorizontalOptions = LayoutOptions.Center;
            labelPrix.TextColor = Color.Black;

            labelPrix.SetBinding(Label.TextProperty, new Binding("PrixActuel", stringFormat: "{0} euros"));
            
            return labelPrix;
        }
        public RelativeLayout InitialiserGrille()
        {
            Image img = new Image();

            img.Source = VuesModele.MonEnchere.LeProduit.Photo;
            img.Aspect = Aspect.AspectFit;
            img.HeightRequest = 325;
            img.WidthRequest = 325;

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

            string[] textSplit = VuesModele.MonEnchere.TableauFlash.Split(',');
            int nb = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var button = new Button();
                    button.Text = i.ToString();
                    if (textSplit[nb] == "0")
                    { button.IsVisible = true; }
                    else
                    { button.IsVisible = false; }
                    button.Clicked += OnButtonClicked;

                    grid.Children.Add(button, j, i);
                    ListeButton.Add(button);
                    nb++;
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
            boxview.Color = Color.Aquamarine;
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
            button.SetBinding(Button.IsVisibleProperty, new Binding("BIsVisibleParticiper"));
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

            b.IsVisible = false;

            this.ReconstruireTableauFlash(ListeButton);
            this.BloquerLesCases(ListeButton);
            VuesModele.Rencherir();
            if (VuesModele.tmps != null && VuesModele.tmps.TempsRestant >= TimeSpan.Zero)
            {
                VuesModele.tmps.TempsRestant = TimeSpan.Zero;
                VuesModele.tmps.Stop();
            }


        }
        public void OnButtonJouer(object sender, EventArgs args)
        {
            VuesModele.Jouer();
        }
        public void OnButtonParticiper(object sender, EventArgs args)
        {
            VuesModele.Participer();
        }
        public void initialiserStackLayout()
        {
           
            rl.Children.Add(this.InitialiserLeTitre(),
                Constraint.Constant(0),
                Constraint.Constant(20),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            rl.Children.Add(this.InitialiserLePrix(),
               Constraint.Constant(0),
               Constraint.Constant(50),
               Constraint.RelativeToParent((parent) => { return parent.Width; }),
               Constraint.RelativeToParent((parent) => { return parent.Height; }));

            rl.Children.Add(this.InitialiserButtonParticiper(),
                Constraint.Constant(50),
                Constraint.Constant(80),
                Constraint.RelativeToParent((parent) => { return parent.Width - 100; }),
                Constraint.RelativeToParent((parent) => { return 50; }));

            rl.Children.Add(this.InitialiserGrille(),
                Constraint.Constant(0),
                Constraint.Constant(220),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            rl.Children.Add(this.InitialiserBoxView(),
                Constraint.Constant(0),
                Constraint.Constant(570),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return 2; }));

            rl.Children.Add(this.InitialiserButtonJouer(),
                Constraint.Constant(50),
                Constraint.Constant(590),
                Constraint.RelativeToParent((parent) => { return parent.Width - 100; }),
                Constraint.RelativeToParent((parent) => { return 50; }));

            ScrollView scrollView = new ScrollView { Content = rl };
            Content = scrollView;
        }
        public void ReconstruireTableauFlash(List<Button> param)
        {
            VuesModele.MonEnchere.TableauFlash = "";
            foreach (Button leButton in param)
            {
                if (leButton.IsVisible == true)
                { VuesModele.MonEnchere.TableauFlash += "0,"; }
                else
                { VuesModele.MonEnchere.TableauFlash += "1,"; }
            }

            VuesModele.MonEnchere.TableauFlash = VuesModele.MonEnchere.TableauFlash.Remove(31);
        }
        public  void BloquerLesCases(List<Button> param)
        {
            foreach (Button leButton in param)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    leButton.IsEnabled = false; 
                });

            }
        }
        public void DebloquerLesCases(List<Button> param)
        {
            foreach (Button leButton in param)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    leButton.IsEnabled = true;
                });

            }
        }
        public  void GetJoueurActif()
        {
            Task.Run(async () =>
            {
                while (OnCancel == false)
                {
                    EnchereFlash uneEnchereFlash = new EnchereFlash("", "",VuesModele.MonEnchere.Id.ToString(), "", false, "", "");
                    uneEnchereFlash = await _apiServices.GetOneAsync<EnchereFlash>("api/getJoueurActifActuel", EnchereFlash.CollClasse, uneEnchereFlash);
                    if (uneEnchereFlash != null)
                    {
                        if (uneEnchereFlash.IdUser == await SecureStorage.GetAsync("ID"))
                        {

                            if (VuesModele.tmps == null) VuesModele.GestionPhaseEncherir();
                            if (VuesModele.tmps != null && VuesModele.tmps.TempsRestant <= TimeSpan.Zero)
                            {
                                VuesModele.tmps = null;
                                BloquerLesCases(ListeButton);
                                VuesModele.RencherirJePasse();

                            }
                            else
                            {
                                DebloquerLesCases(ListeButton);
                            }
                        }
                        else
                        {
                            BloquerLesCases(ListeButton);
                        }
                    }
                    Thread.Sleep(5000);
                }
                
            });
        }

    }
}
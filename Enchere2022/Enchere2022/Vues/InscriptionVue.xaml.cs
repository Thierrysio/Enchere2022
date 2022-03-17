using Enchere2022.Interfaces;
using Enchere2022.Modeles;
using Enchere2022.VuesModeles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enchere2022.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;

namespace Enchere2022.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InscriptionVue : ContentPage
    {
        InscriptionVueModele Vuemodel;
        public InscriptionVue()
        {
            InitializeComponent();
            BindingContext = Vuemodel = new InscriptionVueModele();
        }



        private async void toto_ClickedAsync(object sender, EventArgs e)
        {
            string Photo64 = null;
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                if (stream != null)
                {
                    using (MemoryStream memory = new MemoryStream())
                    {

                        Photo64 = Services.Conversion.ConvertToBase64(stream);
                        
                    }

                }

                Vuemodel.PostUser(new User("gg1hhjhg2", "xjjfxi2x2x", "xx2ixijjxx", Photo64));


            }

    (sender as Button).IsEnabled = true;

        }

        private async void getImage_Clicked(object sender, EventArgs e)
        {
          User monUser = await Vuemodel.GetUser("tlg","tlg");

            byte[] Base64Stream = Convert.FromBase64String(monUser.Photo);
            image.Source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
        }



    }

}
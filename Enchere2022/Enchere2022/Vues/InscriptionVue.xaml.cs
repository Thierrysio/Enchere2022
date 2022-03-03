﻿using Enchere2022.VuesModeles;
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
    public partial class InscriptionVue : ContentPage
    {
        InscriptionVueModele Vuemodel;
        public InscriptionVue()
        {
            InitializeComponent();
            BindingContext = Vuemodel = new InscriptionVueModele();
        }
    }
}
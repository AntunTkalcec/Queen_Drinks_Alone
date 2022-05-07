using DamaPijeSama.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PovijestPage : ContentPage
    {
        private PovijestPageViewModel vm;
        public PovijestPage()
        {
            InitializeComponent();

            BindingContext = vm = new PovijestPageViewModel();
        }
    }
}
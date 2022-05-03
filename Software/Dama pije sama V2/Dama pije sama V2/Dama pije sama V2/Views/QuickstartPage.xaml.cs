using DamaPijeSama.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuickstartPage : ContentPage
    {
        QuickstartPageViewModel vm;
        private int cardCounter = 0;
        public QuickstartPage()
        {
            InitializeComponent();

            BindingContext = vm = new QuickstartPageViewModel();
        }

        private async void slikaKarte_RightSwiped(object sender, SwipedEventArgs e)
        {
            await vm.HandleSwipeCommand("Right");
            cardCounter++;
            await slikaKarte.TranslateTo(-10, 0, 25);
            await slikaKarte.TranslateTo(10, 0, 25);
            await slikaKarte.TranslateTo(-5, 0, 25);
            await slikaKarte.TranslateTo(5, 0, 25);
            await slikaKarte.TranslateTo(-2.5, 0, 25);
            await slikaKarte.TranslateTo(2.5, 0, 25);
            slikaKarte.TranslationX = 0;
        }

        private async void slikaKarte_UpSwiped(object sender, SwipedEventArgs e)
        {
            await vm.HandleSwipeCommand("Up");
            await slikaKarte.TranslateTo(0, -15, 125, Easing.Linear);
            await slikaKarte.TranslateTo(0, 0, 125, Easing.Linear);
            slikaKarte.TranslationY = 0;
        }
    }
}
using DamaPijeSama.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IgranjeSIgracimaPage : ContentPage
    {
        private readonly IgranjeSIgracimaPageViewModel vm;
        public IgranjeSIgracimaPage(List<Player> igraci)
        {
            InitializeComponent();

            BindingContext = vm = new IgranjeSIgracimaPageViewModel(this, igraci);
        }

        private async void slikaKarte_UpSwiped(object sender, SwipedEventArgs e)
        {
            await vm.HandleSwipeCommandAsync("Up");
            await slikaKarte.TranslateTo(0, -15, 125, Easing.Linear);
            await slikaKarte.TranslateTo(0, 0, 125, Easing.Linear);
            slikaKarte.TranslationY = 0;
        }

        private async void slikaKarte_RightSwiped(object sender, SwipedEventArgs e)
        {
            await vm.HandleSwipeCommandAsync("Right");
            await slikaKarte.TranslateTo(-10, 0, 25);
            await slikaKarte.TranslateTo(10, 0, 25);
            await slikaKarte.TranslateTo(-5, 0, 25);
            await slikaKarte.TranslateTo(5, 0, 25);
            await slikaKarte.TranslateTo(-2.5, 0, 25);
            await slikaKarte.TranslateTo(2.5, 0, 25);
            slikaKarte.TranslationX = 0;
        }
    }
}
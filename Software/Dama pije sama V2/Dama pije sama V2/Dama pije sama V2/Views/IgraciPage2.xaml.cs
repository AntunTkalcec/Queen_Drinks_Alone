using DamaPijeSama.ViewModels;
using System;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IgraciPage2 : ContentPage
    {
        private readonly IgraciPage2ViewModel vm;
        public IgraciPage2()
        {
            InitializeComponent();

            BindingContext = vm = new IgraciPage2ViewModel();
        }

        private async void PlusLabel_Tapped(object sender, EventArgs e)
        {
            vm.AddPlayer();
            PlayerCountLabel.CancelAnimations();           
            await PlayerCountLabel.TranslateTo(-10, 0, 50);
            await PlayerCountLabel.TranslateTo(10, 0, 50);
            await PlayerCountLabel.TranslateTo(-5, 0, 50);
            await PlayerCountLabel.TranslateTo(5, 0, 50);
            await PlayerCountLabel.TranslateTo(-2.5, 0, 50);
            await PlayerCountLabel.TranslateTo(-2.5, 0, 50);
            PlayerCountLabel.TranslationX = 0;
        }

        private async void PlayButton_Tapped(object sender, EventArgs e)
        {
            await PlayButton.ScaleTo(0.9, 125, Easing.Linear);
            await PlayButton.ScaleTo(1, 125, Easing.Linear);
            await vm.PlayGame();
        }

        private async void Entry_Focused(object sender, FocusEventArgs e)
        {
            await vm.ClearEntryText(sender as Entry);
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            if ((sender as Entry).Text == "")
            {
                (sender as Entry).Text = LocalizationResourceManager.Current["PlayerNameDefault"];
            }
        }

        private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            await vm.ChangePlayerName(sender as Entry);
        }
    }
}
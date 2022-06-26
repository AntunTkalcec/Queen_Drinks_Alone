using Dama_pije_sama_V2;
using DamaPijeSama.Views;
using MvvmHelpers.Commands;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DamaPijeSama.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private INavigation Navigation => Application.Current.MainPage.Navigation;

        public ICommand HelpIconTapped { get; }
        public ICommand HistoryButtonTapped { get; }
        public ICommand PlayersButtonTapped { get; }
        public ICommand QuickstartButtonTapped { get; }
        public ICommand SettingsButton { get; }
        public bool Clickable { get; set; } = true;

        public MainPageViewModel()
        {
            HelpIconTapped = new AsyncCommand(async () => await GoToAboutPageAsync());
            HistoryButtonTapped = new AsyncCommand(async () => await GoToHistoryPageAsync());
            PlayersButtonTapped = new AsyncCommand(async () => await GoToPlayersPageAsync());
            QuickstartButtonTapped = new AsyncCommand(async () => await GoToQuickStartPageAsync());
            SettingsButton = new AsyncCommand(async () => await GoToSettingsPageAsync());
        }

        private async Task GoToSettingsPageAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SettingsPage());
        }

        private async Task GoToQuickStartPageAsync()
        {
            Clickable = false;
            await Navigation.PushAsync(new QuickstartPage());
            Clickable = true;
        }

        private async Task GoToPlayersPageAsync()
        {
            Clickable = false;
            await Navigation.PushAsync(new IgraciPage2());
            Clickable = true;
        }

        private async Task GoToHistoryPageAsync()
        {
            Clickable = false;
            await Navigation.PushAsync(new PovijestPage());
            Clickable = true;
        }

        private async Task GoToAboutPageAsync()
        {
            Clickable = false;
            await Navigation.PushAsync(new AboutPage());
            Clickable = true;
        }
    }
}

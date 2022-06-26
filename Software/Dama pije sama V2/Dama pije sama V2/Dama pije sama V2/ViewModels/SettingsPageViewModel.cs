using DamaPijeSama.Views;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DamaPijeSama.ViewModels
{
    public class SettingsPageViewModel
    {
        public ICommand ChangeLanguage { get; }
        public ICommand HowToPlay { get; }
        public SettingsPageViewModel()
        {
            ChangeLanguage = new AsyncCommand(async () => await GoToChangeLangPage());
            HowToPlay = new AsyncCommand(async () => await GoToHowToPlayPage());
        }

        private async Task GoToHowToPlayPage()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new HowToPlayPage());
        }

        private async Task GoToChangeLangPage()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SetupPage());
        }
    }
}

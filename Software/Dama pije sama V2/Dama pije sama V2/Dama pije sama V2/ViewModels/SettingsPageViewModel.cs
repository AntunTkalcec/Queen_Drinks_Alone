using DamaPijeSama.Views;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DamaPijeSama.ViewModels
{
    public class SettingsPageViewModel
    {
        public ICommand ChangeLanguage { get; }

        public SettingsPageViewModel()
        {
            ChangeLanguage = new AsyncCommand(async () => await GoToChangeLangPage());
        }

        private async Task GoToChangeLangPage()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SetupPage());
        }
    }
}

using Dama_pije_sama_V2;
using DamaPijeSama.Services;
using MvvmHelpers.Commands;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DamaPijeSama.ViewModels
{
    public class SetupPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CroatianLanguage { get; }
        public ICommand EnglishLanguage { get; }
        public ICommand Start { get; }
        public bool StartBtnEnabled { get; set; } = false;
        public SetupPageViewModel()
        {
            CroatianLanguage = new AsyncCommand(async () => await SetLanguageCro());
            EnglishLanguage = new AsyncCommand(async () => await SetLanguageEng());
            Start = new AsyncCommand(async () => await GoToMainPage());
        }

        private async Task GoToMainPage()
        {
            if (!StartBtnEnabled)
            {
                await ToastHelper.DisplayToastAsync(LocalizationResourceManager.Current["LangSelectError"]);
            }
            else
            {
                Preferences.Set("setupComplete", "1");
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
        }

        private async Task SetLanguageEng()
        {
            StartBtnEnabled = true;
            LocalizationResourceManager.Current.CurrentCulture = new CultureInfo("en-US");
            Preferences.Set("language", "en-US");
            await ToastHelper.DisplayToastAsync(LocalizationResourceManager.Current["LangEngMsg"]);
        }

        private async Task SetLanguageCro()
        {
            StartBtnEnabled = true;
            LocalizationResourceManager.Current.CurrentCulture = new CultureInfo("hr-HR");
            Preferences.Set("language", "hr-HR");
            await ToastHelper.DisplayToastAsync(LocalizationResourceManager.Current["LangCroMsg"]);
        }
    }
}

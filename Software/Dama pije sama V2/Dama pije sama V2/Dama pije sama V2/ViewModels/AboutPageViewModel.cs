using DamaPijeSama.Services;
using MvvmHelpers.Commands;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Essentials;

namespace DamaPijeSama.ViewModels
{
    public class AboutPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand OpenInBrowser { get; }
        public AboutPageViewModel()
        {
            OpenInBrowser = new AsyncCommand<string>(async (url) => await OpenBrowserAsync(url));
        }

        private async Task OpenBrowserAsync(string url)
        {
            try
            {
                await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception)
            {
                await ToastHelper.DisplayToastAsync(LocalizationResourceManager.Current["GeneralError"]);
            }
        }
    }
}

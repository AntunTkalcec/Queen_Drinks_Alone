using DamaPijeSama.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Essentials;
using Xamarin.Forms;

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
                await ToastHelper.DisplayToastAsync("Nešto nije uspjelo :/");
            }
        }
    }
}

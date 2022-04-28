using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public List<Igrac> ListaIgraca;
        public AboutPage(List<Igrac> igraci)
        {
            InitializeComponent();
            if (igraci != null)
            {
                ListaIgraca = igraci;
            }
            else
            {
                ListaIgraca = new List<Igrac>();
            }
        }

        protected override bool OnBackButtonPressed()
        {
            _ = Navigation.PopAsync(true);
            return true;
        }

        private async void InstaLabel(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://www.instagram.com/antuntkalcec", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await Device.InvokeOnMainThreadAsync(async () => await Application.Current.MainPage.DisplayToastAsync("Nešto ti nije u redu sa browserom na mobitelu."));
            }
        }
        private async void LinkedInLabel(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://www.linkedin.com/in/antuntkalcec", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await Device.InvokeOnMainThreadAsync(async () => await Application.Current.MainPage.DisplayToastAsync("Nešto ti nije u redu sa browserom na mobitelu."));
            }
        }
        private async void FacebookLabel(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://www.facebook.com/antun.tkalcec", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await Device.InvokeOnMainThreadAsync(async () => await Application.Current.MainPage.DisplayToastAsync("Nešto ti nije u redu sa browserom na mobitelu."));
            }
        }
    }
}
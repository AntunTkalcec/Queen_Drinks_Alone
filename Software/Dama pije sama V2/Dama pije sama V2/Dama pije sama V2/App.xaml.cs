﻿using Xamarin.Forms;
using Xamarin.CommunityToolkit.Helpers;
using DamaPijeSama.Resources;
using Xamarin.Essentials;
using DamaPijeSama.Views;

[assembly: ExportFont("SpicyRice-Regular.ttf", Alias = "Spicy Rice")]
[assembly: ExportFont("Cagliostro-Regular.ttf", Alias = "Cagliostro")]
[assembly: ExportFont("FontAwesome6Brands.otf", Alias = "FABrands")]
[assembly: ExportFont("FontAwesome6Regular.otf", Alias = "FARegular")]
[assembly: ExportFont("FontAwesome6Solid.otf", Alias = "FASolid")]

namespace Dama_pije_sama_V2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            LocalizationResourceManager.Current.PropertyChanged += (a, b) => AppResources.Culture = LocalizationResourceManager.Current.CurrentCulture;
            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);
            LocalizationResourceManager.Current.CurrentCulture = new System.Globalization.CultureInfo($"{Preferences.Get("language", "en-US")}");

            if (!(Preferences.Get("setupComplete", "0") == "1"))
            {
                MainPage = new SetupPage();
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

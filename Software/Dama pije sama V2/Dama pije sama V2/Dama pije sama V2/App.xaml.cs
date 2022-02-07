using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("SpicyRice-Regular.ttf", Alias = "Spicy Rice")]
[assembly: ExportFont("Cagliostro-Regular.ttf", Alias = "Cagliostro")]

namespace Dama_pije_sama_V2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage(null);
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

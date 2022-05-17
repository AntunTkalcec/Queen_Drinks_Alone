using Dama_pije_sama_V2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DamaPijeSama.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupPage : ContentPage
    {
        public SetupPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            LocalizationResourceManager.Current.CurrentCulture = new CultureInfo("hr-HR");
            Preferences.Set("language", "hr-HR");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            LocalizationResourceManager.Current.CurrentCulture = new CultureInfo("en-US");
            Preferences.Set("language", "en-US");
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Preferences.Set("setupComplete", "1");
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}
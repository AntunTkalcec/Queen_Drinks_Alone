using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new MainPage(null);
            return true;
        }

        private void BackImageButton_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage(null);
            return;
        }
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    }
}
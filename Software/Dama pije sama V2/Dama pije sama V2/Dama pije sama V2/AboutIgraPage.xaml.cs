using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutIgraPage : ContentPage
    {
        public AboutIgraPage()
        {
            InitializeComponent();
        }

        private void Povratak_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PovijestPage();
            return;
        }
        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new PovijestPage();
            return true;
        }
    }
}
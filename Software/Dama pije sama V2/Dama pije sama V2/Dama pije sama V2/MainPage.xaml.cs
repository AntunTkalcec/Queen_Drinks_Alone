using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dama_pije_sama_V2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void HelpIcon_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AboutPage();
            return;
        }
    }
}

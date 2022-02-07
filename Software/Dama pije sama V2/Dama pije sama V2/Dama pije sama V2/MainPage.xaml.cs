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
        List<Igrac> ListaIgraca;
        public MainPage(List<Igrac> igraci)
        {
            InitializeComponent();
            ListaIgraca = igraci;
        }

        private void HelpIcon_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AboutPage();
            return;
        }

        private void Quickstart_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new QuickstartPage();
            return;
        }

        private void Igraci_Tapped(object sender, EventArgs e)
        {
            if (ListaIgraca.Count > 0)
            {
                Application.Current.MainPage = new IgraciPage2(ListaIgraca);
                return;
            }
            else
            {
                Application.Current.MainPage = new IgraciPage();
                return;
            }
        }

        private void Povijest_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PovijestPage();
            return;
        }
    }
}

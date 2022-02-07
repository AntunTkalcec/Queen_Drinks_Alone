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
    public partial class IgraciPage : ContentPage
    {
        List<Igrac> Igraci = new List<Igrac>();
        public IgraciPage()
        {
            InitializeComponent();
        }

        private void HomeButton_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage(null);
            return;
        }

        private void Dodaj_Tapped(object sender, EventArgs e)
        {
            if (ImeIgracaEntry.Text == "" || ImeIgracaEntry.Text == null)
            {
                return;
            }
            else
            {
                string ime = ImeIgracaEntry.Text;
                Igrac noviIgrac = new Igrac(ime, 1);
                Igraci.Add(noviIgrac);
                Application.Current.MainPage = new IgraciPage2(Igraci);
                return;
            }
        }
        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new MainPage(null);
            return true;
        }
    }
}
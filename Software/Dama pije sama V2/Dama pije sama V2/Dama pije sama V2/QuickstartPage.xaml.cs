using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamanimation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuickstartPage : ContentPage
    {
        public List<Karta> karte = new List<Karta>();
        static Random rnd = new Random();
        public QuickstartPage()
        {
            InitializeComponent();
            StvoriListu();
            slikaKarte.Source = karte.Find(x => x.Naziv == "PocetnaKarta").Naziv;
            OpisZadatkaLabel.Text = karte.Find(x => x.Naziv == "PocetnaKarta").Naredba;
            BrKarteLabel.Text = $"{karte.Count - 1}";
        }

        private void HomeButton_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage(null);
            return;
        }

        private void slikaKarte_RightSwiped(object sender, SwipedEventArgs e)
        {
            if (karte.Count == 0)
            {
                OpisZadatkaLabel.Text = "Špil je prazan!";
                return;
            }

            karte.RemoveAll(x => x.Naziv == "PocetnaKarta");
            int r = rnd.Next(karte.Count);
            slikaKarte.Source = karte.ElementAt(r).Naziv;
            OpisZadatkaLabel.Text = karte.ElementAt(r).Naredba;
            karte.RemoveAt(r);
            BrKarteLabel.Text = $"{karte.Count}";
        }

        private void slikaKarte_UpSwiped(object sender, SwipedEventArgs e)
        {
            karte.Clear();
            StvoriListu();
            OpisZadatkaLabel.Text = "Špil resetiran i promiješan";
            slikaKarte.Source = karte.Find(x => x.Naziv == "PocetnaKarta").Naziv;
            BrKarteLabel.Text = $"{karte.Count - 1}";
        }

        private void slikaKarte_DownSwiped(object sender, SwipedEventArgs e)
        {
            Application.Current.MainPage = new IgraciPage();
        }
        private void StvoriListu()
        {
            karte.Add(new Karta("AsHerc", "KATEGORIJE"));
            karte.Add(new Karta("AsZelje", "KATEGORIJE"));
            karte.Add(new Karta("AsBundeva", "KATEGORIJE"));
            karte.Add(new Karta("AsZir", "KATEGORIJE"));
            karte.Add(new Karta("KraljHerc", "BIRAŠ TKO PIJE"));
            karte.Add(new Karta("KraljZelje", "BIRAŠ TKO PIJE"));
            karte.Add(new Karta("KraljBundeva", "BIRAŠ TKO PIJE"));
            karte.Add(new Karta("KraljZir", "BIRAŠ TKO PIJE"));
            karte.Add(new Karta("PocetnaKarta", "Swipe desno za početak"));
            karte.Add(new Karta("BabaHerc", "DAMA PIJE SAMA"));
            karte.Add(new Karta("BabaZelje", "DAMA PIJE SAMA"));
            karte.Add(new Karta("BabaBundeva", "DAMA PIJE SAMA"));
            karte.Add(new Karta("BabaZir", "DAMA PIJE SAMA"));
            karte.Add(new Karta("DeckoHerc", "POGODI BOJU"));
            karte.Add(new Karta("DeckoZelje", "POGODI BOJU"));
            karte.Add(new Karta("DeckoZir", "POGODI BOJU"));
            karte.Add(new Karta("DeckoBundeva", "POGODI BOJU"));
            karte.Add(new Karta("DesetkaHerc", "NIKAD NISAM"));
            karte.Add(new Karta("DesetkaZelje", "NIKAD NISAM"));
            karte.Add(new Karta("DesetkaBundeva", "NIKAD NISAM"));
            karte.Add(new Karta("DesetkaZir", "NIKAD NISAM"));
            karte.Add(new Karta("DevetkaHerc", "SVI PIJU"));
            karte.Add(new Karta("DevetkaZelje", "SVI PIJU"));
            karte.Add(new Karta("DevetkaBundeva", "SVI PIJU"));
            karte.Add(new Karta("DevetkaZir", "SVI PIJU"));
            karte.Add(new Karta("OsmicaHerc", "PIJE DESNO OD TEBE"));
            karte.Add(new Karta("OsmicaZelje", "PIJE DESNO OD TEBE"));
            karte.Add(new Karta("OsmicaBundeva", "PIJE DESNO OD TEBE"));
            karte.Add(new Karta("OsmicaZir", "PIJE DESNO OD TEBE"));
            karte.Add(new Karta("SedmicaHerc", "PIJE LIJEVO OD TEBE"));
            karte.Add(new Karta("SedmicaZelje", "PIJE LIJEVO OD TEBE"));
            karte.Add(new Karta("SedmicaBundeva", "PIJE LIJEVO OD TEBE"));
            karte.Add(new Karta("SedmicaZir", "PIJE LIJEVO OD TEBE"));
        }
        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new MainPage(null);
            return true;
        }
    }
}
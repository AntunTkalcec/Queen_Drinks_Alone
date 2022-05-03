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
        public List<Igrac> ListaIgraca;
        private Igra Igra;
        private List<Boja> Boje = new List<Boja>();
        static Random rnd = new Random();
        public AboutIgraPage(List<Igrac> igraci, Igra igra)
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
            StvoriListuBoja();
            Igra = igra;
            PopuniLabele();
        }

        private void StvoriListuBoja()
        {
            Boje.Add(new Boja("#8f2ce0"));
            Boje.Add(new Boja("#e02cd7"));
            Boje.Add(new Boja("#352ce0"));
            Boje.Add(new Boja("#a01699"));
        }

        private void PopuniLabele()
        {
            NaslovLabel.Text = $"Igra {Igra.Id} ; {Igra.Datum}";

            int r = rnd.Next(Boje.Count);
            IgraciUIgriLabel.Text = Igra.PopisIgraca;
            IgraciUIgriLabel.TextColor = Color.FromHex($"{Boje.ElementAt(r).Kod}");

            r = rnd.Next(Boje.Count);
            BrKartaLabel.Text = Igra.BrOdigranihKarata.ToString();
            BrKartaLabel.TextColor = Color.FromHex($"{Boje.ElementAt(r).Kod}");

            r = rnd.Next(Boje.Count);
            if (int.Parse(Igra.DuljinaIgre) < 60)
            {
                BrMinutaIgreLabel.Text = Igra.DuljinaIgre + " sekundi";
                BrMinutaIgreLabel.TextColor = Color.FromHex($"{Boje.ElementAt(r).Kod}");
            }
            else
            {
                BrMinutaIgreLabel.Text = (int.Parse(Igra.DuljinaIgre) / 60).ToString() + " minuta";
                BrMinutaIgreLabel.TextColor = Color.FromHex($"{Boje.ElementAt(r).Kod}");
            }
        }

        protected override bool OnBackButtonPressed()
        {
            _ = Navigation.PopAsync(true);
            return true;
        }
    }
}
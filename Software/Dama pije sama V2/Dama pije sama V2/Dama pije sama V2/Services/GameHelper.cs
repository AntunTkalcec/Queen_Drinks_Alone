using Dama_pije_sama_V2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DamaPijeSama.Services
{
    public static class GameHelper
    {
        public static Stopwatch stopwatch;
        public static async Task<ObservableCollection<Karta>> GetCardsAsync()
        {
            ObservableCollection<Karta> karte = new();
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
            return karte;
        }
        public static async Task<ObservableCollection<Boja>> GetColorsAsync()
        {
            ObservableCollection<Boja> boje = new();
            boje.Add(new Boja("#8f2ce0"));
            boje.Add(new Boja("#e02cd7"));
            boje.Add(new Boja("#352ce0"));
            boje.Add(new Boja("#a01699"));
            return boje;
        }
        public static async Task StartStopwatch()
        {
            await Task.Run(async () => stopwatch = Stopwatch.StartNew());
        }
        public static async Task GetElapsedTime()
        {
            await Task.Run(async () =>
            {
                stopwatch.Stop();
                return stopwatch.Elapsed.TotalSeconds.ToString("0");
            });
        }
    }
}

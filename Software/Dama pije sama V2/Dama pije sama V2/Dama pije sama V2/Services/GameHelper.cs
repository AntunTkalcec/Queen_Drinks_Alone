using Dama_pije_sama_V2;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DamaPijeSama.Services
{
    public static class GameHelper
    {
        public static Stopwatch Stopwatch = new();
        private static readonly IIgraRepository _igraRepository = DependencyService.Get<IIgraRepository>();
        public static async Task<ObservableCollection<Card>> GetCardsAsync()
        {
            ObservableCollection<Card> cards = new();
            cards.Add(new Card("AsHerc", "KATEGORIJE"));
            cards.Add(new Card("AsZelje", "KATEGORIJE"));
            cards.Add(new Card("AsBundeva", "KATEGORIJE"));
            cards.Add(new Card("AsZir", "KATEGORIJE"));
            cards.Add(new Card("KraljHerc", "BIRAŠ TKO PIJE"));
            cards.Add(new Card("KraljZelje", "BIRAŠ TKO PIJE"));
            cards.Add(new Card("KraljBundeva", "BIRAŠ TKO PIJE"));
            cards.Add(new Card("KraljZir", "BIRAŠ TKO PIJE"));
            cards.Add(new Card("PocetnaKarta", "Swipe desno za početak"));
            cards.Add(new Card("BabaHerc", "DAMA PIJE SAMA"));
            cards.Add(new Card("BabaZelje", "DAMA PIJE SAMA"));
            cards.Add(new Card("BabaBundeva", "DAMA PIJE SAMA"));
            cards.Add(new Card("BabaZir", "DAMA PIJE SAMA"));
            cards.Add(new Card("DeckoHerc", "POGODI BOJU"));
            cards.Add(new Card("DeckoZelje", "POGODI BOJU"));
            cards.Add(new Card("DeckoZir", "POGODI BOJU"));
            cards.Add(new Card("DeckoBundeva", "POGODI BOJU"));
            cards.Add(new Card("DesetkaHerc", "NIKAD NISAM"));
            cards.Add(new Card("DesetkaZelje", "NIKAD NISAM"));
            cards.Add(new Card("DesetkaBundeva", "NIKAD NISAM"));
            cards.Add(new Card("DesetkaZir", "NIKAD NISAM"));
            cards.Add(new Card("DevetkaHerc", "SVI PIJU"));
            cards.Add(new Card("DevetkaZelje", "SVI PIJU"));
            cards.Add(new Card("DevetkaBundeva", "SVI PIJU"));
            cards.Add(new Card("DevetkaZir", "SVI PIJU"));
            cards.Add(new Card("OsmicaHerc", "PIJE DESNO OD TEBE"));
            cards.Add(new Card("OsmicaZelje", "PIJE DESNO OD TEBE"));
            cards.Add(new Card("OsmicaBundeva", "PIJE DESNO OD TEBE"));
            cards.Add(new Card("OsmicaZir", "PIJE DESNO OD TEBE"));
            cards.Add(new Card("SedmicaHerc", "PIJE LIJEVO OD TEBE"));
            cards.Add(new Card("SedmicaZelje", "PIJE LIJEVO OD TEBE"));
            cards.Add(new Card("SedmicaBundeva", "PIJE LIJEVO OD TEBE"));
            cards.Add(new Card("SedmicaZir", "PIJE LIJEVO OD TEBE"));
            return cards;
        }
        public static async Task<ObservableCollection<Dama_pije_sama_V2.Color>> GetColorsAsync()
        {
            ObservableCollection<Dama_pije_sama_V2.Color> colors = new();
            colors.Add(new Dama_pije_sama_V2.Color("#8f2ce0"));
            colors.Add(new Dama_pije_sama_V2.Color("#e02cd7"));
            colors.Add(new Dama_pije_sama_V2.Color("#352ce0"));
            colors.Add(new Dama_pije_sama_V2.Color("#a01699"));
            return colors;
        }
        public static void StartStopwatch()
        {
            if (!Stopwatch.IsRunning)
            {
                Stopwatch = Stopwatch.StartNew();
            }
        }
        public static string GetElapsedTime()
        {
            Stopwatch.Stop();
            return Stopwatch.Elapsed.TotalSeconds.ToString("0");
        }
        public static async Task<ObservableCollection<Game>> GetGamesAsync()
        {
            List<Game> games = await _igraRepository.GetGamesAsync();
            return new ObservableCollection<Game>(games);
        }
        public static async Task<List<Drunkard>> GetDrunkardsAsync()
        {
            List<Drunkard> Drunkards = new()
            {
                new Drunkard("DrunkGirl1"),
                new Drunkard("DrunkGirl2"),
                new Drunkard("DrunkGuy1"),
                new Drunkard("DrunkGuy2"),
                new Drunkard("DrunkGuy3"),
                new Drunkard("DrunkGuy4"),
                new Drunkard("DrunkGuy5")
            };
            return Drunkards;
        }
    }
}

using Dama_pije_sama_V2;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DamaPijeSama.Services
{
    public static class GameHelper
    {
        public static Stopwatch Stopwatch = new Stopwatch();
        private static readonly IIgraRepository _igraRepository = DependencyService.Get<IIgraRepository>();
        public static ObservableCollection<Card> Cards = new ObservableCollection<Card>();
        public static async Task<ObservableCollection<Card>> GetCardsAsync()
        {
            Cards.Clear();

            if (Preferences.Get("language", "hr-HR") == "hr-HR")
            {
                await GetCroatianCards();
            }
            else
            {
                await GetEnglishCards();
            }

            return Cards;
        }

        private static Task GetEnglishCards()
        {
            Cards.Add(new Card("AsHerc", "CATEGORIES"));
            Cards.Add(new Card("AsZelje", "CATEGORIES"));
            Cards.Add(new Card("AsBundeva", "CATEGORIES"));
            Cards.Add(new Card("AsZir", "CATEGORIES"));
            Cards.Add(new Card("KraljHerc", "CHOOSE WHO DRINKS"));
            Cards.Add(new Card("KraljZelje", "CHOOSE WHO DRINKS"));
            Cards.Add(new Card("KraljBundeva", "CHOOSE WHO DRINKS"));
            Cards.Add(new Card("KraljZir", "CHOOSE WHO DRINKS"));
            Cards.Add(new Card("PocetnaKarta", "Swipe right to begin"));
            Cards.Add(new Card("BabaHerc", "QUEEN DRINKS ALONE"));
            Cards.Add(new Card("BabaZelje", "QUEEN DRINKS ALONE"));
            Cards.Add(new Card("BabaBundeva", "QUEEN DRINKS ALONE"));
            Cards.Add(new Card("BabaZir", "QUEEN DRINKS ALONE"));
            Cards.Add(new Card("DeckoHerc", "GUESS THE COLOR"));
            Cards.Add(new Card("DeckoZelje", "GUESS THE COLOR"));
            Cards.Add(new Card("DeckoZir", "GUESS THE COLOR"));
            Cards.Add(new Card("DeckoBundeva", "GUESS THE COLOR"));
            Cards.Add(new Card("DesetkaHerc", "NEVER HAVE I EVER"));
            Cards.Add(new Card("DesetkaZelje", "NEVER HAVE I EVER"));
            Cards.Add(new Card("DesetkaBundeva", "NEVER HAVE I EVER"));
            Cards.Add(new Card("DesetkaZir", "NEVER HAVE I EVER"));
            Cards.Add(new Card("DevetkaHerc", LocalizationResourceManager.Current["EverybodyDrinksMsg"]));
            Cards.Add(new Card("DevetkaZelje", LocalizationResourceManager.Current["EverybodyDrinksMsg"]));
            Cards.Add(new Card("DevetkaBundeva", LocalizationResourceManager.Current["EverybodyDrinksMsg"]));
            Cards.Add(new Card("DevetkaZir", LocalizationResourceManager.Current["EverybodyDrinksMsg"]));
            Cards.Add(new Card("OsmicaHerc", "RIGHT DRINKS"));
            Cards.Add(new Card("OsmicaZelje", "RIGHT DRINKS"));
            Cards.Add(new Card("OsmicaBundeva", "RIGHT DRINKS"));
            Cards.Add(new Card("OsmicaZir", "RIGHT DRINKS"));
            Cards.Add(new Card("SedmicaHerc", "LEFT DRINKS"));
            Cards.Add(new Card("SedmicaZelje", "LEFT DRINKS"));
            Cards.Add(new Card("SedmicaBundeva", "LEFT DRINKS"));
            Cards.Add(new Card("SedmicaZir", "LEFT DRINKS"));
            return Task.CompletedTask;
        }

        private static Task GetCroatianCards()
        {
            Cards.Add(new Card("AsHerc", "KATEGORIJE"));
            Cards.Add(new Card("AsZelje", "KATEGORIJE"));
            Cards.Add(new Card("AsBundeva", "KATEGORIJE"));
            Cards.Add(new Card("AsZir", "KATEGORIJE"));
            Cards.Add(new Card("KraljHerc", "BIRAŠ TKO PIJE"));
            Cards.Add(new Card("KraljZelje", "BIRAŠ TKO PIJE"));
            Cards.Add(new Card("KraljBundeva", "BIRAŠ TKO PIJE"));
            Cards.Add(new Card("KraljZir", "BIRAŠ TKO PIJE"));
            Cards.Add(new Card("PocetnaKarta", "Swipe desno za početak"));
            Cards.Add(new Card("BabaHerc", "DAMA PIJE SAMA"));
            Cards.Add(new Card("BabaZelje", "DAMA PIJE SAMA"));
            Cards.Add(new Card("BabaBundeva", "DAMA PIJE SAMA"));
            Cards.Add(new Card("BabaZir", "DAMA PIJE SAMA"));
            Cards.Add(new Card("DeckoHerc", "POGODI BOJU"));
            Cards.Add(new Card("DeckoZelje", "POGODI BOJU"));
            Cards.Add(new Card("DeckoZir", "POGODI BOJU"));
            Cards.Add(new Card("DeckoBundeva", "POGODI BOJU"));
            Cards.Add(new Card("DesetkaHerc", "NIKAD NISAM"));
            Cards.Add(new Card("DesetkaZelje", "NIKAD NISAM"));
            Cards.Add(new Card("DesetkaBundeva", "NIKAD NISAM"));
            Cards.Add(new Card("DesetkaZir", "NIKAD NISAM"));
            Cards.Add(new Card("DevetkaHerc", LocalizationResourceManager.Current["EverybodyDrinksMsg"]));
            Cards.Add(new Card("DevetkaZelje", LocalizationResourceManager.Current["EverybodyDrinksMsg"]));
            Cards.Add(new Card("DevetkaBundeva", LocalizationResourceManager.Current["EverybodyDrinksMsg"]));
            Cards.Add(new Card("DevetkaZir", LocalizationResourceManager.Current["EverybodyDrinksMsg"]));
            Cards.Add(new Card("OsmicaHerc", "PIJE DESNO OD TEBE"));
            Cards.Add(new Card("OsmicaZelje", "PIJE DESNO OD TEBE"));
            Cards.Add(new Card("OsmicaBundeva", "PIJE DESNO OD TEBE"));
            Cards.Add(new Card("OsmicaZir", "PIJE DESNO OD TEBE"));
            Cards.Add(new Card("SedmicaHerc", "PIJE LIJEVO OD TEBE"));
            Cards.Add(new Card("SedmicaZelje", "PIJE LIJEVO OD TEBE"));
            Cards.Add(new Card("SedmicaBundeva", "PIJE LIJEVO OD TEBE"));
            Cards.Add(new Card("SedmicaZir", "PIJE LIJEVO OD TEBE"));
            return Task.CompletedTask;
        }

        public static async Task<ObservableCollection<Dama_pije_sama_V2.Color>> GetColorsAsync()
        {
            return new ObservableCollection<Dama_pije_sama_V2.Color>
            {
                new Dama_pije_sama_V2.Color("#8f2ce0"),
                new Dama_pije_sama_V2.Color("#e02cd7"),
                new Dama_pije_sama_V2.Color("#352ce0"),
                new Dama_pije_sama_V2.Color("#a01699")
            };
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
            return new List<Drunkard>
            {
                new Drunkard("DrunkGirl1"),
                new Drunkard("DrunkGirl2"),
                new Drunkard("DrunkGuy1"),
                new Drunkard("DrunkGuy2"),
                new Drunkard("DrunkGuy3"),
                new Drunkard("DrunkGuy4"),
                new Drunkard("DrunkGuy5")
            }; ;
        }
    }
}

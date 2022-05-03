using Dama_pije_sama_V2;
using DamaPijeSama.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;

namespace DamaPijeSama.ViewModels
{
    public class QuickstartPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private INavigation Navigation => Application.Current.MainPage.Navigation;
        public ObservableCollection<Karta> Cards { get; set; } = new ObservableCollection<Karta>();
        public ObservableCollection<Boja> Boje { get; set; } = new ObservableCollection<Boja>();
        public ICommand SwipeCard { get; }
        public ICommand GetCards { get; }
        public ICommand GetColors { get; }
        public ICommand GetCurrentPage { get; }
        public string CurrentCard { get; set; }
        public string CardDescription { get; set; }
        public string CardCount { get; set; }
        private int _cardCount { get; set; }
        public string RandomColor { get; set; }
        public int CardsPlayedCounter { get; set; } = 0;
        public bool Initialized { get; set; }
        private readonly IIgraRepository _igraRepository;
        public QuickstartPageViewModel()
        {
            _igraRepository = DependencyService.Get<IIgraRepository>();
            SwipeCard = new AsyncCommand<string>(async (direction) => await HandleSwipeCommand(direction));
            GetCards = new AsyncCommand(async () => await GetCardList());
            GetCards.Execute(null);
            GetColors = new AsyncCommand(async () => await GetColorList());
            GetColors.Execute(null);
            GetCurrentPage = new AsyncCommand(async () => await GetQuickstartPage());
            //GetCurrentPage.Execute(null);
        }

        private Task GetQuickstartPage()
        {
            if (Initialized == false)
            {
                QuickstartPage page = new();
                page.Disappearing += SaveCurrentGame;
            }
            Initialized = true;
            return Task.CompletedTask;
        }

        private async void SaveCurrentGame(object sender, EventArgs e)
        {
            if (CardsPlayedCounter > 0)
            {
                Igra novaIgra = new()
                {
                    Datum = DateTime.Now,
                    BrojIgraca = 0,
                    BrOdigranihKarata = CardsPlayedCounter,
                    PopisIgraca = "Ova se igra igrala bez upisanih igrača",
                    DuljinaIgre = GameHelper.GetElapsedTime().ToString(),
                };
                await _igraRepository.AddNewIgraAsync(novaIgra);
            }
            Initialized = false;
        }

        public async Task GetColorList()
        {
            Boje = await GameHelper.GetColorsAsync();
            RandomColor = Boje[new Random().Next(0, 3)].Kod;
        }

        public async Task GetCardList()
        {
            Cards = await GameHelper.GetCardsAsync();
            _cardCount = Cards.Count - 1;
            CardCount = _cardCount.ToString();

            CurrentCard = Cards.SingleOrDefault(x => x.Naziv == "PocetnaKarta").Naziv;
            CardDescription = Cards.SingleOrDefault(x => x.Naziv == "PocetnaKarta").Naredba;
        }

        public async Task HandleSwipeCommand(string direction)
        {
            if (direction == "Right")
            {
                await ChangeCardAsync();
            }
            else if (direction == "Up")
            {
                await ResetDeckAsync();
            }
            else if (direction == "Down")
            {
                await GoToIgraciPageAsync();
            }
        }

        public async Task GoToIgraciPageAsync()
        {
            await Navigation.PushAsync(new IgraciPage2(), true);
        }

        public async Task ResetDeckAsync()
        {
            await Task.Run(async () =>
            {
                try
                {
                    Cards.Clear();
                    Cards = new ObservableCollection<Karta>(await GameHelper.GetCardsAsync());
                    CardDescription = "Špil resetiran i promiješan.";
                    CurrentCard = Cards.SingleOrDefault(x => x.Naziv == "PocetnaKarta").Naziv;
                    _cardCount = Cards.Count - 1;
                    CardCount = _cardCount.ToString();
                }
                catch (Exception)
                {
                    await ToastHelper.DisplayToastAsync("Prebrzo to radiš. Uspori s mijenjanjem karata.");
                }
            });
        }

        public async Task ChangeCardAsync()
        {
            await Task.Run(async () =>
            {
                try
                {

                    if (Cards.Count == 0)
                    {
                        CardDescription = "Špil je prazan!";
                        return;
                    }
                    CardsPlayedCounter++;
                    Cards.Remove(Cards.SingleOrDefault(x => x.Naziv == "PocetnaKarta"));
                    int r = new Random().Next(Cards.Count);
                    CurrentCard = Cards[r].Naziv;
                    CardDescription = Cards[r].Naredba;

                    if (CardDescription == "SVI PIJU")
                    {
                        Vibration.Vibrate();
                    }

                    Cards.RemoveAt(r);
                    CardCount = Cards.Count.ToString();
                }
                catch (Exception)
                {
                    await ToastHelper.DisplayToastAsync("Prebrzo to radiš. Uspori s mijenjanjem karata.");
                }
            });
        }
    }
}

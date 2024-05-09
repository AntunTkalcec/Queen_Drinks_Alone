using Dama_pije_sama_V2;
using DamaPijeSama.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;
using Xamarin.CommunityToolkit.Helpers;

namespace DamaPijeSama.ViewModels
{
    public class QuickstartPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private INavigation Navigation => Application.Current.MainPage.Navigation;
        public ObservableCollection<Card> Cards { get; set; } = new ObservableCollection<Card>();
        public ObservableCollection<Dama_pije_sama_V2.Color> Colors { get; set; } = new ObservableCollection<Dama_pije_sama_V2.Color>();
        public ICommand SwipeCard { get; }
        public ICommand GetCards { get; }
        public ICommand GetColors { get; }
        public string CurrentCard { get; set; }
        public string CardDescription { get; set; }
        public string CardCount { get; set; }
        private int _cardCount { get; set; }
        public string RandomColor { get; set; }
        public int CardsPlayedCounter { get; set; } = 0;
        private readonly IIgraRepository _igraRepository;
        private readonly QuickstartPage _page;
        public QuickstartPageViewModel(QuickstartPage page)
        {
            _igraRepository = DependencyService.Get<IIgraRepository>();
            _page = page;
            _page.Disappearing += SaveCurrentGame;
            SwipeCard = new AsyncCommand<string>(async (direction) => await HandleSwipeCommandAsync(direction));
            GetCards = new AsyncCommand(async () => await GetCardListAsync());
            GetCards.Execute(null);
            GetColors = new AsyncCommand(async () => await GetColorListAsync());
            GetColors.Execute(null);
        }

        private async void SaveCurrentGame(object sender, EventArgs e)
        {
            if (CardsPlayedCounter > 0)
            {
                Game newGame = new Game()
                {
                    Date = DateTime.Now,
                    NumberOfPlayers = 0,
                    CardsPlayed = CardsPlayedCounter,
                    PlayerList = LocalizationResourceManager.Current["NoPlayersGame"],
                    GameLength = GameHelper.GetElapsedTime(),
                };
                await _igraRepository.AddNewGameAsync(newGame);
            }
        }

        public async Task GetColorListAsync()
        {
            Colors = await GameHelper.GetColorsAsync();
            RandomColor = Colors[new Random().Next(0, 3)].Code;
        }

        public async Task GetCardListAsync()
        {
            Cards = await GameHelper.GetCardsAsync();
            _cardCount = Cards.Count - 1;
            CardCount = _cardCount.ToString();

            CurrentCard = Cards.SingleOrDefault(x => x.Name == "PocetnaKarta").Name;
            CardDescription = Cards.SingleOrDefault(x => x.Name == "PocetnaKarta").Description;
        }

        public async Task HandleSwipeCommandAsync(string direction)
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
            Navigation.RemovePage(_page);
        }

        public async Task ResetDeckAsync()
        {
            await Task.Run(async () =>
            {
                try
                {
                    Cards.Clear();
                    Cards = new ObservableCollection<Card>(await GameHelper.GetCardsAsync());
                    CardDescription = LocalizationResourceManager.Current["DeckShuffledMsg"];
                    CurrentCard = Cards.SingleOrDefault(x => x.Name == "PocetnaKarta").Name;
                    _cardCount = Cards.Count - 1;
                    CardCount = _cardCount.ToString();
                }
                catch (Exception)
                {
                    await ToastHelper.DisplayToastAsync(LocalizationResourceManager.Current["CardChangeError"]);
                }
            });
        }

        public async Task ChangeCardAsync()
        {
            await Task.Run(async () =>
            {
                try
                {
                    GameHelper.StartStopwatch();
                    if (Cards.Count == 0)
                    {
                        CardDescription = LocalizationResourceManager.Current["EmptyDeckMsg"];
                        return;
                    }
                    CardsPlayedCounter++;
                    Cards.Remove(Cards.SingleOrDefault(x => x.Name == "PocetnaKarta"));
                    int r = new Random().Next(Cards.Count);
                    CurrentCard = Cards[r].Name;
                    CardDescription = Cards[r].Description;

                    if (CardDescription == LocalizationResourceManager.Current["EverybodyDrinksMsg"])
                    {
                        Vibration.Vibrate();
                    }

                    Cards.RemoveAt(r);
                    CardCount = Cards.Count.ToString();
                }
                catch (Exception ex)
                {
                    await ToastHelper.DisplayToastAsync(LocalizationResourceManager.Current["CardChangeError"]);
                }
            });
        }
    }
}

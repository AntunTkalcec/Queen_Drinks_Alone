using Dama_pije_sama_V2;
using DamaPijeSama.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DamaPijeSama.ViewModels
{
    public class IgranjeSIgracimaPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private INavigation Navigation => Application.Current.MainPage.Navigation;
        public List<Player> Players { get; set; } = new List<Player>();
        public ObservableCollection<Card> Cards { get; set; } = new ObservableCollection<Card>();
        public ObservableCollection<Dama_pije_sama_V2.Color> Colors { get; set; } = new ObservableCollection<Dama_pije_sama_V2.Color>();
        private Player CurrentPlayer;
        private int CurrentPlayerCounter = 0;
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
        public IgranjeSIgracimaPageViewModel(IgranjeSIgracimaPage page, List<Player> players)
        {
            _igraRepository = DependencyService.Get<IIgraRepository>();
            page.Disappearing += SaveCurrentGame;
            Players = players;
            CurrentPlayer = Players[CurrentPlayerCounter];
            SwipeCard = new AsyncCommand<string>(async (direction) => await HandleSwipeCommandAsync(direction));
            GetCards = new AsyncCommand(async () => await GetCardListAsync());
            GetCards.Execute(null);
            GetColors = new AsyncCommand(async () => await GetColorListAsync());
            GetColors.Execute(null);
        }

        private async Task GetColorListAsync()
        {
            Colors = await GameHelper.GetColorsAsync();
            RandomColor = Colors[new Random().Next(0, 3)].Code;
        }

        private async Task GetCardListAsync()
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

        private async Task GoToIgraciPageAsync()
        {
            await Navigation.PopAsync(true);
        }

        private async Task ResetDeckAsync()
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

        private async Task ChangeCardAsync()
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
                    if (CurrentPlayerCounter == Players.Count - 1)
                    {
                        CurrentPlayerCounter = 0;
                    }
                    else
                    {
                        CurrentPlayerCounter++;
                    }
                    CardsPlayedCounter++;
                    Cards.Remove(Cards.SingleOrDefault(x => x.Name == "PocetnaKarta"));
                    int r = new Random().Next(Cards.Count);
                    CurrentCard = Cards[r].Name;
                    CardDescription = $"{CurrentPlayer.Name}: {Cards[r].Description}";

                    if (CardDescription == LocalizationResourceManager.Current["EverybodyDrinksMsg"])
                    {
                        Vibration.Vibrate();
                    }

                    Cards.RemoveAt(r);
                    CardCount = Cards.Count.ToString();
                    CurrentPlayer = Players[CurrentPlayerCounter];
                }
                catch (Exception)
                {
                    await ToastHelper.DisplayToastAsync(LocalizationResourceManager.Current["CardChangeError"]);
                }
            });
        }

        private async void SaveCurrentGame(object sender, EventArgs e)
        {
            if (CardsPlayedCounter > 0)
            {
                Game newGame = new Game()
                {
                    Date = DateTime.Now,
                    NumberOfPlayers = Players.Count,
                    CardsPlayed = CardsPlayedCounter,
                    PlayerList = await CreatePlayerList(),
                    GameLength = GameHelper.GetElapsedTime(),
                };
                await _igraRepository.AddNewGameAsync(newGame);
            }
        }

        private Task<string> CreatePlayerList()
        {
            string players = string.Empty;
            foreach (Player player in Players)
            {
                players += $"{player.Name}, ";
            }
            players = players.Trim();
            return Task.FromResult(players.TrimEnd(','));
        }
    }
}

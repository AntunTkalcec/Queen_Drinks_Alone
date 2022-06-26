using Dama_pije_sama_V2;
using DamaPijeSama.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace DamaPijeSama.ViewModels
{
    public class PovijestPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private INavigation Navigation => Application.Current.MainPage.Navigation;
        public ObservableCollection<Game> Games { get; set; } = new ObservableCollection<Game>();
        public ObservableCollection<Dama_pije_sama_V2.Color> Colors { get; set; } = new ObservableCollection<Dama_pije_sama_V2.Color>();
        public ICommand GetColors { get; set; }
        public ICommand GetGames { get; set; }
        public ICommand OpenGame { get; }
        public ICommand DeleteHistory { get; }
        public string RandomColor { get; set; }
        public string GameCount { get; set; }
        public bool NoGamesPlayed { get; set; } = false;
        public bool Clickable { get; set; } = true;
        private readonly IIgraRepository _igraRepository;
        public PovijestPageViewModel()
        {
            _igraRepository = DependencyService.Get<IIgraRepository>();
            GetColors = new AsyncCommand(async () => await GetColorListAsync());
            GetColors.Execute(null);
            GetGames = new AsyncCommand(async () => await GetGamesAsync());
            GetGames.Execute(null);
            OpenGame = new AsyncCommand<Game>(async (game) => await OpenSelectedGame(game));
            DeleteHistory = new AsyncCommand(async () => await DeleteHistoryAsync());
        }

        private async Task DeleteHistoryAsync()
        {
            Clickable = false;
            await _igraRepository.DeleteAllGamesAsync();
            await Navigation.PopAsync();
            await ToastHelper.DisplayToastAsync(LocalizationResourceManager.Current["DeleteHistoryMsg"]);
            Clickable = true;
        }

        private async Task OpenSelectedGame(Game game)
        {
            Clickable = false;
            await Navigation.PushModalAsync(new AboutIgraPage(game), true);
            Clickable = true;
        }

        private async Task GetGamesAsync()
        {
            try
            {
                Games = await GameHelper.GetGamesAsync();
                GameCount = $"{Games.Count} {LocalizationResourceManager.Current["GamesString"]}";
            }
            catch (Exception)
            {
                await ToastHelper.DisplayToastAsync(LocalizationResourceManager.Current["GamesLoadingError"]);
            }
            if (Games.Count == 0)
            {
                NoGamesPlayed = true;
            }
        }

        private async Task GetColorListAsync()
        {
            Colors = await GameHelper.GetColorsAsync();
            RandomColor = Colors[new Random().Next(0, 3)].Code;
        }
    }
}

using Dama_pije_sama_V2;
using DamaPijeSama.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Helpers;

namespace DamaPijeSama.ViewModels
{
    public class AboutIgraPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Game ChosenGame;
        public ObservableCollection<Color> Colors { get; set; } = new ObservableCollection<Color>();
        public ICommand GetColors { get; set; }
        public ICommand GetLabels { get; }
        public string RandomColor { get; set; }
        public string GameInfo { get; set; } 
        public string PlayerInfo { get; set; }
        public string PlayedCardsNumber { get; set; }
        public string GameLength { get; set; }
        public AboutIgraPageViewModel(Game game)
        {
            ChosenGame = game;
            GetColors = new AsyncCommand(async () => await GetColorListAsync());
            GetColors.Execute(null);
            GetLabels = new AsyncCommand(async () => await GetLabelsAsync());
            GetLabels.Execute(null);
        }

        private Task GetLabelsAsync()
        {
            GameInfo = $"{LocalizationResourceManager.Current["GameString"]} {ChosenGame.Id} \n {ChosenGame.Date}";
            PlayedCardsNumber = ChosenGame.CardsPlayed.ToString();
            if (int.Parse(ChosenGame.GameLength) < 60)
            {
                GameLength = ChosenGame.GameLength + " sec";
            }
            else
            {
                GameLength = (int.Parse(ChosenGame.GameLength) / 60).ToString() + " min";
            }
            if (ChosenGame.NumberOfPlayers == 0)
            {
                PlayerInfo = LocalizationResourceManager.Current["NoPlayersGame"];
            }
            else
            {
                PlayerInfo = ChosenGame.PlayerList;
            }
            return Task.CompletedTask;
        }

        private async Task GetColorListAsync()
        {
            Colors = await GameHelper.GetColorsAsync();
            RandomColor = Colors[new Random().Next(0, 3)].Code;
        }
    }
}

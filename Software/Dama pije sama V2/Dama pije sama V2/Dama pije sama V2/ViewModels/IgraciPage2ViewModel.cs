using Dama_pije_sama_V2;
using DamaPijeSama.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.Helpers;

namespace DamaPijeSama.ViewModels
{
    public class IgraciPage2ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private INavigation Navigation => Application.Current.MainPage.Navigation;
        public ObservableCollection<Player> Players { get; set; } = new ObservableCollection<Player>();
        public List<Drunkard> Drunkards { get; set; }
        public ObservableCollection<Dama_pije_sama_V2.Color> Colors { get; set; } = new ObservableCollection<Dama_pije_sama_V2.Color>();
        public ICommand GetColors { get; set; }
        public ICommand GetPlayers { get; }
        public ICommand GetDrunkards { get; set; }
        public ICommand FrameTapped { get; }
        public string RandomColor { get; set; }
        public string PlayerCounter { get; set; }
        public string PlayerDrunkardPicture { get; set; }
        public bool ClickablePlus { get; set; } = true;
        public bool EmptyNameExists { get; set; } = false;
        public string PlayBtnImage { get; set; }
        public IgraciPage2ViewModel()
        {
            GetDrunkards = new AsyncCommand(async () => await GetDrunkardsAsync());
            GetDrunkards.Execute(null);
            GetColors = new AsyncCommand(async () => await GetColorListAsync());
            GetColors.Execute(null);
            GetPlayers = new AsyncCommand(async () => await GetPlayersAsync());
            GetPlayers.Execute(null);
            FrameTapped = new AsyncCommand<Player>(async (player) => await DeletePlayerAsync(player));

            if (Preferences.Get("language", "en-US") == "en-US")
            {
                PlayBtnImage = "GumbILabelZaIgranjeENG";
            }
            else
            {
                PlayBtnImage = "GumbILabelZaIgranje";
            }
        }

        public async Task DeletePlayerAsync(Player player)
        {
            if (Players.Count > 2)
            {
                Players.Remove(player);
                PlayerCounter = Players.Count.ToString();
            }   
            else
            {
                await ToastHelper.DisplayToastAsync(LocalizationResourceManager.Current["DeletePlayerError"]);
            }
        }

        public void AddPlayer()
        {
            ClickablePlus = false;
            Players.Add(new Player(int.Parse(PlayerCounter) + 1, $"{LocalizationResourceManager.Current["PlayerString"]} {int.Parse(PlayerCounter) + 1}", 
                Drunkards[new Random().Next(0, 6)].Path));
            PlayerCounter = Players.Count.ToString();
            ClickablePlus = true;
        }

        private async Task GetDrunkardsAsync()
        {
            Drunkards = await GameHelper.GetDrunkardsAsync();
        }

        private Task GetPlayersAsync()
        {
            Players.Add(new Player(1, $"{LocalizationResourceManager.Current["PlayerString"]} 1", Drunkards[new Random().Next(0, 6)].Path));
            Players.Add(new Player(2, $"{LocalizationResourceManager.Current["PlayerString"]} 2", Drunkards[new Random().Next(0, 6)].Path));
            PlayerCounter = Players.Count.ToString();
            return Task.CompletedTask;
        }

        private async Task GetColorListAsync()
        {
            Colors = await GameHelper.GetColorsAsync();
            RandomColor = Colors[new Random().Next(0, 3)].Code;
        }
        public Task ClearEntryText(Entry entry)
        {
            entry.Text = "";
            return Task.CompletedTask;
        }
        public Task ChangePlayerName(Entry entry)
        {
            if (entry.Text == "")
            {
                EmptyNameExists = true;
            }
            else
            {
                EmptyNameExists = false;
            }

            foreach (Player player in Players.Where(x => x.Name == entry.Text))
            {
                player.Name = entry.Text;
            }
            return Task.CompletedTask;
        }
        public async Task PlayGame()
        {
            if (!EmptyNameExists)
            {
                int counter = 0;
                foreach (Player player in Players.Where(x => x.Name == $"{LocalizationResourceManager.Current["PlayerNameDefault"]}" 
                || x.Name.StartsWith($"{LocalizationResourceManager.Current["PlayerNameEmpty"]}") || x.Name.StartsWith("Igrač") || x.Name.StartsWith("Player")))
                {
                    counter++;
                    player.Name = $"{LocalizationResourceManager.Current["PlayerNameEmpty"]} {counter}";
                }
                await Navigation.PushAsync(new IgranjeSIgracimaPage(Players.ToList()));
            }
            else
            {
                await ToastHelper.DisplayToastAsync($"{LocalizationResourceManager.Current["NicknameError"]}");
            }
        }
    }
}

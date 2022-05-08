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
using Xamarin.Forms;
using System.Linq;

namespace DamaPijeSama.ViewModels
{
    public class IgraciPage2ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private INavigation Navigation => Application.Current.MainPage.Navigation;
        public ObservableCollection<Igrac> Players { get; set; } = new ObservableCollection<Igrac>();
        public List<Pijanac> Drunkards { get; set; }
        public ObservableCollection<Boja> Boje { get; set; } = new ObservableCollection<Boja>();
        public ICommand GetColors { get; set; }
        public ICommand GetPlayers { get; }
        public ICommand GetDrunkards { get; set; }
        public ICommand FrameTapped { get; }
        public string RandomColor { get; set; }
        public string PlayerCounter { get; set; }
        public string PlayerDrunkardPicture { get; set; }
        public bool ClickablePlus { get; set; } = true;
        public bool EmptyNameExists { get; set; } = false;
        public IgraciPage2ViewModel()
        {
            GetDrunkards = new AsyncCommand(async () => await GetDrunkardsAsync());
            GetDrunkards.Execute(null);
            GetColors = new AsyncCommand(async () => await GetColorListAsync());
            GetColors.Execute(null);
            GetPlayers = new AsyncCommand(async () => await GetPlayersAsync());
            GetPlayers.Execute(null);
            FrameTapped = new AsyncCommand<Igrac>(async (igrac) => await DeletePlayerAsync(igrac));
        }

        public async Task DeletePlayerAsync(Igrac igrac)
        {
            if (Players.Count > 2)
            {
                Players.Remove(igrac);
                PlayerCounter = Players.Count.ToString();
            }   
            else
            {
                await ToastHelper.DisplayToastAsync("Pa nećeš valjda cugat' solo...");
            }
        }

        public void AddPlayer()
        {
            ClickablePlus = false;
            Players.Add(new Igrac(int.Parse(PlayerCounter) + 1, $"Igrač {int.Parse(PlayerCounter) + 1}", Drunkards[new Random().Next(0, 6)].Naziv));
            PlayerCounter = Players.Count.ToString();
            ClickablePlus = true;
        }

        private async Task GetDrunkardsAsync()
        {
            Drunkards = await GameHelper.GetDrunkardsAsync();
        }

        private Task GetPlayersAsync()
        {
            Players.Add(new Igrac(1, "Igrač 1", Drunkards[new Random().Next(0, 6)].Naziv));
            Players.Add(new Igrac(2, "Igrač 2", Drunkards[new Random().Next(0, 6)].Naziv));
            PlayerCounter = Players.Count.ToString();
            return Task.CompletedTask;
        }

        private async Task GetColorListAsync()
        {
            Boje = await GameHelper.GetColorsAsync();
            RandomColor = Boje[new Random().Next(0, 3)].Kod;
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

            foreach (Igrac player in Players.Where(x => x.Ime == entry.Text))
            {
                player.Ime = entry.Text;
            }
            return Task.CompletedTask;
        }
        public async Task PlayGame()
        {
            if (!EmptyNameExists)
            {
                int counter = 0;
                foreach (Igrac player in Players.Where(x => x.Ime == "Upiši ime"))
                {
                    counter++;
                    player.Ime = $"Bezimeni {counter}";
                }
                await Navigation.PushAsync(new IgranjeSIgracimaPage(Players.ToList()));
            }
            else
            {
                await ToastHelper.DisplayToastAsync("Bar dodaj svim igračima neki nadimak...");
            }
        }
    }
}

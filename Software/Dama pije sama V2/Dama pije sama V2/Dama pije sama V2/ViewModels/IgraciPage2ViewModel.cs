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

namespace DamaPijeSama.ViewModels
{
    public class IgraciPage2ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Igrac> Players { get; set; } = new ObservableCollection<Igrac>();
        public List<Pijanac> Drunkards { get; set; }
        public ObservableCollection<Boja> Boje { get; set; } = new ObservableCollection<Boja>();
        public ICommand GetColors { get; set; }
        public ICommand GetPlayers { get; }
        public ICommand GetDrunkards { get; set; }
        public string RandomColor { get; set; }
        public string PlayerCounter { get; set; } = "2";
        public string PlayerDrunkardPicture { get; set; }
        public IgraciPage2ViewModel()
        {
            GetDrunkards = new AsyncCommand(async () => await GetDrunkardsAsync());
            GetDrunkards.Execute(null);
            GetColors = new AsyncCommand(async () => await GetColorListAsync());
            GetColors.Execute(null);
            GetPlayers = new AsyncCommand(async () => await GetPlayersAsync());
            GetPlayers.Execute(null);
        }

        private async Task GetDrunkardsAsync()
        {
            Drunkards = await GameHelper.GetDrunkardsAsync();
        }

        private Task GetPlayersAsync()
        {
            Players.Add(new Igrac("Igrač 1", Drunkards[new Random().Next(0, 6)].Naziv));
            Players.Add(new Igrac("Igrač 2", Drunkards[new Random().Next(0, 6)].Naziv));
            return Task.CompletedTask;
        }

        private async Task GetColorListAsync()
        {
            Boje = await GameHelper.GetColorsAsync();
            RandomColor = Boje[new Random().Next(0, 3)].Kod;
        }
    }
}

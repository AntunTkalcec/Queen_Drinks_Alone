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
    public class AboutIgraPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Igra ChosenGame;
        public ObservableCollection<Boja> Boje { get; set; } = new ObservableCollection<Boja>();
        public ICommand GetColors { get; set; }
        public ICommand GetLabels { get; }
        public string RandomColor { get; set; }
        public string GameInfo { get; set; } 
        public string PlayerInfo { get; set; }
        public string PlayedCardsNumber { get; set; }
        public string GameLength { get; set; }
        public AboutIgraPageViewModel(Igra igra)
        {
            ChosenGame = igra;
            GetColors = new AsyncCommand(async () => await GetColorListAsync());
            GetColors.Execute(null);
            GetLabels = new AsyncCommand(async () => await GetLabelsAsync());
            GetLabels.Execute(null);
        }

        private Task GetLabelsAsync()
        {
            GameInfo = $"Igra {ChosenGame.Id} {ChosenGame.Datum}";
            PlayedCardsNumber = ChosenGame.BrOdigranihKarata.ToString();
            if (int.Parse(ChosenGame.DuljinaIgre) < 60)
            {
                GameLength = ChosenGame.DuljinaIgre + " sekundi";
            }
            else
            {
                GameLength = (int.Parse(ChosenGame.DuljinaIgre) / 60).ToString() + " minuta";
            }
            if (ChosenGame.BrojIgraca == 0)
            {
                PlayerInfo = "Ova se igra igrala bez igrača";
            }
            else
            {
                PlayerInfo = ChosenGame.PopisIgraca;
            }
            return Task.CompletedTask;
        }

        private async Task GetColorListAsync()
        {
            Boje = await GameHelper.GetColorsAsync();
            RandomColor = Boje[new Random().Next(0, 3)].Kod;
        }
    }
}

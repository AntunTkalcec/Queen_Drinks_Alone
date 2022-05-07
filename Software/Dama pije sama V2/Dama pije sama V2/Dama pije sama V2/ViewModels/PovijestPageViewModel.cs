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

namespace DamaPijeSama.ViewModels
{
    public class PovijestPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private INavigation Navigation => Application.Current.MainPage.Navigation;
        public ObservableCollection<Igra> Igre { get; set; } = new ObservableCollection<Igra>();
        public ObservableCollection<Boja> Boje { get; set; } = new ObservableCollection<Boja>();
        public ICommand GetColors { get; set; }
        public ICommand GetGames { get; set; }
        public ICommand OpenGame { get; }
        public string RandomColor { get; set; }
        public bool NoGamesPlayed { get; set; } = false;
        public bool Clickable { get; set; } = true;
        public PovijestPageViewModel()
        {
            GetColors = new AsyncCommand(async () => await GetColorListAsync());
            GetColors.Execute(null);
            GetGames = new AsyncCommand(async () => await GetGamesAsync());
            GetGames.Execute(null);
            OpenGame = new AsyncCommand<Igra>(async (igra) => await OpenSelectedGame(igra));
        }

        private async Task OpenSelectedGame(Igra igra)
        {
            Clickable = false;
            await Navigation.PushModalAsync(new AboutIgraPage(igra), true);
            Clickable = true;
        }

        private async Task GetGamesAsync()
        {
            try
            {
                Igre = await GameHelper.GetGamesAsync();
            }
            catch (Exception)
            {
                await ToastHelper.DisplayToastAsync("Nešto je pošlo po zlu. Ili ste previše popili...");
            }
        }

        private async Task GetColorListAsync()
        {
            Boje = await GameHelper.GetColorsAsync();
            RandomColor = Boje[new Random().Next(0, 3)].Kod;
        }
    }
}

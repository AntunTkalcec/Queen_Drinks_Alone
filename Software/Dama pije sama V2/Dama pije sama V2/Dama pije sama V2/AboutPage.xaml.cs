using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public List<Igrac> ListaIgraca;
        public AboutPage(List<Igrac> igraci)
        {
            InitializeComponent();
            BindingContext = this;
            if (igraci != null)
            {
                ListaIgraca = igraci;
            }
            else
            {
                ListaIgraca = new List<Igrac>();
            }
        }
        protected override bool OnBackButtonPressed()
        {
            _ = Navigation.PopAsync(true);
            return true;
        }

        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    }
}
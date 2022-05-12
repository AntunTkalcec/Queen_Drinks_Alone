using DamaPijeSama.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutIgraPage : ContentPage
    {
        private readonly AboutIgraPageViewModel vm;
        public AboutIgraPage(Game igra)
        {
            InitializeComponent();
            BindingContext = vm = new AboutIgraPageViewModel(igra);
        }
    }
}
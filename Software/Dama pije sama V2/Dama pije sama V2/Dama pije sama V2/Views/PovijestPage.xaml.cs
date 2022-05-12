using DamaPijeSama.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PovijestPage : ContentPage
    {
        private readonly PovijestPageViewModel vm;
        public PovijestPage()
        {
            InitializeComponent();

            BindingContext = vm = new PovijestPageViewModel();
        }
    }
}
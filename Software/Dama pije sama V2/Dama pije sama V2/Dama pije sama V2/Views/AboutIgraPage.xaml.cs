using DamaPijeSama.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutIgraPage : ContentPage
    {
        private readonly AboutIgraPageViewModel vm;
        public AboutIgraPage(Igra igra)
        {
            InitializeComponent();
            BindingContext = vm = new AboutIgraPageViewModel(igra);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace Dama_pije_sama_V2
{
    public partial class MainPage : ContentPage
    {
        List<Igrac> ListaIgraca;
        public MainPage(List<Igrac> igraci)
        {
            InitializeComponent();
            if (igraci != null)
            {
                ListaIgraca = igraci;
            }
            else
            {
                ListaIgraca = new List<Igrac>();
            }
        }

        private async void HelpIcon_Tapped(object sender, EventArgs e)
        {
            await AboutImage.ScaleTo(0.9, 125, Easing.Linear);
            await AboutImage.ScaleTo(1, 125, Easing.Linear);
            await Navigation.PushAsync(new AboutPage(ListaIgraca), true);
        }

        private async void Quickstart_Tapped(object sender, EventArgs e)
        {
            await AnimirajStisak(QuickstartShadows);
            await AnimirajOtpust(QuickstartShadows);
            await Navigation.PushAsync(new QuickstartPage(), true);
        }

        private async void Igraci_Tapped(object sender, EventArgs e)
        {
            await AnimirajStisak(IgraciShadows);
            await AnimirajOtpust(IgraciShadows);
            await Navigation.PushAsync(new IgraciPage2(), true);
            return;
            
        }

        private async void Povijest_Tapped(object sender, EventArgs e)
        {
            await AnimirajStisak(PovijestShadows);
            await AnimirajOtpust(PovijestShadows);
            await Navigation.PushAsync(new PovijestPage(ListaIgraca), true);
        }

        private async void Quickstart_Pressed(object sender, EventArgs e)
        {
            await AnimirajStisak(QuickstartShadows);
        }

        private async Task AnimirajStisak(Sharpnado.Shades.Shadows shadow)
        {
            await shadow.ScaleTo(0.9, 250, Easing.Linear);
        }

        private async void Quickstart_Released(object sender, EventArgs e)
        {
            await AnimirajOtpust(QuickstartShadows);
        }

        private async Task AnimirajOtpust(Sharpnado.Shades.Shadows shadow)
        {
            await shadow.ScaleTo(1, 250, Easing.Linear);
        }

        private async void Igraci_Pressed(object sender, EventArgs e)
        {
            await IgraciShadows.ScaleTo(0.9, 250, Easing.Linear);
        }

        private async void Igraci_Released(object sender, EventArgs e)
        {
            await IgraciShadows.ScaleTo(1, 250, Easing.Linear);
        }

        private async void Povijest_Pressed(object sender, EventArgs e)
        {
            await PovijestShadows.ScaleTo(0.9, 250, Easing.Linear);
        }

        private async void Povijest_Released(object sender, EventArgs e)
        {
            await PovijestShadows.ScaleTo(1, 250, Easing.Linear);
        }
    }
}

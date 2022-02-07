using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamanimation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IgraciPage2 : ContentPage
    {
        int brojac = 0;
        List<Igrac> Igraci = new List<Igrac>();
        List<Igrac> Igraci2 = new List<Igrac>();
        List<Pijanac> Pijanci = new List<Pijanac>();
        static Random rnd = new Random();
        public IgraciPage2(List<Igrac> igraci)
        {
            InitializeComponent();
            StvoriListuPijanaca();
            Igraci2 = igraci;
            if (Igraci2 != null)
            {
                Igraci = Igraci2;
                PokaziIgrace();
            }
        }

        private void PokaziIgrace()
        {
            foreach (Igrac igrac in Igraci2)
            {
                int r = rnd.Next(Pijanci.Count);
                Frame frame = new Frame
                {
                    BackgroundColor = Color.FromHex("#FFFFFF"),
                    WidthRequest = 265,
                    CornerRadius = 15,
                    HeightRequest = 60,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = new Thickness(0, 13, 0, 0),
                    Content = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            new Frame
                            {
                                WidthRequest = 90,
                                VerticalOptions = LayoutOptions.Center,
                                HorizontalOptions = LayoutOptions.Start,
                                CornerRadius = 15,
                                IsClippedToBounds = true,
                                Padding = 0,
                                Content = new Image
                                {
                                    Source = Pijanci.ElementAt(r).Naziv,
                                    HorizontalOptions = LayoutOptions.Center,
                                    VerticalOptions = LayoutOptions.Center,
                                    Aspect = Aspect.AspectFill,
                                },
                            },
                            new Label
                            {
                                Text = $"{igrac.Ime}",
                                FontSize = 30,
                                TextColor = Color.FromHex("#000"),
                                FontFamily = "Spicy Rice",
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                HorizontalTextAlignment = TextAlignment.Center,
                                Margin = new Thickness(25, 0, 0, 0),
                            },
                        }
                    }
                };
                TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += async (s, eve) =>
                {
                    await ObrisiIgracaAsync(frame, igrac.Ime);
                };
                frame.GestureRecognizers.Add(tapGestureRecognizer);
                IgraciStackLayout.Children.Add(frame);
                ImeIgracaEntry.Text = "";
            }
        }

        private async Task ObrisiIgracaAsync(Frame frame, string ime)
        {
            await AnimirajBrisanje(frame);
            _ = IgraciStackLayout.Children.Remove(frame);
            Igraci.RemoveAll(x => x.Ime == ime);
        }

        private async Task AnimirajBrisanje(Frame frame)
        {
            _ = await frame.Animate(new FadeToAnimation());
        }

        private void StvoriListuPijanaca()
        {
            Pijanci.Add(new Pijanac("DrunkGirl1"));
            Pijanci.Add(new Pijanac("DrunkGirl2"));
            Pijanci.Add(new Pijanac("DrunkGuy1"));
            Pijanci.Add(new Pijanac("DrunkGuy2"));
            Pijanci.Add(new Pijanac("DrunkGuy3"));
            Pijanci.Add(new Pijanac("DrunkGuy4"));
            Pijanci.Add(new Pijanac("DrunkGuy5"));
        }

        private void Dodaj_Tapped(object sender, EventArgs e)
        {
            if (ImeIgracaEntry.Text == "" || ImeIgracaEntry.Text == null)
            {
                return;
            }
            else
            {
                int r = rnd.Next(Pijanci.Count);
                string ime = ImeIgracaEntry.Text;
                Igrac noviIgrac = new Igrac(ime, 1);
                Igraci.Add(noviIgrac);
                Frame frame = new Frame
                {
                    BackgroundColor = Color.FromHex("#FFFFFF"),
                    WidthRequest = 265,
                    CornerRadius = 15,
                    HeightRequest = 60,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = new Thickness(0, 13, 0, 0),
                    Content = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            new Frame
                            {
                                WidthRequest = 90,
                                VerticalOptions = LayoutOptions.Center,
                                HorizontalOptions = LayoutOptions.Start,
                                CornerRadius = 15,
                                IsClippedToBounds = true,
                                Padding = 0,
                                Content = new Image
                                {
                                    Source = Pijanci.ElementAt(r).Naziv,
                                    HorizontalOptions = LayoutOptions.Center,
                                    VerticalOptions = LayoutOptions.Center,
                                    Aspect = Aspect.AspectFill,
                                },
                            },
                            new Label
                            {
                                Text = $"{ime}",
                                FontSize = 30,
                                TextColor = Color.FromHex("#000"),
                                FontFamily = "Spicy Rice",
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                HorizontalTextAlignment = TextAlignment.Center,
                                Margin = new Thickness(25, 0, 0, 0),
                            },
                        }
                    }
                };
                TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += async (s, eve) =>
                {
                    await ObrisiIgracaAsync(frame, noviIgrac.Ime);
                };
                frame.GestureRecognizers.Add(tapGestureRecognizer);
                IgraciStackLayout.Children.Add(frame);
                ImeIgracaEntry.Text = "";
                return;
            }
        }

        private void HomeButton_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage(Igraci);
            return;
        }

        private void Igraj_Tapped(object sender, EventArgs e)
        {
            if (Igraci.Count > 0)
            {
                Application.Current.MainPage = new IgranjeSIgracimaPage(Igraci);
                return;
            }
            else
            {
                Application.Current.MainPage = new QuickstartPage();
                return;
            }
        }
        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new MainPage(Igraci);
            return true;
        }
    }
}
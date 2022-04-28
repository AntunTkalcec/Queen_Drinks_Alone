using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PovijestPage : ContentPage
    {
        public List<Igrac> ListaIgraca;
        static Random rnd = new Random();
        private List<Boja> Boje = new List<Boja>();
        public PovijestPage(List<Igrac> igraci)
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
            StvoriListuBoja();

            PokaziIgre();
        }

        private void StvoriListuBoja()
        {
            Boje.Add(new Boja("#8f2ce0"));
            Boje.Add(new Boja("#e02cd7"));
            Boje.Add(new Boja("#352ce0"));
            Boje.Add(new Boja("#a01699"));
        }

        private async void PokaziIgre()
        {
            try
            {
                int r = rnd.Next(Boje.Count);
                string odabranaBoja = Boje.ElementAt(r).Kod;
                List<Igra> Igre = await App.IgraRepo.GetIgreAsync();
                if (Igre.Count == 0)
                {
                    IgreStackLayout.VerticalOptions = LayoutOptions.CenterAndExpand;
                    IgreStackLayout.Children.Add(new Label
                    {
                        Text = "Igre će se pojaviti ovdje kad započneš jednu",
                        TextColor = Color.FromHex($"{odabranaBoja}"),
                        FontFamily = "Spicy Rice",
                        FontSize = 18,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                    });
                }
                else
                {
                    foreach (Igra igra in Igre)
                    {
                        r = rnd.Next(Boje.Count);
                        odabranaBoja = Boje.ElementAt(r).Kod;
                        Frame frame = new Frame
                        {
                            BackgroundColor = Color.FromHex("#FDB73E"),
                            HorizontalOptions = LayoutOptions.Center,
                            WidthRequest = 280,
                            HeightRequest = 60,
                            CornerRadius = 15,
                            Margin = new Thickness(0, 19, 0, 0),
                            HasShadow = true,
                            BorderColor = Color.FromHex("#C4C4C4"),
                            Content = new StackLayout
                            {
                                Children =
                                {
                                    new Label
                                    {
                                        Text = $"Igra broj {igra.Id}",
                                        TextColor = Color.FromHex($"{odabranaBoja}"),
                                        FontFamily = "Spicy Rice",
                                        HorizontalOptions = LayoutOptions.Center,
                                        FontSize = 18,
                                    },
                                    new StackLayout
                                    {
                                        Orientation = StackOrientation.Horizontal,
                                        Children =
                                        {
                                            new Label
                                            {
                                                Text = $"{igra.Datum}",
                                                TextColor = Color.FromHex($"{odabranaBoja}"),
                                                FontFamily = "Cagliostro",
                                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                                VerticalOptions = LayoutOptions.Center,
                                                FontSize = 16,
                                            },
                                            new Label
                                            {
                                                Text = $"{igra.BrojIgraca} igrača",
                                                TextColor = Color.FromHex($"{odabranaBoja}"),
                                                FontFamily = "Cagliostro",
                                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                                VerticalOptions = LayoutOptions.Center,
                                                FontSize = 16,
                                            },
                                        }
                                    }
                                }
                            }
                        };
                        IgreStackLayout.Children.Add(frame);
                        TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += (s, eve) =>
                        {
                            OtvoriIgru(frame, igra);
                        };
                        frame.GestureRecognizers.Add(tapGestureRecognizer);
                    }
                }
            }
            catch (Exception ex)
            {
                await Device.InvokeOnMainThreadAsync(async () => await Application.Current.MainPage.DisplayToastAsync("Nešto je pošlo po zlu. Ili si samo prepijan.", 3000));
            }
        }

        private async void OtvoriIgru(Frame frame, Igra igra)
        {
            if (ListaIgraca != null && ListaIgraca.Count > 0)
            {
                await frame.ScaleTo(0.9, 125, Easing.Linear);
                await frame.ScaleTo(1, 125, Easing.Linear);
                _ = Navigation.PushAsync(new AboutIgraPage(ListaIgraca, igra), true);
            }
            else
            {
                await frame.ScaleTo(0.9, 125, Easing.Linear);
                await frame.ScaleTo(1, 125, Easing.Linear);
                _ = Navigation.PushAsync(new AboutIgraPage(null, igra),true);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            _ = Navigation.PopAsync(true);
            return true;
        }
    }
}
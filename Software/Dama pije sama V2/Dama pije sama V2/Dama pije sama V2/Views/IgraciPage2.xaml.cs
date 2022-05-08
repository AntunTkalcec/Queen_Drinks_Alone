using DamaPijeSama.Services;
using DamaPijeSama.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dama_pije_sama_V2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IgraciPage2 : ContentPage
    {
        private IgraciPage2ViewModel vm;
        bool praznoImePostoji = false;
        public IgraciPage2()
        {
            InitializeComponent();

            BindingContext = vm = new IgraciPage2ViewModel();
        }

        //private async Task ObrisiIgracaAsync(Frame frame)
        //{
        //    if (Igraci.Count < 3)
        //    {
        //        await DisplayAlert("Molim?", "Pa nećeš valjda sam pit'?", "Neću");
        //        return;
        //    }
        //    else
        //    {
        //        Igraci.RemoveAll(x => x.Frame == frame);
        //        await AnimirajBrisanje(frame);
        //        _ = IgraciStackLayout.Children.Remove(frame);
        //        PlayerCountLabel.Text = Igraci.Count.ToString();
        //        return; 
        //    }
        //}

        //private async void Igraj_Tapped(object sender, EventArgs e)
        //{
        //    if (praznoImePostoji)
        //    {
        //        await DisplayAlert("Čekaj", "Bar dodaj svim igračima neki nadimak...", "OK");
        //        return;
        //    }
        //    if (Igraci.Count > 0)
        //    {
        //        await IgrajGumb.ScaleTo(0.9, 125, Easing.Linear);
        //        await IgrajGumb.ScaleTo(1, 125, Easing.Linear);
        //        _ = Navigation.PushAsync(new IgranjeSIgracimaPage(Igraci), true);
        //    }
        //    else
        //    {
        //        _ = Navigation.PushAsync(new QuickstartPage(), true);
        //    }
        //}

        private async void PlusLabel_Tapped(object sender, EventArgs e)
        {
            vm.AddPlayer();
            PlayerCountLabel.CancelAnimations();           
            await PlayerCountLabel.TranslateTo(-10, 0, 50);
            await PlayerCountLabel.TranslateTo(10, 0, 50);
            await PlayerCountLabel.TranslateTo(-5, 0, 50);
            await PlayerCountLabel.TranslateTo(5, 0, 50);
            await PlayerCountLabel.TranslateTo(-2.5, 0, 50);
            await PlayerCountLabel.TranslateTo(-2.5, 0, 50);
            PlayerCountLabel.TranslationX = 0;
        }

        private async void Igraj_Tapped(object sender, EventArgs e)
        {
            await IgrajGumb.ScaleTo(0.9, 125, Easing.Linear);
            await IgrajGumb.ScaleTo(1, 125, Easing.Linear);
            await vm.PlayGame();
        }

        private async void Entry_Focused(object sender, FocusEventArgs e)
        {
            await vm.ClearEntryText(sender as Entry);
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            if ((sender as Entry).Text == "")
            {
                (sender as Entry).Text = "Upiši ime";
            }
        }

        private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            await vm.ChangePlayerName(sender as Entry);
        }

        //private async void PlusLabel_Tapped(object sender, EventArgs e)
        //{
        //    PlayerCountLabel.CancelAnimations();
        //    int r = rnd.Next(Pijanci.Count);
        //    int r2 = rnd.Next(Boje.Count);
        //    string odabranaBoja = Boje.ElementAt(r2).Kod;
        //    Frame frame = new Frame
        //    {
        //        BackgroundColor = Color.FromHex("#FFFFFF"),
        //        WidthRequest = 265,
        //        CornerRadius = 15,
        //        HeightRequest = 60,
        //        VerticalOptions = LayoutOptions.Start,
        //        HorizontalOptions = LayoutOptions.Center,
        //        Margin = new Thickness(0, 13, 0, 0),
        //        HasShadow = true,
        //        BorderColor = Color.FromHex("#C4C4C4"),
        //    };

        //    StackLayout noviStackLayout = new StackLayout
        //    {
        //        Orientation = StackOrientation.Horizontal,
        //        Children =
        //        {
        //            new Frame
        //            {
        //                WidthRequest = 90,
        //                VerticalOptions = LayoutOptions.Center,
        //                HorizontalOptions = LayoutOptions.Start,
        //                CornerRadius = 15,
        //                IsClippedToBounds = true,
        //                Padding = 0,
        //                Content = new Image
        //                {
        //                    Source = Pijanci.ElementAt(r).Naziv,
        //                    HorizontalOptions = LayoutOptions.Center,
        //                    VerticalOptions = LayoutOptions.Center,
        //                    Aspect = Aspect.AspectFill,
        //                },
        //            }
        //        }
        //    };

        //    Entry noviIgracEntry = new Entry
        //    {
        //        Text = "Upiši ime",
        //        FontSize = 30,
        //        TextColor = Color.FromHex($"{odabranaBoja}"),
        //        FontFamily = "Spicy Rice",
        //        HorizontalOptions = LayoutOptions.CenterAndExpand,
        //        VerticalOptions = LayoutOptions.Center,
        //        HorizontalTextAlignment = TextAlignment.Center,
        //    };

        //    noviStackLayout.Children.Add(noviIgracEntry);
        //    frame.Content = noviStackLayout;

        //    TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
        //    tapGestureRecognizer.Tapped += async (s, eve) =>
        //    {
        //        await ObrisiIgracaAsync(frame);
        //    };
        //    frame.GestureRecognizers.Add(tapGestureRecognizer);

        //    IgraciStackLayout.Children.Add(frame);

        //    Igrac noviIgrac = new Igrac("Igrač", frame);
        //    Igraci.Add(noviIgrac);

        //    noviIgracEntry.TextChanged += (s, eve) =>
        //    {
        //        PromjeniImeIgracu(noviIgracEntry.Text, frame);
        //    };
        //    noviIgracEntry.Focused += (s, eve) =>
        //    {
        //        noviIgracEntry.Text = "";
        //    };

        //    PlayerCountLabel.Text = Igraci.Count.ToString();
        //    await PlayerCountLabel.TranslateTo(-10, 0, 50);
        //    await PlayerCountLabel.TranslateTo(10, 0, 50);
        //    await PlayerCountLabel.TranslateTo(-5, 0, 50);
        //    await PlayerCountLabel.TranslateTo(5, 0, 50);
        //    await PlayerCountLabel.TranslateTo(-2.5, 0, 50);
        //    await PlayerCountLabel.TranslateTo(-2.5, 0, 50);
        //    PlayerCountLabel.TranslationX = 0;
        //    return;
        //}

        //private void PromjeniImeIgracu(string text, Frame frame)
        //{
        //    if (text == "")
        //    {
        //        praznoImePostoji = true;
        //    }
        //    else
        //    {
        //        praznoImePostoji = false;
        //    }
        //    foreach (Igrac player in Igraci.Where(x => x.Frame == frame))
        //    {
        //        player.Ime = text;
        //    }

        //    return;
        //}
    }
}
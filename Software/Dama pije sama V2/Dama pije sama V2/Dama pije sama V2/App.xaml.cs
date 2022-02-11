using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("SpicyRice-Regular.ttf", Alias = "Spicy Rice")]
[assembly: ExportFont("Cagliostro-Regular.ttf", Alias = "Cagliostro")]
[assembly: ExportFont("FontAwesome6Brands.otf", Alias = "FABrands")]
[assembly: ExportFont("FontAwesome6Regular.otf", Alias = "FARegular")]
[assembly: ExportFont("FontAwesome6Solid.otf", Alias = "FASolid")]

namespace Dama_pije_sama_V2
{
    public partial class App : Application
    {
        public string dbPath => FileAccessHelper.GetLocalFilePath("damapijesama.db3");
        public static IgraRepository IgraRepo { get; private set; }
        public App()
        {
            InitializeComponent();
            IgraRepo = new IgraRepository(dbPath);
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);

            MainPage = new NavigationPage(new MainPage(null));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

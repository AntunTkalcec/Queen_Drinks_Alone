using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.AppCompat.App;

namespace Dama_pije_sama_V2.Droid
{
    [Activity(Label = "Queen Drinks Alone", MainLauncher = true, NoHistory = true, Theme = "@style/SplashTheme")]
    public class SplashActivity : AppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
        public override void OnBackPressed()
        {
        }
    }
}
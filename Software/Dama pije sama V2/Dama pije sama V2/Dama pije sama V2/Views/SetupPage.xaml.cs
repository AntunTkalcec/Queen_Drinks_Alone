using Dama_pije_sama_V2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DamaPijeSama.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupPage : ContentPage
    {
        public SetupPage()
        {
            InitializeComponent();
        }

        private void CroBtnClicked(object sender, EventArgs e)
        {
            CroatianBtn.ScaleTo(1.2, 200, Easing.Linear);
            EnglishBtn.ScaleTo(1, 150, Easing.Linear);
        }

        private void EngBtnClicked(object sender, EventArgs e)
        {
            CroatianBtn.ScaleTo(1, 150, Easing.Linear);
            EnglishBtn.ScaleTo(1.2, 200, Easing.Linear);
        }
    }
}
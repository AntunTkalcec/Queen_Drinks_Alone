using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;

namespace DamaPijeSama.Services
{
    public static class ToastHelper
    {
        /// <summary>
        /// Displays a toast using the primary application color, with a corner radius of 30 and a duration of 3 seconds.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <returns></returns>
        public static async Task DisplayToastAsync(string msg)
        {
            var options = new ToastOptions()
            {
                MessageOptions = new MessageOptions
                {
                    Foreground = Color.White,
                    Message = msg
                },
                BackgroundColor = Color.FromHex("#FDB73E"),
                Duration = TimeSpan.FromSeconds(3),
                CornerRadius = 30
            };
            await Device.InvokeOnMainThreadAsync(async () => await Application.Current.MainPage.DisplayToastAsync(options));
        }
    }
}

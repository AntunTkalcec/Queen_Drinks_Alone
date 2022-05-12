using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Globalization;

namespace DamaPijeSama.Converters
{
    public class DateTimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            var datetime = (DateTime)value;
            if (Preferences.Get("language", "en-US") == "en-US")
            {
                return datetime.ToString("dddd, dd MMMM yyyy");
            }
            else
            {
                return datetime.ToString("dd.MM.yyyy HH:mm");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

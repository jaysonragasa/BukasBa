using System;
using System.Globalization;
using Xamarin.Forms;

namespace BukasBa.UI.Converters
{
    public class Converter_FormatTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string ret = string.Empty;

            if(value is TimeSpan)
            {
                string format = parameter != null ? (string)parameter : "h:mm";

                var ds = new DateTime(((TimeSpan)value).Ticks);

                ret = ds.ToString(format);
            }

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
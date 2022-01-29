using System;
using System.Globalization;
using System.Windows.Data;

namespace AudioSynthesiser.ViewModel.Converters
{
    public class LogNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = value.ToString();
            if (string.IsNullOrWhiteSpace(stringValue)) return null;

            var intValue = int.Parse(stringValue);
            return Math.Log(intValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)Math.Exp((double)value);
        }
    }
}

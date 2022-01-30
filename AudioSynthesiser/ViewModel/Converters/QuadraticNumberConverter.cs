using System;
using System.Globalization;
using System.Windows.Data;

namespace AudioSynthesiser.ViewModel.Converters
{
    public class QuadraticNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = value.ToString();
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return null;
            }

            int intValue = int.Parse(stringValue);
            return Math.Sqrt(intValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)((double)value * (double)value);
        }
    }
}

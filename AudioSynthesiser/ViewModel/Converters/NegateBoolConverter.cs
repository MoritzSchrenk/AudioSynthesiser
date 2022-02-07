using System;
using System.Globalization;
using System.Windows.Data;

namespace AudioSynthesiser.ViewModel.Converters
{
    public class NegateBoolConverter : IValueConverter
    {
        /// <summary>
        /// Returns the inverse of value
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        /// <summary>
        /// Returns the inverse of value
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}

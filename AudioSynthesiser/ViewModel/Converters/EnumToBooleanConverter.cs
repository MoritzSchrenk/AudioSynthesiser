using System;
using System.Globalization;
using System.Windows.Data;

namespace AudioSynthesiser.ViewModel.Converters
{
    public class EnumToBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Returns true if value is the same as param
        /// </summary>
        public object Convert(object value, Type targetType, object param, CultureInfo culture)
        {
            return value.Equals(param);
        }

        /// <summary>
        /// Returns param if value is true
        /// </summary>
        public object ConvertBack(object value, Type targetType, object param, CultureInfo culture)
        {
            return (bool)value ? param : Binding.DoNothing;
        }
    }
}

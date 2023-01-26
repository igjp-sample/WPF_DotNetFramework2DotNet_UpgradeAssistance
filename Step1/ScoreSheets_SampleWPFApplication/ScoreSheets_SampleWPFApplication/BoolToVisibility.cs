using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ScoreSheets_SampleWPFApplication
{
    internal class BoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null
                || value.GetType() != typeof(bool))
            {
                return Binding.DoNothing;
            }

            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null
                || value.GetType() != typeof(Visibility))
            {
                return Binding.DoNothing;
            }

            return ((Visibility)value) == Visibility.Visible ? true : false;
        }
    }
}

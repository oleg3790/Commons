using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace XApp.Presentation.Conversion
{
    public class NullValueVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            parameter = parameter == null ? string.Empty : parameter;

            if (parameter.ToString().Equals("Null:Off"))
                return (value == null) ? Visibility.Collapsed : Visibility.Visible;
            else
                return (value == null) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

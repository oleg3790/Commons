using System;
using System.Globalization;
using System.Windows.Data;

namespace Commons.Wpf.ControlLibrary
{
    public class NullObjectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return true;
            else if (value.GetType() == typeof(string))
                return (value == null ? true : string.IsNullOrWhiteSpace(value.ToString()));
            else
                return false;        
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

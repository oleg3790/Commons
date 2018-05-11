using System;
using System.Globalization;
using System.Windows.Data;

namespace Commons.ControlLibrary
{
    public class DateConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            try
            {
                value = System.Convert.ToDateTime(value).ToString("dd-MMM-yy");
            }
            catch
            {
                value = DateTime.Today;
            }
            return value;
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            try
            {
                value = System.Convert.ToDateTime(value).ToString("dd-MMM-yy");
            }
            catch
            {
                value = DateTime.Today;
            }
            return value;
        }
    }
}

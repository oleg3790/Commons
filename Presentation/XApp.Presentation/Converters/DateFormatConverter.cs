using System;
using System.Globalization;
using System.Windows.Data;

namespace XApp.Presentation.Conversion
{
    /// <summary>
    /// Converts a DateTime value to a specific string format
    /// </summary>
    public class DateFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null 
                    && (value.GetType() == typeof(DateTime) || value.GetType() == typeof(DateTime?))
                    && parameter != null)
                    value = System.Convert.ToDateTime(value).ToString(parameter.ToString());

                if (parameter == null)
                    throw new FormatException("convert parameter needs to be passed for DateTime string format");
            }
            catch
            {
                
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

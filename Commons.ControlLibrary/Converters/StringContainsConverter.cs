using System;
using System.Globalization;
using System.Windows.Data;

namespace Commons.ControlLibrary
{
    public class StringContainsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value.ToString().ToLower().Contains(parameter.ToString().ToLower()))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                if (parameter == null)
                    throw new NullReferenceException("ConverterParameter is required");
                else
                    throw new Exception();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

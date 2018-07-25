using System;
using System.Globalization;
using System.Windows.Data;

namespace Commons.Wpf.ControlLibrary
{
    /// <summary>
    /// Converts a GUID to a specific format string passed in through the parameter
    /// </summary>
    public class GuidConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            try
            {
                if (value != null
                && (value.GetType() == typeof(Guid) || value.GetType() == typeof(Guid?))
                && parameter != null)
                    value = ((Guid)value).ToString(parameter.ToString()).ToUpper();

                if (parameter == null)
                    throw new NullReferenceException("convert parameter needs to be passed in the form of a Guid string format");
            }
            catch
            {
                
            }
            return value;
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
}

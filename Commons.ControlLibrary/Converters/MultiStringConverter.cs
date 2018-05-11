using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Commons.ControlLibrary
{
    public class MultiStringConverter : IMultiValueConverter
    {
        public object Convert( object[] value, Type targetType, object parameter, CultureInfo culture )
        {
            try
            {
                string returnValue = string.Empty;
                foreach (object x in value)
                {
                    if (x != DependencyProperty.UnsetValue && !string.IsNullOrWhiteSpace(x.ToString()))
                        returnValue = x.ToString();
                }

                return returnValue;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object[] ConvertBack( object value, Type[] targetTypes, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace XApp.Presentation.Conversion
{
    public class MultiStringConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string returnValue = string.Empty;
                foreach (object x in value)
                {
                    if (x != null && x != DependencyProperty.UnsetValue && !string.IsNullOrWhiteSpace(x.ToString()))
                        returnValue = x.ToString();
                }

                return returnValue;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

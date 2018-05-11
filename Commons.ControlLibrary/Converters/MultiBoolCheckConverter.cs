using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Commons.ControlLibrary
{
    public class MultiBoolCheckConverter : IMultiValueConverter
    {
        public object Convert( object[] value, Type targetType, object parameter, CultureInfo culture )
        {
            try
            {
                if (value.Any(x => x.Equals(true)))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

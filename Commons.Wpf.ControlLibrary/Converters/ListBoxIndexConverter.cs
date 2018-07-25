using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Commons.Wpf.ControlLibrary
{
    public class ListBoxIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string returnValue = string.Empty;

            try
            {
                string prefix = parameter.ToString().Replace("_"," ");
                ListBoxItem item = (ListBoxItem)value;
                ListBox listBox = ItemsControl.ItemsControlFromItemContainer(item) as ListBox;
                int index = listBox.ItemContainerGenerator.IndexFromContainer(item) + 1;
                returnValue = string.Format("{0} {1}", prefix, index);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

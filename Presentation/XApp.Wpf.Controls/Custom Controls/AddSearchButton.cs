using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class AddSearchButton : Button
    {
        static AddSearchButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AddSearchButton), new FrameworkPropertyMetadata(typeof(AddSearchButton)));
        }
    }
}

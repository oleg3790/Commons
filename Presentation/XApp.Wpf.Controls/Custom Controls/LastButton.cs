using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class LastButton : Button
    {
        static LastButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LastButton), new FrameworkPropertyMetadata(typeof(LastButton)));
        }
    }
}

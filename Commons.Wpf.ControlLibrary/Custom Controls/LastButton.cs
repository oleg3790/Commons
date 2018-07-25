using System.Windows;
using System.Windows.Controls;

namespace Commons.Wpf.ControlLibrary
{
    public class LastButton : Button
    {
        static LastButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LastButton), new FrameworkPropertyMetadata(typeof(LastButton)));
        }
    }
}

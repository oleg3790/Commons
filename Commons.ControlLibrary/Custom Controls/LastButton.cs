using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public class LastButton : Button
    {
        static LastButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LastButton), new FrameworkPropertyMetadata(typeof(LastButton)));
        }
    }
}

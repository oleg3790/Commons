using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public class MaximizeButton : Button
    {
        static MaximizeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MaximizeButton), new FrameworkPropertyMetadata(typeof(MaximizeButton)));
        }
    }
}

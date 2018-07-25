using System.Windows;
using System.Windows.Controls;

namespace Commons.Wpf.ControlLibrary
{
    public class DownArrowIcon : Label
    {
        static DownArrowIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DownArrowIcon), new FrameworkPropertyMetadata(typeof(DownArrowIcon)));
        }
    }
}

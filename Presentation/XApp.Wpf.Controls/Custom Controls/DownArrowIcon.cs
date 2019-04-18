using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class DownArrowIcon : Label
    {
        static DownArrowIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DownArrowIcon), new FrameworkPropertyMetadata(typeof(DownArrowIcon)));
        }
    }
}

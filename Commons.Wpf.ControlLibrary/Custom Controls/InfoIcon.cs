using System.Windows;
using System.Windows.Controls;

namespace Commons.Wpf.ControlLibrary
{
    public class InfoIcon : Label
    {
        static InfoIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InfoIcon), new FrameworkPropertyMetadata(typeof(InfoIcon)));
        }
    }
}

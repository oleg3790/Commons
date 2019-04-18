using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class InfoIcon : Label
    {
        static InfoIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InfoIcon), new FrameworkPropertyMetadata(typeof(InfoIcon)));
        }
    }
}

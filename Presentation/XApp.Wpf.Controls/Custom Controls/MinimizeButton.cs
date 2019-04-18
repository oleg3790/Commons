using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class MinimizeButton : Button
    {
        static MinimizeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MinimizeButton), new FrameworkPropertyMetadata(typeof(MinimizeButton)));
        }
    }
}

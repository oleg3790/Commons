using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class MaximizeButton : Button
    {
        static MaximizeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MaximizeButton), new FrameworkPropertyMetadata(typeof(MaximizeButton)));
        }
    }
}

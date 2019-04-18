using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class RefreshButton : Button
    {
        static RefreshButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RefreshButton), new FrameworkPropertyMetadata(typeof(RefreshButton)));
        }
    }
}

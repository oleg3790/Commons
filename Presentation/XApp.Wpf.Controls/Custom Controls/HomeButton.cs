using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class HomeButton : Button
    {
        static HomeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HomeButton), new FrameworkPropertyMetadata(typeof(HomeButton)));
        }
    }
}

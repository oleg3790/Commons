using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public class HomeButton : Button
    {
        static HomeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HomeButton), new FrameworkPropertyMetadata(typeof(HomeButton)));
        }
    }
}

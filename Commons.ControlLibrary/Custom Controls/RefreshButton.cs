using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public class RefreshButton : Button
    {
        static RefreshButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RefreshButton), new FrameworkPropertyMetadata(typeof(RefreshButton)));
        }
    }
}

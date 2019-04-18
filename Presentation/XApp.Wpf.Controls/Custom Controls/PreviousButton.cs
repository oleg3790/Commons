using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class PreviousButton : Button
    {
        static PreviousButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PreviousButton), new FrameworkPropertyMetadata(typeof(PreviousButton)));
        }
    }
}

using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class ExitButton : Button
    {
        static ExitButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExitButton), new FrameworkPropertyMetadata(typeof(ExitButton)));
        }
    }
}

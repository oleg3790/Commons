using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class ResetButton : Button
    {
        static ResetButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResetButton), new FrameworkPropertyMetadata(typeof(ResetButton)));
        }
    }
}

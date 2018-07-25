using System.Windows;
using System.Windows.Controls;

namespace Commons.Wpf.ControlLibrary
{
    public class ResetButton : Button
    {
        static ResetButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResetButton), new FrameworkPropertyMetadata(typeof(ResetButton)));
        }
    }
}

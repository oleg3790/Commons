using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public class ExitButton : Button
    {
        static ExitButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExitButton), new FrameworkPropertyMetadata(typeof(ExitButton)));
        }
    }
}

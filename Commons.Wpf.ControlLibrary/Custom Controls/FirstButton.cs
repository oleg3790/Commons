using System.Windows;
using System.Windows.Controls;

namespace Commons.Wpf.ControlLibrary
{
    public class FirstButton : Button
    {
        static FirstButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FirstButton), new FrameworkPropertyMetadata(typeof(FirstButton)));
        }
    }
}

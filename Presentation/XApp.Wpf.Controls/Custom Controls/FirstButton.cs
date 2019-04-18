using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class FirstButton : Button
    {
        static FirstButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FirstButton), new FrameworkPropertyMetadata(typeof(FirstButton)));
        }
    }
}

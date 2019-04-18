using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class NextButton : Button
    {
        static NextButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NextButton), new FrameworkPropertyMetadata(typeof(NextButton)));
        }
    }
}

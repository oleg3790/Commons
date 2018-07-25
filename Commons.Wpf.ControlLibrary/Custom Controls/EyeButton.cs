using System.Windows;
using System.Windows.Controls;

namespace Commons.Wpf.ControlLibrary
{
    public class EyeButton : Button
    {
        static EyeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EyeButton), new FrameworkPropertyMetadata(typeof(EyeButton)));
        }
    }
}

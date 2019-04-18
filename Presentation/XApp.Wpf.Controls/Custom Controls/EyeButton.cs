using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class EyeButton : Button
    {
        static EyeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EyeButton), new FrameworkPropertyMetadata(typeof(EyeButton)));
        }
    }
}

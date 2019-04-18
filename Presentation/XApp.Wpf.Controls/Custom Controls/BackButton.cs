using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class BackButton : Button
    {
        static BackButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BackButton), new FrameworkPropertyMetadata(typeof(BackButton)));
        }
    }
}

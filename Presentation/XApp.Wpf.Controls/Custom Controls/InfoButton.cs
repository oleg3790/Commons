using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class InfoButton : Button
    {
        static InfoButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InfoButton), new FrameworkPropertyMetadata(typeof(InfoButton)));
        }
    }
}

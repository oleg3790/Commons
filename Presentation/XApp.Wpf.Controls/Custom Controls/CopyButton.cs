using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class CopyButton : Button
    {
        static CopyButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CopyButton), new FrameworkPropertyMetadata(typeof(CopyButton)));
        }
    }
}

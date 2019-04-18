using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class RemoveButton : Button
    {
        static RemoveButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RemoveButton), new FrameworkPropertyMetadata(typeof(RemoveButton)));
        }
    }
}

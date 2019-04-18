using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class AddButton : Button
    {
        static AddButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AddButton), new FrameworkPropertyMetadata(typeof(AddButton)));
        }
    }
}

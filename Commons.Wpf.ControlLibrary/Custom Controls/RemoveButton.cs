using System.Windows;
using System.Windows.Controls;

namespace Commons.Wpf.ControlLibrary
{
    public class RemoveButton : Button
    {
        static RemoveButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RemoveButton), new FrameworkPropertyMetadata(typeof(RemoveButton)));
        }
    }
}

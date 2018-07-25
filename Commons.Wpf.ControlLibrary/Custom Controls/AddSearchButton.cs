using System.Windows;
using System.Windows.Controls;

namespace Commons.Wpf.ControlLibrary
{
    public class AddSearchButton : Button
    {
        static AddSearchButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AddSearchButton), new FrameworkPropertyMetadata(typeof(AddSearchButton)));
        }
    }
}

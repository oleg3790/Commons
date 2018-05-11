using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public class InfoButton : Button
    {
        static InfoButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InfoButton), new FrameworkPropertyMetadata(typeof(InfoButton)));
        }
    }
}

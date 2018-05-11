using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public class PreviousButton : Button
    {
        static PreviousButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PreviousButton), new FrameworkPropertyMetadata(typeof(PreviousButton)));
        }
    }
}

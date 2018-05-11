using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public class NextButton : Button
    {
        static NextButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NextButton), new FrameworkPropertyMetadata(typeof(NextButton)));
        }
    }
}

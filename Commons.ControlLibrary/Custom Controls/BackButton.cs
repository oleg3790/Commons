using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public class BackButton : Button
    {
        static BackButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BackButton), new FrameworkPropertyMetadata(typeof(BackButton)));
        }
    }
}

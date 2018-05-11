using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public class CopyButton : Button
    {
        static CopyButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CopyButton), new FrameworkPropertyMetadata(typeof(CopyButton)));
        }
    }
}

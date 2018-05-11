using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public class SettingsButton : Button
    {
        static SettingsButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SettingsButton), new FrameworkPropertyMetadata(typeof(SettingsButton)));
        }
    }
}

using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class SettingsButton : Button
    {
        static SettingsButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SettingsButton), new FrameworkPropertyMetadata(typeof(SettingsButton)));
        }
    }
}

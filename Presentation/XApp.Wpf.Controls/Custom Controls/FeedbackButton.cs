using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public class FeedbackButton : Button
    {
        static FeedbackButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FeedbackButton), new FrameworkPropertyMetadata(typeof(FeedbackButton)));
        }
    }
}

using System.Windows;
using System.Windows.Controls;

namespace Commons.Wpf.ControlLibrary
{
    public class FeedbackButton : Button
    {
        static FeedbackButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FeedbackButton), new FrameworkPropertyMetadata(typeof(FeedbackButton)));
        }
    }
}

using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public class FeedbackButton : Button
    {
        static FeedbackButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FeedbackButton), new FrameworkPropertyMetadata(typeof(FeedbackButton)));
        }
    }
}

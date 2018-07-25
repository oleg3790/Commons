using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Commons.Wpf.ControlLibrary
{
    public partial class ErrorControl : UserControl
    {
        public static readonly DependencyProperty ControlMarginProperty = DependencyProperty.Register("ControlMargin", typeof(Thickness), typeof(ErrorControl), new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty ErrorMessageProperty = DependencyProperty.Register("ErrorMessage", typeof(string), typeof(ErrorControl), new FrameworkPropertyMetadata(default(string)));
        public static readonly DependencyProperty ErrorStacktraceProperty = DependencyProperty.Register("ErrorStacktrace", typeof(string), typeof(ErrorControl), new FrameworkPropertyMetadata(default(string)));
        public static readonly DependencyProperty QueryProperty = DependencyProperty.Register("Query", typeof(string), typeof(ErrorControl), new FrameworkPropertyMetadata(default(string)));
        public static readonly DependencyProperty SendReportCommandProperty = DependencyProperty.Register("SendReportCommand", typeof(ICommand), typeof(ErrorControl), new FrameworkPropertyMetadata(null));

        private Thickness _controlMargin;
        public Thickness ControlMargin
        {
            get { return (Thickness)_controlMargin; }
            set { _controlMargin = (Thickness)value; }
        }

        public string ErrorMessage { get; set; }
        public string ErrorStacktrace { get; set; }
        public string Query { get; set; }
        public ICommand SendReportCommand { get; set; }

        public ErrorControl()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}

using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public partial class DetailsShortTextBox : UserControl
    {
        private FrameworkElement _foregroundElement = new FrameworkElement();

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(DetailsShortTextBox), new FrameworkPropertyMetadata(default(string)));
        public static readonly DependencyProperty TextForegroundProperty = DependencyProperty.Register("TextForeground", typeof(Brush), typeof(DetailsShortTextBox), new UIPropertyMetadata(Brushes.Black));

        public string Text { get; set; } = string.Empty;

        public Brush TextForeground
        {
            get
            {
                return (Brush)GetValue(TextForegroundProperty);
            }
            set
            {
                SetValue(TextForegroundProperty, value);
            }
        }


        public DetailsShortTextBox()
        {
            InitializeComponent();
        }

        private void CopyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(shortTextBox.Text);
        }
    }   
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace XApp.Wpf.Controls
{
    public partial class EscalationBanner : UserControl
    {
        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(string), typeof(EscalationBanner), new FrameworkPropertyMetadata(default(string)));
        public static readonly DependencyProperty ShowEscalateProperty = DependencyProperty.Register("ShowEscalate", typeof(bool), typeof(EscalationBanner), new FrameworkPropertyMetadata(default(bool)));
        public static readonly DependencyProperty EscalateCommandProperty = DependencyProperty.Register("EscalateCommand", typeof(ICommand), typeof(EscalationBanner), new FrameworkPropertyMetadata(null));

        public string Status { get; set; } = string.Empty;
        public bool ShowEscalate { get; set; } = true;
        public ICommand EscalateCommand { get; set; }

        public EscalationBanner()
        {
            InitializeComponent();
        }
    }
}

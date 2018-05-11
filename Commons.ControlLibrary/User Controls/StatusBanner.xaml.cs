using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public partial class StatusBanner : UserControl
    {
        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(string), typeof(StatusBanner), new FrameworkPropertyMetadata(default(string)));
        
        public string Status { get; set; } = string.Empty;

        public StatusBanner()
        {
            InitializeComponent();
        }
    }
}

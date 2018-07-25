using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Commons.Wpf.ControlLibrary
{
    public partial class StatusBanner : UserControl
    {
        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(string), typeof(StatusBanner), new FrameworkPropertyMetadata(default(string)));
        public static readonly DependencyProperty AutoHideEnabledProperty = DependencyProperty.Register("AutoHideEnabled", typeof(bool), typeof(StatusBanner), new FrameworkPropertyMetadata(false));

        public string Status { get; set; } = string.Empty;

        public bool AutoHideEnabled { get; set; } = false;       

        public StatusBanner()
        {
            InitializeComponent();
        }
    }
}

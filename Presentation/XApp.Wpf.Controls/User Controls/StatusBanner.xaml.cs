using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace XApp.Wpf.Controls
{
    public partial class StatusBanner : UserControl
    {
        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(string), typeof(StatusBanner), new FrameworkPropertyMetadata(default(string)));
        public static readonly DependencyProperty AutoHideEnabledProperty = DependencyProperty.Register("AutoHideEnabled", typeof(bool), typeof(StatusBanner), new FrameworkPropertyMetadata(false));

        public string Status
        {
            get { return this.GetValue(StatusProperty).ToString(); }
            set
            {
                this.SetValue(StatusProperty, value);
            }
        }

        public bool AutoHideEnabled { get; set; }      

        public StatusBanner()
        {
            InitializeComponent();
        }
    }
}

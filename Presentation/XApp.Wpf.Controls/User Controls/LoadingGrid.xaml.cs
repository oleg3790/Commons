using System.Windows;
using System.Windows.Controls;

namespace XApp.Wpf.Controls
{
    public partial class LoadingGrid : UserControl
    {
        public static readonly DependencyProperty EnableLoadProperty = DependencyProperty.Register("EnableLoad", typeof(bool), typeof(LoadingGrid), new FrameworkPropertyMetadata(default(bool)));

        public bool EnableLoad { get; set; }

        public LoadingGrid()
        {
            InitializeComponent();
        }

    }
}

using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public partial class LoadingGrid : UserControl
    {
        public static readonly DependencyProperty EnableLoadProperty = DependencyProperty.Register("EnableLoad", typeof(bool), typeof(LoadingGrid), new FrameworkPropertyMetadata(default(bool)));

        private bool _enableLoad;
        public bool EnableLoad
        {
            get { return _enableLoad; }
            set { _enableLoad = value; }
        }

        public LoadingGrid()
        {
            InitializeComponent();
        }

    }
}

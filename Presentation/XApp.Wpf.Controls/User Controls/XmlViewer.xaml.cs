using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace XApp.Wpf.Controls
{
    public partial class XmlViewer : UserControl
    {
        public static readonly DependencyProperty XmlProviderProperty = DependencyProperty.Register("XmlProvider", typeof(XmlDataProvider), typeof(XmlViewer), new FrameworkPropertyMetadata(default(XmlDataProvider)));

        public XmlDataProvider XmlProvider { get; set; }

        public XmlViewer()
        {
            InitializeComponent();
        }
    }
}

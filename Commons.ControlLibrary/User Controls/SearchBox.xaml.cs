using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public partial class SearchBox : UserControl
    {
        public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register("SearchText", typeof(string), typeof(SearchBox), new FrameworkPropertyMetadata(default(string)));

        public string SearchText { get; set; }

        public SearchBox()
        {
            InitializeComponent();
        }
    }
}

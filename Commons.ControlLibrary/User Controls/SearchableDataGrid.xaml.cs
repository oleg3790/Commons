using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public partial class SearchableDataGrid : UserControl
    {
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(SearchableDataGrid), new FrameworkPropertyMetadata(default(IEnumerable)));
        public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register("SearchText", typeof(string), typeof(SearchableDataGrid), new FrameworkPropertyMetadata(default(string)));
        public static readonly DependencyProperty InfoVisibilityProperty = DependencyProperty.Register("InfoVisibility", typeof(Visibility), typeof(SearchableDataGrid), new FrameworkPropertyMetadata(default(Visibility)));

        public IEnumerable ItemsSource { get; set; }
        public string SearchText { get; set; }
        public Visibility InfoVisibility { get; set; } = Visibility.Visible;

        public SearchableDataGrid()
        {
            InitializeComponent();
        }

    }
}

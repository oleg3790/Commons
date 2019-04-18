using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace XApp.Wpf.Controls
{
    public partial class PaginationBanner : UserControl
    {
        public static readonly DependencyProperty DisplayCurrentMinProperty = DependencyProperty.Register("DisplayCurrentMin", typeof(int), typeof(PaginationBanner), new FrameworkPropertyMetadata(default(int)));
        public static readonly DependencyProperty DisplayCurrentMaxProperty = DependencyProperty.Register("DisplayCurrentMax", typeof(int), typeof(PaginationBanner), new FrameworkPropertyMetadata(default(int)));
        public static readonly DependencyProperty DisplayTotalProperty = DependencyProperty.Register("DisplayTotal", typeof(int), typeof(PaginationBanner), new FrameworkPropertyMetadata(default(int)));
        public static readonly DependencyProperty PageCurrentProperty = DependencyProperty.Register("PageCurrent", typeof(int), typeof(PaginationBanner), new FrameworkPropertyMetadata(default(int)));
        public static readonly DependencyProperty PageTotalProperty = DependencyProperty.Register("PageTotal", typeof(int), typeof(PaginationBanner), new FrameworkPropertyMetadata(default(int)));
        public static readonly DependencyProperty FirstPageCommandProperty = DependencyProperty.Register("FirstPageCommand", typeof(ICommand), typeof(PaginationBanner), new FrameworkPropertyMetadata(default(ICommand)));
        public static readonly DependencyProperty PreviousPageCommandProperty = DependencyProperty.Register("PreviousPageCommand", typeof(ICommand), typeof(PaginationBanner), new FrameworkPropertyMetadata(default(ICommand)));
        public static readonly DependencyProperty NextPageCommandProperty = DependencyProperty.Register("NextPageCommand", typeof(ICommand), typeof(PaginationBanner), new FrameworkPropertyMetadata(default(ICommand)));
        public static readonly DependencyProperty LastPageCommandProperty = DependencyProperty.Register("LastPageCommand", typeof(ICommand), typeof(PaginationBanner), new FrameworkPropertyMetadata(default(ICommand)));

        public int DisplayCurrentMin { get; set; }
        public int DisplayCurrentMax { get; set; }
        public int DisplayTotal { get; set; }
        public int PageCurrent { get; set; }
        public int PageTotal { get; set; }
        public ICommand FirstPageCommand { get; set; }
        public ICommand PreviousPageCommand { get; set; }
        public ICommand NextPageCommand { get; set; }
        public ICommand LastPageCommand { get; set; }

        public PaginationBanner()
        {
            InitializeComponent();
        }
    }
}

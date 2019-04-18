using System.ComponentModel;
using System.Windows;

namespace XApp.Presentation.Helpers
{
    public static class DesignTimeHelper
    {
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor
                    .FromProperty(prop, typeof(FrameworkElement))
                    .Metadata.DefaultValue;
            }
        }
    }
}

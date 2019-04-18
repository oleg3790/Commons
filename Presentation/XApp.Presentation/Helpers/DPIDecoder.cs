using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;

namespace XApp.Presentation.Helpers
{
    public class DpiDecorator : Decorator
    {            
        public double xVal { get; set; }
        public double yVal { get; set; }

        public DpiDecorator()
        {
            this.Loaded += (s, e) =>
            {
                Matrix m = PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice;
                ScaleTransform dpiTransform = new ScaleTransform(1 / m.M11, 1 / m.M22);
                if (dpiTransform.CanFreeze)
                    dpiTransform.Freeze();
                this.LayoutTransform = dpiTransform;
            };
        }

        public void TransformByDPI(Visual visual, out int pixelX, out int pixelY)
        {
            Matrix matrix;
            var source = PresentationSource.FromVisual(visual);
            if (source != null)            
                matrix = source.CompositionTarget.TransformToDevice;            
            else
            {
                using (var src = new HwndSource(new HwndSourceParameters()))
                {
                    matrix = src.CompositionTarget.TransformToDevice;
                }
            }

            pixelX = (int)(matrix.M11 * 96);
            pixelY = (int)(matrix.M22 * 96);
        }

        public void AdjustByDPI(Visual visual, Button childBtn)
        {
            int x = 0;
            int y = 0;
            TransformByDPI(visual, out x, out y);

            Point point = childBtn.PointToScreen(new Point(0d, childBtn.ActualHeight));
            xVal = (point.X * 96 / x);
            yVal = (point.Y * 96 / y);
        }
       
    }
}

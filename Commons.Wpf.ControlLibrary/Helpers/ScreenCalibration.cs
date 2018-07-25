
using System.Windows.Forms;
using Dapplo.Windows.Dpi;
using System.Windows.Interop;
using System.Windows;

namespace Commons.Wpf.ControlLibrary
{
    public static class ScreenCalibration
    {
        public static double offset { get; set; }

        public static void OffsetToParentWindow(Window childWindow, Window parentWindow)
        {
            Point outputPoint = parentWindow.PointToScreen(new Point());
            childWindow.Left = outputPoint.X + offset;
            childWindow.Top = outputPoint.Y + offset;

            offset += 20;
        }

        public static void CenterWindow(Window childWindow, Window parentWindow, int topOffset)
        {
            if (GetDpi(parentWindow) == 120)
            {
                DpiDecorator dpiHandler = new DpiDecorator();
                int x = 0;
                int y = 0;
                
                Point outputPoint = parentWindow.PointToScreen(new Point());
                System.Drawing.Point newPoint = new System.Drawing.Point((int)outputPoint.X, (int)outputPoint.Y);
                Screen currentScreen = Screen.FromPoint(newPoint);

                dpiHandler.TransformByDPI(parentWindow, out x, out y);
                childWindow.Left = (currentScreen.Bounds.Left * 96 / x) + (((currentScreen.Bounds.Width * 96 / x) - childWindow.Width) / 2);
                childWindow.Top = (((currentScreen.Bounds.Height * 96 / x) - (childWindow.Height * 96 / x)) / 2) + topOffset - 90;
            }
            else
            {
                Point outputPoint = parentWindow.PointToScreen(new Point());
                System.Drawing.Point newPoint = new System.Drawing.Point((int)outputPoint.X, (int)outputPoint.Y);
                Screen currentScreen = Screen.FromPoint(newPoint);

                //Set childs left/top to parent window's current screen left/height
                childWindow.Left = currentScreen.Bounds.Left + ((currentScreen.Bounds.Width - childWindow.Width) / 2);
                childWindow.Top = ((currentScreen.Bounds.Height - childWindow.Height) / 2) + topOffset;
            }            
        }

        public static void CenterWindow(Window childWindow, System.Windows.Controls.UserControl parentControl, int topOffset)
        {
            if (GetDpi(childWindow) == 120)
            {
                DpiDecorator dpiHandler = new DpiDecorator();
                int x = 0;
                int y = 0;

                Point outputPoint = parentControl.PointToScreen(new Point());
                System.Drawing.Point newPoint = new System.Drawing.Point((int)outputPoint.X, (int)outputPoint.Y);
                Screen currentScreen = Screen.FromPoint(newPoint);

                dpiHandler.TransformByDPI(parentControl, out x, out y);
                childWindow.Left = (currentScreen.Bounds.Left * 96 / x) + (((currentScreen.Bounds.Width * 96 / x) - childWindow.Width) / 2);
                childWindow.Top = (((currentScreen.Bounds.Height * 96 / x) - (childWindow.Height * 96 / x)) / 2) + topOffset - 90;
            }
            else
            {
                Point outputPoint = parentControl.PointToScreen(new Point());
                System.Drawing.Point newPoint = new System.Drawing.Point((int)outputPoint.X, (int)outputPoint.Y);
                Screen currentScreen = Screen.FromPoint(newPoint);

                //Set childs left/top to parent window's current screen left/height
                childWindow.Left = currentScreen.Bounds.Left + ((currentScreen.Bounds.Width - childWindow.Width) / 2);
                childWindow.Top = ((currentScreen.Bounds.Height - childWindow.Height) / 2) + topOffset;
            }            
        }

        public static int GetDpi(Window window)
        {
            return DpiHandler.GetDpi(new WindowInteropHelper(window).Handle);
        }

    }
}

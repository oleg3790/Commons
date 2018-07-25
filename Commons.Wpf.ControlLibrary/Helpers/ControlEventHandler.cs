using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

namespace Commons.Wpf.ControlLibrary
{
    public class ControlEventHandler
    {
        private Button _controlButton;

        public void InitiateButtonEvent(Window initiatedWindow, UserControl parentWindow, int initiatedWindowTopOffset, Button controlButton)
        {
            _controlButton = controlButton;
            
            initiatedWindow.Show();
            initiatedWindow.Owner = Window.GetWindow(parentWindow);
            initiatedWindow.Closing += Button_Closing;
            controlButton.Visibility = Visibility.Hidden;
            ScreenCalibration.CenterWindow(initiatedWindow, parentWindow, initiatedWindowTopOffset);
        }

        public void InitiateButtonEvent(Window initiatedWindow, Window parentWindow, int initiatedWindowTopOffset, Button controlButton)
        {            
            _controlButton = controlButton;
            
            initiatedWindow.Show();
            initiatedWindow.Owner = Window.GetWindow(parentWindow);
            initiatedWindow.Closing += Button_Closing;
            controlButton.Visibility = Visibility.Hidden;
            ScreenCalibration.CenterWindow(initiatedWindow, parentWindow, initiatedWindowTopOffset);
        }

        private void Button_Closing(object sender, CancelEventArgs e)
        {
            _controlButton.Visibility = Visibility.Visible;
            ((Window)sender).Closing -= Button_Closing;
        }

        public void ClearTextboxContent(TextBox[] boxes)
        {
            foreach (TextBox box in boxes)
            {
                box.Clear();
            }
        }
    }
}

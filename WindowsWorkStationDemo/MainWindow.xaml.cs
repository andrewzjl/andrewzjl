using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowsWorkStationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // This is a static public property that allows downstream pages to get a handle to the MainPage instance
        // in order to call methods that are in this class.
        public static MainWindow Current;

        public string comboboxItemForeground
        {
            get { return "black"; }
        }
        public MainWindow()
        {
            InitializeComponent();

            Current = this;
        }
        public enum NotifyType
        {
            StatusMessage,
            ErrorMessage,
            TitleChanged,
            BarSelectionChanged
        };
        
        /// <summary>
        /// Used to display messages to the user
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="type"></param>
        public void NotifyUser(string strMessage, NotifyType type)
        {
            switch (type)
            {
                case NotifyType.StatusMessage:
                    StatusBorder.Background = new SolidColorBrush(Colors.Green);
                    statusBar.Text = strMessage;
                    break;
                case NotifyType.ErrorMessage:
                    StatusBorder.Background = new SolidColorBrush(Colors.Red);
                    statusBar.Text = strMessage;
                    break;
                case NotifyType.TitleChanged:
                    Current.Title = strMessage;
                    break;
                case NotifyType.BarSelectionChanged:
                    if (strMessage.Equals("d"))
                    {
                        // todo
                    }
                    else
                    {
                        // todo
                    }
                    break;
            }

            // Collapse the StatusBlock if it has no text to conserve real estate.
            StatusBorder.Visibility = (statusBar.Text != String.Empty) ? Visibility.Visible : Visibility.Collapsed;
            if (statusBar.Text != String.Empty)
            {
                StatusBorder.Visibility = Visibility.Visible;
            }
            else
            {
                StatusBorder.Visibility = Visibility.Collapsed;
            }
        }

        private void Forward_Browsing(object sender, RoutedEventArgs e)
        {
            if (browsingFrame.NavigationService.CanGoForward)
            {
                browsingFrame.NavigationService.GoForward();
            }
        }

        private void Back_Browsing(object sender, RoutedEventArgs e)
        {
            if (browsingFrame.NavigationService.CanGoBack)
            {
                browsingFrame.NavigationService.GoBack();
            }
        }

        private void Exit_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void new_dashboard(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("todo in future", "Message");
        }
    }
    
    public class BoolInverterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Frame)
            {
                // if it's browsing frame, try to get it's go back or forward
                Frame browseFrame = value as Frame;
                return browseFrame.NavigationService.CanGoBack;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}

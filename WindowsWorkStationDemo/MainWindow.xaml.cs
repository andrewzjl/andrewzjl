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
        
        private void Exit_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void new_dashboard(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("todo in future", "Message");
        }
    }
}

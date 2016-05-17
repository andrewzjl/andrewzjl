using System;
using System.Collections.Generic;
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

namespace WindowsWorkStationDemo.View
{
    /// <summary>
    /// Interaction logic for DocumentsBarPage.xaml
    /// </summary>
    public partial class DocumentsBarPage : Page
    {
        public DocumentsBarPage()
        {
            InitializeComponent();
        }

        private void selection_changed(object sender, SelectionChangedEventArgs e)
        {
            // Clear the status block when navigating scenarios.
            MainWindow.Current.NotifyUser(String.Empty, MainWindow.NotifyType.StatusMessage);

            ListBox scenarioListBox = sender as ListBox;
            var s = scenarioListBox.SelectedItem as Model.BrowseViewObject;
            if (s != null)
            {
                MainWindow.Current.NotifyUser(string.Format("{0} - {1}", "workstation", s.Title), MainWindow.NotifyType.TitleChanged);
                var newPage = Activator.CreateInstance(s.ClassType);
                MainWindow.Current.browsingFrame.Navigate(newPage);
            }
        }
    }
}

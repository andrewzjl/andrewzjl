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
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using System.Globalization;
using GalaSoft.MvvmLight.Messaging;

namespace WindowsWorkStationDemo.View
{
    /// <summary>
    /// Interaction logic for DashboardsPage.xaml
    /// </summary>
    public partial class DashboardsPage : BasePage
    {
        public DashboardsPage()
        {
            InitializeComponent();
        }

        private void selection_changed(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListView;
            int Count = listBox.SelectedItems.Count;
            var statusUpdateMsg = new Model.MainWindowUINotificationMsg { ChangedUIElement = Model.ChangedUIElement.StatusInfo, NewValue = ""};
            if (Count > 0)
            {
                statusUpdateMsg.NewValue = string.Format("{0} of {1} items selected", Count, listBox.Items.Count);
            }
            Messenger.Default.Send(statusUpdateMsg);

            // send msg to show the dashboard info
            if (Count == 1)
            {
                var selectedItem = listBox.SelectedItem as Model.DashboardInfo;
                Model.DashboardNotificationMessage msg = new Model.DashboardNotificationMessage { Message = selectedItem.Name, MsgType = Model.DashboardNotificationMessage.MessageType.showDashboard, selectedIndex = listBox.SelectedIndex };
                Messenger.Default.Send(msg);
            }
        }

        private void DashBoardsListView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HitTestResult r = VisualTreeHelper.HitTest(this, e.GetPosition(this));
            if (r.VisualHit.GetType() != typeof(ListBoxItem))
            {
                DashBoardsListView.UnselectAll();
                Model.DashboardNotificationMessage msg = new Model.DashboardNotificationMessage { Message = "", MsgType = Model.DashboardNotificationMessage.MessageType.showDashboard, selectedIndex = -1 };
                Messenger.Default.Send(msg);
            }
        }
    }

    public class DashboardBindingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = value as Model.DashboardInfo;
            if (parameter == null)
                return (s != null) ? s.Name : "";
            if (((string)parameter).Equals("IsSelected"))
                return (s == null) ? Visibility.Collapsed : Visibility.Visible;
            if (((string)parameter).Equals("CreateTime"))
                return (s != null) ? s.CreateTime : "";
            
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}

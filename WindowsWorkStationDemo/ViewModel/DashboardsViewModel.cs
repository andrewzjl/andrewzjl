using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsWorkStationDemo.Model;

namespace WindowsWorkStationDemo.ViewModel
{
    class DashboardsViewModel: ViewModelBase
    {
        private ObservableCollection<Model.DashboardInfo> dashboards;
        private static DashboardsViewModel instance;
        private Model.DashboardInfo selectedDashboard;
        public DashboardsViewModel()
        {
            dashboards = new ObservableCollection<Model.DashboardInfo>();
            dashboards.Add(new Model.DashboardInfo("line 1"));
            Messenger.Default.Register<DashboardNotificationMessage>(this, async (msg) => await showDashboard(msg));
        }
        
        public static DashboardsViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new DashboardsViewModel();

                return instance;
            }
        }
        public ObservableCollection<Model.DashboardInfo> Dashboards
        {
            get { return dashboards; }
        }

        public Model.DashboardInfo SelectedDashboard
        {
            get
            {
                return selectedDashboard;
            }
            set
            {
                selectedDashboard = value;
                RaisePropertyChanged();
            }
        }
        public bool AddNewDashboard(string dashboardName)
        {
            if (string.IsNullOrEmpty(dashboardName))
                return false;
            var dashboard = new Model.DashboardInfo();
            dashboard.Name = dashboardName;
            dashboards.Add(dashboard);
            return true;
        }

        private async Task showDashboard(DashboardNotificationMessage msg)
        {
            if (msg.selectedIndex < 0)
            {
                SelectedDashboard = null;
            }
            else if (msg.selectedIndex < dashboards.Count)
            {
                SelectedDashboard = dashboards.ElementAt(msg.selectedIndex);
            }
            else foreach (var dashboard in dashboards)
            {
                if (dashboard.Name == msg.Message)
                {
                    SelectedDashboard = dashboard;
                    break;
                }
            }
            await Task.Delay(300);
            return;
        }
    }
}

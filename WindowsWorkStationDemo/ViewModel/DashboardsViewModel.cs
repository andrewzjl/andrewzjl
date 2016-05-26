using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WindowsWorkStationDemo.Model;

namespace WindowsWorkStationDemo.ViewModel
{
    class DashboardsViewModel: BaseBrowseViewModel
    {
        private Model.DashboardInfo selectedDashboard;
        public DashboardsViewModel()
        {
            Log.Error("load dashboards vm error");
            _ObjectList.Add(new Model.DashboardInfo("line 1"));
            CreateObjectCommand = CreateNewDashBoard;
            Messenger.Default.Register<DashboardNotificationMessage>(this, async (msg) => await showDashboard(msg));
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
        private bool AddNewDashboard(string dashboardName)
        {
            if (string.IsNullOrEmpty(dashboardName))
                return false;
            var dashboard = new Model.DashboardInfo();
            dashboard.Name = dashboardName;
            _ObjectList.Add(dashboard);
            var barItem = new BrowseViewObject() { Title = dashboardName, ClassType = typeof(View.DatasetsPage), Icon = "\uE81E" };
            BrowseViewObjectFactory.Instance.register(barItem);
            return true;
        }

        private async Task showDashboard(DashboardNotificationMessage msg)
        {
            if (msg.selectedIndex < 0)
            {
                SelectedDashboard = null;
            }
            else if (msg.selectedIndex < _ObjectList.Count)
            {
                SelectedDashboard = _ObjectList.ElementAt(msg.selectedIndex) as DashboardInfo;
            }
            else foreach (DashboardInfo dashboard in _ObjectList)
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

        private RelayCommand _createNewDashBoard;
        static int index = 0;
        public ICommand CreateNewDashBoard
        {
            get
            {
                return _createNewDashBoard ?? (_createNewDashBoard = new RelayCommand(() => {
                    Messenger.Default.Send(new Model.MainWindowUINotificationMsg(Model.ChangedUIElement.StatusInfo, null, ""));
                    AddNewDashboard("new add " + (index++).ToString());
                }));
            }
        }
    }
}

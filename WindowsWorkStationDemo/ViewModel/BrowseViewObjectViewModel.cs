using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WindowsWorkStationDemo.Model;

namespace WindowsWorkStationDemo.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class BrowseViewObjectViewModel : ViewModelBase
    {
        public ObservableCollection<BrowseViewObject> EnterpriseBrowseViewObjects { get; set; }
        
        public ObservableCollection<BrowseViewObject> DocumentsBrowseViewObjects { get; set; }

        /// <summary>
        /// Initializes a new instance of the BrowseViewObjectViewModel class.
        /// </summary>
        public BrowseViewObjectViewModel()
        {
            EnterpriseBrowseViewObjects = new ObservableCollection<BrowseViewObject>
            {
                new BrowseViewObject() { Title = "Environments", ClassType = typeof(View.EnvironmentsPage), Icon = "\uE2B0" },
                new BrowseViewObject() { Title = "Applications", ClassType = typeof(View.ApplicationsPage), Icon = "\uE74C" }
            };

            DocumentsBrowseViewObjects = new ObservableCollection<BrowseViewObject>
            {
                new BrowseViewObject() { Title = "Dossiers", ClassType = typeof(View.DossiersPage), Icon = "\uE8EC" },
                new BrowseViewObject() { Title = "Dashboards", ClassType = typeof(View.DashboardsPage), Icon = "\uEC25", AddObject = View.MSTRObjectHelper.Instance.addNewDashboard},
                new BrowseViewObject() { Title = "Charts", ClassType = typeof(View.ChartsPage), Icon = "\uE12A" },
                new BrowseViewObject() { Title = "Maps", ClassType = typeof(View.MapsPage), Icon = "\uEB49" },
                new BrowseViewObject() { Title = "Grids", ClassType = typeof(View.GridsPage), Icon = "\uE80A" },
                new BrowseViewObject() { Title = "Datasets", ClassType = typeof(View.DatasetsPage), Icon = "\uE81E" }
            };
        }

        private RelayCommand<BrowseViewObject> _SelectViewObjectCommand;

        /// <summary>
        /// Gets the SelectedViewObjectCommand.
        /// </summary>
        public RelayCommand<BrowseViewObject> SelectedViewObjectCommand
        {
            get
            {
                return _SelectViewObjectCommand
                    ?? (_SelectViewObjectCommand = new RelayCommand<BrowseViewObject>(
                    (SelectedItem) =>
                    {
                        // Clear the status block when navigating scenarios.
                        MainWindow.Current.NotifyUser(string.Empty, MainWindow.NotifyType.StatusMessage);

                        var s = SelectedItem as BrowseViewObject;
                        if (s != null)
                        {
                            MainWindow.Current.NotifyUser(string.Format("{0} - {1}", "workstation", s.Title), MainWindow.NotifyType.TitleChanged);
                            var newPage = System.Activator.CreateInstance(s.ClassType);
                            MainWindow.Current.browsingFrame.Navigate(newPage);
                        }
                    }));
            }
        }
    }
}
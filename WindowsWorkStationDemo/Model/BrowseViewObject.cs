using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WindowsWorkStationDemo.Model
{
    public class BrowseViewObjectFactory
    {
        private static BrowseViewObjectFactory _instance;
        public static BrowseViewObjectFactory Instance
        {
            get { return _instance ?? (_instance = new BrowseViewObjectFactory()); }
        }

        public List<BrowseViewObject> BrowseViewObjects { get; private set; }
        private BrowseViewObjectFactory()
        {
            BrowseViewObjects = new List<BrowseViewObject>
            {
                new BrowseViewObject() { Title = "ENTERPRISES", Icon="null"},
                new BrowseViewObject() { Title = "Environments", ClassType = typeof(View.EnvironmentsPage), Icon = "\uE2B0" },
                new BrowseViewObject() { Title = "Applications", ClassType = typeof(View.ApplicationsPage), Icon = "\uE74C" },
                new BrowseViewObject() { Title = "-"},
                new BrowseViewObject() { Title = "DOCUMENTS", Icon="null"},
                new BrowseViewObject() { Title = "Dossiers", ClassType = typeof(View.DossiersPage), Icon = "\uE8EC" },
                new BrowseViewObject() { Title = "Dashboards", ClassType = typeof(View.DashboardsPage), Icon = "\uEC25", AddObject = View.MSTRObjectHelper.Instance.addNewDashboard},
                new BrowseViewObject() { Title = "Charts", ClassType = typeof(View.ChartsPage), Icon = "\uE12A" },
                new BrowseViewObject() { Title = "Maps", ClassType = typeof(View.MapsPage), Icon = "\uEB49" },
                new BrowseViewObject() { Title = "Grids", ClassType = typeof(View.GridsPage), Icon = "\uE80A" },
                new BrowseViewObject() { Title = "Datasets", ClassType = typeof(View.DatasetsPage), Icon = "\uE81E" }
            };
        }
        public bool register(BrowseViewObject newViewObject)
        {
            if (newViewObject == null)
            {
                return false;
            }

            if (FindBrowseViewObject(newViewObject.Title) == null)
            {
                BrowseViewObjects.Add(newViewObject);
                return true;
            }

            return false;
        }
        public bool unRegister(BrowseViewObject newViewObject)
        {
            if (newViewObject == null)
            {
                return false;
            }

            if (FindBrowseViewObject(newViewObject.Title) != null)
            {
                return BrowseViewObjects.Remove(newViewObject);
            }

            return false;
        }

        public BrowseViewObject FindBrowseViewObject(string title)
        {
            foreach (var viewObject in BrowseViewObjects)
            {
                if (viewObject.Title.Equals(title))
                    return viewObject;
            }

            return null;
        }
    }
    public class BrowseViewObject
    {
        public string Icon { get; set; }

        public string Title { get; set; }

        public Type ClassType { get; set; }

        public ICommand AddObject { get; set; }

        public System.Windows.Visibility Visibility
        {
            get { return (AddObject != null) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed; }
        }
        public override string ToString()
        {
            return Title;
        }
    }
}

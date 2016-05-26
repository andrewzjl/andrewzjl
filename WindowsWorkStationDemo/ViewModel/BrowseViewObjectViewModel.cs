using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WindowsWorkStationDemo.Model;
using WindowsWorkStationDemo.Utility;

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
        public ObservableCollection<BrowseViewObject> BrowseViewObjects
        {
            get
            {
                return new ObservableCollection<BrowseViewObject>(BrowseViewObjectFactory.Instance.BrowseViewObjects);
            }
        }

        private BrowseViewObject _selectedViewObject;
        public BrowseViewObject SelectedViewObject {
            get { return _selectedViewObject; }
            set
            {
                if (_selectedViewObject == value)
                {
                    return;
                }

                _selectedViewObject = value;
                RaisePropertyChanged();

                // send the Broadcast that object changed
                var msg = new MainWindowUINotificationMsg { ChangedUIElement = ChangedUIElement.ViewObject, NewValue = _selectedViewObject.Title };
                msg.Sender = this;
                Messenger.Default.Send(msg);
            }
        }
        /// <summary>
        /// Initializes a new instance of the BrowseViewObjectViewModel class.
        /// </summary>
        public BrowseViewObjectViewModel()
        {
            if (BrowseViewObjects.Count > 1)
            {
                SelectedViewObject = BrowseViewObjects[1];
            }
            Messenger.Default.Register<MainWindowUINotificationMsg>(this, (msg) => RefreshPage(msg));
        }

        private void RefreshPage(MainWindowUINotificationMsg msg)
        {
            if (msg == null || (msg.Sender == this))
            {
                return;
            }

            if (msg.ChangedUIElement == ChangedUIElement.ViewObject)
            {
                _selectedViewObject = BrowseViewObjectFactory.Instance.FindBrowseViewObject(msg.NewValue as string);
                RaisePropertyChanged(nameof(SelectedViewObject));
            }
            else if (msg.ChangedUIElement == ChangedUIElement.MutilpleUI)
            {
                var oldValue = msg.OldValue as MainWindowUIStatusModel;
                var newValue = msg.NewValue as MainWindowUIStatusModel; ;
                if (oldValue != null && newValue != null && !oldValue.BrowseViewObjectKey.Equals(newValue.BrowseViewObjectKey))
                {
                    _selectedViewObject = BrowseViewObjectFactory.Instance.FindBrowseViewObject(newValue.BrowseViewObjectKey);
                    RaisePropertyChanged(nameof(SelectedViewObject));
                }
            }
        }
    }
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
                new BrowseViewObject() { Title = Constants.ENTERPRISES, Icon="null"},
                new BrowseViewObject() { Title = Constants.Environments, ClassType = typeof(View.EnvironmentsPage), Icon = "\uE2B0" },
                new BrowseViewObject() { Title = Constants.Applications, ClassType = typeof(View.ApplicationsPage), Icon = "\uE74C" },
                new BrowseViewObject() { Title = Constants.SeparatorToken},
                new BrowseViewObject() { Title = Constants.DOCUMENTS, Icon="null"},
                new BrowseViewObject() { Title = Constants.Dossiers, ClassType = typeof(View.DossiersPage), Icon = "\uE8EC" },
                new BrowseViewObject() { Title = Constants.Dashboards, ClassType = typeof(View.DashboardsPage),  AddObject = MSTRObjectHelper.Instance.CreateNewObject(Constants.Dashboards), Icon = "\uEC25"},
                new BrowseViewObject() { Title = Constants.Charts, ClassType = typeof(View.ChartsPage), Icon = "\uE12A"},
                new BrowseViewObject() { Title = Constants.Maps, ClassType = typeof(View.MapsPage), Icon = "\uEB49" },
                new BrowseViewObject() { Title = Constants.Grids, ClassType = typeof(View.GridsPage), Icon = "\uE80A" },
                new BrowseViewObject() { Title = Constants.Datasets, ClassType = typeof(View.DatasetsPage), Icon = "\uE81E" }
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


    public sealed partial class MSTRObjectHelper
    {
        #region private fields
        private static MSTRObjectHelper instance;
        #endregion
        public static MSTRObjectHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new MSTRObjectHelper();

                return instance;
            }
        }
        private ICommand _createObjectCommand;
        public ICommand CreateObjectCommand
        {
            get
            {
                return _createObjectCommand ?? (_createObjectCommand = new RelayCommand<string>((objectKey) => {
                    var command = CreateNewObject(objectKey) as RelayCommand;
                    if (command != null)
                    {
                        command.Execute(null);
                    }
                }); );
            }
        }
        public ICommand CreateNewObject(string objectKey)
        {
            var objectViewModel = ViewModelLocator.BrowseViewModel(objectKey);
            if (objectViewModel != null)
            {
                return objectViewModel.CreateObjectCommand;
            }
            return null;
        }
    }
}
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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
        }
    }
}
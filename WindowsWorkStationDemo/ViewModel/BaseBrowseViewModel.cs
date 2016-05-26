using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Common.Logging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WindowsWorkStationDemo.Model;
using System.Windows.Input;

namespace WindowsWorkStationDemo.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class BaseBrowseViewModel : ViewModelBase
    {
        public ICommand CreateObjectCommand;
        public MainWindowUIStatusModel CurrentStatus;
        protected ObservableCollection<object> _ObjectList = new ObservableCollection<object>();
        public ObservableCollection<object> BrowsingObjects
        {
            get { return _ObjectList; }
        }
        static protected ILog Log { get; private set; }
        /// <summary>
        /// Initializes a new instance of the BaseBrowseViewModel class.
        /// </summary>
        public BaseBrowseViewModel()
        {
            Log = LogManager.GetLogger(GetType().FullName);
            CreateObjectCommand = null;
        }

        /// <summary>
        /// load necessary resources when the target page is loading.
        /// </summary>
        virtual public void Loaded()
        {
            Messenger.Default.Register<MainWindowUINotificationMsg>(this, HandleUIChangedEvent);
            Log.InfoFormat("{0} is loaded.", GetType().FullName);
        }
        public override void Cleanup()
        {
            Log.InfoFormat("{0} is Cleanup.", GetType().FullName);
            try
            {
                throw new System.Exception("throw a error. Try to catch and log it.");
            }
            catch (System.Exception ex)
            {
                Log.Error("catch an ex", ex);
            }
            base.Cleanup();
        }

        virtual protected void HandleUIChangedEvent(MainWindowUINotificationMsg msg)
        {
            Log.DebugFormat("{0} is changed to value {1}.", msg.ChangedUIElement, msg.NewValue);
        }
        
    }
}
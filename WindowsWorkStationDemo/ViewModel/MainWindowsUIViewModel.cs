using Common.Logging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WindowsWorkStationDemo.Model;

namespace WindowsWorkStationDemo.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainWindowsUIStatusViewModel : ViewModelBase
    {
        static ILog Log;
        /// <summary>
        /// Initializes a new instance of the MainWindowsUIViewModel class.
        /// </summary>
        public MainWindowsUIStatusViewModel()
        {
            Log = LogManager.GetLogger(GetType().FullName);
            _BackStatusStack = new Stack<MainWindowUIStatusModel>();
            _ForwardStatusStack = new Stack<MainWindowUIStatusModel>();
            _currentUIStatus = new MainWindowUIStatusModel();
            ViewStyleList = new List<string>
            {
                "\uE8A9",
                "\uE700",
                "\uE145"
            };

            _arrangeByList = new List<KindOfArrangeBy>
            {
                KindOfArrangeBy.ByDateModified,
                KindOfArrangeBy.ByDateCreated,
                KindOfArrangeBy.ByKind,
                KindOfArrangeBy.Reserved,
                KindOfArrangeBy.None
            };

            _sortByList = new List<KindOfSortBy>
            {
                KindOfSortBy.ByName,
                KindOfSortBy.ByKind,
                KindOfSortBy.ByOwner,
                KindOfSortBy.ByDateModified,
                KindOfSortBy.ByDateCreated,
                KindOfSortBy.ByServer,
                KindOfSortBy.ByProject,
                KindOfSortBy.Reserved,
                KindOfSortBy.None
            };
            Messenger.Default.Register<MainWindowUINotificationMsg>(this, (msg) => UpdateUI(msg));
            Title = App.GetResource("ApplicationName") as string;
        }

        #region Properties of Navigation stack
        const int MAX_LIST_SIZE = 15;

        private Stack<MainWindowUIStatusModel> _BackStatusStack;
        public ObservableCollection<MainWindowUIStatusModel> BackStatusStack
        {
            get
            {
                if (_BackStatusStack.Count <= MAX_LIST_SIZE)
                {
                    return new ObservableCollection<MainWindowUIStatusModel>(_BackStatusStack);
                }
                else
                {
                    return new ObservableCollection<MainWindowUIStatusModel>(_BackStatusStack.ToList().GetRange(0, MAX_LIST_SIZE));
                }
            }
        }

        private Stack<MainWindowUIStatusModel> _ForwardStatusStack;
        public ObservableCollection<MainWindowUIStatusModel> ForwardStatusStack {
            get
            {
                if (_BackStatusStack.Count <= MAX_LIST_SIZE)
                {
                    return new ObservableCollection<MainWindowUIStatusModel>(_ForwardStatusStack);
                }
                else
                {
                    return new ObservableCollection<MainWindowUIStatusModel>(_ForwardStatusStack.ToList().GetRange(0, MAX_LIST_SIZE));
                }
            }
        }
        #endregion

        #region operation of Navigation Stack
        private RelayCommand _GoBack;
        /// <summary>
        /// Gets the GoBack.
        /// </summary>
        public RelayCommand GoBack
        {
            get
            {
                return _GoBack ?? (_GoBack = new RelayCommand(
                    ExecuteGoBack,
                    CanExecuteGoBack));
            }
        }

        private void ExecuteGoBack()
        {
            _ForwardStatusStack.Push(new MainWindowUIStatusModel(CurrentUIStatus));
            if (_ForwardStatusStack.Count == 1)
            {
                // After changed from 0 to 1, notify UI that we can go forward now.
                GoForward.RaiseCanExecuteChanged();
            }

            CurrentUIStatus = _BackStatusStack.Pop();
            if (_BackStatusStack.Count == 0)
            {
                // After changed from 1 to 0, notify UI that we can't go back now.
                GoBack.RaiseCanExecuteChanged();
            }
        }

        private bool CanExecuteGoBack()
        {
            return _BackStatusStack.Count > 0;
        }

        private RelayCommand _GoForward;
        /// <summary>
        /// Gets the GoForward.
        /// </summary>
        public RelayCommand GoForward
        {
            get
            {
                return _GoForward
                    ?? (_GoForward = new RelayCommand(
                    () =>
                    {
                        _BackStatusStack.Push(new MainWindowUIStatusModel(CurrentUIStatus));
                        if (_BackStatusStack.Count == 1)
                        {
                            // After changed from 0 to 1, notify UI that we can go back now.
                            GoBack.RaiseCanExecuteChanged();
                        }
                        CurrentUIStatus = _ForwardStatusStack.Pop();
                        if (_ForwardStatusStack.Count == 0)
                        {
                            // After changed from 1 to 0, notify UI that we can't go forward now.
                            GoForward.RaiseCanExecuteChanged();
                        }
                    }, () =>
                    {
                        return _ForwardStatusStack.Count > 0;
                    }));
            }
        }

        void SaveChangedStatus()
        {
            _BackStatusStack.Push(new MainWindowUIStatusModel(CurrentUIStatus));
            if (_BackStatusStack.Count == 1)
            {
                // After changed from 0 to 1, notify UI that we can go back now.
                GoBack.RaiseCanExecuteChanged();
            }

            if (_ForwardStatusStack.Count > 0)
            {
                _ForwardStatusStack.Clear();
                GoForward.RaiseCanExecuteChanged();
            }
        }
        #endregion

        #region Properties of Selectionable Content
        public List<string> ViewStyleList { get; }

        private List<KindOfArrangeBy> _arrangeByList;
        public List<KindOfArrangeBy> ArrangeByList
        {
            get
            {
                return _arrangeByList;
            }
        }

        private List<KindOfSortBy> _sortByList;
        public List<KindOfSortBy> SortByList
        {
            get
            {
                return _sortByList;
            }
        }

        public Brush ForegroundColor
        {
            get { return Brushes.Black; }
        }
        #endregion

        #region Current UI status
        void UpdateUI(MainWindowUINotificationMsg msg)
        {
            if (msg == null)
            {
                return;
            }

            switch (msg.ChangedUIElement)
            {
                case ChangedUIElement.MutilpleUI:
                    CurrentUIStatus = msg.NewValue as MainWindowUIStatusModel;
                    break;
                case ChangedUIElement.ViewObject:
                    BrowseViewObjectKey = msg.NewValue as string;
                    break;
                case ChangedUIElement.StatusInfo:
                    StatusMessage = msg.NewValue as string;
                    break;
                case ChangedUIElement.SortBy:
                    break;
                case ChangedUIElement.ViewStyle:
                    break;
            }
        }
        private List<BaseBrowseViewModel> _testRefAddress = new List<BaseBrowseViewModel>();
        private void NavigationToNewPage(string newPageTitle)
        {
            var selectedViewObject = BrowseViewObjectFactory.Instance.FindBrowseViewObject(newPageTitle);
            if (selectedViewObject == null || selectedViewObject.ClassType == null)
            {
                return;
            }

            BrowsingPage = (Page)System.Activator.CreateInstance(selectedViewObject.ClassType);

            BaseBrowseViewModel dataContext = ViewModelLocator.BrowseViewModel(selectedViewObject.Title);
            foreach (var item in _testRefAddress)
            {
                Log.Debug(item.GetHashCode());
                if (item == dataContext)
                {
                    Log.InfoFormat("there is a duplicate {0} in list now.", dataContext.GetType().FullName);
                }
            }
            _testRefAddress.Add(dataContext);

            BrowsingPage.DataContext = dataContext;
            Title = string.Format("{0} - {1}", App.GetResource("ApplicationName") as string, newPageTitle);
            StatusMessage = "";
        }

        private Page _browsingPage = null;

        /// <summary>
        /// Sets and gets the BrowsingPage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Page BrowsingPage
        {
            get
            {
                return _browsingPage;
            }

            set
            {
                if (_browsingPage == value)
                {
                    return;
                }

                _browsingPage = value;
                RaisePropertyChanged();
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value)
                {
                    return;
                }
                _title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private string _statusMessage = "";

        /// <summary>
        /// Sets and gets the StatusMessage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }
            set
            {
                if (_statusMessage == value)
                {
                    return;
                }

                _statusMessage = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Sets and gets the BrowseViewStyle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int BrowseViewStyle
        {
            get
            {
                return (int)CurrentUIStatus.BrowseViewStyle;
            }

            set
            {
                if ((int)CurrentUIStatus.BrowseViewStyle == value)
                {
                    return;
                }

                SaveChangedStatus();
                Messenger.Default.Send(new MainWindowUINotificationMsg(ChangedUIElement.ViewStyle, CurrentUIStatus.BrowseViewStyle, value));
                CurrentUIStatus.BrowseViewStyle = (BrowseViewStyle)value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The <see cref="KindOfArrangeBy" /> property's name.
        /// </summary>
        public const string KindOfArrangeByPropertyName = "KindOfArrangeBy";

        /// <summary>
        /// Sets and gets the KindOfArrangeBy property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public KindOfArrangeBy KindOfArrangeBy
        {
            get
            {
                return CurrentUIStatus.KindOfArrangeBy;
            }

            set
            {
                if (CurrentUIStatus.KindOfArrangeBy == value)
                {
                    return;
                }

                SaveChangedStatus();
                Messenger.Default.Send(new MainWindowUINotificationMsg(ChangedUIElement.ArrangeBy, CurrentUIStatus.KindOfArrangeBy, value));
                CurrentUIStatus.KindOfArrangeBy = value;
                RaisePropertyChanged(KindOfArrangeByPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="KindOfSortBy" /> property's name.
        /// </summary>
        public const string KindOfSortByPropertyName = "KindOfSortBy";

        /// <summary>
        /// Sets and gets the KindOfSortBy property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public KindOfSortBy KindOfSortBy
        {
            get
            {
                return CurrentUIStatus.KindOfSortBy;
            }

            set
            {
                if (CurrentUIStatus.KindOfSortBy == value)
                {
                    return;
                }

                SaveChangedStatus();
                Messenger.Default.Send(new MainWindowUINotificationMsg(ChangedUIElement.SortBy, CurrentUIStatus.KindOfSortBy, value));
                CurrentUIStatus.KindOfSortBy = value;
                RaisePropertyChanged(KindOfSortByPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsAscending" /> property's name.
        /// </summary>
        public const string IsAscendingPropertyName = "IsAscending";
        
        /// <summary>
        /// Sets and gets the IsAscending property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsAscending
        {
            get
            {
                return CurrentUIStatus.IsAscending;
            }

            set
            {
                if (CurrentUIStatus.IsAscending == value)
                {
                    return;
                }

                SaveChangedStatus();
                Messenger.Default.Send(new MainWindowUINotificationMsg(ChangedUIElement.SortBy, CurrentUIStatus.IsAscending, value));
                CurrentUIStatus.IsAscending = value;
                RaisePropertyChanged(IsAscendingPropertyName);
            }
        }
        
        /// <summary>
        /// Sets and gets the KindOfViewMode property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int KindOfViewMode
        {
            get
            {
                return (int)CurrentUIStatus.KindOfViewMode;
            }

            set
            {
                if ((int)CurrentUIStatus.KindOfViewMode == value)
                {
                    return;
                }

                SaveChangedStatus();
                Messenger.Default.Send(new MainWindowUINotificationMsg(ChangedUIElement.ViewMode, CurrentUIStatus.KindOfViewMode, value));
                CurrentUIStatus.KindOfViewMode = (KindOfViewMode)value;
                RaisePropertyChanged();
            }
        }
        
        /// <summary>
        /// Sets and gets the BrowseViewObjectKey property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string BrowseViewObjectKey
        {
            get
            {
                return CurrentUIStatus.BrowseViewObjectKey;
            }
            set
            {
                if (CurrentUIStatus.BrowseViewObjectKey == value)
                {
                    return;
                }

                // the viewObjectKey is null until the viewObject selected, skip the meaningless UI status
                if (!string.IsNullOrEmpty(CurrentUIStatus.BrowseViewObjectKey))
                { 
                    SaveChangedStatus();
                }
                CurrentUIStatus.BrowseViewObjectKey = value;
                NavigationToNewPage(CurrentUIStatus.BrowseViewObjectKey);
            }
        }

        private MainWindowUIStatusModel _currentUIStatus;
        public MainWindowUIStatusModel CurrentUIStatus {
            get
            {
                return _currentUIStatus;
            }
            set
            {
                var msg = new MainWindowUINotificationMsg();
                if (_currentUIStatus.BrowseViewStyle != value.BrowseViewStyle)
                {
                    msg.setMsg(ChangedUIElement.ViewStyle, _currentUIStatus.BrowseViewStyle, value.BrowseViewStyle);
                    _currentUIStatus.BrowseViewStyle = value.BrowseViewStyle;
                    RaisePropertyChanged(nameof(BrowseViewStyle));
                }
                if (_currentUIStatus.KindOfArrangeBy != value.KindOfArrangeBy)
                {
                    if (msg.Empty)
                    {
                        msg.setMsg(ChangedUIElement.ArrangeBy, _currentUIStatus.KindOfArrangeBy, value.KindOfArrangeBy);
                    }
                    else
                    {
                        msg.setMsg(ChangedUIElement.MutilpleUI, _currentUIStatus, value);
                    }
                    _currentUIStatus.KindOfArrangeBy = value.KindOfArrangeBy;
                    RaisePropertyChanged(nameof(KindOfArrangeBy));
                }
                if (_currentUIStatus.KindOfSortBy != value.KindOfSortBy)
                {
                    if (msg.Empty)
                    {
                        msg.setMsg(ChangedUIElement.SortBy, _currentUIStatus.KindOfSortBy, value.KindOfSortBy);
                    }
                    else
                    {
                        msg.setMsg(ChangedUIElement.MutilpleUI, _currentUIStatus, value);
                    }
                    _currentUIStatus.KindOfSortBy = value.KindOfSortBy;
                    RaisePropertyChanged(KindOfSortByPropertyName);
                }
                if (_currentUIStatus.IsAscending != value.IsAscending)
                {
                    if (msg.Empty)
                    {
                        msg.setMsg(ChangedUIElement.SortBy, _currentUIStatus.IsAscending, value.IsAscending);
                    }
                    else
                    {
                        msg.setMsg(ChangedUIElement.MutilpleUI, _currentUIStatus, value);
                    }
                    _currentUIStatus.IsAscending = value.IsAscending;
                    RaisePropertyChanged(IsAscendingPropertyName);
                }
                if (_currentUIStatus.KindOfViewMode != value.KindOfViewMode)
                {
                    if (msg.Empty)
                    {
                        msg.setMsg(ChangedUIElement.ViewMode, _currentUIStatus.KindOfViewMode, value.KindOfViewMode);
                    }
                    else
                    {
                        msg.setMsg(ChangedUIElement.MutilpleUI, _currentUIStatus, value);
                    }
                    _currentUIStatus.KindOfViewMode = value.KindOfViewMode;
                    RaisePropertyChanged(nameof(KindOfViewMode));
                }
                if (_currentUIStatus.BrowseViewObjectKey != value.BrowseViewObjectKey)
                {
                    if (msg.Empty)
                    {
                        msg.setMsg(ChangedUIElement.ViewObject, _currentUIStatus.BrowseViewObjectKey, value.BrowseViewObjectKey);
                    }
                    else
                    {
                        msg.setMsg(ChangedUIElement.MutilpleUI, _currentUIStatus, value);
                    }
                    _currentUIStatus.BrowseViewObjectKey = value.BrowseViewObjectKey;
                    NavigationToNewPage(CurrentUIStatus.BrowseViewObjectKey);
                }
                if (!msg.Empty)
                {
                    Messenger.Default.Send(msg);
                }
            }
        }

        #endregion
    }
}
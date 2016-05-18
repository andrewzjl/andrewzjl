using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        /// <summary>
        /// Initializes a new instance of the MainWindowsUIViewModel class.
        /// </summary>
        public MainWindowsUIStatusViewModel()
        {
            _BackStatusStack = new Stack<MainWindowUIStatusModel>();
            _ForwardStatusStack = new Stack<MainWindowUIStatusModel>();
            CurrentUIStatus = new MainWindowUIStatusModel();
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
        }

        #region Properties of Navigation stack
        const int MAX_LIST_SIZE = 15;
        public MainWindowUIStatusModel CurrentStatus { get; set; }

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
        public bool CanGoBack
        { get
            {
                return _BackStatusStack.Count > 0;
            }
        }

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
            _ForwardStatusStack.Push(CurrentUIStatus);
            CurrentUIStatus = _BackStatusStack.Pop();
        }

        private bool CanExecuteGoBack()
        {
            return CanGoBack;
        }

        public bool CanGoForward { get { return _ForwardStatusStack.Count > 0; } }

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
                        _BackStatusStack.Push(CurrentUIStatus);
                        CurrentUIStatus = _ForwardStatusStack.Pop();
                    }, () =>
                    {
                        return CanGoForward;
                    }));
            }
        }

        void SaveChangedStatus()
        {
            _BackStatusStack.Push(CurrentUIStatus);
            _ForwardStatusStack.Clear();
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
        #endregion

        #region Current UI status properties
        /// <summary>
        /// The <see cref="BrowseViewStyle" /> property's name.
        /// </summary>
        public const string BrowseViewStylePropertyName = "BrowseViewStyle";
        
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
                CurrentUIStatus.BrowseViewStyle = (BrowseViewStyle)value;
                RaisePropertyChanged(BrowseViewStylePropertyName);
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
                CurrentUIStatus.IsAscending = value;
                RaisePropertyChanged(IsAscendingPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="KindOfViewMode" /> property's name.
        /// </summary>
        public const string KindOfViewModePropertyName = "KindOfViewMode";

        /// <summary>
        /// Sets and gets the KindOfViewMode property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public KindOfViewMode KindOfViewMode
        {
            get
            {
                return CurrentUIStatus.KindOfViewMode;
            }

            set
            {
                if (CurrentUIStatus.KindOfViewMode == value)
                {
                    return;
                }

                SaveChangedStatus();
                CurrentUIStatus.KindOfViewMode = value;
                RaisePropertyChanged(KindOfViewModePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="BrowseViewObjectKey" /> property's name.
        /// </summary>
        public const string BrowseViewObjectKeyPropertyName = "BrowseViewObjectKey";
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

                SaveChangedStatus();
                CurrentUIStatus.BrowseViewObjectKey = value;
                RaisePropertyChanged(BrowseViewObjectKeyPropertyName);
            }
        }
        public MainWindowUIStatusModel CurrentUIStatus { get; private set; }

        #endregion
    }
}
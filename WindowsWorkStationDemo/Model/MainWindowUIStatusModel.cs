using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWorkStationDemo.Model
{
    class MainWindowUIStatusModel
    {
        public BrowseViewStyle BrowseViewStyle { get; set; }

        public KindOfArrangeBy KindOfArrangeBy { get; set; }

        public KindOfSortBy KindOfSortBy { get; set; }
        public bool IsAscending { get; set; }

        public KindOfViewMode KindOfViewMode { get; set; }

        public string BrowseViewObjectKey { get; set; }
    }

    public enum BrowseViewStyle
    {
        AsIcons,
        AsList,
        AsColumns,
        AsCoverFlow
    }

    public enum KindOfArrangeBy
    {
        None,
        ByName,
        ByKind,
        ByDateLastOpened,
        ByDateModified,
        ByDateCreated,
        ByProject
    }
    public enum KindOfSortBy
    {
        None,
        ByName,
        ByKind,
        ByDateLastOpened,
        ByDateModified,
        ByDateCreated,
        ByProject,
        ByServer,
        ByOwner
    }

    public enum KindOfViewMode
    {
        SmartMode,
        FolderMode
    }
}

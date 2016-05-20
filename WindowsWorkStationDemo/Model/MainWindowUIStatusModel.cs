using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWorkStationDemo.Model
{
    public class MainWindowUIStatusModel
    {
        public MainWindowUIStatusModel()
        {
            BrowseViewStyle = BrowseViewStyle.AsList;
            KindOfArrangeBy = KindOfArrangeBy.None;
            KindOfSortBy = KindOfSortBy.None;
            IsAscending = true;
            KindOfViewMode = KindOfViewMode.SmartMode;
            BrowseViewObjectKey = "";
        }

        public MainWindowUIStatusModel(MainWindowUIStatusModel currentUIStatus)
        {
            BrowseViewStyle = currentUIStatus.BrowseViewStyle;
            KindOfArrangeBy = currentUIStatus.KindOfArrangeBy;
            KindOfSortBy = currentUIStatus.KindOfSortBy; 
            IsAscending = currentUIStatus.IsAscending;
            KindOfViewMode = currentUIStatus.KindOfViewMode;
            BrowseViewObjectKey = currentUIStatus.BrowseViewObjectKey;
        }

        public BrowseViewStyle BrowseViewStyle { get; set; }

        public KindOfArrangeBy KindOfArrangeBy { get; set; }

        public KindOfSortBy KindOfSortBy { get; set; }
        public bool IsAscending { get; set; }

        public KindOfViewMode KindOfViewMode { get; set; }

        public string BrowseViewObjectKey { get; set; }
    }

    public enum BrowseViewStyle
    {
        [Description("AsIcons")]
        AsIcons,
        [Description("AsList")]
        AsList,
        [Description("AsColumns")]
        AsColumns,
        [Description("AsCoverFlow")]
        AsCoverFlow
    }

    public enum KindOfArrangeBy
    {
        [Description("None")]
        None,
        [Description("Name")]
        ByName,
        [Description("Type")]
        ByKind,
        [Description("Last Opened")]
        ByDateLastOpened,
        [Description("Data Modified")]
        ByDateModified,
        [Description("Data Created")]
        ByDateCreated,
        [Description("Project")]
        ByProject,
        [Description("-")]
        Reserved
    }
    public enum KindOfSortBy
    {
        [Description("None")]
        None,
        [Description("Name")]
        ByName,
        [Description("Type")]
        ByKind,
        [Description("Last Opened")]
        ByDateLastOpened,
        [Description("Date Modified")]
        ByDateModified,
        [Description("Date Created")]
        ByDateCreated,
        [Description("Project")]
        ByProject,
        [Description("Server")]
        ByServer,
        [Description("Owner")]
        ByOwner,
        [Description("-")]
        Reserved
    }

    public enum KindOfViewMode
    {
        SmartMode,
        FolderMode
    }
}

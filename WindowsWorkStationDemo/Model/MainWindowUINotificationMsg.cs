using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWorkStationDemo.Model
{
    class MainWindowUINotificationMsg
    {
        public MainWindowUIStatusModel UIStatus { get; set; }
        public ChangedUIElement ChangedUIElement { get; set; }
        public object OldValue { get; set; }
    }

    public enum ChangedUIElement
    {
        ViewStyle,
        ArrangeBy,
        SortBy,
        ViewMode,
        ViewObject
    }
}

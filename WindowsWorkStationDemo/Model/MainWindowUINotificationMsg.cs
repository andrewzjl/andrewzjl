using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWorkStationDemo.Model
{
    class MainWindowUINotificationMsg
    {
        public MainWindowUINotificationMsg()
        {
            ChangedUIElement = ChangedUIElement.Reserved;
        }
        public MainWindowUINotificationMsg(ChangedUIElement changedUIElement, object oldValue, object newValue)
        {
            setMsg(changedUIElement, oldValue, newValue);
        }
        public ChangedUIElement ChangedUIElement { get; set; }
        // optional
        public object OldValue { get; set; }
        // if it's multiple changed, use MainWindowUIStatusModel to pass the full status
        public object NewValue { get; set; }

        public object Sender { get; set; }

        public bool Empty { get { return ChangedUIElement == ChangedUIElement.Reserved; } }

        public void setMsg(ChangedUIElement changedUIElement, object oldValue, object newValue)
        {
            ChangedUIElement = changedUIElement;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }

    public enum ChangedUIElement
    {
        Reserved,
        ViewStyle,
        ArrangeBy,
        SortBy,
        ViewMode,
        ViewObject,
        StatusInfo,
        MutilpleUI
    }
}

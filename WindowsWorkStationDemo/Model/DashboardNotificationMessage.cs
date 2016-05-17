using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWorkStationDemo.Model
{
    class DashboardNotificationMessage
    {
        public string Message;
        public enum MessageType
        {
            addDashboard,
            deleteDashboard,
            renameDashboard,
            showDashboard
        };
        public MessageType MsgType;
        public int selectedIndex;
    }
}

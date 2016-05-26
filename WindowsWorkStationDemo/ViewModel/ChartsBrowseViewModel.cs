using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsWorkStationDemo.Model;

namespace WindowsWorkStationDemo.ViewModel
{
    public class ChartsBrowseViewModel : BaseBrowseViewModel
    {
        protected override void HandleUIChangedEvent(MainWindowUINotificationMsg msg)
        {
            // todo, handle the basic UI changed msg; derived vm can handle special by override
            _ObjectList.Add(string.Format("{0} is changed to value {1}.", msg.ChangedUIElement, msg.NewValue));
            RaisePropertyChanged();
        }
    }
}

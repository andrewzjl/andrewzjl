using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WindowsWorkStationDemo.Model
{
    public class BrowseViewObject
    {
        public string Icon { get; set; }

        public string Title { get; set; }

        public Type ClassType { get; set; }

        public ICommand AddObject { get; set; }
        
        public System.Windows.Visibility AddBtnVisibility
        {
            get { return (AddObject != null) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed; }
        }
        public override string ToString()
        {
            return Title;
        }
    }
}

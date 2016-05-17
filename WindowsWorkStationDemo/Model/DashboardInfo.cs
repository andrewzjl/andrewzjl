using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWorkStationDemo.Model
{
    class DashboardInfo
    {
        private DateTime _createTime;
        public string Name;

        public string CreateTime
        {
            get { return _createTime.ToString(); }
        }
        public DashboardInfo(string name)
        {
            Name = name;
            _createTime = DateTime.Now;
        }
        public DashboardInfo()
        {
            _createTime = DateTime.Now;
        }
    }
}

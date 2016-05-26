using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common.Logging;
using NLog;

namespace WindowsWorkStationDemo.View
{
    public partial class BasePage : Page
    {
        protected Logger Log { get; private set; }
        public BasePage()
        {
            Log = NLog.LogManager.GetLogger(GetType().FullName);
            this.Loaded += BasePage_Loaded;
            this.Unloaded += BasePage_Unloaded;
        }

        private void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Log.Debug("{0} loaded", GetType().FullName);
            if ((DataContext != null) && (DataContext is ViewModel.BaseBrowseViewModel))
            {
                ((ViewModel.BaseBrowseViewModel)DataContext).Loaded();
            }
        }
        
        private void BasePage_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Log.Debug("{0} unloaded!", GetType().FullName);
            if ((DataContext != null) && (DataContext is ViewModel.BaseBrowseViewModel))
            {
                ((ViewModel.BaseBrowseViewModel)DataContext).Cleanup();
            }
        }
    }
}

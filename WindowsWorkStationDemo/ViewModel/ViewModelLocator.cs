/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WindowsWorkStationDemo"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using WindowsWorkStationDemo.Utility;

namespace WindowsWorkStationDemo.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<BrowseViewObjectViewModel>();
            SimpleIoc.Default.Register<MainWindowsUIStatusViewModel>();
            SimpleIoc.Default.Register<BaseBrowseViewModel>(() => { return new BaseBrowseViewModel(); }, Constants.Environments);
            SimpleIoc.Default.Register<BaseBrowseViewModel>(() => { return new BaseBrowseViewModel(); }, Constants.Applications);
            SimpleIoc.Default.Register<BaseBrowseViewModel>(() => { return new BaseBrowseViewModel(); }, Constants.Dossiers);
            SimpleIoc.Default.Register<BaseBrowseViewModel>(() => { return new DashboardsViewModel(); }, Constants.Dashboards);
            SimpleIoc.Default.Register<BaseBrowseViewModel>(() => { return new ChartsBrowseViewModel(); }, Constants.Charts);
            SimpleIoc.Default.Register<BaseBrowseViewModel>(() => { return new BaseBrowseViewModel(); }, Constants.Maps);
            SimpleIoc.Default.Register<BaseBrowseViewModel>(() => { return new BaseBrowseViewModel(); }, Constants.Grids);
            SimpleIoc.Default.Register<BaseBrowseViewModel>(() => { return new BaseBrowseViewModel(); }, Constants.Datasets);
        }

        public BrowseViewObjectViewModel BrowseViewObjectVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BrowseViewObjectViewModel>();
            }
        }

        public MainWindowsUIStatusViewModel MainWindowsUIStatus
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowsUIStatusViewModel>();
            }
        }

        public static BaseBrowseViewModel BrowseViewModel(string BrowseObjectKey)
        {
            return ServiceLocator.Current.GetInstance<BaseBrowseViewModel>(BrowseObjectKey);
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
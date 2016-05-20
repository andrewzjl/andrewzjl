using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsWorkStationDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static object GetResource(string resourceName)
        {
            try
            {
                return Current.FindResource(resourceName);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}

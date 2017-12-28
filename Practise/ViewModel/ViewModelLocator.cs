/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:LeetCodePractise"
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
using LeetCodePractise.Solutions;

namespace LeetCodePractise.ViewModel
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
        static  ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>(true);
            SimpleIoc.Default.Register<StringToIntViewModel>(true);
            SimpleIoc.Default.Register<PalindromeNumberVerifyViewModel>(true);
            SimpleIoc.Default.Register<RomanToIntegerViewModel>(true);
            SimpleIoc.Default.Register<IntegerToRomanViewModel>(true);
            SimpleIoc.Default.Register<RemoveLastNthNodeViewModel>(true);
            SimpleIoc.Default.Register<MergeTwoSortedListsViewModel>(true);
            SimpleIoc.Default.Register<LongestCommonPrefixViewModel>(true);
            SimpleIoc.Default.Register<LongestSubstringWithoutRepeatViewModel>(true);
            SimpleIoc.Default.Register<RegularExpressionMatchingViewModel>(true);
            SimpleIoc.Default.Register<EditDistanceCalculatorViewModel>(true);
            SimpleIoc.Default.Register<LongestPalindromicSubstringViewModel>(true);
            SimpleIoc.Default.Register<MaxStockProfitViewModel>(true);
            SimpleIoc.Default.Register<CountOfSmallerAfterSelfViewModel>(true);
        }

        public MainViewModel MainViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        public static void Cleanup()
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LeetCodePractise.Solutions.PreoderTreeVerify
{
    /// <summary>
    /// Interaction logic for PreorderVerifyWindow.xaml
    /// </summary>
    public partial class PreorderVerifyWindow : Window
    {
        public PreorderVerifyWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var testString = TestString.Text;
            Console.WriteLine("test string:"+testString);
            var result = PreorderTreeVerify.IsValidSerialization(testString);
            Console.WriteLine(result);
            TestResult.Text = result.ToString();
        }
    }
}

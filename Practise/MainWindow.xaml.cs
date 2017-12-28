using LeetCodePractise.Solutions;
using LeetCodePractise.Solutions.PreoderTreeVerify;
using LeetCodePractise.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LeetCodePractise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PreorderTreeVerify_Click(object sender, RoutedEventArgs e)
        {
            (new PreorderVerifyWindow()).ShowDialog();
        }

        private void PractiseSolutionClicked(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var viewModel = button.DataContext;
            var window = new GenericTestCaseWindow();
            window.DataContext = viewModel;
            window.Show();
        }
    }
}

using GalaSoft.MvvmLight.Ioc;
using LeetCodePractise.Model;
using LeetCodePractise.Model.Extensions;
using LeetCodePractise.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    public class MyPowViewModel : PractiseBaseViewModel<KeyValuePair<double, int>, string>
    {
        private List<Tuple<double, int, string>> _testCases = new List<Tuple<double, int, string>>
        {
            new Tuple<double, int, string>( 2.00000, 10, "1024.00000" ),
            new Tuple<double, int, string>( 2.10000, 3, "9.26100" ),
            new Tuple<double, int, string>( 2.10000, 0, "1.00000" ),
            new Tuple<double, int, string>( 1024.00000, -102, "0.00000" ),
            new Tuple<double, int, string>( 1.00300, -102, "0.73672" ),
            new Tuple<double, int, string>( 4.00300, 0, "1.00000" ),
            new Tuple<double, int, string>( 0.00000, 0, "1.00000" ),
            new Tuple<double, int, string>( 0.00000, 2, "0.00000" ),
            new Tuple<double, int, string>( 0.00000, -2, double.PositiveInfinity.ToString("F5") ),
            new Tuple<double, int, string>( 2.00000, -2147483648, "0.00000" ),
            new Tuple<double, int, string>( 0.99999, 948688, "0.00008" ),
            new Tuple<double, int, string>( 1.00001, 948688, "13184.96660" ),
        };

        protected override void InitialTestCases()
        {
            Title = "pow(x, n)";
            Requirement = "Implement pow(x, n).";
            Id = 50;
            SolutionExecutor = ExecuteTestCase;
            _testCases.ForEach(testCase => AddTestCases(new KeyValuePair<double, int>(testCase.Item1, testCase.Item2), testCase.Item3));
        }

        string ExecuteTestCase(KeyValuePair<double, int> testCase)
        {
            var result = PowSolution.MyPow(testCase.Key, testCase.Value);

            return result.ToString("F5");
        }
    }
}

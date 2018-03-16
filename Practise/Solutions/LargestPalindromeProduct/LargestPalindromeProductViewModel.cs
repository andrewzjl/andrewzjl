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
    public class LargetestPalindromeProdutViewModel : PractiseBaseViewModel<int, int>
    {
        private List<Tuple<int, int>> _testCases = new List<Tuple<int, int>>
        {
            new Tuple<int, int>( 1, 9 ),
            new Tuple<int, int>( 2, 987 ),
            new Tuple<int, int>( 3, 123 ),
            new Tuple<int, int>( 4, 597 ),
            new Tuple<int, int>( 5, 677 ),
            new Tuple<int, int>( 6, 1218 ),
            new Tuple<int, int>( 7, 877 ),
            new Tuple<int, int>( 8, 475 ),
        };

        protected override void InitialTestCases()
        {
            Title = "Largest Palindrome Product";
            Requirement = "Find the largest palindrome made from the product of two n-digit numbers.";
            Id = 479;
            SolutionExecutor = ExecuteTestCase;
            _testCases.ForEach(testCase => AddTestCases(testCase.Item1, testCase.Item2));
        }

        int ExecuteTestCase(int testCase)
        {
            var result = LargestPalindromeProductSolution.LargestPalindrome(testCase);

            return result;
        }
    }
}

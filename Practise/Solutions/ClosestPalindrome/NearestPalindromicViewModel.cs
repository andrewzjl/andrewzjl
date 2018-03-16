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
    public class NearestPalindromicViewModel : PractiseBaseViewModel<string, string>
    {
        private List<KeyValuePair<string, string>> _testCases = new List<KeyValuePair<string, string>>
        {
            { new KeyValuePair<string, string>("0", "-1") },
            { new KeyValuePair<string, string>("1", "0") },
            { new KeyValuePair<string, string>("121", "111") },
            { new KeyValuePair<string, string>("101", "99") },
            { new KeyValuePair<string, string>("12345678987654321", "12345678887654321") },
            { new KeyValuePair<string, string>("121", "111") },
            { new KeyValuePair<string, string>("4565456456", "4565445654") },
            { new KeyValuePair<string, string>("99", "101") },
            { new KeyValuePair<string, string>("1001", "999") },
            { new KeyValuePair<string, string>("3", "2") },
            { new KeyValuePair<string, string>("11", "9") },
            { new KeyValuePair<string, string>("10", "9") },
            { new KeyValuePair<string, string>("100", "99") },
            { new KeyValuePair<string, string>("102", "101") },
            { new KeyValuePair<string, string>("109", "111") },
            { new KeyValuePair<string, string>("909", "919") },
            { new KeyValuePair<string, string>("223372036854775807", "223372036630273322") },
            { new KeyValuePair<string, string>("999999999999999999", "1000000000000000001") },
        };

        protected override void InitialTestCases()
        {
            Title = "Find the Closest Palindrome";
            Requirement = "Given an integer n, find the closest integer (not including itself), which is a palindrome. The 'closest' is defined as absolute difference minimized between two integers.";
            SolutionExecutor = ExecuteTestCase;
            _testCases.ForEach(testCase => AddTestCases(testCase.Key, testCase.Value));
        }

        string ExecuteTestCase(string testCase)
        {
            var result = ClosestPalindromic.NearestPalindromic(testCase);
            
            return result;
        }
    }
}

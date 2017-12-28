using GalaSoft.MvvmLight.Ioc;
using LeetCodePractise.Model;
using LeetCodePractise.Model.Extensions;
using LeetCodePractise.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    public class LongestCommonPrefixViewModel : PractiseBaseViewModel<string, string>
    {
        private List<KeyValuePair<string, string>> _testCases = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("", ""),
            new KeyValuePair<string, string>("1234,234,34", ""),
            new KeyValuePair<string, string>(" 1234, 234, 134", " "),
            new KeyValuePair<string, string>("abc", "abc"),
            new KeyValuePair<string, string>("abc,abcd", "abc"),
            new KeyValuePair<string, string>("abc,abcd,abe", "ab"),
            new KeyValuePair<string, string>("abc,abcd,abe,", ""),
        };
        protected override void InitialTestCases()
        {
            Title = "LongestCommonPrefix";
            Requirement = "Write a function to find the longest common prefix string amongst an array of strings.";
            SolutionExecutor = ExecuteTestCase;
            _testCases.ForEach(testCase => TestRecords.Add(new TestRecord<string, string>(testCase.Key, testCase.Value, SolutionExecutor(testCase.Key))));
        }

        string ExecuteTestCase(string testCase)
        {
            string[] testArray = testCase.Split(',');
            return LongestCommonPrefixSolution.LongestCommonPrefix(testArray);
        }
    }
}

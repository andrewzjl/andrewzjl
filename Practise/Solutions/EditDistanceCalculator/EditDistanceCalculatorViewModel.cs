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
    public class EditDistanceCalculatorViewModel : PractiseBaseViewModel<string, int>
    {
        private List<KeyValuePair<string, int>> _testCases = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("\n", 0),
            new KeyValuePair<string, int>("Aa\naa", 1),
            new KeyValuePair<string, int>("baa\naa", 1),
            new KeyValuePair<string, int>("ab\nbab", 1),
            new KeyValuePair<string, int>("abc\nbab", 2),
            new KeyValuePair<string, int>("abc\nbcabc", 2),
            new KeyValuePair<string, int>("abc\nbcabd", 3),
            new KeyValuePair<string, int>("abc\naabcd", 2),
            new KeyValuePair<string, int>("abc\n", 3),
            new KeyValuePair<string, int>("\naabcd", 5),
        };
        protected override void ExecuteTestCases()
        {
            Title = "EditDistanceCalculator";
            Requirement = "Given two words word1 and word2, find the minimum number of steps required to convert word1 to word2. ";
            SolutionExecutor = ExecuteTestCase;
            _testCases.ForEach(testCase => TestRecords.Add(new TestRecord<string, int>(testCase.Key, testCase.Value, SolutionExecutor(testCase.Key))));
        }
       
        int ExecuteTestCase(string testCase)
        {
            if (string.IsNullOrEmpty(testCase))
            {
                throw new ArgumentNullException("Execute TestCase failed.");
            }
            var testCaseArray = testCase.Split('\n');
            var word1 = testCaseArray[0];
            var word2 = testCaseArray[1];
            return EditDistanceCalculator.MinDistance(word1, word2);
        }
    }
}

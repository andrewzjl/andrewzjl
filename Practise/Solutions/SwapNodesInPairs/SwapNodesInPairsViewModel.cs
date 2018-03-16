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
    public class SwapNodesInPairsViewModel : PractiseBaseViewModel<string, string>
    {
        private List<KeyValuePair<string, string>> _testCases = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("1,2", "2,1"),
            new KeyValuePair<string, string>("1", "1"),
            new KeyValuePair<string, string>("1,2,3,4", "2,1,4,3"),
            new KeyValuePair<string, string>("1,2,3,4,5", "2,1,4,3,5"),
            new KeyValuePair<string, string>("1,2,3,4,5,6", "2,1,4,3,6,5"),
        };

        protected override void ExecuteTestCases()
        {
            Title = "Swap Nodes in Pairs";
            Requirement = "Given a linked list, swap every two adjacent nodes and return its head.";
            Id = 24;
            SolutionExecutor = ExecuteTestCase;
            _testCases.ForEach(testCase => TestRecords.Add(new TestRecord<string, string>(testCase.Key, testCase.Value, SolutionExecutor(testCase.Key))));
        }

        string ExecuteTestCase(string testCase)
        {
            var testLinks = testCase.StringToLink();
            var resultLink = SwapNodesInPairs.SwapPairs(testLinks);
            return resultLink?.ToString();
        }
    }
}

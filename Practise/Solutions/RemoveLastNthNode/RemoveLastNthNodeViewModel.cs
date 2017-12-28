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
    public class RemoveLastNthNodeViewModel : PractiseBaseViewModel<string, string>
    {
        private List<KeyValuePair<string, string>> _testCases = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("1\n1", null),
            new KeyValuePair<string, string>("1\n2", "1"),
            new KeyValuePair<string, string>("1,2\n2", "2"),
            new KeyValuePair<string, string>("1,2\n1", "1"),
            new KeyValuePair<string, string>("1,2\n3", "1,2"),
            new KeyValuePair<string, string>("1,2,3\n1", "1,2"),
            new KeyValuePair<string, string>("1,2,3\n2", "1,3"),
            new KeyValuePair<string, string>("1,2,3\n3", "2,3"),
            new KeyValuePair<string, string>("1,2,3\n4", "1,2,3"),
            new KeyValuePair<string, string>("1,2,3,4,5\n2", "1,2,3,5"),
            new KeyValuePair<string, string>("1,2,3,4,5,6,7\n7","2,3,4,5,6,7"),
        };
        protected override void InitialTestCases()
        {
            Title = "RemoveLastNthNode";
            Requirement = "Given a linked list, remove the nth node from the end of list and return its head.";
            SolutionExecutor = ExecuteTestCase;
            _testCases.ForEach(testCase => TestRecords.Add(new TestRecord<string, string>(testCase.Key, testCase.Value, SolutionExecutor(testCase.Key))));
        }

        string ExecuteTestCase(string testCase)
        {
            if (string.IsNullOrWhiteSpace(testCase))
            {
                throw new ArgumentNullException("Execute TestCase failed.");
            }
            var testCaseArray = testCase.Split('\n');
            var linkString = testCaseArray[0];
            var lastN = int.Parse(testCaseArray[1]);
            var testLink = linkString.StringToLink();
            var resultLink = RemoveLastNthNode.RemoveNthFromEnd(testLink, lastN);
            return resultLink?.ToString();
        }
    }
}

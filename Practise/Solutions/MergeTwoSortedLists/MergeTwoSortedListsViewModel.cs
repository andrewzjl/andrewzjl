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
    public class MergeTwoSortedListsViewModel : PractiseBaseViewModel<string, string>
    {
        private List<KeyValuePair<string, string>> _testCases = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("\n", null),
            new KeyValuePair<string, string>("1\n2", "1,2"),
            new KeyValuePair<string, string>("1,2\n2", "1,2,2"),
            new KeyValuePair<string, string>("1,2\n1", "1,1,2"),
            new KeyValuePair<string, string>("1,2\n3", "1,2,3"),
            new KeyValuePair<string, string>("1,2,3\n1", "1,1,2,3"),
            new KeyValuePair<string, string>("1,2,3\n2", "1,2,2,3"),
            new KeyValuePair<string, string>("1,2,3\n3", "1,2,3,3"),
            new KeyValuePair<string, string>("\n1,2,3", "1,2,3"),
            new KeyValuePair<string, string>("1,2,3\n", "1,2,3"),
            new KeyValuePair<string, string>("1,2,3,4,5\n2", "1,2,2,3,4,5"),
            new KeyValuePair<string, string>("1,6,7\n2,3,4,5,7","1,2,3,4,5,6,7,7"),
            new KeyValuePair<string, string>("1,2,2,2,7\n2,2,2,2,3","1,2,2,2,2,2,2,2,3,7"),
        };
        protected override void InitialTestCases()
        {
            Title = "MergeTwoSortedLists";
            Requirement = "Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.";
            SolutionExecutor = ExecuteTestCase;
            _testCases.ForEach(testCase => TestRecords.Add(new TestRecord<string, string>(testCase.Key, testCase.Value, SolutionExecutor(testCase.Key))));
        }

        string ExecuteTestCase(string testCase)
        {
            if (string.IsNullOrEmpty(testCase))
            {
                throw new ArgumentNullException("Execute TestCase failed.");
            }
            var testCaseArray = testCase.Split('\n');
            var linkString1 = testCaseArray[0];
            var linkString2 = testCaseArray[1];
            var testLink1 = linkString1.StringToLink();
            var testLink2 = linkString2.StringToLink();
            var resultLink = MergeTwoSortedLists.MergeTwoLists(testLink1, testLink2);
            return resultLink?.ToString();
        }
    }
}

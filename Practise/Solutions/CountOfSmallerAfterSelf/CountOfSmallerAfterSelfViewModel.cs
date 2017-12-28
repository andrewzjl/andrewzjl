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
    public class CountOfSmallerAfterSelfViewModel : PractiseBaseViewModel<string, string>
    {
        private List<KeyValuePair<string, string>> _testCases = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("", ""),
            new KeyValuePair<string, string>("1,2", "0,0"),
            new KeyValuePair<string, string>("1,2,1", "0,1,0"),
            new KeyValuePair<string, string>("5,1,2,4,1", "4,0,1,1,0"),
            new KeyValuePair<string, string>("5,2,6,1", "2,1,1,0"),
            new KeyValuePair<string, string>("5,2,4,1", "3,1,1,0"),
            new KeyValuePair<string, string>("3,5,2,4,1", "2,3,1,1,0"),
            new KeyValuePair<string, string>("4,5,2,4,1", "2,3,1,1,0"),
            new KeyValuePair<string, string>("2,5,2,4,1", "1,3,1,1,0"),
            new KeyValuePair<string, string>("0,0,0,0,0", "0,0,0,0,0"),
            new KeyValuePair<string, string>("1,1,1,1,1", "0,0,0,0,0"),
            new KeyValuePair<string, string>("2,-5,-2,-4,-1", "4,0,1,0,0"),
        };
        protected override void InitialTestCases()
        {
            Title = "Count of Smaller Numbers After Self";
            Requirement = "You are given an integer array nums and you have to return a new counts array. The counts array has the property where counts[i] is the number of smaller elements to the right of nums[i].";
            SolutionExecutor = ExecuteTestCase;
            _testCases.ForEach(testCase => TestRecords.Add(new TestRecord<string, string>(testCase.Key, testCase.Value, SolutionExecutor(testCase.Key))));
        }

        string ExecuteTestCase(string testCase)
        {
            var testCaseArray = testCase.StringToIntArray();
            var resultLink = CountOfSmallerAfterSelf.CountSmaller(testCaseArray);
            return string.Join(",", resultLink);
        }
    }
}

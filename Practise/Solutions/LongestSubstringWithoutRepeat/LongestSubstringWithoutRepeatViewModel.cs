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
    public class LongestSubstringWithoutRepeatViewModel : PractiseBaseViewModel<string, int>
    {
        private List<KeyValuePair<string, int>> _testCases = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("", 0),
            new KeyValuePair<string, int>("abcabcbb", 3),
            new KeyValuePair<string, int>("bbbbb", 1),
            new KeyValuePair<string, int>("pwwkew", 3),
            new KeyValuePair<string, int>("abdcbabcbb", 4),
            new KeyValuePair<string, int>("abbbbb", 2),
            new KeyValuePair<string, int>("pwwkpewpew", 4),
            new KeyValuePair<string, int>("abcabcdefgabcddefgh", 7),
            new KeyValuePair<string, int>("aabbccdeef", 3),
            new KeyValuePair<string, int>("aabcacdedc", 4),
        };
        protected override void ExecuteTestCases()
        {
            Title = "LongestSubstringWithoutRepeating";
            Requirement = "Given a string, find the length of the longest substring without repeating characters.";
            SolutionExecutor = ExecuteTestCase;
            _testCases.ForEach(testCase => TestRecords.Add(new TestRecord<string, int>(testCase.Key, testCase.Value, SolutionExecutor(testCase.Key))));
        }

        int ExecuteTestCase(string testCase)
        {
            return LongestSubstringWithoutRepeat.LengthOfLongestSubstring(testCase);
        }
    }
}

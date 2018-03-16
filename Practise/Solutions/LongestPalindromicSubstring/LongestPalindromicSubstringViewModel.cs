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
    public class LongestPalindromicSubstringViewModel : PractiseBaseViewModel<string, string>
    {
        private List<KeyValuePair<string, string>> _testCases = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("babad", "bab"),
            new KeyValuePair<string, string>("cbbd", "bb"),
            new KeyValuePair<string, string>("cbcdcbd", "bcdcb"),
            new KeyValuePair<string, string>("cbcdcbdcabcdcbac", "cabcdcbac"),
            new KeyValuePair<string, string>("abcdcb", "bcdcb"),
            new KeyValuePair<string, string>("abccbad", "abccba"),
            new KeyValuePair<string, string>("babaddtattarrattatddetartrateedredividerb", "ddtattarrattatdd"),
            new KeyValuePair<string, string>("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"),
        };
        protected override void ExecuteTestCases()
        {
            Title = "LongestPalindromicSubstring";
            Requirement = "Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.";
            SolutionExecutor = LongestPalindromicSubstring.LongestPalindrome;
            _testCases.ForEach(testCase => TestRecords.Add(new TestRecord<string, string>(testCase.Key, testCase.Value, SolutionExecutor(testCase.Key))));
        }
    }
}

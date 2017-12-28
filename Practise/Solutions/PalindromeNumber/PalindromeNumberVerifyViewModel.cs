using LeetCodePractise.Model;
using LeetCodePractise.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    public class PalindromeNumberVerifyViewModel : PractiseBaseViewModel<int, bool>
    {
        private List<KeyValuePair<int, bool>> _testCases = new List<KeyValuePair<int, bool>>
        {
            new KeyValuePair<int, bool>(-2147483648, false),
            new KeyValuePair<int, bool>(2147483647, false),
            new KeyValuePair<int, bool>(-232, false),
            new KeyValuePair<int, bool>(0, true),
            new KeyValuePair<int, bool>(343, true),
            new KeyValuePair<int, bool>(3434, false),
            new KeyValuePair<int, bool>(10, false),
            new KeyValuePair<int, bool>(22, true),
            new KeyValuePair<int, bool>(2147447412, true),
            new KeyValuePair<int, bool>(1000021, false),
            new KeyValuePair<int, bool>(100, false),
            new KeyValuePair<int, bool>(101, true),
            new KeyValuePair<int, bool>(1001, true),
            new KeyValuePair<int, bool>(1000, false),
            new KeyValuePair<int, bool>(999, true),
            new KeyValuePair<int, bool>(9999, true),
            new KeyValuePair<int, bool>(10101, true),
            new KeyValuePair<int, bool>(10001, true),
        };
        protected override void InitialTestCases()
        {
            Title = "PalindromeNumberVerify";
            Requirement = "Determine whether an integer is a palindrome. Do this without extra space.";
            SolutionExecutor = PalindromeNumberVerify.IsPalindrome;
            _testCases.ForEach(testCase=>TestRecords.Add(new TestRecord<int,bool>(testCase.Key, testCase.Value, SolutionExecutor(testCase.Key))));
        }
    }
}

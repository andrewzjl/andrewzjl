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
    public class RegularExpressionMatchingViewModel : PractiseBaseViewModel<string, bool>
    {
        private List<KeyValuePair<string, bool>> _testCases = new List<KeyValuePair<string, bool>>
        {
            new KeyValuePair<string, bool>("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n....................*.*ab*c*d*.*.*", true),
            new KeyValuePair<string, bool>("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n.*.d*d*d*.*.*.*.*.*.*ab*c*d*.*.*d*e*x*y*z", false),
            new KeyValuePair<string, bool>("acbbcbcbcbaaacaac\nac*.a*ac*.*ab*b*ac", false),
            new KeyValuePair<string, bool>("\n", true),
            new KeyValuePair<string, bool>("\n.", false),
            new KeyValuePair<string, bool>("\na*", true),
            new KeyValuePair<string, bool>("b\na*", false),
            new KeyValuePair<string, bool>("aa\na*", true),
            new KeyValuePair<string, bool>("aa\na*b*", true),
            new KeyValuePair<string, bool>("aa\n.*", true),
            new KeyValuePair<string, bool>("aab\n.*", true),
            new KeyValuePair<string, bool>("aab\n.*B", false),
            new KeyValuePair<string, bool>("aab*\n.*", true),
            new KeyValuePair<string, bool>("abcdabc\n.*c", true),
            new KeyValuePair<string, bool>("abcdabc\n.*d", false),
            new KeyValuePair<string, bool>("abcdabc\n.*d.*", true),
            new KeyValuePair<string, bool>("abcdabc\n.*d*.*", true),
            new KeyValuePair<string, bool>("abcdabc\n.*d...", true),
            new KeyValuePair<string, bool>("abcdabc\n.*d..", false),
           new KeyValuePair<string, bool>("aaaaaaaaaaaaab\na*a*a*a*a*a*a*a*a*a*c", false),
           new KeyValuePair<string, bool>("aaaaaaaaaaaaab\na*a*a*a*a*a*a*a*a*a*aaaaaaaaaaaaabc", false),
           new KeyValuePair<string, bool>("aaaaaaaaaaaaab\na*a*a*a*a*a*a*a*a*a*aaaaaaaaaaaab", true),
           new KeyValuePair<string, bool>("aaaaaaaaaaaaab\na*a*a*a*a*a*a*a*a*a*a.*a.*b.*.*c", false),
           new KeyValuePair<string, bool>("aaaaaaaaaaaaab\na*a*a*a*a*a*a*a*a*a*b*c*d*e*h*.*b", true),
        };
        protected override void InitialTestCases()
        {
            Title = "RegularExpressionMatching";
            Requirement = "Implement regular expression matching with support for '.' and '*'.";
            SolutionExecutor = ExecuteTestCase;
            _testCases.ForEach(testCase => TestRecords.Add(new TestRecord<string, bool>(testCase.Key, testCase.Value, SolutionExecutor(testCase.Key))));
        }

        bool ExecuteTestCase(string testCase)
        {
            if (string.IsNullOrEmpty(testCase))
            {
                throw new ArgumentNullException("Execute TestCase failed.");
            }
            var testCaseArray = testCase.Split('\n');
            var sourceString = testCaseArray[0];
            var regularExpressionString = testCaseArray[1];
            return RegularExpressionMatching.isMatch(sourceString, regularExpressionString);
        }
    }
}

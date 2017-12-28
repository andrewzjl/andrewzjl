using LeetCodePractise.Model;
using LeetCodePractise.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    public class RomanToIntegerViewModel : PractiseBaseViewModel<string, int>
    {
        private List<KeyValuePair<string, int>> _testCases = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("DCXXI", 621),
            new KeyValuePair<string, int>("MCMLIV", 1954),
            new KeyValuePair<string, int>("MCMXC", 1990),
            new KeyValuePair<string, int>("MMXIV", 2014),
            new KeyValuePair<string, int>("MDCDIII", 1903),
            new KeyValuePair<string, int>("MCMIII", 1903),
            new KeyValuePair<string, int>("CCVII", 207),
            new KeyValuePair<string, int>("MLXVI", 1066),
        };
        protected override void InitialTestCases()
        {
            Title = "RomanToInteger";
            Requirement = "Given a roman numeral, convert it to an integer.";
            SolutionExecutor = RomanToInteger.RomanToInt;
            _testCases.ForEach(testCase => TestRecords.Add(new TestRecord<string, int>(testCase.Key, testCase.Value, SolutionExecutor(testCase.Key))));
        }
    }
}

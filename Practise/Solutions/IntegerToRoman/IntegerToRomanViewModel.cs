using LeetCodePractise.Model;
using LeetCodePractise.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    public class IntegerToRomanViewModel : PractiseBaseViewModel<int, string>
    {
        private List<KeyValuePair<int, string>> _testCases = new List<KeyValuePair<int, string>>
        {
            new KeyValuePair<int, string>(621, "DCXXI"),
            new KeyValuePair<int, string>(1954, "MCMLIV"),
            new KeyValuePair<int, string>(1990, "MCMXC"),
            new KeyValuePair<int, string>(2014, "MMXIV"),
            new KeyValuePair<int, string>(1903, "MCMIII"),
            new KeyValuePair<int, string>(207, "CCVII"),
            new KeyValuePair<int, string>(1066, "MLXVI"),
            new KeyValuePair<int, string>(1, "I"),
            new KeyValuePair<int, string>(4, "IV"),
            new KeyValuePair<int, string>(99, "XCIX"),
        };
        protected override void InitialTestCases()
        {
            Title = "IntegerToRoman";
            Requirement = "Given an integer, convert it to a roman numeral.";
            SolutionExecutor = IntegerToRoman.IntToRoman;
            _testCases.ForEach(testCase => TestRecords.Add(new TestRecord<int, string>(testCase.Key, testCase.Value, SolutionExecutor(testCase.Key))));
        }
    }
}

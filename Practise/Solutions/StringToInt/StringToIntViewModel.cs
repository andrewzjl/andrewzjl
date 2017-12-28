using LeetCodePractise.Model;
using LeetCodePractise.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    public class StringToIntViewModel : PractiseBaseViewModel<string, int>
    {
        protected override void InitialTestCases()
        {
            var testCases = new List<KeyValuePair<string, int>> {
                new KeyValuePair<string, int>("123",123),
                new KeyValuePair<string, int>("3r4",3),
                new KeyValuePair<string, int>("r45",0),
                new KeyValuePair<string, int>("+43",43),
                new KeyValuePair<string, int>("-23",-23),
                new KeyValuePair<string, int>("-5r7",-5),
                new KeyValuePair<string, int>("-w25r7",0),
                new KeyValuePair<string, int>("--5r7",0),
                new KeyValuePair<string, int>("+-w25r7",0),
                new KeyValuePair<string, int>("-+w25r7",0),
                new KeyValuePair<string, int>("2147483648",2147483647),
                new KeyValuePair<string, int>("2147483646",2147483646),
                new KeyValuePair<string, int>("2147483647",2147483647),
                new KeyValuePair<string, int>("214748364724",2147483647),
                new KeyValuePair<string, int>("-214748364724",-2147483648),
                new KeyValuePair<string, int>("-2147483648",-2147483648),
                new KeyValuePair<string, int>("-2147483649",-2147483648),
                new KeyValuePair<string, int>("-214748364798",-2147483648),
                new KeyValuePair<string, int>("    ",0),
                new KeyValuePair<string, int>("    -090348",-90348),
                new KeyValuePair<string, int>("    0090348",90348),
                new KeyValuePair<string, int>("    003-4",3),
                new KeyValuePair<string, int>("    10522545459",2147483647),
            };
            Title = "StringToInt";
            Requirement = "Implement atoi to convert a string to an integer.";
            SolutionExecutor = StringToInt.MyAtoi;
            testCases.ForEach(testCase =>
            {
                var result = new TestRecord<string, int>(testCase.Key, testCase.Value, StringToInt.MyAtoi(testCase.Key));
                TestRecords.Add(result);
            });
        }
    }
}

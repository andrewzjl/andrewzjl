using GalaSoft.MvvmLight.Ioc;
using LeetCodePractise.Model;
using LeetCodePractise.Model.Extensions;
using LeetCodePractise.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    public class FourSumViewModel : PractiseBaseViewModel<KeyValuePair<string, int>, string>
    {
        private List<Tuple<string, int, string>> _testCases = new List<Tuple<string, int, string>>
        {
            new Tuple<string, int, string>("", 0, "[]"),
            new Tuple<string, int, string>("1,2", 0, "[]"),
            new Tuple<string, int, string>("1,0,2,4", 0, "[]"),
            new Tuple<string, int, string>("1, 0, -1, 0, -2, 2", 0, "[[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]"),
            new Tuple<string, int, string>("0,0,0,0,1,-5", 0,"[[0,0,0,0]]"),
            new Tuple<string, int, string>("0,0,0,0,1,-5,9,2,99,-35,7,21", 11,"[[-5,0,7,9],[0,0,2,9]]"),
       };

        protected override void ExecuteTestCases()
        {
            Title = "4Sum";
            Requirement = "Given an array S of n integers, are there elements a, b, c, and d in S such that a + b + c + d = target? Find all unique quadruplets in the array which gives the sum of target.";
            SolutionExecutor = ExecuteTestCase;
            Id = 18;
            var records = new List<TestRecord<KeyValuePair<string, int>, string>>();
            _testCases.ForEach(testCase => records.Add(new TestRecord<KeyValuePair<string, int>, string>(new KeyValuePair<string, int>(testCase.Item1, testCase.Item2), testCase.Item3, SolutionExecutor(new KeyValuePair<string, int>(testCase.Item1, testCase.Item2)))));
            TestRecords = new ObservableCollection<TestRecord<KeyValuePair<string, int>, string>>(records);
        }

        string ExecuteTestCase(KeyValuePair<string, int> testCase)
        {
            int[] testArray = testCase.Key.StringToIntArray();
            var result = FourSumSolution.FourSum(testArray, testCase.Value);
            if (result == null)
            {
                return string.Empty;
            }
            return JsonConvert.SerializeObject(result);
        }
    }
}

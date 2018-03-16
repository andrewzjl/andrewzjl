using LeetCodePractise.Model;
using LeetCodePractise.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    public class MaxStockProfitViewModel : PractiseBaseViewModel<string, int>
    {
        private List<KeyValuePair<string, int>> _testCases = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("", 0),
            new KeyValuePair<string, int>("1", 0),
            new KeyValuePair<string, int>("1, 2, 3, 0, 2", 3),
            new KeyValuePair<string, int>("3, 2, 3, 0, 2", 2),
            new KeyValuePair<string, int>("1, 2, 3, 5, 2", 4),
            new KeyValuePair<string, int>("5, 5, 4, 5, 7, 5, 9", 5),
            new KeyValuePair<string, int>("5, 35, 100", 95),
            new KeyValuePair<string, int>("105, 35, 10", 0),
            new KeyValuePair<string, int>("2,2,2,2", 0),
            new KeyValuePair<string, int>("2,24,2,32", 30),
            new KeyValuePair<string, int>("2,24,9,2,32", 52),
        };
        protected override void ExecuteTestCases()
        {
            Title = "Best Time to Buy and Sell Stock with Cooldown";
            Requirement = "Say you have an array for which the ith element is the price of a given stock on day i.\n" +
                "Design an algorithm to find the maximum profit. You may complete as many transactions as you like(ie, buy one and sell one share of the stock multiple times) with the following restrictions:\n" +
                "  * You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).\n" +
                "  * After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)";
            SolutionExecutor = ExecuteTestCase;
            _testCases.ForEach(testCase => TestRecords.Add(new TestRecord<string, int>(testCase.Key, testCase.Value, SolutionExecutor(testCase.Key))));
        }

        int ExecuteTestCase(string testCase)
        {
            if (string.IsNullOrEmpty(testCase))
            {
                return 0;
            }
            var strList = testCase.Split(',');
            int[] intArray = new int[strList.Length];
            for (int i = 0; i < strList.Length; i++)
            {
                intArray[i] = int.Parse(strList[i]);
            }
            return MaxStockProfit.MaxProfit(intArray);
        }
    }
}

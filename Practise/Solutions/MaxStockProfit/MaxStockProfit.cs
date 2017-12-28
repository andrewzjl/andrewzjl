using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
    https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/description/
    Say you have an array for which the ith element is the price of a given stock on day i.

    Design an algorithm to find the maximum profit. You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:

    You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
    After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)

    */
    public class MaxStockProfit
    {
        public static int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            var pricesCount = prices.Length;
            // list of profit if buy at the i day
            int[] buyProfits = new int[pricesCount];
            // list of profit if sell at the i day
            int[] sellProfits = new int[pricesCount];
            // list of profit if not hold stock at i day
            int[] cooldownProfits = new int[pricesCount];

            // init the bound
            buyProfits[0] = -prices[0];
            sellProfits[0] = 0;
            cooldownProfits[0] = 0;

            for (int i = 1; i < pricesCount; i++)
            {
                var todayProfit = prices[i];
                buyProfits[i] = Math.Max(cooldownProfits[i - 1] - todayProfit, buyProfits[i-1]);
                sellProfits[i] = Math.Max(sellProfits[i - 1], buyProfits[i - 1] + todayProfit);
                cooldownProfits[i] = Math.Max(sellProfits[i - 1], cooldownProfits[i - 1]);

            }

            return Math.Max(sellProfits[pricesCount-1], cooldownProfits[pricesCount - 1]);
        }

    }
}

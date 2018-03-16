using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/find-the-closest-palindrome/description/
    Given an integer n, find the closest integer (not including itself), which is a palindrome.

    The 'closest' is defined as absolute difference minimized between two integers.

    Example 1:
        Input: "123"
        Output: "121"
    Note:
    1. The input n is a positive integer represented by string, whose length will not exceed 18.
    2. If there is a tie, return the smaller one as answer.
    */
    public class ClosestPalindromic
    {
        public static string NearestPalindromic(string n)
        {
            if (string.IsNullOrEmpty(n))
            {
                return "-1";
            }
            List<string> resultList = GetCandidatePalindromicList(n);
            var nearestPalindromic = GetNearestParlindromic(resultList, n);
            return nearestPalindromic;
        }

        private static string GetNearestParlindromic(List<string> resultList, string n)
        {
            var distance = long.MaxValue;
            var nearestParlindromic = string.Empty;
            var nValue = Convert.ToInt64(n);
            foreach (var item in resultList)
            {
                var iValue = Convert.ToInt64(item);
                var itemDistance = Math.Abs(iValue - nValue);
                if (itemDistance > 0 )
                {
                    if ((itemDistance < distance) || (itemDistance == distance && iValue < nValue))
                    {
                        distance = itemDistance;
                        nearestParlindromic = item;
                    }
                }
            }
            return nearestParlindromic;
        }

        private static List<string> GetCandidatePalindromicList(string n)
        {
            List<string> resultList = new List<string>();
            var mid = n.Length / 2;
            var headString = n.Substring(0, mid + n.Length % 2);
            var headValue = Convert.ToInt64(headString);
            resultList.Add(GetPalindromic(headValue - 1, mid));
            resultList.Add(GetPalindromic(headValue, mid));
            resultList.Add(GetPalindromic(headValue + 1, mid));
            // special handle the "10" ~ "15" case
            if (headValue - 1 == 0)
            {
                resultList.Add("9");
            }
            return resultList;
        }

        private static string GetPalindromic(long head, int mid)
        {
            var headString = head.ToString();
            var builder = new StringBuilder(headString);
            for (int i = mid - 1; i >= 0; i--)
            {
                var index = i;
                if (index >= headString.Length)
                {
                    index = headString.Length - 1;
                }
                builder.Append(headString[index]);
            }
            return builder.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/integer-to-roman/
    Given an integer, convert it to a roman numeral.
    Input is guaranteed to be within the range from 1 to 3999.
    */
    public class IntegerToRoman
    {
        static public string IntToRoman(int num)
        {
            var calculateList = new List<int> { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            var romanList = new List<string> { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            var result = string.Empty;
            for (int i = 0; i < calculateList.Count; i++)
            {
                var calculator = calculateList[i];
                int remain = num / calculator;
                while (remain > 0)
                {
                    result += romanList[i];
                    num = num - calculator;
                    remain = num / calculator;
                }
            }
            return result;
        }
    }
}

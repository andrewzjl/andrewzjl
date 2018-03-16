using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/largest-palindrome-product/description/
    Find the largest palindrome made from the product of two n-digit numbers.

    Since the result could be very large, you should return the largest palindrome mod 1337.

    Example:

    Input: 2

    Output: 987

    Explanation: 99 x 91 = 9009, 9009 % 1337 = 987

    Note:

    The range of n is [1,8].
    */
    public class LargestPalindromeProductSolution
    {
        public static int LargestPalindrome(int n)
        {
            var largestPalindrome = GetMaxPalindrome(n);
            long result = largestPalindrome % 1337;
            return (int)result;
        }

        private static long GetMaxPalindrome(int n)
        {
            long maxInteger = GetMaxInt(n);
            long minInteger = 1;
            long currentPalindrome = maxInteger;
            for (var i = maxInteger; (i >= minInteger); i-=2)
            {
                for (var j = i; (j >= minInteger); j-=2)
                {
                    long result  = i * j;
                    if (result <= currentPalindrome)
                    {
                        break;
                    }
                    if (IsPalindrome(result))
                    {
                        if ((result > currentPalindrome))
                        {
                            currentPalindrome = result;
                        }
                        minInteger = j;
                    }
                }
            }
            return currentPalindrome;
        }

        private static long GetMaxInt(int length)
        {
            long result = 9;
            while (length > 1)
            {
                result = result * 10 + 9;
                length--;
            }
            return result;
        }

        private static bool IsPalindrome(long value)
        {
            var str = value.ToString();
            int j = str.Length - 1;
            for (int i = 0; i < j; i++, j--)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

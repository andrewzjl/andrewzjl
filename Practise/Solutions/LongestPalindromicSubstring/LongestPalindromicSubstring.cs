using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/longest-palindromic-substring/description/
     Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.
     */
    public class LongestPalindromicSubstring
    {
        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            var maxPalindromeIndex = 0;
            var maxPalindromeLength = 1;
            for (int i = 1; i < s.Length; i++)
            {
                // check the s[i] as middle
                var currentMaxPalinrome = 1;
                for (int start = i - 1, end = i + 1; (start >= 0) && (end < s.Length); start--, end++)
                {
                    if (s[start] != s[end])
                    {
                        currentMaxPalinrome = end - start - 1;
                        break;
                    }
                    else
                    {
                        currentMaxPalinrome += 2;
                    }
                }
                if (currentMaxPalinrome > maxPalindromeLength)
                {
                    maxPalindromeLength = currentMaxPalinrome;
                    maxPalindromeIndex = i - currentMaxPalinrome / 2;
                }

                // check the s[i] as right of middle
                if (s[i] == s[i - 1])
                {
                    currentMaxPalinrome = 2;
                    for (int start = i - 2, end = i + 1; (start >= 0) && (end < s.Length); start--, end++)
                    {
                        if (s[start] != s[end])
                        {
                            currentMaxPalinrome = end - start - 1;
                            break;
                        }
                        else
                        {
                            currentMaxPalinrome += 2;
                        }
                    }
                    if (currentMaxPalinrome > maxPalindromeLength)
                    {
                        maxPalindromeLength = currentMaxPalinrome;
                        maxPalindromeIndex = i - currentMaxPalinrome / 2;
                    }
                }
            }
            return s.Substring(maxPalindromeIndex, maxPalindromeLength);
        }

    }
}

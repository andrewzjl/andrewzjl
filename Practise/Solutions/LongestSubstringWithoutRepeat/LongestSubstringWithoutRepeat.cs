using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
     Given a string, find the length of the longest substring without repeating characters.

    Examples:

    Given "abcabcbb", the answer is "abc", which the length is 3.

    Given "bbbbb", the answer is "b", with the length of 1.

    Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
*/
    public class LongestSubstringWithoutRepeat
    {
        public static int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int maxLengthOfSubstring = 0;
            StringBuilder currentSubstring = new StringBuilder();
            foreach (char c in s)
            {
                var currentString = currentSubstring.ToString();
                var index = currentString.IndexOf(c);
                if (index >= 0)
                {
                    currentSubstring.Remove(0, index + 1);
                }

                currentSubstring.Append(c);
                var length = currentSubstring.Length;
                if (length > maxLengthOfSubstring)
                {
                    maxLengthOfSubstring = length;
                }
            }
            return maxLengthOfSubstring;
        }
    }
}

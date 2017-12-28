using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/longest-common-prefix/description/
     Write a function to find the longest common prefix string amongst an array of strings.
     */
    public class LongestCommonPrefixSolution
    {
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return string.Empty;
            }

            if (strs.Length == 1)
            {
                return strs[0];
            }

            var commonPrefix = new StringBuilder();
            for (int i = 0; i < strs[0].Length; i++)
            {
                var current = strs[0][i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i >= strs[j].Length)
                    {
                        return commonPrefix.ToString();
                    }
                    else if (strs[j][i] != current)
                    {
                        return commonPrefix.ToString();
                    }
                }
                commonPrefix.Append(current);
            }
            return commonPrefix.ToString();
        }
    }
}

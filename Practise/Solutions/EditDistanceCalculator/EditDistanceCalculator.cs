using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/edit-distance/description/
     * Given two words word1 and word2, find the minimum number of steps required to convert word1 to word2. (each operation is counted as 1 step.)

        You have the following 3 operations permitted on a word:

        a) Insert a character
        b) Delete a character
        c) Replace a character
     */
    public class EditDistanceCalculator
    {
        public static int MinDistance(string word1, string word2)
        {
            if (word1 == word2)
            {
                return 0;
            }
            if (string.IsNullOrEmpty(word1))
            {
                return word2?.Length ?? 0;
            }
            if (string.IsNullOrEmpty(word2))
            {
                return word1.Length;
            }

            var m = word1.Length;
            var n = word2.Length;
            var distance = new int[m + 1,n + 1];
            for (int i = 0; i < m + 1; i++)
            {
                distance[i, 0] = i;
            }
            for (int j = 0; j < n + 1; j++)
            {
                distance[0, j] = j;
            }
            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        distance[i, j] = distance[i - 1, j - 1];
                    }
                    else
                    {
                        distance[i, j] = Math.Min(Math.Min(distance[i - 1, j], distance[i, j - 1]), distance[i - 1, j - 1]) + 1;
                    }
                }
            }
            return distance[m, n];
        }
    }
}

using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/find-k-closest-elements/description/
     Given a sorted array, two integers k and x, find the k closest elements to x in the array. The result should also be sorted in ascending order. If there is a tie, the smaller elements are always preferred.

    Example 1:
        Input: [1,2,3,4,5], k=4, x=3
        Output: [1,2,3,4]
    Example 2:
        Input: [1,2,3,4,5], k=4, x=-1
        Output: [1,2,3,4]
    Note:
        1. The value k is positive and will always be smaller than the length of the sorted array.
        2. Length of the given array is positive and will not exceed 10^4
        3. Absolute value of elements in the array and x will not exceed 10^4
    */
    public class FindKClosestElements
    {
        public static IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            var index = BinaryRangeSearch(arr, k, x);
            int i = Math.Max(index - k / 2, 0);
            int j = i + k;
            if (j >= arr.Length)
            {
                j = arr.Length - 1;
                i = j - k;
            }
            while ((i >= 0) && (j < arr.Length))
            {
                var leftDistance = Distance(arr[i], x);
                var rightDistance = Distance(arr[j], x);
                if (leftDistance == rightDistance)
                {
                    while ((i > 0) && (arr[i] == arr[i - 1]) && ((arr[j] == arr[j - 1])))
                    {
                        i--;
                        j--;
                    }
                    break;
                }
                else if (leftDistance > rightDistance)
                {
                    i++;
                    j++;
                    var nextLeftDistance = Distance(arr[i], x);
                    if (nextLeftDistance <= rightDistance)
                    {
                        break;
                    }
                }
                else
                {
                    var nextRightDistance = Distance(arr[j - 1], x);
                    if (nextRightDistance <= leftDistance)
                    {
                        break;
                    }
                    i--;
                    j--;
                }
            }
            return arr.Skip(Math.Max(i, 0)).Take(k).ToList();
        }

        private static int Distance(int v, int x)
        {
            return Math.Abs(v - x);
        }

        private static int BinaryRangeSearch(int[] arr, int k, int x)
        {
            int start = 0;
            int end = arr.Length;
            while (start + k < end)
            {
                var middle = start + (end - start) / 2;
                if (arr[middle] == x)
                {
                    return middle;
                }
                else if (arr[middle] > x)
                {
                    end = middle;
                }
                else
                {
                    start = middle;
                }
            }
            return start;
        }
    }
}

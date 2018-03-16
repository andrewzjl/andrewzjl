using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/3sum/description/
    Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

    Note: The solution set must not contain duplicate triplets.

    For example, given array S = [-1, 0, 1, 2, -1, -4],

    A solution set is:
    [
      [-1, 0, 1],
      [-1, -1, 2]
    ]
    */
    public class ThreeSumSolution
    {
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums == null || nums.Length <= 2)
            {
                return new List<IList<int>>();
            }

            QuickSort(ref nums, 0, nums.Length - 1);

            var resultList = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && (nums[i] == nums[i-1]))
                {
                    continue;
                }
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    while (((nums[i] + nums[j] + nums[k]) < 0) && (j < k)) j++;
                    while (((nums[i] + nums[j] + nums[k]) > 0) && (j < k)) k--;
                    if ((j < k) && (nums[i] + nums[j] + nums[k]) == 0)
                    {
                        var validTuple = new List<int> { nums[i], nums[j], nums[k] };
                        resultList.Add(validTuple);
                        do { j++; } while (j < k && nums[j] == nums[j - 1]);
                        do { k--; } while (j < k && nums[k] == nums[k + 1]);
                    }
                }
            }

            return resultList;
        }

        private static bool Exist(List<IList<int>> resultList, List<int> validTuple)
        {
            foreach (var item in resultList)
            {
                bool exist = true;
                for (int i = 0; i < validTuple.Count; i++)
                {
                    if (item.ElementAt(i) != validTuple[i])
                    {
                        exist = false;
                    }
                }
                if (exist)
                {
                    return true;
                }
            }

            return false;
        }

        private static void QuickSort(ref int[] nums, int start, int end)
        {
            var index = PartialSort(ref nums, start, end);
            if (index - 1 > start)
            {
                QuickSort(ref nums, start, index - 1);
            }
            if (index + 1 < end)
            {
                QuickSort(ref nums, index + 1, end);
            }
        }

        private static int PartialSort(ref int[] nums, int start, int end)
        {
            var pivot = nums[start];
            while (start < end)
            {
                while (nums[end] >= pivot && (start < end)) end--;
                if (start != end)
                {
                    nums[start] = nums[end];
                    start++;
                }
                while (nums[start] <= pivot  && (start < end)) start++;
                if (start != end)
                {
                    nums[end] = nums[start];
                    end--;
                }
            }
            nums[start] = pivot;
            return start;
        }

        private static void Swap(ref int v1, ref int v2)
        {
            var tmp = v2;
            v2 = v1;
            v1 = tmp;
        }
    }
}

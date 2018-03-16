using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/4sum/description/
    Given an array S of n integers, are there elements a, b, c, and d in S such that a + b + c + d = target? Find all unique quadruplets in the array which gives the sum of target.

    Note: The solution set must not contain duplicate quadruplets.

    For example, given array S = [1, 0, -1, 0, -2, 2], and target = 0.

    A solution set is:
    [
      [-1,  0, 0, 1],
      [-2, -1, 1, 2],
      [-2,  0, 0, 2]
    ]
    */
    public class FourSumSolution
    {
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            if (nums == null || nums.Length <= 3)
            {
                return new List<IList<int>>();
            }

            QuickSort(ref nums, 0, nums.Length - 1);

            var resultList = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && (nums[i] == nums[i-1]))
                {
                    continue;
                }
                var sum = target - nums[i];
                for (int j = i+1; j < nums.Length - 2; j++)
                {
                    if (j > i + 1 && (nums[j] == nums[j - 1]))
                    {
                        continue;
                    }
                    int k = j + 1;
                    int l = nums.Length - 1;
                    while (k < l)
                    {
                        while (((nums[l] + nums[j] + nums[k]) < sum) && (k < l)) k++;
                        while (((nums[l] + nums[j] + nums[k]) > sum) && (k < l)) l--;
                        if ((k < l) && (nums[l] + nums[j] + nums[k]) == sum)
                        {
                            var validTuple = new List<int> { nums[i], nums[j], nums[k], nums[l] };
                            resultList.Add(validTuple);
                            do { k++; } while (k < l && nums[k] == nums[k - 1]);
                            do { l--; } while (k < l && nums[l] == nums[l + 1]);
                        }
                    }
                }
                
            }

            return resultList;
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

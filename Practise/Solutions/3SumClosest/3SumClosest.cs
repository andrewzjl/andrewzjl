using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/3sum-closest/description/
    Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. Return the sum of the three integers. You may assume that each input would have exactly one solution.

    For example, given array S = {-1 2 1 -4}, and target = 1.

    The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
    */
    public class ThreeSumClosestSolution
    {
        public static int ThreeSumClosest(int[] nums, int target)
        {
            QuickSort(ref nums, 0, nums.Length - 1);

            int closestTarget = nums[0] + nums[1] + nums[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    var sum = nums[i] + nums[j] + nums[k];
                    if (IsCloser(sum, target, closestTarget))
                    {
                        closestTarget = sum;
                        if (sum == target)
                        {
                            return sum;
                        }
                    }
                    if (sum > target)
                    {
                        k--;
                    }
                    else if (sum < target)
                    {
                        j++;
                    }
                }
            }

            return closestTarget;
        }

        private static bool IsCloser(int sum, int target, int closestTarget)
        {
            var newDist = Math.Abs(sum - target);
            var currDist = Math.Abs(target - closestTarget);
            return (newDist <= currDist);
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
                while (nums[start] <= pivot && (start < end)) start++;
                if (start != end)
                {
                    nums[end] = nums[start];
                    end--;
                }
            }
            nums[start] = pivot;
            return start;
        }

    }
}

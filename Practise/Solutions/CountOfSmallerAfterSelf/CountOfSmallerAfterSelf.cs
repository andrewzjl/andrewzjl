using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     *https://leetcode.com/problems/count-of-smaller-numbers-after-self/description/
     You are given an integer array nums and you have to return a new counts array. The counts array has the property where counts[i] is the number of smaller elements to the right of nums[i].
     */
    public class CountOfSmallerAfterSelf
    {
        public static IList<int> CountSmaller(int[] nums)
        {
            if ((nums == null) || nums.Length == 0)
            {
                return new List<int>();
            }
            var length = nums.Length;
            var result = new List<int>(length);
            for (int i = 0; i < length; i++)
            {
                result.Add(length - 1 - i);
            }
            var orderedList = new List<int>(length);
            for (int i = length - 1; i >= 0; i--)
            {
                var index = InsertToOrderedList(orderedList, nums[i]);
                result[i] -= index;
            }
            return result;
        }

        /// <summary>
        /// Updates the list by insert the new element in order.
        /// </summary>
        /// <param name="orderedList">The ordered list.</param>
        /// <param name="newElement">The newElement.</param>
        /// <returns>the inserted index</returns>
        private static int InsertToOrderedList(List<int> orderedList, int newElement)
        {
            var index = orderedList.FindIndex(i => i < newElement);
            if (index < 0)
            {
                orderedList.Add(newElement);
                return orderedList.Count - 1;
            }
            else
            {
                orderedList.Insert(index, newElement);
                return index;
            }
        }
    }
}

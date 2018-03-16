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
            int[] result = new int[length];
            Node root = null;
            for (int i = length - 1; i >= 0; i--)
            {
                root = BuildBinarySearchTree(root, nums, result, i, 0);
            }
            return result;
        }

        private static Node BuildBinarySearchTree(Node root, int[] nums, int[] result, int index, int preSum)
        {
            if (root == null)
            {
                root = new Node(nums[index], 0);
                result[index] = preSum;
            }
            else
            {
                if (root.Val == nums[index])
                {
                    root.DupCount++;
                    result[index] = preSum + root.Num;
                }
                else if (root.Val < nums[index])
                {
                    root.Right = BuildBinarySearchTree(root.Right, nums, result, index, preSum + root.DupCount + root.Num);
                }
                else
                {
                    root.Num++;
                    root.Left = BuildBinarySearchTree(root.Left, nums, result, index, preSum);
                }
            }
            return root;
        }

        private class Node
        {
            public Node Left = null;
            public Node Right = null;
            /// <summary>
            /// Current node's value
            /// </summary>
            public int Val;
            /// <summary>
            /// The count of current node's left tree
            /// </summary>
            public int Num = 0;
            /// <summary>
            /// The duplicate count
            /// </summary>
            public int DupCount = 1;
            /// <summary>
            /// Initializes a new instance of the <see cref="Node"/> class.
            /// </summary>
            /// <param name="val">The value.</param>
            /// <param name="num">The number of left tree.</param>
            public Node(int val, int num)
            {
                Val = val;
                Num = num;
            } 
        }

    }
}

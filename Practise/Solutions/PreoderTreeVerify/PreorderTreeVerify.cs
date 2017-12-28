using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * https://leetcode.com/problems/verify-preorder-serialization-of-a-binary-tree/
 * One way to serialize a binary tree is to use pre-order traversal. When we encounter a non-null node, we record the node's value. If it is a null node, we record using a sentinel value such as #.

     _9_
    /   \
   3     2
  / \   / \
 4   1  #  6
/ \ / \   / \
# # # #   # #
For example, the above binary tree can be serialized to the string "9,3,4,#,#,1,#,#,2,#,6,#,#", where # represents a null node.

Given a string of comma separated values, verify whether it is a correct preorder traversal serialization of a binary tree. Find an algorithm without reconstructing the tree.

Each comma separated value in the string must be either an integer or a character '#' representing null pointer.

You may assume that the input format is always valid, for example it could never contain two consecutive commas such as "1,,3".

Example 1:
"9,3,4,#,#,1,#,#,2,#,6,#,#"
Return true

Example 2:
"1,#"
Return false

Example 3:
"9,#,#,1"
Return false

    */
namespace LeetCodePractise.Solutions
{
    public class PreorderTreeVerify
    {
        public static bool IsValidSerialization(string preorder)
        {
            if ("#".Equals(preorder))
            {
                return true;
            }
            var stack = new List<KeyValuePair<string, bool>>();

            var orderArray = preorder.Split(',');
            for (int i = 0; i < orderArray.Count(); i++)
            {
                var item = orderArray[i];
                if (item.Equals("#"))
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        var lastNode = stack.Last();
                        while (lastNode.Value && (stack.Count > 1))
                        {
                            stack.RemoveAt(stack.Count - 1);
                            lastNode = stack.Last();
                        }
                        stack.RemoveAt(stack.Count - 1);
                        if (!lastNode.Value)
                        {
                            stack.Add(new KeyValuePair<string, bool>(lastNode.Key, true));
                        }
                    }
                }
                else
                {
                    if ((i != 0) && (stack.Count == 0))
                    {
                        return false;
                    }
                    stack.Add(new KeyValuePair<string, bool>(item, false));
                }
            }
            return stack.Count == 0;
        }
    }
}

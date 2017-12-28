using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/merge-two-sorted-lists/
     Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.
     */
    public class MergeTwoSortedLists
    {
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var preNewHead = new ListNode(-1);
            var preNext = preNewHead;
            var p1 = l1;
            var p2 = l2;
            while ((p1 != null) && (p2 != null))
            {
                if (p1.val > p2.val)
                {
                    preNext.next = p2;
                    p2 = p2.next;
                    preNext = preNext.next;
                }
                else if (p1.val == p2.val)
                {
                    preNext.next = p1;
                    p1 = p1.next;
                    preNext = preNext.next;
                    preNext.next = p2;
                    p2 = p2.next;
                    preNext = preNext.next;
                }
                else
                {
                    preNext.next = p1;
                    p1 = p1.next;
                    preNext = preNext.next;
                }
            }

            if (p1 == null)
            {
                preNext.next = p2;
            }
            else if (p2 == null)
            {
                preNext.next = p1;
            }

            return preNewHead.next;
        }
    }
}

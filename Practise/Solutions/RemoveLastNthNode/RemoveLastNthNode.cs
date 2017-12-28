using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/remove-nth-node-from-end-of-list/
     Given a linked list, remove the nth node from the end of list and return its head.

    For example,

       Given linked list: 1->2->3->4->5, and n = 2.

       After removing the second node from the end, the linked list becomes 1->2->3->5.
    Note:
    Given n will always be valid.
    Try to do this in one pass.
     */
    public class RemoveLastNthNode
    {
        /// <summary>
        /// Removes the NTH from end which is not good. It's two pass.
        /// </summary>
        /// <param name="head">The head.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        static public ListNode RemoveNthFromEndNotGood(ListNode head, int n)
        {
            if (head == null || (n <= 0))
            {
                return head;
            }
            long linkLength = 0;
            for (var p = head; p != null; p = p.next)
            {
                linkLength++;
            }
            if (n > linkLength)
            {
                return head;
            }
            long deleteNodeIndex = linkLength - n; // 0 base
            if (deleteNodeIndex == 0)
            {
                return head.next;
            }
            else
            {
                var previousNode = head;
                while (deleteNodeIndex > 1)
                {
                    previousNode = previousNode.next;
                    deleteNodeIndex--;
                }
                previousNode.next = previousNode.next.next;
                return head;
            }
        }

        static public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null || n <= 0)
            {
                return head;
            }
            var preHead = new ListNode(-1) { next = head };
            var preDelete = preHead;
            var pLaterN = preHead;
            while (n-- > 0)
            {
                pLaterN = pLaterN.next;
                if (pLaterN == null)
                {
                    return head;
                }
            }
            while (pLaterN.next != null)
            {
                pLaterN = pLaterN.next;
                preDelete = preDelete.next;
            }
            preDelete.next = preDelete.next.next;
            return preHead.next;
        }
    }
}

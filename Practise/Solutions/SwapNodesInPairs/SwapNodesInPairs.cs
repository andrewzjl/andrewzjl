using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/swap-nodes-in-pairs/description/
     Given a linked list, swap every two adjacent nodes and return its head.

    For example,
    Given 1->2->3->4, you should return the list as 2->1->4->3.

    Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.

    */
    public class SwapNodesInPairs
    {
        public static ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var newHead = new ListNode(-1) { next = head };
            var previous = newHead;
            var curr = head;
            var next = head.next;
            var nextPair = next?.next;
            while (next != null)
            {
                previous.next = next;
                next.next = curr;
                curr.next = nextPair;
                previous = curr;
                curr = curr.next;
                next = curr?.next;
                nextPair = next?.next;
            }

            return newHead.next;
        }
    }
}

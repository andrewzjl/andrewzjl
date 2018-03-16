using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/merge-k-sorted-lists/description/
     Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.
     */
    public class MergeKSortedLists
    {
        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Count() == 0)
            {
                return null;
            }
            foreach (var item in lists)
            {
                PushWithoutSort(item);
            }
            Sort();
            var head = new ListNode(-1);
            var pre = head;
            var current = Pop();
            head.next = current;
            while (current != null)
            {
                var minInQueue = Pop();
                if (minInQueue != null)
                {
                    while (current != null && (current.val <= minInQueue.val))
                    {
                        pre = current;
                        current = current.next;
                    }
                    Push(current);
                    pre.next = minInQueue;
                }
                current = minInQueue;
            }
            return head.next;
        }

        private static void Push(ListNode newNode)
        {
            if (newNode != null)
            {
                _sortedQueue.PushNode(newNode);
            }
        }

        private static void PushWithoutSort(ListNode newNode)
        {
            if (newNode != null)
            {
                _sortedQueue.PushNodeWithoutSort(newNode);
            }
        }

        private static void Sort()
        {
            _sortedQueue.Sort();
        }

        private static ListNode Pop()
        {
            return _sortedQueue.PopNode();
        }

        private class SortedQueue
        {
            private ListNode _e;
            private SortedQueue _nextNode;
            public SortedQueue(ListNode e)
            {
                _e = e;
            }

            public void PushNode(ListNode newNode)
            {
                if (_e == null)
                {
                    _e = newNode;
                }
                else if (newNode != null)
                {
                    if (_e.val >= newNode.val)
                    {
                        InsertInHead(newNode);
                    }
                    else
                    {
                        var newQueueNode = new SortedQueue(newNode);
                        if (_nextNode == null || _nextNode.IsEmpty())
                        {
                            _nextNode = newQueueNode;
                        }
                        else
                        {
                            _nextNode.PushNode(newNode);
                        }
                    }
                }
            }

            private void InsertInHead(ListNode newNode)
            {
                var newQueueNode = new SortedQueue(_e);
                newQueueNode._nextNode = _nextNode;
                _e = newNode;
                _nextNode = newQueueNode;
            }

            public ListNode PopNode()
            {
                ListNode minimumNode = _e;
                _e = _nextNode?._e;
                _nextNode = _nextNode?._nextNode;
                return minimumNode;
            }
            public bool IsEmpty()
            {
                return _e == null;
            }

            internal void Sort()
            {
                if (IsEmpty())
                {
                    return;
                }
                bool isSwitched = true;
                while (isSwitched)
                {
                    isSwitched = false;
                    var current = this;
                    var next = this._nextNode;
                    while (next != null && !next.IsEmpty())
                    {
                        if (current._e.val > next._e.val)
                        {
                            var tmp = current._e;
                            current._e = next._e;
                            next._e = tmp;
                            isSwitched = true;
                        }
                        current = next;
                        next = next._nextNode;
                    }
                }
            }

            internal void PushNodeWithoutSort(ListNode newNode)
            {
                InsertInHead(newNode);
            }
        }
        private static SortedQueue _sortedQueue = new SortedQueue(null);
    }
}

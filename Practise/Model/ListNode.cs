using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Model
{
    /// <summary>
    /// The link node
    /// </summary>
    public class ListNode
    {

        public int val;

        public ListNode next;

        public ListNode(int x) { val = x; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var result = val.ToString();
            var p = next;
            while (p != null)
            {
                result += "," + p.val.ToString();
                p = p.next;
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Model.Extensions
{
    public static class StrinsExtensions
    {
        /// <summary>
        /// Converter string to link.
        /// </summary>
        /// <param name="linkString">The link string, format like "1,2,3,...".</param>
        /// <returns></returns>
        public static ListNode StringToLink(this string linkString)
        {
            if (string.IsNullOrWhiteSpace(linkString))
            {
                return null;
            }
            try
            {
                var linkArray = linkString.Split(',');
                var result = new ListNode(int.Parse(linkArray[0]));
                var previous = result;
                for (int i = 1; i < linkArray.Count(); i++)
                {
                    var p = new ListNode(int.Parse(linkArray[i]));
                    previous.next = p;
                    previous = p;
                }
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Converter string to int array.
        /// </summary>
        /// <param name="arrayString">The array string.</param>
        /// <param name="seperator">The seperator.</param>
        /// <returns></returns>
        public static int[] StringToIntArray(this string arrayString, char seperator = ',')
        {
            var stringArray = arrayString.Split(',');
            return stringArray.Where(s=>s.IsValidToInteger()).Select(s=>int.Parse(s)).ToArray();
        }

        /// <summary>
        /// Determines whether the source string is valid to converter as integer.
        /// </summary>
        /// <param name="sourceStr">The source string.</param>
        /// <returns>
        ///   <c>true</c> if the source string is valid to converter as integer; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidToInteger(this string sourceStr)
        {
            int validInt;
            return int.TryParse(sourceStr, out validInt);
        }
    }
}

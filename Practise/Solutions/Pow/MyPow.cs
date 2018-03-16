using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/powx-n/description/
    Implement pow(x, n).


    Example 1:

    Input: 2.00000, 10
    Output: 1024.00000
    Example 2:

    Input: 2.10000, 3
    Output: 9.26100
    */
    public class PowSolution
    {
        public static double MyPow(double x, int n)
        {
            if (n == 0)
            {
                return 1.00000;
            }
            if (NearlyEqual(x, 0.00000))
            {
                return n > 0 ? 0 : double.PositiveInfinity;
            }
            if (NearlyEqual(x, 1.00000))
            {
                return 1.00000;
            }
            var absN = Math.Abs((long)n);
            var result = MyPow(x, (int)(absN / 2));
            result *= result;
            if ((absN & 0x1) != 0)
            {
                result *= x;
            }
            if (n < 0)
            {
                result = 1 / result;
            }
            return result;
        }

        private static bool NearlyEqual(double f1, double f2)
        {
            // Equal if they are within 0.00001 of each other
            return Math.Abs(f1 - f2) <= 0.0000099;
        }
    }
}

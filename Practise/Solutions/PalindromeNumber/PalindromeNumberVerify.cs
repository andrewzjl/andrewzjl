using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     *https://leetcode.com/problems/palindrome-number/ 
Determine whether an integer is a palindrome. Do this without extra space.

Some hints:
Could negative integers be palindromes? (ie, -1)

If you are thinking of converting the integer to string, note the restriction of using extra space.

You could also try reversing an integer. However, if you have solved the problem "Reverse Integer", you know that the reversed integer might overflow. How would you handle such case?

There is a more generic way of solving this problem.
      */
    public class PalindromeNumberVerify
    {
        public static bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }
            else if (x < 10)
            {
                return true;
            }

            int m = 10;
            while (x / m >= 10)
                m *= 10;

            while ((x > 0) && (m > 0))
            {
                if ((x / m) != (x % 10))
                {
                    return false;
                }
                x = (x % m) / 10;
                m = m / 100;
            }
            return (x <= 10);
        }
    }
}

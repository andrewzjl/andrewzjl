using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
    https://leetcode.com/problems/roman-to-integer/
    Given a roman numeral, convert it to an integer.

    Input is guaranteed to be within the range from 1 to 3999.
    */
    public class RomanToInteger
    {
        public static int RomanToInt(string s)
        {
            int result = 0;
            if (!string.IsNullOrWhiteSpace(s))
            {
                var stack = new List<int>();
                for (int i = 0; i < s.Length; i++)
                {
                    switch (s[i])
                    {
                        case 'I':
                            PushNewValue(stack, 1);
                            break;
                        case 'V':
                            PushNewValue(stack, 5);
                            break;
                        case 'X':
                            PushNewValue(stack, 10);
                            break;
                        case 'L':
                            PushNewValue(stack, 50);
                            break;
                        case 'C':
                            PushNewValue(stack, 100);
                            break;
                        case 'D':
                            PushNewValue(stack, 500);
                            break;
                        case 'M':
                            PushNewValue(stack, 1000);
                            break;
                        default:
                            break;
                    }
                }
                stack.ForEach(p => result += p);
            }
            return result;
        }

        static private List<int> PushNewValue(List<int> stack, int newValue)
        {
            int lessValue = 0;
            while ((stack.Count > 0) && (newValue > stack.Last()))
            {
                lessValue += stack.Last();
                stack.RemoveAt(stack.Count - 1);
            }
            if (lessValue > 0)
            {
                newValue = newValue - lessValue;
            }
            stack.Add(newValue);
            return stack;
        }
    }
}

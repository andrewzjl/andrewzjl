using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/string-to-integer-atoi/
Implement atoi to convert a string to an integer.

Hint: Carefully consider all possible input cases. If you want a challenge, please do not see below and ask yourself what are the possible input cases.

Notes: It is intended for this problem to be specified vaguely (ie, no given input specs). You are responsible to gather all the input requirements up front.

Update (2015-02-10):
The signature of the C++ function had been updated. If you still see your function signature accepts a const char * argument, please click the reload button  to reset your code definition.

spoilers alert... click to show requirements for atoi.

Requirements for atoi:
The function first discards as many whitespace characters as necessary until the first non-whitespace character is found. Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.

The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.

If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.

If no valid conversion could be performed, a zero value is returned. If the correct value is out of the range of representable values, INT_MAX (2147483647) or INT_MIN (-2147483648) is returned.

*/
    public class StringToInt
    {
        public static int MyAtoi(string str)
        {
            var isNegative = false;
            var result = 0;
            var isOverFlow = false;
            if (!string.IsNullOrWhiteSpace(str))
            {
                var isStarted = false;
                var isValid = true;
                for (int i = 0; (i < str.Length) && isValid && (!isOverFlow); i++)
                {
                    var c = str[i];
                    switch (c)
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            isStarted = true;
                            result = AppendNewValue(result, isNegative, c, out isOverFlow);
                            break;
                        case '+':
                        case '-':
                            if (isStarted)
                            {
                                isValid = false;
                            }
                            else
                            {
                                isNegative = (c == '-');
                            }
                            isStarted = true;
                            break;
                        case ' ':
                            if (isStarted)
                            {
                                isValid = false;
                            }
                            break;
                        default:
                            isValid = false;
                            break;
                    }
                }
            }
            if (isOverFlow)
            {
                return result;
            }
            return isNegative ? -result : result;
        }

        const int MAX_INT = 2147483647;
        const int MIN_INT = -2147483648;

        private static int AppendNewValue(int result, bool isNegative, char c, out bool isOverflow)
        {
            int newValue = result * 10 + (c - '0');
            isOverflow = false;

            if ((newValue > MAX_INT) || (newValue < 0) || (result > MAX_INT / 10))
            {
                isOverflow = true;
                return isNegative ? MIN_INT : MAX_INT;
            }

            return newValue;
        }
    }
}

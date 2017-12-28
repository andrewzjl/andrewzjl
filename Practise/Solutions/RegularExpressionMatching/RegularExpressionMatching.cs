using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/regular-expression-matching/description/
     * Implement regular expression matching with support for '.' and '*'.
     */
    public class RegularExpressionMatching
    {
        public static bool isMatch(string s, string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                return string.IsNullOrEmpty(s);
            }
            if (s == null)
            {
                s = "";
            }
            var patternStack = PreTreatPattern(p);
            return isMatch(s, 0, patternStack, 0);
        }

        private static List<string> PreTreatPattern(string p)
        {
            var newPatternStack = new List<string>();
            var lastPattern = GetNextPattern(p, 0);
            var isLastGenericPattern = lastPattern.Length == 2;
            newPatternStack.Add(lastPattern);
            for (int index = lastPattern.Length; index < p.Length; )
            {
                var currentPattern = GetNextPattern(p, index);
                var isCurrentGenericPattern = currentPattern.Length == 2;
                if (!isCurrentGenericPattern)
                {
                    newPatternStack.Add(currentPattern);
                    lastPattern = string.Empty;
                    isLastGenericPattern = false;
                }
                else if (!isLastGenericPattern)
                {
                    newPatternStack.Add(currentPattern);
                    lastPattern = currentPattern;
                    isLastGenericPattern = isCurrentGenericPattern;
                }
                else if (currentPattern != lastPattern)
                {
                    var isCurrentPatternMatchAll = currentPattern.Equals(".*");
                    var isLastPatternMatchAll = lastPattern.Equals(".*");
                    if (isLastPatternMatchAll)
                    {
                        // while last pattern is .*, just ignore the new generic pattern
                    }
                    else if (isCurrentPatternMatchAll)
                    {
                        // while current pattern is .*, reverse the generic pattern in the stack
                        int shouldDeleteLastN = 0;
                        for (int i = newPatternStack.Count - 1; i >= 0; i--)
                        {
                            if (newPatternStack[i].Length == 2)
                            {
                                shouldDeleteLastN++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        newPatternStack.RemoveRange(newPatternStack.Count - shouldDeleteLastN, shouldDeleteLastN);
                        newPatternStack.Add(currentPattern);
                        lastPattern = currentPattern;
                        isLastGenericPattern = isCurrentGenericPattern;
                    }
                    else
                    {
                        // while both the pattern are not .* and they are different, put the next pattern in the string stack and update
                        newPatternStack.Add(currentPattern);
                        lastPattern = currentPattern;
                        isLastGenericPattern = isCurrentGenericPattern;
                    }
                }
                index = index + currentPattern.Length;
            }

            return newPatternStack;
        }
        private static bool isMatch(string s, int startIndex, List<string> pStack, int patternStartIndex)
        {
            var nextPattern = GetNextPattern(pStack, patternStartIndex);
            var sourceStringLength = s.Length;
            // if next pattern is empty, return true only when s is empty
            if (string.IsNullOrEmpty(nextPattern))
            {
                return startIndex >= sourceStringLength;
            }
            var offset = nextPattern.Length;
            var isGenericPattern = offset == 2;
            // s is empty, check whether pattern can be valid
            if (startIndex >= sourceStringLength)
            {
                if (isGenericPattern)
                {
                    return isMatch(s, startIndex, pStack, patternStartIndex + 1);
                }
                else
                {
                    return false;
                }
            }

            var sourceChar = s[startIndex];
            var patternChar = nextPattern[0];
            if (isGenericPattern)
            {
                if (sourceChar == patternChar || (patternChar == '.'))
                {
                    // for "abc" vs ".*"
                    if (isMatch(s, startIndex + 1, pStack, patternStartIndex))
                    {
                        return true;
                    }

                    // for "abc" vs ".*abc"
                    if (isMatch(s, startIndex, pStack, patternStartIndex + 1))
                    {
                        return true;
                    }

                    // for "abc" vs ".*c"
                    if (isMatch(s, startIndex + 1, pStack, patternStartIndex + 1))
                    {
                        return true;
                    }
                }
                else
                {
                    return isMatch(s, startIndex, pStack, patternStartIndex + 1);
                }
            }
            else
            {

                if (sourceChar == patternChar || (patternChar == '.'))
                {
                    return isMatch(s, startIndex + 1, pStack, patternStartIndex + 1);
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        private static string GetNextPattern(string patternString, int index)
        {
            var length = patternString.Length;
            if (index >= length)
            {
                return string.Empty;
            }
            else if (index == (length - 1))
            {
                return patternString.Substring(index, 1);
            }
            else
            {
                if (patternString[index + 1] == '*')
                {
                    return patternString.Substring(index, 2);
                }
                else
                {
                    return patternString.Substring(index, 1);
                }
            }
        }
        private static string GetNextPattern(List<string> patternStack, int index)
        {
            var length = patternStack.Count;
            if (index >= length || index < 0)
            {
                return string.Empty;
            }
            else 
            {
                return patternStack[index];
            }
        }
    }
}

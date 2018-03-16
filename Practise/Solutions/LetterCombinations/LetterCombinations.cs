using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
    Given a digit string, return all possible letter combinations that the number could represent.

    A mapping of digit to letters (just like on the telephone buttons) is given below.
    2. abc
    3. def
    4. ghi
    5. jkl
    6. mno
    7. pqrs
    8. tuv
    9. wxyz
    
    Input:Digit string "23"
    Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
    Note:
    Although the above answer is in lexicographical order, your answer could be in any order you want.
    */
    public class LetterCombinationsSolution
    {
        public static IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits))
            {
                return new List<string>();
            }
            var validDigits = _digitToFirstChar.Keys.ToList();
            if (digits.Any(c => !validDigits.Contains(c)))
            {
                return new List<string>();
            }
            var firstString = new string(digits.Select(c => _digitToFirstChar[c]).ToArray());
            var result = new List<string> { firstString };
            for (int i = firstString.Length - 1; i >= 0; i--)
            {
                var replacableString = _firstCharDictionary[firstString[i]];
                var tempResult = new List<string>(replacableString.Length * result.Count);
                tempResult.AddRange(result);
                for (int j = 0; j < replacableString.Length; j++)
                {
                    tempResult.AddRange(result.Select(s => ReplacedString(s, i, replacableString[j])));
                }
                result = tempResult;
            }
            return result;
        }

        private static string ReplacedString(string s, int index, char newChar)
        {
            StringBuilder sb = new StringBuilder(s);
            sb[index] = newChar;
            return sb.ToString();
        }

        private static Dictionary<char, char> _digitToFirstChar = new Dictionary<char, char>
        {
            { '2', 'a' },
            { '3', 'd' },
            { '4', 'g' },
            { '5', 'j' },
            { '6', 'm' },
            { '7', 'p' },
            { '8', 't' },
            { '9', 'w' },
        };
        private static Dictionary<char, string> _firstCharDictionary = new Dictionary<char, string>
        {
            { 'a', "bc" },
            { 'd', "ef" },
            { 'g', "hi" },
            { 'j', "kl" },
            { 'm', "no" },
            { 'p', "qrs" },
            { 't', "uv" },
            { 'w', "xyz" },
        };
    }
}

using LeetCodePractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    /*
     * https://leetcode.com/problems/reverse-bits/description/
     Reverse bits of a given 32 bits unsigned integer.

     For example, given input 43261596 (represented in binary as 00000010100101000001111010011100), return 964176192 (represented in binary as 00111001011110000010100101000000).

     Follow up:
        If this function is called many times, how would you optimize it?
    */
    public class Reverse32Bits
    {
        public static uint ReverseBits(uint n)
        {
            uint result = 0x0;
            for (int i = 0; i < 32; i++)
            {
                result = result << 1;
                result = result | (n & 0x1);
                n = n >> 1;
            }
            return result;
        }
        
    }
}

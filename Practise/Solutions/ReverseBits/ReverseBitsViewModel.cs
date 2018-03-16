using GalaSoft.MvvmLight.Ioc;
using LeetCodePractise.Model;
using LeetCodePractise.Model.Extensions;
using LeetCodePractise.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Solutions
{
    public class ReverseBitsViewModel : PractiseBaseViewModel<uint, uint>
    {
        private List<KeyValuePair<uint, uint>> _testCases = new List<KeyValuePair<uint, uint>>
        {
            { new KeyValuePair<uint, uint>(43261596, 964176192) },
        };

        protected override void InitialTestCases()
        {
            Title = "Reverse bits of a given 32 bits unsigned integer.";
            Requirement = "For example, given input 43261596 (represented in binary as 00000010100101000001111010011100), return 964176192 (represented in binary as 00111001011110000010100101000000).";
            Id = 190;
            SolutionExecutor = ExecuteTestCase;
            _testCases.ForEach(testCase => AddTestCases(testCase.Key, testCase.Value));
        }

        uint ExecuteTestCase(uint testCase)
        {
            var result = Reverse32Bits.ReverseBits(testCase);
            
            return result;
        }
    }
}

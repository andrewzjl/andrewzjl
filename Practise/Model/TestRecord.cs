using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.Model
{
    public class TestRecord<TestType, ResultType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestRecord{TestType, ResultType}"/> class.
        /// </summary>
        public TestRecord()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestRecord{TestType, ResultType}"/> class.
        /// </summary>
        /// <param name="testCase">The test case.</param>
        /// <param name="expected">The expected result.</param>
        /// <param name="actual">The actual result.</param>
        public TestRecord(TestType testCase, ResultType expected, ResultType actual)
        {
            TestCase = testCase;
            ExpectedResult = expected;
            ActualResult = actual;
        }

        public TestType TestCase { get; set; }
        public ResultType ExpectedResult { get; set; }
        public ResultType ActualResult { get; set; }

        public bool IsCorrect
        {
            get { return Equals(ExpectedResult, ActualResult); }
        }
    }
}

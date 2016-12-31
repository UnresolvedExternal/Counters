using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Counters.Test
{
	[TestFixture]
    public class NumericsHelperTests
    {
	    [Test]
		[TestCase(0, 1)]
		[TestCase(1, 1)]
		[TestCase(9, 1)]
		[TestCase(10, 2)]
		[TestCase(154000, 6)]
		[TestCase(999999, 6)]
		[TestCase(1000000, 7)]
		public void LengthTest(int input, int expectedLength)
		{
			var actualLength = NumericsHelper.Length(input);
			Assert.That(actualLength, Is.EqualTo(expectedLength));
	    }

	    [Test]
		[TestCaseSource(nameof(EnumerateToTextCases))]
	    public string ToTextCorrectInputTest(int value, int length)
	    {
		    var actual = NumericsHelper.ToText(value, length);
		    return actual;
	    }

	    [Test]
		[TestCase(0, 0)]
		[TestCase(12, -1)]
		[TestCase(124, 2)]
		[TestCase(2147483647, 9)]
		[TestCase(1010, 2)]
	    public void ToTextIncorectInputTest(int value, int length)
	    {
		    Assert.Throws(typeof(ArgumentOutOfRangeException), () => NumericsHelper.ToText(value, length));
	    }

	    private static IEnumerable<TestCaseData> EnumerateToTextCases
	    {
		    get
		    {
			    yield return new TestCaseData(0, 1).Returns("0");
				yield return new TestCaseData(0, 3).Returns("000");
				yield return new TestCaseData(1, 1).Returns("1");
				yield return new TestCaseData(109, 4).Returns("0109");
				yield return new TestCaseData(999, 4).Returns("0999");
				yield return new TestCaseData(1230450,7).Returns("1230450");
				yield return new TestCaseData(9801, 8).Returns("00009801");
				yield return new TestCaseData(2147483647, 20).Returns("00000000002147483647");
		    }
	    }
    }
}

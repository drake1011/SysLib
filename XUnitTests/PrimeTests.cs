using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Extensions;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace XUnitTests
{
    public class PrimeTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(199)]
        [InlineData(1999993)]
        [InlineData(1342193473)]
        [InlineData(2146435069)]
        public void Test_IsPrime_True_Pass(int input)
        {
            Assert.True(Math.Prime.IsPrime(input));
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(1999999)]
        [InlineData(2146435070)]
        public void Test_IsPrime_False_Pass(int input)
        {
            Assert.False(Math.Prime.IsPrime(input));
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(3, 5)]
        [InlineData(4, 5)]
        [InlineData(5564, 5569)]
        [InlineData(12158, 12161)]
        [InlineData(65323, 65327)]
        [InlineData(65324, 65327)]
        public void Test_NextPrime_Pass(int input, int expected)
        {
            Assert.Equal(expected, Math.Prime.NextPrime(input));
        }

        [Theory]
        [InlineData(4, 3)]
        [InlineData(6, 5)]
        [InlineData(7, 5)]
        [InlineData(5569, 5563)]
        [InlineData(12161, 12157)]
        [InlineData(65327, 65323)]
        [InlineData(65326, 65323)]
        public void Test_PreviousPrime_Pass(int input, int expected)
        {
            Assert.Equal(expected, Math.Prime.PreviousPrime(input));
        }
    }
}

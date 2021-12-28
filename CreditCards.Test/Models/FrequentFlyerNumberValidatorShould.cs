using SampleUnitTestingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreditCards.Test.Models
{
    public class FrequentFlyerNumberValidatorShould
    {
        [Theory]
        [InlineData("012345-A")]
        [InlineData("012345 Q")]
        [InlineData("012345-Y")]
        public void AcceptValidSchemes(string number)
        {
            var sut = new FrequentFlyerNumberValidator();
            Assert.True(sut.IsValid(number));
        }

        [Theory]
        [InlineData("012345-1")]
        [InlineData("012345- ")]
        [InlineData("rrr- ")]
        public void RejectInvalidSchemes(string number)
        {
            var sut = new FrequentFlyerNumberValidator();
            Assert.False(sut.IsValid(number));
        }

        [Theory]
        [InlineData("       -A")]
        public void RejectEmptyMemberNumberDigits(string number)
        {
            var sut = new FrequentFlyerNumberValidator();
            Assert.False(sut.IsValid(number));
        }

        [Fact]
        public void ThrowExceptionWhenNullFrequentFlyerNumber()
        {
            var sut = new FrequentFlyerNumberValidator();
            Assert.Throws<ArgumentNullException>(() => sut.IsValid(null));
        }
    }
}

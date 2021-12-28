using Moq;
using SampleUnitTestingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreditCards.Test.Models
{
    public class CreditCardApplicationEvaluatorShould
    {
        private const int ExpectedLowIncomeThreshold = 20_000;
        private const int ExpectedHightIncomeThreshold = 100_000;

        [Theory]
        [InlineData(ExpectedHightIncomeThreshold)]
        [InlineData(ExpectedHightIncomeThreshold + 1)]
        [InlineData(int.MaxValue)]
        public void AcceptAllHightIncomeApplicants(int income)
        {
            var sut = new CreditCardApplicationEvaluator(new FrequentFlyerNumberValidator());
            var application = new CreditCardApplication
            {
                GrossAnnualIncome = income,
                FrequentFlyerNumber = "01g345-B"
            };
            Assert.Equal(CreditCardApplicationDecision.AutoAccepted,
                sut.Evaluate(application));
        }

        [Theory]
        [InlineData(20)]
        [InlineData(19)]
        [InlineData(0)]
        [InlineData(int.MinValue)]
        public void ReferYoungApplicantWhoAreNotHightIncome(int age)
        {
            var sut = new CreditCardApplicationEvaluator(new FrequentFlyerNumberValidator());
            var application = new CreditCardApplication
            {
                GrossAnnualIncome = ExpectedHightIncomeThreshold - 1,
                Age = age
                //harus tambahin field FreqeuntFlyerNumber = " "
            };
            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman,
                sut.Evaluate(application));
        }

        [Theory]
        [InlineData(ExpectedLowIncomeThreshold)]
        [InlineData(ExpectedLowIncomeThreshold + 1)]
        public void ReferYoungApplicantWhoAreMiddleIncome(int income)
        {
            var sut = new CreditCardApplicationEvaluator(new FrequentFlyerNumberValidator());
            var application = new CreditCardApplication
            {
                GrossAnnualIncome = income,
                Age = 21
            };

            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman,
                sut.Evaluate(application));
        }

        [Fact]
        public void ReferInvalidFrequentFlyerNumbers_RealValidator()
        {
            var sut = new CreditCardApplicationEvaluator(new FrequentFlyerNumberValidator());
            var application = new CreditCardApplication
            {
                FrequentFlyerNumber = "01g345-B"
            };
            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman,
                sut.Evaluate(application));
        }

        [Fact]
        public void ReferInvalidFrequentFlyerNumbers_MockValidater()
        {
            var mockValidator = new Mock<IFrequentFlyerNumberValidator>();
            mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(false);
            var sut = new CreditCardApplicationEvaluator(mockValidator.Object);
            var application = new CreditCardApplication();
            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman,
                sut.Evaluate(application));
        }
    }
}
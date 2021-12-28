using SampleUnitTestingApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreditCards.Test.Controllers
{
    public class FizzBuzzControllerTest
    {
        [Fact]
        public void Given1Return1()
        {
            FizzBuzzController controller = new FizzBuzzController();
            string expected = "1 ";
            string actual = controller.Get(1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Given3Return12Fizz()
        {
            FizzBuzzController controller = new FizzBuzzController();
            string expected = "1 2 Fizz ";
            string actual = controller.Get(3);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Given5Return12Fizz4Buzz()
        {
            FizzBuzzController controller = new FizzBuzzController();
            string expected = "1 2 Fizz 4 Buzz ";
            string actual = controller.Get(5);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Given15ReturnFizzBuzz()
        {
            FizzBuzzController controller = new FizzBuzzController();
            string expected = "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz ";
            string actual = controller.Get(15);
            Assert.Equal(expected, actual);
        }
    }
}
